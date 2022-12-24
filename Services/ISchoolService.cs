using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.Store;
using Task3.Store.Models;
using Task3.ViewModels;

namespace Task3.Services
{
    public interface ISchoolService
    {
        Task<SchoolViewModel> GetViewModelAsync(int id);
        Task<SchoolEditViewModel> GetEditViewModelAsync(int id /*, ClaimsPrincipal user*/ );
        Task<SchoolDeleteViewModel> GetDeleteViewModelAsync(int id);
        Task<List<SchoolViewModel>> GetIndexViewModelAsync();
        SchoolCreateViewModel GetCreateViewModel();
        Task CreateAsync(SchoolCreateViewModel model);
        Task EditAsync(SchoolEditViewModel model /*, ClaimsPrincipal user*/ );
        Task DeleteAsync(SchoolDeleteViewModel model);
    }

    public class SchoolService : ISchoolService
    {
        private ApplicationDbContext Context { get; }
        private IMapper Mapper { get; }
        private IWebHostEnvironment AppEnvironment { get; }

        public SchoolService(ApplicationDbContext context,
            IMapper mapper,
            IWebHostEnvironment appEnvironment)
        {
            Context = context;
            Mapper = mapper;
            AppEnvironment = appEnvironment;
        }

        public async Task<List<SchoolViewModel>> GetIndexViewModelAsync()
        {
            var schools = await Context.Schools
                /*.Include(x => x.Moderators)*/
                .Include(x => x.Inventories)
                .Include(x => x.RentRequests)
                .Include(x => x.Storekeeper)
                .ToListAsync();

            var model = Mapper.Map<List<SchoolViewModel>>(schools);
            return model;
        }

        public async Task<SchoolViewModel> GetViewModelAsync(int id)
        {
            var school = await Context.Schools
                .Include(x => x.Inventories)
                .ThenInclude(y => y.AllocatedInventories)
                .Include(x => x.Inventories)
                .ThenInclude(y => y.RequestedInventories)
                .Include(x => x.Inventories)
                .ThenInclude(y => y.InventoryType)
                .Include(x => x.RentRequests)
                .Include(x => x.Storekeeper)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (school == null)
            {
                throw new ArgumentNullException(nameof(school));
            }

            var viewModel = Mapper.Map<SchoolViewModel>(school);

            return viewModel;
        }

        public SchoolCreateViewModel GetCreateViewModel()
        {
            return new SchoolCreateViewModel { };
        }

        public async Task<SchoolEditViewModel> GetEditViewModelAsync(int id /*, ClaimsPrincipal user*/)
        {
            var school = await Context.Schools
                /*.Include(x => x.Moderators)
                .ThenInclude(y => y.User)*/
                .FirstOrDefaultAsync(x => x.Id == id);
            if (school == null)
            {
                throw new ArgumentNullException(nameof(school));
            }

            /*
            if (!user.IsInRole(Roles.Admin))
            {
                if (!section.Moderators.Any(x => x.User.UserName == user.Identity.Name))
                {
                    throw new ArgumentNullException("User is not moderator for this section");
                }
            }
            */
            return Mapper.Map<SchoolEditViewModel>(school);
        }

        public async Task<SchoolDeleteViewModel> GetDeleteViewModelAsync(int id)
        {
            var school = await Context.Schools.FirstOrDefaultAsync(x => x.Id == id);
            if (school == null)
            {
                throw new ArgumentNullException(nameof(school));
            }

            return Mapper.Map<SchoolDeleteViewModel>(school);
        }

        public async Task CreateAsync(SchoolCreateViewModel model)
        {
            if (Context.Schools.Any(x => x.Name.ToLower() == model.Name.ToLower()))
            {
                throw new ArgumentException($"School with name {model.Name} already exists.");
            }

            var newSchool = Mapper.Map<School>(model);

            Context.Schools.Add(newSchool);
            await Context.SaveChangesAsync();
        }

        public async Task EditAsync(SchoolEditViewModel model /*, ClaimsPrincipal user*/)
        {
            var school = await Context.Schools
                /*.Include(x => x.Moderators)
                .ThenInclude(y => y.User)*/
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (school == null)
            {
                throw new ArgumentNullException(nameof(school));
            }

            /*
            if (!user.IsInRole(Roles.Admin))
            {
                if (!section.Moderators.Any(x => x.User.UserName == user.Identity.Name))
                {
                    throw new ArgumentNullException("User is not moderator for this section");
                }
            }*/

            var withSameName = await Context.Schools.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower());
            if (withSameName != null && school.Id != withSameName.Id)
            {
                throw new ArgumentException($"School with name {school.Name} already exists.");
            }

            school.Name = model.Name;
            school.Location = model.Location;

            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SchoolDeleteViewModel model)
        {
            var school = await Context.Schools.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (school == null)
            {
                throw new ArgumentNullException(nameof(school));
            }

            Context.Schools.Remove(school);
            await Context.SaveChangesAsync();
        }


    }
}

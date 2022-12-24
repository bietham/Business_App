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
    public interface IInventoryTypeService
    {
        Task<InventoryTypeViewModel> GetViewModelAsync(int id);
        Task<InventoryTypeEditViewModel> GetEditViewModelAsync(int id /*, ClaimsPrincipal user*/ );
        Task<InventoryTypeDeleteViewModel> GetDeleteViewModelAsync(int id);
        Task<List<InventoryTypeViewModel>> GetIndexViewModelAsync();
        InventoryTypeCreateViewModel GetCreateViewModel();
        Task CreateAsync(InventoryTypeCreateViewModel model);
        Task EditAsync(InventoryTypeEditViewModel model /*, ClaimsPrincipal user*/ );
        Task DeleteAsync(InventoryTypeDeleteViewModel model);
    }

    public class InventoryTypeService : IInventoryTypeService
    {
        private ApplicationDbContext Context { get; }
        private IMapper Mapper { get; }
        private IWebHostEnvironment AppEnvironment { get; }

        public InventoryTypeService(ApplicationDbContext context,
            IMapper mapper,
            IWebHostEnvironment appEnvironment)
        {
            Context = context;
            Mapper = mapper;
            AppEnvironment = appEnvironment;
        }

        public async Task<List<InventoryTypeViewModel>> GetIndexViewModelAsync()
        {
            var types = await Context.InventoryTypes
                .ToListAsync();

            var model = Mapper.Map<List<InventoryTypeViewModel>>(types);
            return model;
        }

        public async Task<InventoryTypeViewModel> GetViewModelAsync(int id)
        {
            var type = await Context.InventoryTypes
                .Include(x => x.Inventories)
                .ThenInclude(y => y.School)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var viewModel = Mapper.Map<InventoryTypeViewModel>(type);

            return viewModel;
        }

        public InventoryTypeCreateViewModel GetCreateViewModel()
        {
            return new InventoryTypeCreateViewModel { };
        }

        public async Task<InventoryTypeEditViewModel> GetEditViewModelAsync(int id /*, ClaimsPrincipal user*/)
        {
            var type = await Context.InventoryTypes
                /*.Include(x => x.Moderators)
                .ThenInclude(y => y.User)*/
                .FirstOrDefaultAsync(x => x.Id == id);
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
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
            return Mapper.Map<InventoryTypeEditViewModel>(type);
        }

        public async Task<InventoryTypeDeleteViewModel> GetDeleteViewModelAsync(int id)
        {
            var type = await Context.InventoryTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Mapper.Map<InventoryTypeDeleteViewModel>(type);
        }

        public async Task CreateAsync(InventoryTypeCreateViewModel model)
        {
            if (Context.InventoryTypes.Any(x => x.Name.ToLower() == model.Name.ToLower()))
            {
                throw new ArgumentException($"Type with name {model.Name} already exists.");
            }

            var newType = Mapper.Map<InventoryType>(model);

            Context.InventoryTypes.Add(newType);
            await Context.SaveChangesAsync();
        }

        public async Task EditAsync(InventoryTypeEditViewModel model)
        {
            var type = await Context.InventoryTypes.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var withSameName = await Context.InventoryTypes.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower());
            if (withSameName != null && type.Id != withSameName.Id)
            {
                throw new ArgumentException($"Inventory type with name {type.Name} already exists.");
            }

            type.Name = model.Name;

            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(InventoryTypeDeleteViewModel model)
        {
            var type = await Context.InventoryTypes.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            Context.InventoryTypes.Remove(type);
            await Context.SaveChangesAsync();
        }


    }
}

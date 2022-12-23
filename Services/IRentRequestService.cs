using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
    public interface IRentRequestService
    {
        Task<RentRequestViewModel> GetViewModelAsync(int id);
        Task<RentRequestEditViewModel> GetEditViewModelAsync(int id);
        Task<RentRequestDeleteViewModel> GetDeleteViewModelAsync(int id);
        Task<RentRequestCreateViewModel> GetCreateViewModelAsync(int id);
        Task CreateAsync(RentRequestCreateViewModel model);
        Task EditAsync(RentRequestEditViewModel model);
        Task DeleteAsync(RentRequestDeleteViewModel model);
    }

    public class RentRequestService : IRentRequestService
    {

        private ApplicationDbContext Context { get; }
        private IMapper Mapper { get; }
        private UserManager<IdentityUser> UserManager { get; }
        private IWebHostEnvironment AppEnvironment { get; }

        public RentRequestService(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IMapper mapper,
            IWebHostEnvironment appEnvironment)
        {
            Context = context;
            Mapper = mapper;
            UserManager = userManager;
            AppEnvironment = appEnvironment;
        }
        public async Task<RentRequestViewModel> GetViewModelAsync(int id)
        {
            var rentRequest = await Context.RentRequests
                .Include(x => x.RequestedInventories)
                .Include(x => x.AllocatedInventories)
                .Include(x => x.School)
                .Where(x => x.Id == id)
                .ToListAsync();

            var ViewModel = Mapper.Map<RentRequestViewModel>(rentRequest);
            return ViewModel;
        }

        public async Task<RentRequestCreateViewModel> GetCreateViewModelAsync(int id)
        {
            var eventParent = await Context.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (eventParent == null)
            {
                throw new ArgumentNullException(nameof(eventParent));
            }

            var createViewModel = Mapper.Map<RentRequestCreateViewModel>(eventParent);
            return createViewModel;
        }

        public async Task<RentRequestEditViewModel> GetEditViewModelAsync(int id)
        {
            var item = await Context.RentRequests
                .FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            return Mapper.Map<RentRequestEditViewModel>(item);
        }

        public async Task<RentRequestDeleteViewModel> GetDeleteViewModelAsync(int id)
        {
            var item = await Context.RentRequests
                .FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            return Mapper.Map<RentRequestDeleteViewModel>(item);
        }
        public async Task CreateAsync(RentRequestCreateViewModel model)
        {
            var eventParent = await Context.Events.FirstOrDefaultAsync(x => x.Id == model.EventId);
            if (eventParent == null)
            {
                throw new ArgumentNullException(nameof(eventParent));
            }

            var newReq = Mapper.Map<RentRequest>(model);
            newReq.Event = eventParent;

            await Context.RentRequests.AddAsync(newReq);
            await Context.SaveChangesAsync();
        }

        public async Task EditAsync(RentRequestEditViewModel model)
        {
            var item = await Context.RentRequests
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.Approval = model.Approval;
//            item.AllocatedInventories = model.AllocatedInventories;
//            item.RequestedInventories = model.RequestedInventories;
//            item.UnloadRequests = model.UnloadRequests;
//            item.ReturnRequests = model.ReturnRequests;

            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RentRequestDeleteViewModel model)
        {
            var item = await Context.RentRequests.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Context.RentRequests.Remove(item);
            await Context.SaveChangesAsync();
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Task3.Store;
using Task3.Store.Models;
using Task3.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Task3.Store.Roles;

namespace Task3.Services
{

    public interface IPlannedInventoryService
    {
        Task<PlannedInventoryDeleteViewModel> GetDeleteViewModelAsync(int? id);
        Task<PlannedInventoryCreateViewModel> GetCreateViewModelAsync(int? id);
        Task<PlannedInventoryEditViewModel> GetEditViewModelAsync(int? id);
        Task CreateAsync(PlannedInventoryCreateViewModel model);
        Task DeleteAsync(PlannedInventoryDeleteViewModel model);
        Task EditAsync(PlannedInventoryEditViewModel model);
    }
    public class PlannedInventoryService : IPlannedInventoryService
    {
        private ApplicationDbContext Context { get; }
        private IMapper Mapper { get; }
        private UserManager<IdentityUser> UserManager { get; }
        private IWebHostEnvironment AppEnvironment { get; }

        public PlannedInventoryService(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IMapper mapper,
            IWebHostEnvironment appEnvironment)
        {
            Context = context;
            Mapper = mapper;
            UserManager = userManager;
            AppEnvironment = appEnvironment;
        }

        public async Task<PlannedInventoryCreateViewModel> GetCreateViewModelAsync(int? id)
        {
            var eevent = await Context.Events.FirstOrDefaultAsync(x => x.Id == id);
            var invTypes = await Context.InventoryTypes.ToListAsync();
            if (eevent == null)
            {
                throw new ArgumentNullException(nameof(eevent));
            }

            var createViewModel = Mapper.Map<PlannedInventoryCreateViewModel>(eevent);
            var invTypesView = Mapper.Map<List<InventoryTypeViewModel>>(invTypes);
            createViewModel.InventoryTypes = invTypesView;

            return createViewModel;
        }

        public async Task<PlannedInventoryDeleteViewModel> GetDeleteViewModelAsync(int? id)
        {
            var item = await Context.PlannedInventories
                .FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            return Mapper.Map<PlannedInventoryDeleteViewModel>(item);
        }
        public async Task CreateAsync(PlannedInventoryCreateViewModel model)
        {
            if (Context.PlannedInventories.Any(x => x.InventoryTypeId == model.SelectedInventoryTypeId))
            {
                throw new ArgumentException($"Planned Inventory already exists.");
            }

            var invType = await Context.InventoryTypes.FirstOrDefaultAsync(x => x.Id == model.SelectedInventoryTypeId);
            if (invType == null)
            {
                throw new ArgumentNullException(nameof(invType));
            }

            var newInv = Mapper.Map<PlannedInventory>(model);
            
            await Context.PlannedInventories.AddAsync(newInv);
            await Context.SaveChangesAsync();
        }
        public async Task DeleteAsync(PlannedInventoryDeleteViewModel model)
        {
            var item = await Context.PlannedInventories.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Context.PlannedInventories.Remove(item);
            await Context.SaveChangesAsync();
        }

        public async Task<PlannedInventoryEditViewModel> GetEditViewModelAsync(int? id /*, ClaimsPrincipal user*/)
        {
            var inv = await Context.PlannedInventories
                /*.Include(x => x.Moderators)
                .ThenInclude(y => y.User)*/
                .Include(x => x.InventoryType)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (inv == null)
            {
                throw new ArgumentNullException(nameof(inv));
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
            return Mapper.Map<PlannedInventoryEditViewModel>(inv);
        }

        public async Task EditAsync(PlannedInventoryEditViewModel model)
        {
            var inv = await Context.PlannedInventories
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (inv == null)
            {
                throw new ArgumentNullException(nameof(inv));
            }

            inv.Amount = model.Amount;

            await Context.SaveChangesAsync();
        }
    }
}

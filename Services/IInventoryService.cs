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

    public interface IInventoryService
    {
        Task<InventoryViewModel> GetViewModelAsync(int id);
        //Task<InventoryEditViewModel> GetEditViewModelAsync(int id, ClaimsPrincipal User);
        //Task<InventoryDeleteViewModel> GetDeleteViewModelAsync(int id, ClaimsPrincipal User);
        Task<InventoryCreateViewModel> GetCreateViewModelAsync(int id);
        Task CreateAsync(InventoryCreateViewModel model);
        //Task EditAsync(InventoryEditViewModel model, ClaimsPrincipal User);
        //Task DeleteAsync(InventoryDeleteViewModel model, ClaimsPrincipal User);
    }
    public class InventoryService : IInventoryService
    {
        private ApplicationDbContext Context { get; }
        private IMapper Mapper { get; }
        private UserManager<IdentityUser> UserManager { get; }
        private IWebHostEnvironment AppEnvironment { get; }

        public InventoryService(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IMapper mapper,
            IWebHostEnvironment appEnvironment)
        {
            Context = context;
            Mapper = mapper;
            UserManager = userManager;
            AppEnvironment = appEnvironment;
        }
        public async Task<InventoryViewModel> GetViewModelAsync(int id)
        {
            var inventory = await Context.Inventories
                .Include(x => x.School)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (inventory == null)
            {
                throw new ArgumentNullException(nameof(inventory));
            }

            var detailsViewModel = Mapper.Map<InventoryViewModel>(inventory);
            return detailsViewModel;
        }

        public async Task<InventoryCreateViewModel> GetCreateViewModelAsync(int id)
        {
            var school = await Context.Schools.FirstOrDefaultAsync(x => x.Id == id);
            if (school == null)
            {
                throw new ArgumentNullException(nameof(school));
            }
            var createViewModel = Mapper.Map<InventoryCreateViewModel>(school);
            return createViewModel;
        }

        public async Task CreateAsync(InventoryCreateViewModel model)
        {
            var school = await Context.Schools.FirstOrDefaultAsync(x => x.Id == model.SchoolId);
            if (school == null)
            {
                throw new ArgumentNullException(nameof(school));
            }

            var newInv = Mapper.Map<Inventory>(model);
            newInv.School = school;

            await Context.Inventories.AddAsync(newInv);
            await Context.SaveChangesAsync();
        }
    }
}

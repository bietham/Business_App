﻿using System;
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

namespace Task3.Services
{
    public interface IAdminService
    {


        public RegisterViewModel GetCreateModelAsync();

        Task AddUserRoleStorekeeper(string username);
        Task AddUserRoleDeliveryman(string username);
        Task AddUserRoleMastermind(string username);

        Task RemoveRoleDeliveryman(string username);
        Task RemoveRoleStorekeeper(string username);
        Task RemoveRoleMastermind(string username);


        Task RegisterAsync(RegisterViewModel model);
        Task<List<AccountViewModel>> GetIndexViewModelAsync();
        Task<AccountEditViewModel> GetEditViewModelAsync(string username);
        Task EditAsync(AccountEditViewModel model);
        Task AddModerator(string username);
        Task DeleteModerator(string username);


    }

    public class AdminService : IAdminService
    {
        private ApplicationDbContext Context { get; }
        private IMapper Mapper { get; }
        private UserManager<IdentityUser> UserManager { get; }
        private SignInManager<IdentityUser> SignInManager { get; }
        private IWebHostEnvironment AppEnvironment { get; }

        public AdminService(ApplicationDbContext context,
            IMapper mapper,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IWebHostEnvironment appEnvironment)
        {
            Context = context;
            Mapper = mapper;
            UserManager = userManager;
            SignInManager = signInManager;
            AppEnvironment = appEnvironment;
        }

        public RegisterViewModel GetCreateModelAsync()
        {
            return new RegisterViewModel { };
        }
        public async Task RegisterAsync(RegisterViewModel model)
        {
            var withSameEmail = await Context.Users.FirstOrDefaultAsync(x => x.NormalizedEmail == model.Email.ToLower());
            if (withSameEmail != null)
            {
                throw new ArgumentException($"User with {model.Email} is already registered.");
            }

            var identityResult = await UserManager.CreateAsync(
                new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = model.Email,
                    UserName = model.UserName
                },
                model.Password);

            if (identityResult.Succeeded)
            {
                return;
            }

            throw new Exception(identityResult.Errors.First().Description);
        }


        public async Task<List<AccountViewModel>> GetIndexViewModelAsync()
        {
            var users = await Context.Users.ToListAsync();
            var model = Mapper.Map<List<AccountViewModel>>(users);
            
            return model;
        }
        public async Task AddUserRoleDeliveryman(string user)
        {
            var userAcc = await UserManager.Users.FirstOrDefaultAsync(x => x.UserName == user);
            if (userAcc == null)
            {
                throw new ArgumentNullException(nameof(userAcc));
            }

            await UserManager.AddToRoleAsync(userAcc, "Deliveryman");
        }

        public async Task AddUserRoleMastermind(string user)
        {
            var userAcc = await UserManager.Users.FirstOrDefaultAsync(x => x.UserName == user);
            if (userAcc == null)
            {
                throw new ArgumentNullException(nameof(userAcc));
            }

            await UserManager.AddToRoleAsync(userAcc, "Mastermind");
        }

        public async Task AddUserRoleStorekeeper(string user)
        {
            var userAcc = await UserManager.Users.FirstOrDefaultAsync(x => x.UserName == user);
            if (userAcc == null)
            {
                throw new ArgumentNullException(nameof(userAcc));
            }

            await UserManager.AddToRoleAsync(userAcc, "Storekeeper");
        }

        public async Task RemoveRoleDeliveryman(string username)
        {
            var user = await UserManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            //Courier function


            await UserManager.RemoveFromRoleAsync(user, "Deliveryman");
        }


        public async Task RemoveRoleMastermind(string username)
        {
            var user = await UserManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }


            var userEvents = await Context.Events.Where(x => x.Mastermind.UserName == username).ToListAsync();

            if (userEvents != null)
            {
                foreach (var userEvent in userEvents)
                {
                    userEvent.Mastermind = null;
                }
                await Context.SaveChangesAsync();
            }



            await UserManager.RemoveFromRoleAsync(user, "Mastermind");
        }

        public async Task RemoveRoleStorekeeper(string username)
        {
            var user = await UserManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }


            var userSchools = await Context.Schools.FirstOrDefaultAsync(x => x.User.UserName == username);

            if (userSchools != null)
            {
                userSchools.User = null;
                await Context.SaveChangesAsync();
            }



            await UserManager.RemoveFromRoleAsync(user, "Storekeeper");
        }


        public async Task AddModerator(string username)
        {
            var user = await UserManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await UserManager.AddToRoleAsync(user, "Moderator");
        }

        public async Task DeleteModerator(string username)
        {
            var user = await UserManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userSection = await Context.ModeratedSections
                .Include(x => x.User)
                .Where(x => x.User.UserName == username)
                .ToListAsync();

            Context.ModeratedSections.RemoveRange(userSection);

            await UserManager.RemoveFromRoleAsync(user, "Moderator");
        }

        public async Task<AccountEditViewModel> GetEditViewModelAsync(string username)
        {
            var sections = await Context.Sections
                .Include(x => x.Moderators)
                .ThenInclude(y => y.User)
                .ToListAsync();

            if (sections == null)
            {
                throw new ArgumentNullException(nameof(sections));
            }

            var sectionView = Mapper.Map<List<SectionViewModel>>(sections);

            var result = new AccountEditViewModel
            {
                UserName = username,
                Sections = sectionView
            };

            return result;
        }

        public async Task EditAsync(AccountEditViewModel model)
        {
            var userSection = await Context.ModeratedSections
                .Include(x => x.User)
                .Where(x => x.User.UserName == model.UserName)
                .ToListAsync();

            Context.ModeratedSections.RemoveRange(userSection);

            if (model.SelectedSections == null)
            {
                await Context.SaveChangesAsync();
                return;
            };

            var sections = await Context.Sections
                .Include(x => x.Moderators)
                .ThenInclude(y => y.User)
                .Where(x => model.SelectedSections.Contains(x.Id))
                .ToListAsync();

            if (!sections.Any())
            {
                throw new ArgumentNullException(nameof(sections));
            }

            var user = await UserManager.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            foreach (var item in sections) 
            {
                Context.ModeratedSections.Add(new ModeratedSections { Section = item, User = user });
            }
            await Context.SaveChangesAsync();
        }
    }
}
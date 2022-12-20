using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Task3.Store;
using Task3.ViewModels;
using Task3.Store.Models;
using Task3.Store.Roles;
using Microsoft.Extensions.Logging;

namespace Task3.Services
{
    public interface IEventService
    {
        Task<List<EventViewModel>> GetIndexViewModelAsync();
        Task<EventViewModel> GetViewModelAsync(int id);
        Task<EventEditViewModel> GetEditViewModelAsync(int id, ClaimsPrincipal user);
        Task<EventDeleteViewModel> GetDeleteViewModelAsync(int id);
        EventCreateViewModel GetCreateViewModel();
        Task CreateAsync(EventCreateViewModel vm); 
        Task EditAsync(EventEditViewModel vm);
        Task DeleteAsync(EventDeleteViewModel vm);
    }

    public class EventService : IEventService
    {
        private ApplicationDbContext Context { get; }
        private IMapper Mapper { get; }
        private IWebHostEnvironment _appEnvironment { get; }

        public EventService(ApplicationDbContext context,
            IMapper mapper,
            IWebHostEnvironment appEnvironment)
        {
            Context = context;
            Mapper = mapper;
            _appEnvironment = appEnvironment;
        }


        public async Task<List<EventViewModel>> GetIndexViewModelAsync()
        {
            var events = await Context.Events
                .ToListAsync();

            var vm = Mapper.Map<List<EventViewModel>>(events);

            return vm;
        }

        public async Task<EventViewModel> GetViewModelAsync(int id)
        {
            var eventt = await Context.Events
                .Include(x => x.StartTime)
                .Include(x => x.EndTime)
                .Include(x => x.Location)
                .Include(x => x.AllocatedInventories)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (eventt == null)
            {
                throw new ArgumentNullException(nameof(eventt));
            }

            return Mapper.Map<EventViewModel>(eventt);
        }

        public EventCreateViewModel GetCreateViewModel()
        {
            return new EventCreateViewModel { };
        }

        public async Task<EventEditViewModel> GetEditViewModelAsync(int id, ClaimsPrincipal user)
        {
            var eventt = await Context.Events
                .FirstOrDefaultAsync(x => x.Id == id);
            if (eventt == null)
            {
                throw new ArgumentNullException(nameof(eventt));
            }

            //if (!user.IsInRole(Roles.Mastermind))
            //{
            //    if (!eventt.Masterminds.Any(x => x.User.UserName == user.Identity.Name))
            //    {
            //        throw new ArgumentNullException("User is not moderator for this section");
            //    }
            //}

            return Mapper.Map<EventEditViewModel>(eventt);
        }

        public async Task CreateAsync(EventCreateViewModel vm)
        {
            if (Context.Events.Any(x => x.Name.ToLower() == vm.Name.ToLower()))
            {
                throw new ArgumentException($"Мероприятие с названием {vm.Name} уже существует.");
            }

            var newEvent = Mapper.Map<Event>(vm);

            Context.Events.Add(newEvent);
            await Context.SaveChangesAsync();
        }

        public async Task EditAsync(EventEditViewModel vm)
        {
            var eventt = await Context.Events
                .FirstOrDefaultAsync(x => x.Id == vm.Id);

            if (eventt == null)
            {
                throw new ArgumentNullException(nameof(eventt));
            }

            var withSameName = await Context.Sections.FirstOrDefaultAsync(x => x.Name.ToLower() == vm.Name.ToLower());
            if (withSameName != null && eventt.Id != withSameName.Id)
            {
                throw new ArgumentException($"Мероприятие с названием {eventt.Name} уже существует.");
            }

            eventt.Name = vm.Name;

            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EventDeleteViewModel vm)
        {
            var eventt = await Context.Events.FirstOrDefaultAsync(x => x.Id == vm.Id);
            if (eventt == null)
            {
                throw new ArgumentNullException(nameof(eventt));
            }

            Context.Events.Remove(eventt);
            await Context.SaveChangesAsync();
        }

        public async Task<EventDeleteViewModel> GetDeleteViewModelAsync(int id)
        {
            var eventt = await Context.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (eventt == null)
            {
                throw new ArgumentNullException(nameof(eventt));
            }

            return Mapper.Map<EventDeleteViewModel>(eventt);
        }
    }
}

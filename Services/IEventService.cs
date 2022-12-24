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
using Microsoft.Data.SqlClient;

namespace Task3.Services
{
    public interface IEventService
    {
        Task<List<EventViewModel>> GetIndexViewModelAsync(string sortOrder);
        Task<EventViewModel> GetViewModelAsync(int id);
        Task<EventEditViewModel> GetEditViewModelAsync(int id);
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


        public async Task<List<EventViewModel>> GetIndexViewModelAsync(string sortOrder)
        {
            var events = await Context.Events
                .ToListAsync();

            switch (sortOrder)
            {
                case "Status":
                    events = await Context.Events
                        .OrderBy(x => (int)x.EventStatus)
                        .ToListAsync();
                    break;
                case "status_desc":
                    events = await Context.Events
                        .OrderBy(x => (int)x.EventStatus)
                        .ToListAsync();
                    break;
                case "Name":
                    events = await Context.Events
                        .OrderBy(x => x.Name)
                        .ToListAsync();
                    break;
                case "name_desc":
                    events = await Context.Events
                        .OrderByDescending(x => x.Name)
                        .ToListAsync();
                    break;
                case "date_desc":
                    events = await Context.Events
                        .OrderByDescending(x => x.StartTime)
                        .ToListAsync();
                    break;
                default:
                    events = await Context.Events
                        .OrderBy(x => x.StartTime)
                        .ToListAsync();
                    break;
            }

            var vm = Mapper.Map<List<EventViewModel>>(events);

            return vm;
        }

        public async Task<EventViewModel> GetViewModelAsync(int id)
        {
            var eventt = await Context.Events
                .Include(x=> x.Deliveryman)
                .Include(x => x.Mastermind)
                .Include(x => x.PlannedInventories)
                .ThenInclude(y => y.InventoryType)
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

        public async Task<EventEditViewModel> GetEditViewModelAsync(int id)
        {
            var eventt = await Context.Events
                 .Include(x => x.Deliveryman)
                 .Include(x => x.Mastermind)
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

            var deliveryman = await Context.Users.FirstOrDefaultAsync(x => x.UserName == vm.DeliverymanId);

            if (vm.DeliverymanId != null & deliveryman == null)
            {
                throw new ArgumentException($"User with id {deliveryman.Id} could not be found.");
            }

            var mastermind = await Context.Users.FirstOrDefaultAsync(x => x.UserName == vm.MastermindId);

            if (vm.MastermindId != null & mastermind == null)
            {
                throw new ArgumentException($"User with id {mastermind.Id} could not be found.");
            }
            var newEvent = Mapper.Map<Event>(vm);
            newEvent.EventStatus = EventStatus.Planning;
            newEvent.Deliveryman = deliveryman;
            newEvent.Mastermind = mastermind;

            Context.Events.Add(newEvent);
            await Context.SaveChangesAsync();
        }

        public async Task EditAsync(EventEditViewModel vm)
        {
            var eventt = await Context.Events
                .Include(x => x.Deliveryman)
                .Include(x => x.Mastermind)
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


            var deliveryman = await Context.Users.FirstOrDefaultAsync(x => x.UserName == vm.DeliverymanId);

            if (vm.DeliverymanId != null & deliveryman == null)
            {
                throw new ArgumentException($"User with id {deliveryman.Id} could not be found.");
            }

            var mastermind = await Context.Users.FirstOrDefaultAsync(x => x.UserName == vm.MastermindId);

            if (vm.MastermindId != null & mastermind == null)
            {
                throw new ArgumentException($"User with id {mastermind.Id} could not be found.");
            }
            

            eventt.Name = vm.Name;
            eventt.Location = vm.Location;
            eventt.StartTime = vm.StartTime;
            eventt.EndTime = vm.EndTime;
            eventt.EventStatus = EventStatus.Planning;
            eventt.Deliveryman = deliveryman;
            eventt.Mastermind = mastermind;

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

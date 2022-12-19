using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Task3.Store;
using Task3.ViewModels;

namespace Task3.Services
{
    public interface IEventService
    {
        Task<List<EventViewModel>> GetIndexViewModelAsync();
        Task<EventViewModel> GetViewModelAsync(int id);
        Task CreateAsync(EventCreateViewModel vm);
        Task EditAsync(EventEditViewModel vm);
        Task DeleteAsync(EventDeleteViewModel vm);
    }

    public class EventService : IEventService
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _appEnvironment { get; }

        public EventService(ApplicationDbContext context,
            IMapper mapper,
            IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _mapper= mapper;
            _appEnvironment = appEnvironment;
        }

        public async Task<List<EventViewModel>> GetIndexViewModelAsync()
        {
            var events = await _context.Events
                .ToListAsync();

            var vm = _mapper.Map<List<EventViewModel>>(events);

            return vm;
        }

        public async EventViewModel GetViewModelAsync(int id)
        {
            var event = await _context.
        }


        public async Task CreateAsync(EventCreateViewModel vm)
        {
            if (vm == null) { return; }
        }

        public async Task EditAsync(EventEditViewModel vm)
        {
            if (vm == null) { return; }
        }

        public async Task DeleteAsync(EventDeleteViewModel vm)
        {
            if (vm == null) { return; }
        }
    }
}

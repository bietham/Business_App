using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Task3.Store;
using Task3.ViewModels;
using Task3.ViewModels.Store;

namespace Task3.Services.Store
{
    public interface IEventService
    {
        // Task<List<EventViewModel>> GetIndexViewModelAsync();
        Task CreateAsync(EventCreateViewModel vm);
        Task EditAsync(EventEditViewModel vm);
        Task DeleteAsync(EventDeleteViewModel vm);
    }

    public class EventService : IEventService
    {
        private ApplicationDbContext Context { get; }
        private IWebHostEnvironment AppEnvironment { get; }

        public EventService(ApplicationDbContext context,
            IWebHostEnvironment appEnvironment)
        {
            Context = context;
            AppEnvironment = appEnvironment;
        }

        /*public async Task<List<EventViewModel>> GetIndexViewModels()
        {
            
        }*/

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

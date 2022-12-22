using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Task3.Services;
using Task3.ViewModels;

namespace Task3.Controllers
{
    public class EventController : Controller
    {
        public IEventService EventService { get; }

        public EventController(IEventService eventService)
        {
            EventService = eventService;
        }

        // GET: EventController
        public async Task<ActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "status_desc" : "Status";

            var model = await EventService.GetIndexViewModelAsync(sortOrder);

            return View(model);
        }

        // GET: EventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await EventService.GetViewModelAsync(id);
            return View(model);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            var model = EventService.GetCreateViewModel();
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await EventService.CreateAsync(model);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model.Name), ae.Message);
                return View(model);
            }
        }

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var model = await EventService.GetEditViewModelAsync(id);
                return View(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EventEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var editModel = await EventService.GetEditViewModelAsync(model.Id);
                return View(editModel);
            }
            try
            {
                await EventService.EditAsync(model);
                return RedirectToAction("Index");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model.Name), ae.Message);
                var editViewModel = await EventService.GetEditViewModelAsync(model.Id);
                return View(editViewModel);
            }
        }

        // GET: EventController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var model = await EventService.GetDeleteViewModelAsync(id);
                return View(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(EventDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await EventService.DeleteAsync(model);
                return RedirectToAction("Index");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}

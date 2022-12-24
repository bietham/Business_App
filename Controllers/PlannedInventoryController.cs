using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task3.Services;
using System.Threading.Tasks;
using Task3.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

namespace Task3.Controllers
{
    public class PlannedInventoryController : Controller
    {
        private IPlannedInventoryService PlannedInventoryService { get; }
        public PlannedInventoryController(IPlannedInventoryService plannedInventoryService)
        {
            PlannedInventoryService = plannedInventoryService;
        }

        [Authorize]
        // GET: InventoryController/Create
        public async Task<IActionResult> Create(int id)
        {
            var model = await PlannedInventoryService.GetCreateViewModelAsync(id);
            return View(model);
        }

        // POST: InventoryController/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlannedInventoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var createModel = await PlannedInventoryService.GetCreateViewModelAsync(model.EventId);
                return View(createModel);
            }
            try
            {
                await PlannedInventoryService.CreateAsync(model);
                return RedirectToAction("Details", "Event", new { Id = model.EventId });
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model), ae.Message);
                var editViewModel = await PlannedInventoryService.GetCreateViewModelAsync(model.EventId/*, User*/);
                return View(editViewModel);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await PlannedInventoryService.GetEditViewModelAsync(id/*, User*/);
                return View(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlannedInventoryEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var editModel = await PlannedInventoryService.GetEditViewModelAsync(model.Id/*, User*/);
                return View(editModel);
            }
            try
            {
                await PlannedInventoryService.EditAsync(model);
                return RedirectToAction("Details", "Event", new { Id = model.EventId });
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model), ae.Message);
                var editViewModel = await PlannedInventoryService.GetEditViewModelAsync(model.Id/*, User*/);
                return View(editViewModel);
            }
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await PlannedInventoryService.GetDeleteViewModelAsync(id);
                return View(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PlannedInventoryDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await PlannedInventoryService.DeleteAsync(model);
                return RedirectToAction("Details", "Event", new { Id = model.EventId });
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}

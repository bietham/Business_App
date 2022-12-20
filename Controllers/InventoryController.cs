using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task3.Services;
using System.Threading.Tasks;
using Task3.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Task3.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryService InventoryService { get; }
        public InventoryController(IInventoryService inventoryService)
        {
            InventoryService = inventoryService;
        }

        // GET: InventoryController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: InventoryController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = await InventoryService.GetViewModelAsync(id);
            return View(model);
        }

        [Authorize]
        // GET: InventoryController/Create
        public async Task<IActionResult> Create(int id)
        {
            var model = await InventoryService.GetCreateViewModelAsync(id);
            return View(model);
        }

        // POST: InventoryController/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var createModel = await InventoryService.GetCreateViewModelAsync(model.SchoolId);
                return View(createModel);
            }
            try
            {
                await InventoryService.CreateAsync(model);
                return RedirectToAction("Details", "School", new { Id = model.SchoolId });
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await InventoryService.GetEditViewModelAsync(id/*, User*/);
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
        public async Task<IActionResult> Edit(InventoryEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var editModel = await InventoryService.GetEditViewModelAsync(model.Id/*, User*/);
                return View(editModel);
            }
            try
            {
                await InventoryService.EditAsync(model);
                return RedirectToAction("Details", "School", new { Id = model.SchoolId });
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model.Name), ae.Message);
                var editViewModel = await InventoryService.GetEditViewModelAsync(model.Id/*, User*/);
                return View(editViewModel);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await InventoryService.GetDeleteViewModelAsync(id);
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
        public async Task<IActionResult> Delete(InventoryDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await InventoryService.DeleteAsync(model);
                return RedirectToAction("Details", "School", new { Id = model.SchoolId });
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}

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
                return RedirectToAction("Details", new { Id = model.SchoolId });
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

            // GET: InventoryController/Edit/5
            public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

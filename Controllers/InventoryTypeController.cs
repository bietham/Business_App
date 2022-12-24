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
    public class InventoryTypeController : Controller
    {
        private IInventoryTypeService InventoryTypeService { get; }
        public InventoryTypeController(IInventoryTypeService inventoryTypeService)
        {
            InventoryTypeService = inventoryTypeService;
        }

        // GET: InventoryController
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.NameTypeParm = sortOrder == "InventoryType" ? "InventoryType_desc" : "InventoryType";
            var model = await InventoryTypeService.GetIndexViewModelAsync();

            return View(model);
        }

        // GET: InventoryController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = await InventoryTypeService.GetViewModelAsync(id);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = InventoryTypeService.GetCreateViewModel();
            return View(model);
        }

        // POST: InventoryController/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryTypeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await InventoryTypeService.CreateAsync(model);
                return RedirectToAction("Index");
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
                var model = await InventoryTypeService.GetEditViewModelAsync(id/*, User*/);
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
        public async Task<IActionResult> Edit(InventoryTypeEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var editModel = await InventoryTypeService.GetEditViewModelAsync(model.Id/*, User*/);
                return View(editModel);
            }
            try
            {
                await InventoryTypeService.EditAsync(model);
                return RedirectToAction("Index");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model.Name), ae.Message);
                var editViewModel = await InventoryTypeService.GetEditViewModelAsync(model.Id/*, User*/);
                return View(editViewModel);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await InventoryTypeService.GetDeleteViewModelAsync(id);
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
        public async Task<IActionResult> Delete(InventoryTypeDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await InventoryTypeService.DeleteAsync(model);
                return RedirectToAction("Index");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}

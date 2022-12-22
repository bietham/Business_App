using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Task3.Services;
using Task3.ViewModels;

namespace Task3.Controllers
{
    public class RentRequestController : Controller
    {

        private IRentRequestService rentRequestService { get; }
        public RentRequestController(IRentRequestService RentRequestService)
        {
            rentRequestService = RentRequestService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await rentRequestService.GetViewModelAsync(id);
            return View(model);
        }

        [Authorize]
        // GET: InventoryController/Create
        public async Task<IActionResult> Create(int id)
        {
            var model = await rentRequestService.GetCreateViewModelAsync(id);
            return View(model);
        }

        // POST: InventoryController/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var createModel = await InventoryService.GetCreateViewModelAsync(model.PlannedInventories);
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

        // GET: RentRequestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: RentRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: RentRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

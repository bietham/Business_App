using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Task3.Services;
using Task3.ViewModels;

namespace Task3.Controllers
{
    public class SchoolController : Controller
    {

        private ISchoolService SchoolService { get; }
        public SchoolController(ISchoolService schoolService)
        {
            SchoolService = schoolService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var model = await SchoolService.GetIndexViewModelAsync();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = SchoolService.GetCreateViewModel();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchoolCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await SchoolService.CreateAsync(model);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model.Name), ae.Message);
                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await SchoolService.GetEditViewModelAsync(id/*, User*/);
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
        public async Task<IActionResult> Edit(SchoolEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var editModel = await SchoolService.GetEditViewModelAsync(model.Id/*, User*/);
                return View(editModel);
            }
            try
            {
                await SchoolService.EditAsync(model/*, User*/);
                return RedirectToAction("Index");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model.Name), ae.Message);
                var editViewModel = await SchoolService.GetEditViewModelAsync(model.Id/*, User*/);
                return View(editViewModel);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await SchoolService.GetDeleteViewModelAsync(id);
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
        public async Task<IActionResult> Delete(SchoolDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await SchoolService.DeleteAsync(model);
                return RedirectToAction("Index");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}

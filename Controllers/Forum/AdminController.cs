using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Task3.Models;
using Microsoft.AspNetCore.Authorization;
using Task3.Services;
using Task3.ViewModels;

namespace Task3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IAdminService AdminService { get; }
        public AdminController(IAdminService adminService)
        {
            AdminService = adminService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await AdminService.GetIndexViewModelAsync();
            return View(model);
        }

        public async Task<IActionResult> Register()
        {
            return View(AdminService.GetCreateModelAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await AdminService.RegisterAsync(model);
                return RedirectToAction("Index", "Admin");
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model.Email), ae.Message);
                return View(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }


        }

        public async Task<IActionResult> Add(string id)
        {
            await AdminService.AddModerator(id);
            return RedirectToAction("Index");
        }
        

        public async Task<IActionResult> AddDeliveryman(string id)
        {
            await AdminService.AddUserRoleDeliveryman(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddStorekeeper(string id)
        {
            await AdminService.AddUserRoleStorekeeper(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddMastermind(string id)
        {
            await AdminService.AddUserRoleMastermind(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await AdminService.DeleteModerator(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDeliveryman(string id)
        {
            await AdminService.RemoveRoleDeliveryman(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteStorekeeper(string id)
        {
            await AdminService.RemoveRoleStorekeeper(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteMastermind(string id)
        {
            await AdminService.RemoveRoleMastermind(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await AdminService.GetEditViewModelAsync(id);
                return View(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AccountEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var editModel = await AdminService.GetEditViewModelAsync(model.UserName);
                return View(editModel);
            }
            try
            {
                await AdminService.EditAsync(model);
                return RedirectToAction("Index");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(nameof(model.UserName), ae.Message);
                var editViewModel = await AdminService.GetEditViewModelAsync(model.UserName);
                return View(editViewModel);
            }
        }
    }
}

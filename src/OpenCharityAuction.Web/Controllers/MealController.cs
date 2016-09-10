using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OpenCharityAuction.Web.Models.Interfaces;
using OpenCharityAuction.Web.ViewModels;
using OpenCharityAuction.Entities.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(EventRequiredFilter))]
    public class MealController : Controller
    {
        private readonly IAuctionService AuctionService;
        private readonly IUserService UserService;

        public MealController(IAuctionService auctionService, IUserService userService)
        {
            UserService = userService;
            AuctionService = auctionService;
        }

        // GET: /<controller>/
        public IActionResult Index(string successMessage = null)
        {
            ViewData["SuccessMessage"] = successMessage;
            return View("Index");
        }

        public IActionResult AddMeal(string errorMessage = null)
        {
            ViewData["ErrorMessage"] = errorMessage;
            return View("AddMeal");
        }

        [HttpPost]
        [ServiceFilter(typeof(EventRequiredFilter))]
        public async Task<IActionResult> AddMeal(AddMealViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var eventId = await UserService.GetCurrentUsersActiveEvent();
                Meal meal = new Meal()
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    CreatedBy = UserService.GetUserId(),
                    EventId = eventId.Value
                };
                await AuctionService.AddMeal(meal);
                return RedirectToAction("Index", "Meal", new { successMessage = "New Meal Added" });
            }
            return View("AddMeal", vm);
        }

        public async Task<IActionResult> EditMeal(int id, string errorMessage = null)
        {
            Meal dbMeal = new Meal();
            await AuctionService.GetMealById(id, (meal) => dbMeal = meal);
            EditMealViewModel editMealVm = new EditMealViewModel()
            {
                Name = dbMeal.Name,
                Id = dbMeal.Id,
                Description = dbMeal.Description
            };
            ViewData["ErrorMessage"] = errorMessage;

            return View("EditMeal", editMealVm);
        }

        [HttpPost]
        public async Task<IActionResult> EditMeal(EditMealViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var eventId = await UserService.GetCurrentUsersActiveEvent();
                Meal meal = new Meal()
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Description = vm.Description
                };
                await AuctionService.UpdateMeal(meal);
                return RedirectToAction("Index", "Meal", new { successMessage = "Meal Updated" });
            }
            return View("EditMeal", vm);
        }

        public IActionResult SearchMeal()
        {
            return View("SearchMeal");
        }
    }
}

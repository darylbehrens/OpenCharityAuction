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
        public async Task<IActionResult> AddMeal(AddMealViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var eventId = await UserService.GetCurrentUsersActiveEvent();
                if (eventId != null)
                {
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
                else
                {
                    return RedirectToAction("AddMeal", new { errorMessage = "You must have an active event before you can add meals" });
                }
            }

            return View("AddMeal", vm);
        }


    }
}

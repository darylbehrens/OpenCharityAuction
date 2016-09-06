using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Entities.Models;
using OpenCharityAuction.Web.Models.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Api
{
    [Route("api/[controller]")]
    public class MealsController : Controller
    {
        private readonly IAuctionService AuctionService;
        private readonly IUserService UserService;

        public MealsController(IAuctionService auctionService, IUserService userService)
        {
            AuctionService = auctionService;
            UserService = userService;
        }

        // GET: api/values/{serach query}
        [HttpGet]
        public async Task<IEnumerable<Meal>> Get(string query)
        {
            List<Meal> mealList = new List<Meal>();
            await AuctionService.GetMeals(meals => mealList = meals, query);
            return mealList;
        }
    }
}

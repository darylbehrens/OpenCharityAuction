using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Controllers
{
    [ServiceFilter(typeof(EventRequiredFilter))]
    public class BidderGroupController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string successMessage = null)
        {
            ViewData["SuccessMessage"] = successMessage;
            return View("Index");
        }

        public IActionResult AddBidderGroup()
        {
            return View("AddBidderGroup");
        }
    }
}

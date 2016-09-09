using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using OpenCharityAuction.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web
{
    public class EventRequiredFilter : ActionFilterAttribute
    {
        private readonly IUserService UserService;

        public EventRequiredFilter(IUserService userService)
        {
            UserService = userService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var eventId = UserService.GetCurrentUsersActiveEvent().Result;
            if (eventId == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary()
                    {
                        { "controller", "Home" },
                        { "action", "Index" },
                        { "errorMessage", "Must Select a Active Event" }
                    });
            }
        }
    }
}

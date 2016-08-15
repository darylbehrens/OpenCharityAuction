using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using OpenCharityAuction.Web.ViewModels;
using OpenCharityAuction.Web.Models.Interfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<Models.User> UserManager;
        private readonly SignInManager<Models.User> SignInManager;
        private readonly ILogger Logger;
        private readonly IUserService UserService;

        public AuthenticationController(UserManager<Models.User> userManager, SignInManager<Models.User> signInManager, ILoggerFactory loggerFactory, IUserService userService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Logger = loggerFactory.CreateLogger<AuthenticationController>();
            UserService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult InitialSetup(string returnUrl = null)
        {
            if (UserService.CheckIfThereAreAnyUsers())
            {
                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitialSetup(ViewModels.InitialSetupViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new Models.User { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    Logger.LogInformation(3, "User created a new account with password.");
                    //return RedirectToLocal(returnUrl);
                }
                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            if (SignInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    Logger.LogInformation(1, "User logged in.");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await SignInManager.SignOutAsync();
            Logger.LogInformation(4, "User logged out.");
            return RedirectToAction("Login", "Authentication");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }
    }
}

namespace OdeToFood.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public ViewResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = new User() { UserName = model.Username };
                var result = await this.userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, false);
                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrWhiteSpace(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return this.Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return this.RedirectToAction("Index", "Home");
                    }
                }
            }

            this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}

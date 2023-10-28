using BAExpense.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BAExpense.Controllers
{
    public class AuthenticationController : Controller
    {
        //REGISTRATION
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) { 
                var user = new IdentityUser {  UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Expense");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);                    
                }
            }
            return View(model);
        }

        // LOGIN
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Expense");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt");                
            }
            return View(model);
        }

        //Logout
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnLogout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Authentication");
        }

        [HttpPost]
        public IActionResult OnDontLogout()
        {
            return RedirectToAction("Index", "Expense"); 
        }

    }
}
//https://www.youtube.com/watch?v=sPbDrqpme_w


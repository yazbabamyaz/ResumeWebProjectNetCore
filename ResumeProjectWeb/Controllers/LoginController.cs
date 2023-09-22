using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ResumeProjectWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {

            //var user = _context.TblAdmins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            var values = _userService.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (values != null)
            {
                HttpContext.Session.SetString("userid", user.Id.ToString());
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,"Admin"),
			                 //new Claim(ClaimTypes.Role,user.Role),
					new Claim(ClaimTypes.Email,user.Password)
                };

                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);


                await HttpContext.SignInAsync(principal);


                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction("index", "About");
            }

            return View(user);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}

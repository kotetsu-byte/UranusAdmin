using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Data;
using UranusAdmin.Dto;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DataContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            var response = new LoginDto();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginDto);
            }
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginDto);
        }

        public IActionResult Register()
        {
            var response = new RegisterDto();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = await _userManager.FindByEmailAsync(registerDto.Email);
            if(user != null) 
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerDto);
            }

            var newUser = new User()
            {
                Username = registerDto.Email,
                Email = registerDto.Email
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerDto.Password);
            if(newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}

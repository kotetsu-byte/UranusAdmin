using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Dto;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Admin> _userManager;
        private readonly SignInManager<Admin> _signInManager;

        public AccountController(UserManager<Admin> userManager, SignInManager<Admin> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            var response = new LoginDto();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
                return View(loginDto);
            
            var admin = await _userManager.FindByNameAsync(loginDto.Username);

            if(admin != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(admin, loginDto.Password);
                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(admin, loginDto.Password, false, false);
                    if(result.Succeeded)
                    {
                        await _signInManager.SignInAsync(admin, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View(loginDto);
            }
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
            if(!ModelState.IsValid)
            {
                return View(registerDto);
            }
            
            var admin = new Admin()
            {
                UserName = registerDto.Username
            };

            var result = await _userManager.CreateAsync(admin, registerDto.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout(LoginDto loginDto)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
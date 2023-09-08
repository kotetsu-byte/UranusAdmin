using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<User> users = await _userRepository.GetUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            User user = await _userRepository.GetUserByIdAsync(id);
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _userRepository.Create(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id) 
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(User user)
        {
            _userRepository.Update(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            _userRepository.Delete(user);
            return RedirectToAction("Index");
        }
    }
}

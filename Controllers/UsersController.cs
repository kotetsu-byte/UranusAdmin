using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Dto;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var usersMap = _mapper.Map<List<UserDto>>(await _userRepository.GetUsersAsync());
            return View(usersMap);
        }

        public async Task<IActionResult> Details(int id)
        {
            var userMap = _mapper.Map<UserDto>(await _userRepository.GetUserByIdAsync(id));
            return View(userMap);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserPostDto userCreate)
        {
            if (!ModelState.IsValid)
                return View(userCreate);

            var user = _mapper.Map<User>(userCreate);
            _userRepository.Create(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id) 
        {
            var userMap = _mapper.Map<UserDto>(await _userRepository.GetUserByIdAsync(id));
            return View(userMap);
        }

        [HttpPost]
        public IActionResult Update(UserDto userUpdate)
        {
            if (!ModelState.IsValid)
                return View(userUpdate);

            var user = _mapper.Map<User>(userUpdate);
            _userRepository.Update(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userMap = _mapper.Map<UserDto>(await _userRepository.GetUserByIdAsync(id));
            return View(userMap);
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

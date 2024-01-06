using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Dto;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var coursesMap = _mapper.Map<List<CourseDto>>(await _courseRepository.GetCoursesAsync());
            return View(coursesMap);
        }

        public async Task<IActionResult> Details(int id)
        {
            var courseMap = _mapper.Map<CourseDto>(await _courseRepository.GetCourseByIdAsync(id));
            return View(courseMap);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CoursePostDto courseCreate)
        {
            if (!ModelState.IsValid)
                return View(courseCreate);
            
            var course = _mapper.Map<Course>(courseCreate);
            _courseRepository.Create(course);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var courseMap = _mapper.Map<CourseDto>(await _courseRepository.GetCourseByIdAsync(id));
            return View(courseMap);
        }

        [HttpPost]
        public IActionResult Update(CourseDto courseUpdate)
        {
            if (!ModelState.IsValid)
                return View(courseUpdate);
            
            var course = _mapper.Map<Course>(courseUpdate);
            _courseRepository.Update(course);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var courseMap = _mapper.Map<CourseDto>(await _courseRepository.GetCourseByIdAsync(id));
            return View(courseMap);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var user = await _courseRepository.GetCourseByIdAsync(id);
            _courseRepository.Delete(user);
            return RedirectToAction("Index");
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Dto;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;
using UranusAdmin.Repositories;

namespace UranusAdmin.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public LessonsController(ILessonRepository lessonRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var lessonsMap = _mapper.Map<List<LessonDto>>(await _lessonRepository.GetLessonsAsync());
            return View(lessonsMap);
        }

        public async Task<IActionResult> Details(int id)
        {
            var lessonMap = _mapper.Map<LessonDto>(await _lessonRepository.GetLessonByIdAsync(id));
            return View(lessonMap);
        }

        public async Task<IActionResult> Create()
        {
            var lessonDto = new LessonDto();
            lessonDto.Courses = await _lessonRepository.GetAllCoursesAsync();
            return View(lessonDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LessonDto lessonCreate)
        {
            var lesson = _mapper.Map<Lesson>(lessonCreate);
            _lessonRepository.Create(lesson);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var lessonMap = _mapper.Map<LessonDto>(await _lessonRepository.GetLessonByIdAsync(id));
            lessonMap.Courses = await _lessonRepository.GetAllCoursesAsync();
            return View(lessonMap);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LessonDto lessonUpdate)
        {
            var lesson = _mapper.Map<Lesson>(lessonUpdate);
            _lessonRepository.Update(lesson);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var lessonMap = _mapper.Map<LessonDto>(await _lessonRepository.GetLessonByIdAsync(id));
            lessonMap.Courses = await _lessonRepository.GetAllCoursesAsync();
            return View(lessonMap);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _lessonRepository.GetLessonByIdAsync(id);
            _lessonRepository.Delete(lesson);
            return RedirectToAction("Index");
        }
    }
}

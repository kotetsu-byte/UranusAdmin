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
        private readonly IMapper _mapper;

        public LessonsController(ILessonRepository lessonRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        [Route("[controller]/[action]/{courseId}")]
        public async Task<IActionResult> Index(int courseId)
        {
            var lessonsMap = _mapper.Map<List<LessonDto>>(await _lessonRepository.GetLessonsAsync(courseId));
            foreach(var lessonMap in lessonsMap)
            {
                lessonMap.CourseId = courseId;
            }
            return View(lessonsMap);
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        public async Task<IActionResult> Details(int courseId, int id)
        {
            var lessonMap = _mapper.Map<LessonDto>(await _lessonRepository.GetLessonByIdAsync(courseId, id));
            lessonMap.CourseId = courseId;
            return View(lessonMap);
        }

        [Route("[controller]/[action]/{courseId}")]
        public async Task<IActionResult> Create(int courseId)
        {
            var lessonDto = new LessonDto();
            lessonDto.CourseId = courseId;
            return View(lessonDto);
        }

        [Route("[controller]/[action]/{courseId}")]
        [HttpPost]
        public async Task<IActionResult> Create(LessonDto lessonCreate, int courseId)
        {
            var lesson = _mapper.Map<Lesson>(lessonCreate);

            lesson.CourseId = courseId;

            _lessonRepository.Create(lesson);
            return RedirectToAction("Index", "Lessons", new {courseId = lessonCreate.CourseId});
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        public async Task<IActionResult> Update(int courseId, int id)
        {
            var lessonMap = _mapper.Map<LessonDto>(await _lessonRepository.GetLessonByIdAsync(courseId, id));
            lessonMap.CourseId= courseId;
            return View(lessonMap);
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        [HttpPost]
        public async Task<IActionResult> Update(LessonDto lessonUpdate)
        {
            var lesson = _mapper.Map<Lesson>(lessonUpdate);
            _lessonRepository.Update(lesson);
            return RedirectToAction("Index", "Lessons", new { courseId = lessonUpdate.CourseId });
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        public async Task<IActionResult> Delete(int courseId, int id)
        {
            var lessonMap = _mapper.Map<LessonDto>(await _lessonRepository.GetLessonByIdAsync(courseId, id));
            lessonMap.CourseId = courseId;
            return View(lessonMap);
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteLesson(int courseId, int id)
        {
            var lesson = await _lessonRepository.GetLessonByIdAsync(courseId, id);
            _lessonRepository.Delete(lesson);
            return RedirectToAction("Index", "Lessons", new { courseId = courseId });
        }
    }
}

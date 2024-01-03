using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Dto;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class HomeworksController : Controller
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IMapper _mapper;

        public HomeworksController(IHomeworkRepository homeworkRepository, ILessonRepository lessonRepository, IMapper mapper)
        {
            _homeworkRepository = homeworkRepository;
            _mapper = mapper;
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        public async Task<IActionResult> Index(int courseId, int lessonId)
        {
            var homeworksMap = _mapper.Map<List<HomeworkDto>>(await _homeworkRepository.GetHomeworksAsync(courseId, lessonId));
            foreach(var homeworkMap in homeworksMap)
            {
                homeworkMap.CourseId = courseId;
                homeworkMap.LessonId = lessonId;
            }
            ViewBag.CourseId = courseId;
            return View(homeworksMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        public async Task<IActionResult> Details(int courseId, int lessonId, int id)
        {
            var homeworkMap = _mapper.Map<HomeworkDto>(await _homeworkRepository.GetHomeworkByIdAsync(courseId, lessonId, id));
            homeworkMap.CourseId = courseId;
            homeworkMap.LessonId = lessonId;
            return View(homeworkMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        public async Task<IActionResult> Create(int courseId, int lessonId)
        {
            var homeworkDto = new HomeworkDto();
            homeworkDto.CourseId = courseId;
            homeworkDto.LessonId = lessonId;
            return View(homeworkDto);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        [HttpPost]
        public async Task<IActionResult> Create(HomeworkDto homeworkCreate, int courseId, int lessonId)
        {
            var homework = _mapper.Map<Homework>(homeworkCreate);

            homework.CourseId = courseId;
            homework.LessonId = lessonId;

            _homeworkRepository.Create(homework);
            return RedirectToAction("Index", "Homeworks", new {courseId = homeworkCreate.CourseId, lessonId = homeworkCreate.LessonId});
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        public async Task<IActionResult> Update(int courseId, int lessonId, int id)
        {
            var homeworkMap = _mapper.Map<HomeworkDto>(await _homeworkRepository.GetHomeworkByIdAsync(courseId, lessonId, id));
            homeworkMap.CourseId = courseId;
            homeworkMap.LessonId = lessonId;
            return View(homeworkMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        [HttpPost]
        public async Task<IActionResult> Update(HomeworkDto homeworkUpdate)
        {
            var homework = _mapper.Map<Homework>(homeworkUpdate);
            _homeworkRepository.Update(homework);
            return RedirectToAction("Index", "Homeworks", new { courseId = homeworkUpdate.CourseId, lessonId = homeworkUpdate.LessonId });
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        public async Task<IActionResult> Delete(int courseId, int lessonId, int id)
        {
            var homeworkMap = _mapper.Map<HomeworkDto>(await _homeworkRepository.GetHomeworkByIdAsync(courseId, lessonId, id));
            homeworkMap.CourseId = courseId;
            homeworkMap.LessonId = lessonId;
            return View(homeworkMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteHomework(int courseId, int lessonId, int id)
        {
            var homework = await _homeworkRepository.GetHomeworkByIdAsync(courseId, lessonId, id);
            _homeworkRepository.Delete(homework);
            return RedirectToAction("Index", "Homeworks", new { courseId = courseId, lessonId = lessonId });
        }
    }
}

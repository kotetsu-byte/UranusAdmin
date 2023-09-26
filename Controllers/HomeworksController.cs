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
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public HomeworksController(IHomeworkRepository homeworkRepository, ILessonRepository lessonRepository, IMapper mapper)
        {
            _homeworkRepository = homeworkRepository;
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var homeworksMap = _mapper.Map<List<HomeworkDto>>(await _homeworkRepository.GetHomeworksAsync());
            return View(homeworksMap);
        }

        public async Task<IActionResult> Details(int id)
        {
            var homeworkMap = _mapper.Map<HomeworkDto>(await _homeworkRepository.GetHomeworkByIdAsync(id));
            return View(homeworkMap);
        }

        public async Task<IActionResult> Create()
        {
            var homeworkDto = new HomeworkDto();
            homeworkDto.Lessons = await _homeworkRepository.GetAllLessonsAsync();
            return View(homeworkDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HomeworkDto homeworkCreate)
        {
            var homework = _mapper.Map<Homework>(homeworkCreate);
            _homeworkRepository.Create(homework);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var homeworkMap = _mapper.Map<HomeworkDto>(await _homeworkRepository.GetHomeworkByIdAsync(id));
            homeworkMap.Lessons = await _homeworkRepository.GetAllLessonsAsync();
            return View(homeworkMap);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HomeworkDto homeworkUpdate)
        {
            var homework = _mapper.Map<Homework>(homeworkUpdate);
            _homeworkRepository.Update(homework);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var homeworkMap = _mapper.Map<HomeworkDto>(await _homeworkRepository.GetHomeworkByIdAsync(id));
            homeworkMap.Lessons = await _homeworkRepository.GetAllLessonsAsync();
            return View(homeworkMap);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteHomework(int id)
        {
            var homework = await _homeworkRepository.GetHomeworkByIdAsync(id);
            _homeworkRepository.Delete(homework);
            return RedirectToAction("Index");
        }
    }
}

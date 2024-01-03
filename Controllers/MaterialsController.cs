using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Dto;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public MaterialsController(IMaterialRepository materialRepository, IHomeworkRepository homeworkRepository, ILessonRepository lessonRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _homeworkRepository = homeworkRepository;
            _lessonRepository = lessonRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{homeworkId}")]
        public async Task<IActionResult> Index(int courseId, int lessonId, int homeworkId)
        {
            var materialsMap = _mapper.Map<List<MaterialDto>>(await _materialRepository.GetMaterialsAsync(courseId, lessonId, homeworkId));
            foreach(var materialMap in materialsMap)
            {
                materialMap.CourseId = courseId;
                materialMap.LessonId = lessonId;
                materialMap.HomeworkId = homeworkId;
            }
            ViewBag.CourseId = courseId;
            ViewBag.LessonId = lessonId;
            return View(materialsMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{homeworkId}/{id?}")]
        public async Task<IActionResult> Details(int courseId, int lessonId, int homeworkId, int id)
        {
            var materialMap = _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialByIdAsync(courseId, lessonId, homeworkId, id));
            materialMap.CourseId = courseId;
            materialMap.LessonId = lessonId;
            materialMap.HomeworkId = homeworkId;
            return View(materialMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{homeworkId}")]
        public async Task<IActionResult> Create(int courseId, int lessonId, int homeworkId)
        {
            var materialDto = new MaterialDto();
            materialDto.CourseId = courseId;
            materialDto.LessonId = lessonId;
            materialDto.HomeworkId = homeworkId;
            return View(materialDto);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{homeworkId}")]
        [HttpPost]
        public async Task<IActionResult> Create(MaterialDto materialCreate, int courseId, int lessonId, int homeworkId)
        {
            var material = _mapper.Map<Material>(materialCreate);

            material.CourseId = courseId;
            material.LessonId = lessonId;
            material.HomeworkId = homeworkId;

            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            var lesson = await _lessonRepository.GetLessonByIdAsync(courseId, lessonId);
            var homework = await _homeworkRepository.GetHomeworkByIdAsync(courseId, lessonId, homeworkId);

            var path = $"wwwroot/materials/{course.Name}/{lesson.Title}/{homework.Title}/{materialCreate.MaterialContent.FileName}";

            using (var stream = new FileStream(path, FileMode.Create))
            {
                materialCreate.MaterialContent.CopyTo(stream);
            }

            _materialRepository.Create(material);

            return RedirectToAction("Index", "Materials", new {courseId = materialCreate.CourseId, lessonId = materialCreate.LessonId, homeworkId = materialCreate.HomeworkId});
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{homeworkId}/{id?}")]
        public async Task<IActionResult> Update(int courseId, int lessonId, int homeworkId, int id)
        {
            var materialMap = _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialByIdAsync(courseId, lessonId, homeworkId, id));
            materialMap.CourseId = courseId; ;
            materialMap.LessonId = lessonId;
            materialMap.HomeworkId = homeworkId;
            return View(materialMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{homeworkId}/{id?}")]
        [HttpPost]
        public async Task<IActionResult> Update(MaterialDto materialUpdate, int courseId, int lessonId, int homeworkId)
        {
            var material = _mapper.Map<Material>(materialUpdate);

            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            var lesson = await _lessonRepository.GetLessonByIdAsync(courseId, lessonId);
            var homework = await _homeworkRepository.GetHomeworkByIdAsync(courseId, lessonId, homeworkId);

            var path = $"wwwroot/materials/{course.Name}/{lesson.Title}/{homework.Title}/{materialUpdate.MaterialContent.FileName}";

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                materialUpdate.MaterialContent.CopyTo(stream);
            }

            _materialRepository.Update(material);

            return RedirectToAction("Index", "Materials", new { courseId = materialUpdate.CourseId, lessonId = materialUpdate.LessonId, homeworkId = materialUpdate.HomeworkId });
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{homewrokId}/{id?}")]
        public async Task<IActionResult> Delete(int courseId, int lessonId, int homeworkId, int id)
        {
            var materialMap = _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialByIdAsync(courseId, lessonId, homeworkId, id));
            materialMap.CourseId = courseId;
            materialMap.LessonId = lessonId;
            materialMap.HomeworkId = homeworkId;
            return View(materialMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{homewrokId}/{id?}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteMaterial(int courseId, int lessonId, int homewrokId, int id)
        {
            var material = await _materialRepository.GetMaterialByIdAsync(courseId, lessonId, homewrokId, id);

            _materialRepository.Delete(material);

            return RedirectToAction("Index", "Materials", new { courseId = courseId, lessonId = lessonId, homeworkId = homewrokId });
        }
    }
}

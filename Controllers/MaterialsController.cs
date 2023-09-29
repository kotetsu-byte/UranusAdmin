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
        private readonly IMapper _mapper;

        public MaterialsController(IMaterialRepository materialRepository, IHomeworkRepository homeworkRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
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
        public async Task<IActionResult> Create(MaterialDto materialCreate)
        {
            var material = _mapper.Map<Material>(materialCreate);
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
        public async Task<IActionResult> Update(MaterialDto materialUpdate)
        {
            var material = _mapper.Map<Material>(materialUpdate);
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

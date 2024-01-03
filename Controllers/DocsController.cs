using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Dto;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class DocsController : Controller
    {
        private readonly IDocRepository _docRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public DocsController(IDocRepository docRepository, ILessonRepository lessonRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _docRepository = docRepository;
            _lessonRepository = lessonRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        public async Task<IActionResult> Index(int courseId, int lessonId)
        {
            var docsMap = _mapper.Map<List<DocDto>>(await _docRepository.GetDocsAsync(courseId, lessonId));
            foreach(var docMap in docsMap)
            {
                docMap.CourseId = courseId;
                docMap.LessonId = lessonId;
            }
            ViewBag.CourseId = courseId;
            return View(docsMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        public async Task<IActionResult> Details(int courseId, int lessonId, int id)
        {
            var docMap = _mapper.Map<DocDto>(await _docRepository.GetDocByIdAsync(courseId, lessonId, id));
            docMap.CourseId = courseId;
            docMap.LessonId = lessonId;
            return View(docMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        public async Task<IActionResult> Create(int courseId, int lessonId)
        {
            var docDto = new DocDto();
            docDto.CourseId = courseId;
            docDto.LessonId = lessonId;
            return View(docDto);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        [HttpPost]
        public async Task<IActionResult> Create(DocDto docCreate, int courseId, int lessonId)
        {
            docCreate.DocName = docCreate.DocContent.FileName;

            var doc = _mapper.Map<Doc>(docCreate);

            doc.CourseId = courseId;
            doc.LessonId = lessonId;

            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            var lesson = await _lessonRepository.GetLessonByIdAsync(courseId, lessonId);

            var path = $"wwwroot/docs/{course.Name}/{lesson.Title}/{docCreate.DocContent.FileName}";

            using(var stream = new FileStream(path, FileMode.Create))
            {
                docCreate.DocContent.CopyTo(stream);
            }

            _docRepository.Create(doc);

            return RedirectToAction("Index", "Docs", new {courseId = docCreate.CourseId, lessonId = docCreate.LessonId});
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        public async Task<IActionResult> Update(int courseId, int lessonId, int id)
        {
            var docMap = _mapper.Map<DocDto>(await _docRepository.GetDocByIdAsync(courseId, lessonId, id));
            docMap.CourseId = courseId;
            docMap.LessonId = lessonId;
            return View(docMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        [HttpPost]
        public async Task<IActionResult> Update(DocDto docUpdate, int courseId, int lessonId)
        {
            var doc = _mapper.Map<Doc>(docUpdate);

            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            var lesson = await _lessonRepository.GetLessonByIdAsync(courseId, lessonId);

            var path = $"wwwroot/docs/{course.Name}/{lesson.Title}/{docUpdate.DocContent.FileName}";

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                docUpdate.DocContent.CopyTo(stream);
            }

            _docRepository.Update(doc);

            return RedirectToAction("Index", "Docs", new { courseId = docUpdate.CourseId, lessonId = docUpdate.LessonId });
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        public async Task<IActionResult> Delete(int courseId, int lessonId, int id)
        {
            var docMap = _mapper.Map<DocDto>(await _docRepository.GetDocByIdAsync(courseId, lessonId, id));
            docMap.CourseId = courseId;
            docMap.LessonId = lessonId;
            return View(docMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteDoc(int courseId, int lessonId, int id)
        {
            var doc = await _docRepository.GetDocByIdAsync(courseId, lessonId, id);
            _docRepository.Delete(doc);
            return RedirectToAction("Index", "Docs", new { courseId = courseId, lessonId = lessonId });
        }
    }
}

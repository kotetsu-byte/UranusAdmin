using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UranusAdmin.Data;
using UranusAdmin.Dto;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class TestsController : Controller
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestsController(ITestRepository testRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        [Route("[controller]/[action]/{courseId}")]
        public async Task<IActionResult> Index(int courseId)
        {
            var testsMap = _mapper.Map<List<TestDto>>(await _testRepository.GetTestsAsync(courseId));
            foreach(var testMap in testsMap)
            {
                testMap.CourseId = courseId;
            }
            return View(testsMap);
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        public async Task<IActionResult> Details(int courseId, int id)
        {
            var testMap = _mapper.Map<TestDto>(await _testRepository.GetTestByIdAsync(courseId, id));
            testMap.CourseId = courseId;
            return View(testMap);
        }

        [Route("[controller]/[action]/{courseId}")]
        public async Task<IActionResult> Create(int courseId)
        {
            var testDto = new TestDto();
            testDto.CourseId = courseId;
            return View(testDto);
        }

        [Route("[controller]/[action]/{courseId}")]
        [HttpPost]
        public async Task<IActionResult> Create(TestPostDto testCreate, int courseId)
        {
            if (!ModelState.IsValid)
                return View(testCreate);

            var test = _mapper.Map<Test>(testCreate);

            test.CourseId = courseId;

            _testRepository.Create(test);
            return RedirectToAction("Index", "Tests", new {courseId = testCreate.CourseId});
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        public async Task<IActionResult> Update(int courseId, int id)
        {
            var testMap = _mapper.Map<TestDto>(await _testRepository.GetTestByIdAsync(courseId, id));
            testMap.CourseId = courseId;
            return View(testMap);
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        [HttpPost]
        public async Task<IActionResult> Update(TestDto testUpdate)
        {
            if (!ModelState.IsValid)
                return View(testUpdate);

            var test = _mapper.Map<Test>(testUpdate);
            _testRepository.Update(test);
            return RedirectToAction("Index", "Tests", new { courseId = testUpdate.CourseId });
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        public async Task<IActionResult> Delete(int courseId, int id)
        {
            var testMap = _mapper.Map<TestDto>(await _testRepository.GetTestByIdAsync(courseId, id));
            testMap.CourseId = courseId;
            return View(testMap);
        }

        [Route("[controller]/[action]/{courseId}/{id?}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTest(int courseId, int id)
        {
            var test = await _testRepository.GetTestByIdAsync(courseId, id);
            _testRepository.Delete(test);
            return RedirectToAction("Index", "Tests", new { courseId = courseId });
        }
    }
}

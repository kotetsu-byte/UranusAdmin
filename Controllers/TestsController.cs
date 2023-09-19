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

        public TestsController(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var testsMap = _mapper.Map<List<TestDto>>(await _testRepository.GetTestsAsync());
            return View(testsMap);
        }

        public async Task<IActionResult> Details(int id)
        {
            var testMap = _mapper.Map<TestDto>(await _testRepository.GetTestByIdAsync(id));
            return View(testMap);
        }

        public async Task<IActionResult> Create()
        {
            var testDto = new TestDto();
            testDto.Courses = await _testRepository.GetAllNamesOfCoursesAsync();
            return View(testDto);
        }

        [HttpPost]
        public IActionResult Create(TestDto testCreate)
        {
            var test = _mapper.Map<Test>(testCreate);
            _testRepository.Create(test);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var testMap = _mapper.Map<TestDto>(await _testRepository.GetTestByIdAsync(id));
            testMap.Courses = await _testRepository.GetAllNamesOfCoursesAsync();
            return View(testMap);
        }

        [HttpPost]
        public IActionResult Update(TestDto testUpdate)
        {
            var test = _mapper.Map<Test>(testUpdate);
            _testRepository.Update(test);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var testMap = _mapper.Map<TestDto>(await _testRepository.GetTestByIdAsync(id));
            testMap.Courses = await _testRepository.GetAllNamesOfCoursesAsync();
            return View(testMap);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            var test = await _testRepository.GetTestByIdAsync(id);
            _testRepository.Delete(test);
            return RedirectToAction("Index");
        }
    }
}

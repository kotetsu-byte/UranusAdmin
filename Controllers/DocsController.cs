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
        private readonly IMapper _mapper;

        public DocsController(IDocRepository docRepository, IMapper mapper)
        {
            _docRepository = docRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var docsMap = _mapper.Map<List<DocDto>>(await _docRepository.GetDocsAsync());
            
            return View(docsMap);
        }

        public async Task<IActionResult> Details(int id)
        {
            var docMap = _mapper.Map<DocDto>(await _docRepository.GetDocByIdAsync(id));

            return View(docMap);
        }

        public async Task<IActionResult> Create()
        {
            var docDto = new DocDto();
            docDto.Lessons = await _docRepository.GetAllNamesOfLessonsAsync();
            return View(docDto);
        }

        [HttpPost]
        public IActionResult Create(DocDto docCreate)
        {
            var doc = _mapper.Map<Doc>(docCreate);
            
            _docRepository.Create(doc);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var docMap = _mapper.Map<DocDto>(await _docRepository.GetDocByIdAsync(id));

            return View(docMap);
        }

        [HttpPost]
        public IActionResult Update(DocDto docUpdate)
        {
            var doc = _mapper.Map<Doc>(docUpdate);
            
            _docRepository.Update(doc);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var docMap = _mapper.Map<DocDto>(await _docRepository.GetDocByIdAsync(id));

            return View(docMap);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteDoc(int id)
        {
            var doc = await _docRepository.GetDocByIdAsync(id);
            _docRepository.Delete(doc);
            return RedirectToAction("Index");
        }
    }
}

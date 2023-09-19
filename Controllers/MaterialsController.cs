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

        public MaterialsController(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var materialsMap = _mapper.Map<List<MaterialDto>>(await _materialRepository.GetMaterialsAsync());
            
            return View(materialsMap);
        }

        public async Task<IActionResult> Details(int id)
        {
            var materialMap = _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialByIdAsync(id));

            return View(materialMap);
        }

        public async Task<IActionResult> Create()
        {
            var materialDto = new MaterialDto();
            materialDto.Homeworks = await _materialRepository.GetAllNamesOfHomeworksAsync();
            return View(materialDto);
        }

        [HttpPost]
        public IActionResult Create(MaterialDto materialCreate)
        {
            var material = _mapper.Map<Material>(materialCreate);
            
            _materialRepository.Create(material);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var materialMap = _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialByIdAsync(id));

            return View(materialMap);
        }

        [HttpPost]
        public IActionResult Update(MaterialDto materialUpdate)
        {
            var material = _mapper.Map<Material>(materialUpdate);
            
            _materialRepository.Update(material);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var materialMap = _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialByIdAsync(id));

            return View(materialMap);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _materialRepository.GetMaterialByIdAsync(id);

            _materialRepository.Delete(material);

            return RedirectToAction("Index");
        }
    }
}

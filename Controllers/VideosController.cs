using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Dto;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Controllers
{
    public class VideosController : Controller
    {
        private readonly IVideoRepository _videoRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public VideosController(IVideoRepository videoRepository, ILessonRepository lessonRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var videosMap = _mapper.Map<List<VideoDto>>(await _videoRepository.GetVideosAsync());
            return View(videosMap);
        }

        public async Task<IActionResult> Details(int id)
        {
            var videoMap = _mapper.Map<VideoDto>(await _videoRepository.GetVideoByIdAsync(id));
            return View(videoMap);
        }

        public async Task<IActionResult> Create()
        {
            var videoDto = new VideoDto();
            videoDto.Lessons = await _videoRepository.GetAllLessonsAsync();
            return View(videoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VideoDto videoCreate)
        {
            var video = _mapper.Map<Video>(videoCreate);
            _videoRepository.Create(video);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var videoMap = _mapper.Map<VideoDto>(await _videoRepository.GetVideoByIdAsync(id));
            videoMap.Lessons = await _videoRepository.GetAllLessonsAsync();
            return View(videoMap);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VideoDto videoUpdate)
        {
            var video = _mapper.Map<Video>(videoUpdate);
            _videoRepository.Update(video);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var videoMap = _mapper.Map<VideoDto>(await _videoRepository.GetVideoByIdAsync(id));
            videoMap.Lessons = await _videoRepository.GetAllLessonsAsync();
            return View(videoMap);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await _videoRepository.GetVideoByIdAsync(id);
            _videoRepository.Delete(video);
            return RedirectToAction("Index");
        }
    }
}

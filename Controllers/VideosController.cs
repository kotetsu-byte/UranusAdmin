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
        private readonly IMapper _mapper;

        public VideosController(IVideoRepository videoRepository, ILessonRepository lessonRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        public async Task<IActionResult> Index(int courseId, int lessonId)
        {
            var videosMap = _mapper.Map<List<VideoDto>>(await _videoRepository.GetVideosAsync(courseId, lessonId));
            foreach(var videoMap in videosMap)
            {
                videoMap.CourseId = courseId;
                videoMap.LessonId = lessonId;
            }
            return View(videosMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        public async Task<IActionResult> Details(int courseId, int lessonId, int id)
        {
            var videoMap = _mapper.Map<VideoDto>(await _videoRepository.GetVideoByIdAsync(courseId, lessonId, id));
            videoMap.CourseId = courseId;
            videoMap.LessonId = lessonId;
            return View(videoMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        public async Task<IActionResult> Create(int courseId, int lessonId)
        {
            var videoDto = new VideoDto();
            videoDto.CourseId = courseId;
            videoDto.LessonId = lessonId;
            return View(videoDto);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}")]
        [HttpPost]
        public async Task<IActionResult> Create(VideoDto videoCreate)
        {
            var video = _mapper.Map<Video>(videoCreate);
            _videoRepository.Create(video);
            return RedirectToAction("Index", "Videos", new {courseId = videoCreate.CourseId, lessonId = videoCreate.LessonId});;
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        public async Task<IActionResult> Update(int courseId, int lessonId, int id)
        {
            var videoMap = _mapper.Map<VideoDto>(await _videoRepository.GetVideoByIdAsync(courseId, lessonId, id));
            videoMap.CourseId = courseId;    
            videoMap.LessonId = lessonId;
            return View(videoMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        [HttpPost]
        public async Task<IActionResult> Update(VideoDto videoUpdate)
        {
            var video = _mapper.Map<Video>(videoUpdate);
            _videoRepository.Update(video);

            return RedirectToAction("Index", "Videos", new { courseId = videoUpdate.CourseId, lessonId = videoUpdate.LessonId });
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        public async Task<IActionResult> Delete(int courseId, int lessonId, int id)
        {
            var videoMap = _mapper.Map<VideoDto>(await _videoRepository.GetVideoByIdAsync(courseId, lessonId, id));
            videoMap.CourseId = courseId;
            videoMap.LessonId = lessonId;
            return View(videoMap);
        }

        [Route("[controller]/[action]/{courseId}/{lessonId}/{id?}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteVideo(int courseId, int lessonId, int id)
        {
            var video = await _videoRepository.GetVideoByIdAsync(courseId, lessonId, id);
            _videoRepository.Delete(video);
            return RedirectToAction("Index", "Videos", new { courseId = courseId, lessonId = lessonId });
        }
    }
}

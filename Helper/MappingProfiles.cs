using AutoMapper;
using UranusAdmin.Dto;
using UranusAdmin.Models;

namespace UranusAdmin.Helper
{
    public class MappingProfiles : Profile 
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Lesson, LessonDto>();
            CreateMap<LessonDto, Lesson>();
            CreateMap<Homework, HomeworkDto>();
            CreateMap<HomeworkDto, Homework>();
            CreateMap<Test, TestDto>();
            CreateMap<TestDto, Test>();
            CreateMap<Video, VideoDto>();
            CreateMap<VideoDto, Video>();
            CreateMap<Doc, DocDto>();
            CreateMap<DocDto, Doc>();
            CreateMap<Material, MaterialDto>();
            CreateMap<MaterialDto, Material>();
        }
    }
}

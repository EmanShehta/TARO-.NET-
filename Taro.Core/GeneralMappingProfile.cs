using AutoMapper;
using System.Diagnostics.Metrics;
using Taro.Core.Dtos.CourseDtos;
using Taro.Core.Dtos.VideoDtos;
using Taro.Core.Entities.Models.CourseModels;

namespace Core.MappingProfiles
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            #region
            CreateMap<Course,AddCourseDto>().ReverseMap();
            CreateMap<Course, CourseDetailsDto>().ReverseMap();
        
            #endregion

            #region
            CreateMap<Video, AddVideoDto>().ReverseMap();
            CreateMap<Video, VideoDetailsDto>().ReverseMap();
            #endregion
        }
    }
}

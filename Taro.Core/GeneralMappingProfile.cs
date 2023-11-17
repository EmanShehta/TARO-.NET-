using AutoMapper;
using System.Diagnostics.Metrics;
using Taro.Core.Dtos.CourseDtos;
using Taro.Core.Dtos.RoleDtos;
using Taro.Core.Dtos.VideoDtos;
using Taro.Core.Entities.Models.CourseModels;
using Taro.Core.Entities.Roles;

namespace Core.MappingProfiles
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            #region Course
            CreateMap<Course,AddCourseDto>().ReverseMap();
            CreateMap<Course, CourseDetailsDto>().ReverseMap();
        
            #endregion

            #region Video
            CreateMap<Video, AddVideoDto>().ReverseMap();
            CreateMap<Video, VideoDetailsDto>().ReverseMap();
            #endregion

            #region Role
            CreateMap<Role, RoleAddModel>().ReverseMap();
            #endregion
        }
    }
}

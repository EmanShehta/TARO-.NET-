using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taro.Core.Dtos.CourseDtos;
using Taro.Core.Dtos.Responses;
using Taro.Core.Entities.Models.CourseModels;

namespace Taro.Core.Interfaces
{
    public interface ICourseServices
    {
        Task<Response<long>> AddCourse(AddCourseDto request);
        Task<Response<Course>> UpdateCourse(AddCourseDto request, long Id);
        Task<Response<bool>> DeleteCourse(long Id);
        Task<Response<CourseDetailsDto>> GetcourseDetails(long Id);
        Task<Response<List<CourseDetailsDto>>> GetAllCourses();
        Task<Response<bool>> RateCourse(RateCourseDto request);
    }
}

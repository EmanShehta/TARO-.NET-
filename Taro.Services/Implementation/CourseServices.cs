using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taro.Core.Dtos.CourseDtos;
using Taro.Core.Dtos.Responses;
using Taro.Core.Entities.Models.CourseModels;
using Taro.Core.Interfaces;
using Taro.Repository.Context;

namespace Taro.Services.NewFolder
{
    public class CourseServices : ICourseServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CourseServices(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<long>> AddCourse(AddCourseDto request)
        {
            var course = _mapper.Map<Course>(request);
            await _context.AddAsync(course);
            _context.SaveChanges();
            return new Response<long>(course.Id, $"Course: {course.Code} added successfully.");
        }

        public async Task<Response<bool>> DeleteCourse(long Id)
        {
             var course = _context.courses.FirstOrDefault(c => c.Id == Id);
            if (course == null) return new Response<bool>("Id not Exist");
            _context.courses.Remove(course);
            _context.SaveChanges();
            return new Response<bool>(true,$"Course {Id} deleted successfully");
        }

        public async Task<Response<List<CourseDetailsDto>>> GetAllCourses()
        {
            var courses = _context.courses.Include(x => x.Videos).ToList();
            var result = _mapper.Map<List<CourseDetailsDto>>(courses);
            _context.SaveChanges();
            return new Response<List<CourseDetailsDto>>(result);
        }

        public async Task<Response<CourseDetailsDto>> GetcourseDetails(long Id)
        {
            var course = _context.courses.Include(x=>x.Videos).FirstOrDefault(x => x.Id == Id);
            var result = _mapper.Map<CourseDetailsDto>(course);
            _context.SaveChanges();
            return  new Response<CourseDetailsDto>(result);
        }
        
        public async Task<Response<bool>> RateCourse(RateCourseDto request)
        {
            var course = _context.courses.FirstOrDefault(x => x.Id == request.Id );
            if (course == null) return new Response<bool>("Id not Exist");
            course.Rate = request.Rate;
            _context.SaveChanges();
            return new Response<bool> (true,"Course Rated successfully");

        }

        public async Task<Response<Course>> UpdateCourse(AddCourseDto request, long Id)
        {
            var course = _context.courses.FirstOrDefault(x => x.Id == Id);
            if (course == null) return new Response<Course>("Id not valid");
            _mapper.Map(request,course);
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<Course>(course);

        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taro.Core.Dtos.CourseDtos;
using Taro.Core.Dtos.Responses;
using Taro.Core.Entities.Models.CourseModels;
using Taro.Core.Interfaces;

namespace Taro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[Authorize(Roles = "Instructor")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseServices _courseService;
        public CoursesController(ICourseServices courseServices)
        {
            _courseService = courseServices;
        }

        /// <summary>
        /// Add Course
        /// </summary>
        /// <response code="200">Added Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpPost("AddCourse")]
        [ProducesResponseType(typeof(Response<long>), 200)]
        
        public async Task<IActionResult> AddCourse(AddCourseDto addCourseDto)
        {
            var response = await _courseService.AddCourse(addCourseDto);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Get Course
        /// </summary>
        /// <response code="200">Return Specific Course Details </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpGet("GetCourse/{Id}")]
        [ProducesResponseType(typeof(Response<CourseDetailsDto>), 200)]
        //[Authorize(Roles = "Instructor , Student")]
        public async Task<IActionResult> GetCourse([FromRoute]long Id)
        {
            var response = await _courseService.GetcourseDetails(Id);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Rate Course
        /// </summary>
        /// <response code="200">Course Rated Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpPut("RateCourse/{Id}")]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        //[Authorize(Roles = "Student")]
        public async Task<IActionResult> RateCourse(RateCourseDto rateCourseDto)
        {
            var response = await _courseService.RateCourse(rateCourseDto);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Update Course
        /// </summary>
        /// <response code="200">Return Updated Course Details </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpPut("UpdateCourse/{Id}")]
        [ProducesResponseType(typeof(Response<Course>), 200)]
        
        public async Task<IActionResult> UpdateCourse(AddCourseDto addCourseDto,long Id)
        {
            var response = await _courseService.UpdateCourse(addCourseDto,Id);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Get All Courses
        /// </summary>
        /// <response code="200">Return All Courses with Details </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpGet("GetAllCourses")]
        [ProducesResponseType(typeof(Response<List<CourseDetailsDto>>), 200)]
        //[Authorize(Roles = "Instructor , Student")]
        public async Task<IActionResult> GetAllCourses()
        {
            var response = await _courseService.GetAllCourses();

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Delete Course
        /// </summary>
        /// <response code="200">Course Deleted Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpDelete("DeleteCourse/{Id}")]
        [ProducesResponseType(typeof(Response<bool>), 200)]
      
        public async Task<IActionResult> DeleteCourse(long Id)
        {
            var response = await _courseService.DeleteCourse(Id);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}

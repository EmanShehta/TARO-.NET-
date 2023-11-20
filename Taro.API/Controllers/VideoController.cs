using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taro.Core.Dtos.Responses;
using Taro.Core.Dtos.VideoDtos;
using Taro.Core.Interfaces;

namespace Taro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize(Roles = "Instructor")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoServices _videoServices;
        public VideoController(IVideoServices videoServices)
        {
           _videoServices = videoServices;
        }

        /// <summary>
        /// Add Video
        /// </summary>
        /// <response code="200">Added Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpPost("AddVideo")]
        [ProducesResponseType(typeof(Response<long>), 200)]
        public async Task<IActionResult> AddVideo(AddVideoDto addVideoDto)
        {
            var response = await _videoServices.AddVideo(addVideoDto);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Get Video
        /// </summary>
        /// <response code="200">Return Specific Video Details </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpGet("GetVideo/{Id}")]
        [ProducesResponseType(typeof(Response<VideoDetailsDto>), 200)]
        //[Authorize(Roles = "Instructor , Student")]
        public async Task<IActionResult> GetVideo([FromRoute] int Id)
        {
            var response = await _videoServices.GetVideo(Id);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Get All videos in Spesific Course
        /// </summary>
        /// <response code="200">Return All videos in Spesific Course </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpGet("GetVideosInCourse/{Id}")]
        [ProducesResponseType(typeof(Response<List<VideoDetailsDto>>), 200)]
        //[Authorize(Roles = "Instructor , Student")]
        public async Task<IActionResult> GetVideosInCourse([FromRoute]long Id)
        {
            var response = await _videoServices.GetCourseVideos(Id);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Update Video
        /// </summary>
        /// <response code="200">Video Updated Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpPut("UpdateVideo/{Id}")]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        public async Task<IActionResult> UpdateVideo(AddVideoDto addVideoDto, int Id)
        {
            var response = await _videoServices.UpdateVideo(addVideoDto, Id);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Delete Video
        /// </summary>
        /// <response code="200">Video Deleted Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpDelete("DeleteVideo/{Id}")]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        public async Task<IActionResult> DeleteVideo(int Id)
        {
            var response = await _videoServices.DeleteVideo(Id);

            if (response.Succeeded == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}

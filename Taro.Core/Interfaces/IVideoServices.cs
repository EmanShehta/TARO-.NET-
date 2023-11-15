using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taro.Core.Dtos.Responses;
using Taro.Core.Dtos.VideoDtos;

namespace Taro.Core.Interfaces
{
    public interface IVideoServices
    {
        Task<Response<long>> AddVideo(AddVideoDto addVideoDto);
        Task<Response<bool>> DeleteVideo(int Id);
        Task<Response<VideoDetailsDto>> GetVideo(int Id);
        Task<Response<bool>> UpdateVideo(AddVideoDto addVideoDto, int Id);
        Task<Response<List<VideoDetailsDto>>> GetCourseVideos(long courseId);
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taro.Core.Dtos.CourseDtos;
using Taro.Core.Dtos.Responses;
using Taro.Core.Dtos.VideoDtos;
using Taro.Core.Entities.Models.CourseModels;
using Taro.Core.Interfaces;
using Taro.Repository.Context;

namespace Taro.Services.Implementation
{
    public class VideoServices : IVideoServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public VideoServices(AppDbContext appDbContext,
                             IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;
        }
        public async Task<Response<long>> AddVideo(AddVideoDto addVideoDto)
        {
            var video = _mapper.Map<Video>(addVideoDto);
            await _context.videos.AddAsync(video);
            _context.SaveChanges();
            return new Response<long>(video.Id, $"Video {video.Id} added successfully");
        }


        public async Task<Response<List<VideoDetailsDto>>> GetCourseVideos(long courseId)
        {
            var courseVideos = _context.videos.Where(x=> x.CourseId == courseId).ToList();
            if (courseVideos.Count == 0) return new Response<List<VideoDetailsDto>>("No videos exist");
            var result = _mapper.Map<List<VideoDetailsDto>>(courseVideos);
            _context.SaveChanges();
            return new Response<List<VideoDetailsDto>>(result);
        }

        public async Task<Response<VideoDetailsDto>> GetVideo(int Id)
        {
            var video = _context.videos.FirstOrDefault(x => x.Id == Id);
            if (video == null) return new Response<VideoDetailsDto>("Id not Exist");
            var result = _mapper.Map<VideoDetailsDto>(video);
            _context.SaveChanges();
            return new Response<VideoDetailsDto>(result);
        }

        public async Task<Response<bool>> DeleteVideo(int Id)
        {
            var video = _context.videos.FirstOrDefault(c => c.Id == Id);
            if (video == null) return new Response<bool>("Id not Exist");
            _context.videos.Remove(video);
            _context.SaveChanges();
            return new Response<bool>(true, $"Video {Id} deleted successfully");
        }
        public async Task<Response<bool>> UpdateVideo(AddVideoDto addVideoDto, int Id)
        {
            var video = _context.videos.FirstOrDefault(x => x.Id == Id);
            if (video == null) return new Response<bool>("Id not valid");
            _mapper.Map(addVideoDto,video);
            _context.Entry(video).State = EntityState.Modified;
            _context.SaveChanges();
            return new Response<bool>(true,$"Video {Id} Updated Successfully");
        }
    }
}

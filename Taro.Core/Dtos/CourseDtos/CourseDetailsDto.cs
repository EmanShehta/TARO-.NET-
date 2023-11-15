using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taro.Core.Entities.Models.CourseModels;

namespace Taro.Core.Dtos.CourseDtos
{
    public class CourseDetailsDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Rate { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public List<Video> Videos { get; set; }
    }
}

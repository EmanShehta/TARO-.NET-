﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taro.Core.Dtos.VideoDtos
{
    public class VideoDetailsDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public long CourseId { get; set; }
    }
}

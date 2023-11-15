using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taro.Core.Dtos.VideoDtos
{
    public class AddVideoDto
    {
        public string Url { get; set; } = string.Empty;
        public long CourseId { get; set; }
    }
}

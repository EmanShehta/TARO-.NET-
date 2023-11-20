using System.ComponentModel.DataAnnotations;

namespace Taro.Core.Entities.Models.CourseModels
{
    public class Quiz
        {
            [Required]
            public int Id { get; set; }
            public String A { get; set; }
            public String Q { get; set; }
    }
    
}

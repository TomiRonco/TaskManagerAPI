using System.ComponentModel.DataAnnotations;

namespace taskManaggerAPI.Data.Models
{
    public class CommentPutDto
    {
        [Required]
        public string Content { get; set; }
    }
}

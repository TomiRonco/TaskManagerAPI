using System.ComponentModel.DataAnnotations;

namespace taskManaggerAPI.Data.Models
{
    public class CommentPostDto
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}

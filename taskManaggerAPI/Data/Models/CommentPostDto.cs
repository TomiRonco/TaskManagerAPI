using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace taskManaggerAPI.Data.Models
{
    public class CommentPostDto
    {
        [Required]
        public string Content { get; set; }
        [JsonIgnore]
        public int ClientId { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}

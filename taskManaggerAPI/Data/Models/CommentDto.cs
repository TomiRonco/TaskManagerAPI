using System.Text.Json.Serialization;

namespace taskManaggerAPI.Data.Models
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ClientId { get; set; }
    }
}

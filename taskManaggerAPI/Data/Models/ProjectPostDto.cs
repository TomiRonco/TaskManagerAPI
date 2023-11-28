using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace taskManaggerAPI.Data.Models
{
    public class ProjectPostDto
    {
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string Description { get; set; }
        [JsonIgnore]
        public int AdminId { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}

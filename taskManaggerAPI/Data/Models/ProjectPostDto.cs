using System.ComponentModel.DataAnnotations;

namespace taskManaggerAPI.Data.Models
{
    public class ProjectPostDto
    {
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AdminId { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace taskManaggerAPI.Data.Models
{
    public class ProjectPutDto
    {
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

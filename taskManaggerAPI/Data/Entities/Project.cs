using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace taskManaggerAPI.Data.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }

        public string Description { get; set; }
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public bool State { get; set; } = true;
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}

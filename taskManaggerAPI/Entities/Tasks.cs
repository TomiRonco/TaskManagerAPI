using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace taskManaggerAPI.Entities
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

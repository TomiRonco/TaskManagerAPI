using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace taskManaggerAPI.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        public string UserType { get; set; }
        public ICollection<Tasks> AssignedTasks { get; set; } = new List<Tasks>();

    }
}

namespace TPI_taskManaggerAPI.Entities
{
    public class Admin : User
    {
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

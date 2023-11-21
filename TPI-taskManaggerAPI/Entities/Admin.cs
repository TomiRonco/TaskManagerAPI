namespace TPI_taskManaggerAPI.Entities
{
    public class Admin : User
    {
        public ICollection<Task> CreatedTasks { get; set; } = new List<Task>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

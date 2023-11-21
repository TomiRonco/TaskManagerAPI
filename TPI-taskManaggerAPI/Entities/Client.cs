namespace TPI_taskManaggerAPI.Entities
{
    public class Client : User
    {
        public ICollection<Task> AssginedTask { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

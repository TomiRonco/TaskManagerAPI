namespace TPI_taskManaggerAPI.Entities
{
    public class Client : User
    {
        public ICollection<Task> AssginedTask { get; set; } = new List<Task>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); 
    }
}

namespace taskManaggerAPI.Entities
{
    public class Client : User
    {
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

namespace taskManaggerAPI.Data.Entities
{
    public class Client : User
    {
        public string Role { get; set; } = "Client";
        public List<Project> AssignedProjects { get; set; } = new List<Project>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}

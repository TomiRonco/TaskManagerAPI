namespace taskManaggerAPI.Data.Entities
{
    public class Admin : User
    {
        public string Role { get; set; } = "Admin";
        public List<Project> CreatedProjects { get; set; } = new List<Project>();
    }
}

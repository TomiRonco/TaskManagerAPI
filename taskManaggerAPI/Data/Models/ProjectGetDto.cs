namespace taskManaggerAPI.Data.Models
{
    public class ProjectGetDto
    {
        public int Id { get; set; }
        public string projectName { get; set; }
        public string Description { get; set; }
        public int adminId { get; set; }
        public int clientId { get; set; }
        public bool state { get; set; } 
    }
}

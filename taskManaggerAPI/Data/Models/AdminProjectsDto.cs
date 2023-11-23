namespace taskManaggerAPI.Data.Models
{
    public class AdminProjectsDto
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }
}

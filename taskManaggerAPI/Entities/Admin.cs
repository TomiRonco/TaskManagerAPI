namespace taskManaggerAPI.Entities
{
    public class Admin : User
    {
        public ICollection<Tasks> CreatedTasks { get; set; } = new List<Tasks>();
    }
}

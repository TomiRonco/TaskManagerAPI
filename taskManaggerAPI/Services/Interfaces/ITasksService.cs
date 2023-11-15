using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface ITasksService
    {
        Tasks GetTaskById(int taskId);
        IEnumerable<Tasks> GetAllTasks();
    }
}

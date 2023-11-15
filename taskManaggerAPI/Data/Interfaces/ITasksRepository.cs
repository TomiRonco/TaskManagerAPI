using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Interfaces
{
    public interface ITasksRepository
    {
        Tasks GetTaskById(int taskId);
        IEnumerable<Tasks> GetAllTasks();
        //void CreateTask(Tasks task);
    }
}

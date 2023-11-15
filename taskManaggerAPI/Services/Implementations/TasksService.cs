using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.Entities;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public Tasks GetTaskById(int taskId)
        {
            return _tasksRepository.GetTaskById(taskId);
        }

        public IEnumerable<Tasks> GetAllTasks()
        {
            return _tasksRepository.GetAllTasks();
        }

    }
}

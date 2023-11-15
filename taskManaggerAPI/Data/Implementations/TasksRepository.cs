using Microsoft.EntityFrameworkCore;
using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.DBContexts;
using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Implementations
{
    public class TasksRepository : Repository, ITasksRepository
    {
        public TasksRepository(taskManaggerContext context) : base(context) { }

        public Tasks GetTaskById(int taskId)
        {
            return _context.Tasks.Find(taskId);
        }

        public IEnumerable<Tasks> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        //public void CreateTask(Tasks task)
        //{
        //    _context.Tasks.Add(task);
        //    SaveChanges(); 
        //}
    }
}

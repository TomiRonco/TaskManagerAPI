using taskManaggerAPI.Data.Entities;
using taskManaggerAPI.DBContext;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly taskContext _taskContext;

        public ProjectService(taskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public List<Project> GetProjectCompleted()
        {
            return _taskContext.Projects.Where(p => p.State == false).ToList();
        }

        public List<Project> GetProjectIncompleted()
        {
            return _taskContext.Projects.Where(p => p.State == true).ToList();
        }
        public Project GetProjectById(int id)
        {
            return _taskContext.Projects.FirstOrDefault(p => p.Id == id);
        }

        public List<Project> GetAdminProjects(int adminId)
        {
            return _taskContext.Projects.Where(p => p.AdminId == adminId).ToList();
        }

        public int CreateProject(Project project)
        {
            _taskContext.Add(project);
            _taskContext.SaveChanges();
            return project.Id;
        }
        public Project UpdateProject(Project project)
        {
            _taskContext.Update(project);
            _taskContext.SaveChanges();
            return project;
        }

        public void DeleteProject(int proyectId)
        {
            Project? projectToDelete = _taskContext.Projects.FirstOrDefault(u => u.Id == proyectId);
            projectToDelete.State = false;
            _taskContext.Update(projectToDelete);
            _taskContext.SaveChanges();
        }
    }
}

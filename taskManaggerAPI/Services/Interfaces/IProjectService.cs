using taskManaggerAPI.Data.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetProjectIncompleted();
        List<Project> GetProjectCompleted();
        List<Project> GetAdminProjects(int adminId);
        Project GetProjectById(int id);
        int CreateProject(Project project);
        Project UpdateProject(Project project);
        void DeleteProject(int proyectId);
    }
}

using TBSS.Model;

namespace TBSS.Repositories.IRepositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects(int? customerId, int? userId);
        Project GetProjectById(int id);
        Project CreateProject(Project project);
        Project UpdateProject(Project project);
        bool DeleteProject(int id);
        bool AddUserToProject(int projectId, int userId);
        bool RemoveUserFromProject(int projectId, int userId);
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TBSS.Model;
using TBSS.Repositories.IRepositories;

namespace TBSS.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetProjects(int? customerId, int? userId)
        {
            IQueryable<Project> query = _context.Projects;

            if (customerId.HasValue)
                query = query.Where(p => p.CustomerId == customerId);

            if (userId.HasValue)
                query = query.Where(p => p.Users.Any(u => u.UserId == userId));

            return query.ToList();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public Project CreateProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public Project UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
            return project;
        }

        public bool DeleteProject(int id)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                return false;

            _context.Projects.Remove(project);
            _context.SaveChanges();
            return true;
        }

        public bool AddUserToProject(int projectId, int userId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == projectId);
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (project == null || user == null)
                return false;

            project.Users.Add(new ProjectUser { UserId = userId, ProjectId = projectId });
            _context.SaveChanges();
            return true;
        }

        public bool RemoveUserFromProject(int projectId, int userId)
        {
            var projectUser = _context.ProjectUsers.FirstOrDefault(pu => pu.ProjectId == projectId && pu.UserId == userId);
            if (projectUser == null)
                return false;

            _context.ProjectUsers.Remove(projectUser);
            _context.SaveChanges();
            return true;
        }
    }
}
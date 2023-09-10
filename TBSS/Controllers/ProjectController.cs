using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBSS.Model;
using TBSS.Repositories.IRepositories;

namespace TBSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _context;

        public ProjectController(IProjectRepository projectService)
        {
            _context = projectService;
        }

        [HttpGet]
        public IActionResult GetAllProjects([FromQuery] int? customerId, [FromQuery] int? userId)
        {
            // Implement logic to get projects with optional filters
            var projects = _context.GetProjects(customerId, userId);
            return Ok(projects);
        }
        [HttpGet("{id}")]
        public Project GetProjectById(int id)
        {
            return _context.GetProjectById(id);
        }
        [HttpPost]
        public Project CreateProject(Project project)
        {
            _context.CreateProject(project);
            return project;
        }
        [HttpPut]
        public Project UpdateProject(Project project)
        {
            _context.UpdateProject(project);
            return project;
        }
        [HttpDelete("{id}")]
        public bool DeleteProject(int id)
        {
            var project = _context.GetProjectById(id);
            if (project == null)
                return false;

            _context.DeleteProject(id); 
            return true;
        }
        [HttpPost("{projectId}/Users/{userId}")]
        public bool AddUserToProject(int projectId, int userId)
        {
            _context.AddUserToProject(projectId, userId);
            return true;
        }
        [HttpDelete("{projectId}/Users/{userId}")]
        public bool RemoveUserFromProject(int projectId, int userId)
        {
           _context.RemoveUserFromProject(projectId, userId);
            return true;
        }

    }
}

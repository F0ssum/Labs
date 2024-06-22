using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Models;
using Portfolio.Domain.Interfaces;

namespace Portfolio.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectService projectService, IProjectRepository projectRepository)
        {
            _projectService = projectService;
            _projectRepository = projectRepository;
        }


        [HttpGet("{projectId}")]
        public async Task<ActionResult<Project>> GetProjectById(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProject = await _projectService.CreateProjectAsync(project.Title, project.Description);
            return CreatedAtAction(nameof(GetProjectById), new { projectId = createdProject.ProjectId }, createdProject);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(int projectId, [FromBody] Project project)
        {
            if (projectId != project.ProjectId)
            {
                return BadRequest("Project ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProject = await _projectRepository.GetProjectByIdAsync(projectId);
            if (existingProject == null)
            {
                return NotFound();
            }

            await _projectRepository.UpdateProjectAsync(project);
            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                return NotFound();
            }

            await _projectRepository.DeleteProjectAsync(projectId);
            return NoContent();
        }
    }
}

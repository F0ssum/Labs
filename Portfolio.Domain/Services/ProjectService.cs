using Portfolio.Core.Models;
using Portfolio.Domain.Interfaces;

namespace Portfolio.Domain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> CreateProjectAsync( string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Project title cannot be empty or whitespace.");
            }

            var project = new Project
            {
                ProjectId = Guid.NewGuid().GetHashCode(),
                Title = title,
                Description = description
            };

            await _projectRepository.CreateProjectAsync(project);
            return project;
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _projectRepository.GetProjectByIdAsync(projectId);
        }



        public async Task UpdateProjectAsync(Project project)
        {
            if (project == null || string.IsNullOrWhiteSpace(project.Title))
            {
                throw new ArgumentException("Project and title cannot be null or whitespace.");
            }

            await _projectRepository.UpdateProjectAsync(project);
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project != null)
            {
                await _projectRepository.DeleteProjectAsync(projectId);
            }
        }
    }
}
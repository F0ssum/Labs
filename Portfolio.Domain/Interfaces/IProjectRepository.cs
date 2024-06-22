using Portfolio.Core.Models;

namespace Portfolio.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByIdAsync(int projectId);
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);
    }
}

using Portfolio.Core.Models;

namespace Portfolio.Domain.Interfaces
{
    public interface IProjectService
    {
        Task<Project> CreateProjectAsync( string title, string description);
        Task<Project> GetProjectByIdAsync(int projectId);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);
    }
}

using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;
using Portfolio.Domain.Interfaces;


namespace Portfolio.Infrastructure.Repositories
{


    public class ProjectRepository : IProjectRepository
    {
        private readonly PortfolioDbContext _context;

        public ProjectRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _context.Projects
            .FirstOrDefaultAsync(p => p.ProjectId == projectId);
        }


        public async Task CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project updatedProject)
        {
            var existingProject = await _context.Projects.FindAsync(updatedProject.ProjectId);
            if (existingProject != null)
            {
                existingProject.Title = updatedProject.Title;
                existingProject.Description = updatedProject.Description;

                await _context.SaveChangesAsync();
            }
        }



        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }

}

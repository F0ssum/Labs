//using Microsoft.EntityFrameworkCore;
//using Portfolio.Core.Models;
//using Portfolio.Domain.Interfaces;

//namespace Portfolio.Infrastructure.Repositories
//{
//    public class CommentRepository : ICommentRepository
//    {
//        private readonly PortfolioDbContext _context;

//        public CommentRepository(PortfolioDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Comment>> GetCommentsByProjectAsync(int projectId)
//        {
//            return await _context.Comments
//            .Where(c => c.ProjectId == projectId)
//            .OrderByDescending(c => c.CreatedAt)
//            .ToListAsync();
//        }

//        public async Task AddCommentAsync(Comment comment)
//        {
//            await _context.Comments.AddAsync(comment);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<Comment> GetCommentByIdAsync(int commentId)
//        {
//            return await _context.Comments.FindAsync(commentId);
//        }

//        public async Task<IEnumerable<Comment>> GetCommentsByUserAsync(int userId)
//        {
//            return await _context.Comments
//            .Where(c => c.UserId == userId)
//            .OrderByDescending(c => c.CreatedAt)
//            .ToListAsync();
//        }

//        public async Task UpdateAsync(Comment comment)
//        {
//            _context.Comments.Update(comment);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(Comment comment)
//        {
//            _context.Comments.Remove(comment);
//            await _context.SaveChangesAsync();
//        }
//    }
//}

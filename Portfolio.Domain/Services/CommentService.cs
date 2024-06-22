//using Portfolio.Core.Models;
//using Portfolio.Domain.Interfaces;

//namespace Portfolio.Domain.Services
//{


//    public class CommentService : ICommentService
//    {
//        private readonly ICommentRepository commentRepository;

//        public CommentService(ICommentRepository commentRepository)
//        {
//            this.commentRepository = commentRepository;
//        }

//        public async Task<Comment> CreateCommentAsync(int projectId, int userId, string content)
//        {
//            if (string.IsNullOrWhiteSpace(content))
//            {
//                throw new ArgumentException("Comment content cannot be empty or whitespace.");
//            }

//            var comment = new Comment
//            {
//                ProjectId = projectId,
                
//                Content = content,
//            };

//            await commentRepository.AddCommentAsync(comment);

//            return comment;
//        }

//        public async Task<Comment> GetCommentByIdAsync(int commentId)
//        {
//            return await commentRepository.GetCommentByIdAsync(commentId);
//        }

//        public async Task<IEnumerable<Comment>> GetCommentsByProjectAsync(int projectId)
//        {
//            return await commentRepository.GetCommentsByProjectAsync(projectId);
//        }

//        public async Task<IEnumerable<Comment>> GetCommentsByUserAsync(int userId)
//        {
//            return await commentRepository.GetCommentsByUserAsync(userId);
//        }

//        public async Task UpdateCommentAsync(Comment comment)
//        {
//            if (string.IsNullOrWhiteSpace(comment.Content))
//            {
//                throw new ArgumentException("Comment content cannot be empty or whitespace.");
//            }

//            await commentRepository.UpdateAsync(comment);
//        }

//        public async Task DeleteCommentAsync(Comment comment)
//        {
//            await commentRepository.DeleteAsync(comment);
//        }
//    }

//}

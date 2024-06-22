//using Microsoft.AspNetCore.Mvc;
//using Portfolio.Core.Models;
//using Portfolio.Domain.Interfaces;

//namespace Portfolio.WebApi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class CommentController : ControllerBase
//    {
//        private readonly ICommentService _commentService;

//        public CommentController(ICommentService commentService)
//        {
//            _commentService = commentService;
//        }


//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsByProjectAsync(int projectId)
//        {
//            var comments = await _commentService.GetCommentsByProjectAsync(projectId);
//            if (comments == null)
//            {
//                return NotFound();
//            }
//            return Ok(comments);
//        }


//        [HttpPost]
//        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
//            }

//            var createdComment = await _commentService.CreateCommentAsync(comment.ProjectId, comment.UserId, comment.Content);
//            return CreatedAtAction("GetCommentById", new { commentId = createdComment.CommentId }, createdComment);
//        }


//        [HttpDelete("{commentId}")]
//        public async Task<IActionResult> DeleteCommentAsync(int commentId)
//        {
//            var comment = await _commentService.GetCommentByIdAsync(commentId);
//            if (comment == null)
//            {
//                return NotFound();
//            }

//            await _commentService.DeleteCommentAsync(comment);
//            return NoContent();
//        }
//    }
//}

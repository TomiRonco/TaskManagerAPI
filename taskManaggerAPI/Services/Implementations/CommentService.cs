using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.Entities;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Comment GetCommentById(int commentId)
        {
            return _commentRepository.GetCommentById(commentId);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _commentRepository.GetAllComments();
        }
    }
}

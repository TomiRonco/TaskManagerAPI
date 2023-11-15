using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface ICommentService
    {
        Comment GetCommentById(int commentId);
        IEnumerable<Comment> GetAllComments();
    }
}

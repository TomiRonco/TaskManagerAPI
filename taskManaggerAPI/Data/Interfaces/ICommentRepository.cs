using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Interfaces
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int commentId);
        IEnumerable<Comment> GetAllComments();
        //void CreateComment(Comment comment);
    }
}

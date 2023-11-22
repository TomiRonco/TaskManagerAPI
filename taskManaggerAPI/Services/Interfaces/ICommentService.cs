using taskManaggerAPI.Data.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface ICommentService
    {
        Comment GetCommentById(int id);
        int CreateComment(Comment comment);
        Comment UpdateComment(Comment comment);
        void DeleteComment(int commentId);
    }
}

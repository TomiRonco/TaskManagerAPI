using taskManaggerAPI.Data.Entities;

namespace taskManaggerAPI.Services.Interfaces
{
    public interface ICommentService
    {
        Comment GetCommentById(int id);

        List<Comment> GetCommentsByProjectId(int projectId);
        int CreateComment(Comment comment);
        Comment UpdateComment(Comment comment);
        void DeleteComment(int commentId);
    }
}

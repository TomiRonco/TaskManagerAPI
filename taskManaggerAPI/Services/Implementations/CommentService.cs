using taskManaggerAPI.Data.Entities;
using taskManaggerAPI.DBContext;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly taskContext _taskContext;

        public CommentService(taskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public Comment GetCommentById(int id)
        {
            return _taskContext.Comments.FirstOrDefault(p => p.Id == id);
        }
        public int CreateComment(Comment comment)
        {
            _taskContext.Add(comment);
            _taskContext.SaveChanges();
            return comment.Id;
        }

        public void DeleteComment(int commentId)
        {
            _taskContext.Remove(commentId);
            _taskContext.SaveChanges();
        }

        public Comment UpdateComment(Comment comment)
        {
            _taskContext.Update(comment);
            _taskContext.SaveChanges();
            return comment;
        }
    }
}

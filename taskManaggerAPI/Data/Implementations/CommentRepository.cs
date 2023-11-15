using taskManaggerAPI.Data.Interfaces;
using taskManaggerAPI.DBContexts;
using taskManaggerAPI.Entities;

namespace taskManaggerAPI.Data.Implementations
{
    public class CommentRepository : Repository, ICommentRepository
    {
        public CommentRepository(taskManaggerContext context) : base(context) { }

        public Comment GetCommentById(int commentId)
        {
            return _context.Comments.Find(commentId);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        //public void CreateComment(Comment comment)
        ////{
        ////    _context.Comments.Add(comment);
        ////    SaveChanges();
        ////}
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.CommentAgg;

namespace MB.Infrastructure.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

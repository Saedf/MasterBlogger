using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contract.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

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

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(x => x.Article).Select(x=> new CommentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    Status = x.Status,
                    CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture),
                    Article = x.Article.Title
                    
                })
                .OrderByDescending(x=>x.Id)
                .ToList();
        }

        public Comment Get(long Id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == Id);
        }
    }
}

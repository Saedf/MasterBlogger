using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FrameWork.Infrastructure;
using MB.Application.Contract.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository:IRepository<long,Comment>
    {
        //void Create(Comment comment);
        //void Save();
        List<CommentViewModel> GetList();
        //Comment Get(long Id);
    }
}

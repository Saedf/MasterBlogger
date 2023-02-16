using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FrameWork.Infrastructure;
using MB.Application.Contract.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddComment command)
        {
            _unitOfWork.BeginTran();
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(comment);
         
            // _commentRepository.Save();
            _unitOfWork.CommitTran();
        }

        public List<CommentViewModel> GetComments()
        {
            return _commentRepository.GetList();
        }

        public void Confirmed(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Confirmed();
            // _commentRepository.Save();
            _unitOfWork.CommitTran();
        }

        public void Canceled(long id)
        {
            _unitOfWork.BeginTran();
            var  comment=_commentRepository.Get(id);
            comment.Canceled();
            // _commentRepository.Save();
            _unitOfWork.CommitTran();
        }
    }
}

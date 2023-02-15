﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contract.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(comment);
        }

        public List<CommentViewModel> GetComments()
        {
            return _commentRepository.GetList();
        }

        public void Confirmed(long id)
        {
            var comment = _commentRepository.Get(id);
            comment.Confirmed();
            _commentRepository.Save();
        }

        public void Canceled(long id)
        {
            var  comment=_commentRepository.Get(id);
            comment.Canceled();
            _commentRepository.Save();
        }
    }
}

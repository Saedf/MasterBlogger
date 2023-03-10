using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FrameWork.Domain;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
    public class Comment:DomainBase<long>
    {
        // public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; } //new =0 ,confirmed=1,=canceled=2
        // public DateTime CreationDate { get; private set; }
        public long ArticleId { get; private set; }
        public Article Article { get; private set; }

        public Comment(string name, string email, string message, long articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            // CreationDate=DateTime.Now;
            Status = Statuses.New;
        }

        protected Comment()
        {
            
        }
        public void Confirmed()
        {
            Status =Statuses.Confirmed;
        }

        public void Canceled()
        {
            Status = Statuses.Canceled;
        }
    }
}

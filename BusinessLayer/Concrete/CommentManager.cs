using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void AddComment(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void AddT(Comment entity)
        {
            _commentDal.Add(entity);
        }

        public void DeleteComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteT(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetList(int id)
        {
            return _commentDal.GetListAll(x => x.BlogId == id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetListAll();
        }

        public List<Comment> GetCommentWithBlog()
        {
            return _commentDal.GetCommentWithBlog();
        }

        public Comment TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void UpdateT(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}

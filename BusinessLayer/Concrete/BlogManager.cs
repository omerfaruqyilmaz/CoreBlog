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
    public class BlogManager : IBlogService
    {
        
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void AddBlog(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetCategoryName(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetListAll(x => x.BlogId == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> GetListLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }

        public void UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterId == id);
            
        }

        public void AddT(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void DeleteT(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public void UpdateT(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}

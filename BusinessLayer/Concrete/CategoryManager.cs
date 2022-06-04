using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : IGenericService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void AddT(Category entity)
        {
            _categoryDal.Add(entity);
        }
        public void DeleteT(Category entity)
        {
            _categoryDal.Delete(entity);
        }
        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }
        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }
        public void UpdateT(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}

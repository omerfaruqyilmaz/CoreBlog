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
    public class WriterManager : IWriterService
    {

        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void AddT(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void DeleteT(Writer entity)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetListAll(x => x.WriterId == id);
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public void UpdateT(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}

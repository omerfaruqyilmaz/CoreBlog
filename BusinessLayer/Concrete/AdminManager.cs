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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddT(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteT(Admin entity)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public Admin TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateT(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}

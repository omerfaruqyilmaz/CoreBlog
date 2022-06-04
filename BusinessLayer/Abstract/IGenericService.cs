using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IGenericService<T>
    {
        void AddT(T entity);
        void DeleteT(T entity);
        void UpdateT(T entity);
        List<T> GetList();
        T TGetById(int id);
    }
}

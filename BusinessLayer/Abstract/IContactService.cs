using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        void DeleteContact(About contact);
        void UpdateContact(About contact);
        List<Contact> GetList();
        Contact GetById(int id);

    }
}

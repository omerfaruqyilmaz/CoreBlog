using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface INewsLetterService
    {
        void AddNewsLetter(NewsLetter newsLetter);
        void DeleteNewsLetter(NewsLetter newsLetter);
        void UpdateNewsLetter(NewsLetter newsLetter);
        List<NewsLetter> GetList();
        NewsLetter GetById(int id);

    }
}

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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _messageDal;

        public Message2Manager(IMessage2Dal messageDal)
        {
            _messageDal = messageDal;
        }
        public void AddT(Message2 entity)
        {
            _messageDal.Add(entity);
        }

        public void DeleteT(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _messageDal.GetInboxWithMessageByWriter(id);
        }

        public List<Message2> GetList()
        {
            return _messageDal.GetListAll();
        }

        public List<Message2> GetSendboxWithMessageByWriter(int id)
        {
            return _messageDal.GetSendboxWithMessageByWriter(id);
        }

        public Message2 TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void UpdateT(Message2 entity)
        {
            throw new NotImplementedException();
        }

        
    }
}

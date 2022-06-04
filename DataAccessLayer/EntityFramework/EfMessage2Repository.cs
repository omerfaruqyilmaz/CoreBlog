﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetSendboxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2.Include(x => x.ReveiverUser).Where(x => x.SenderId == id).ToList();
            }
        }
        public List<Message2> GetInboxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2.Include(x => x.SenderUser).Where(x => x.ReceiverId == id).ToList();
            }
        }
        

        
    }
}

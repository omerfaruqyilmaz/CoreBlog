﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void AddT(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void DeleteT(Notification entity)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetList()
        {
            return _notificationDal.GetListAll();
        }

        public Notification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateT(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}

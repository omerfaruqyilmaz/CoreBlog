using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string NotificationType { get; set; }
        public string NotificationColor { get; set; }
        public string NotificationSymbol { get; set; }
        public string NotificationDetails { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }

        
        
    }
}

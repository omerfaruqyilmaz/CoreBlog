using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Message2
    {
        [Key]
        public int MessageId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }

        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public Writer SenderUser { get; set; }
        public Writer ReveiverUser{ get; set; }

        
    }
}

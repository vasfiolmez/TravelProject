using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelProject.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }

        // Gönderen admin bilgisi
        public int SenderAdminId { get; set; }
        public virtual Admin SenderAdmin { get; set; }

        // Alıcı admin bilgisi
        public int ReceiverAdminId { get; set; }
        public virtual Admin ReceiverAdmin { get; set; }

    }
}
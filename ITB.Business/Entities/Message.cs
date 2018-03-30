using System;
using System.Collections.Generic;
using System.Text;

namespace ITB.Business.Entities
{

    public class Message : BaseMongoId
    {
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

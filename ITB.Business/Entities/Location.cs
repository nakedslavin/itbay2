using System;
using System.Collections.Generic;
using System.Text;

namespace ITB.Business
{
    public class Location : BaseMongoId
    {
        public string Name { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
    }
}

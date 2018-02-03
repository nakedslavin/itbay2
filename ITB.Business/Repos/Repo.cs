using System;
using System.Collections.Generic;
using System.Text;
using ITB.Business;

namespace ITB.Business.Repos
{
    public class Repo
    {
        private List<Location> locations;

        public List<Location> Locations
        {
            get {
                if (locations == null) {
                    var _db = new MongoSession<Location>();
                    locations = _db.Get(_ => true);
                }
                return locations;
            }
        }
    }
}

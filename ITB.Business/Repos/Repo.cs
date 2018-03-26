using System;
using System.Collections.Generic;
using System.Text;
using ITB.Business;
using MongoDB.Bson;
using System.Linq;

namespace ITB.Business.Repos
{
    public class Repo
    {
        private List<Location> locations;
        private List<string> skills;
        private List<string> positions;

        public List<Location> Locations
        {
            get {
                if (locations == null) {
                    var _db = new MongoSession<Location>("City");
                    locations = _db.Get(_ => true);
                }
                return locations;
            }
        }
        public List<string> Skills
        {
            get
            {
                if (skills == null)
                {
                    var _db = new MongoSession<BsonDocument>("Skill");
                    skills = _db.Get(_ => true).Select(x => x["Name"].AsString).ToList();
                }
                return skills;
            }
        }
        public List<string> Positions
        {
            get
            {
                if (positions == null)
                {
                    var _db = new MongoSession<BsonDocument>("Position");
                    positions = _db.Get(_ => true).Select(x => x["Name"].AsString).ToList();
                }
                return positions;
            }
        }
    }
}

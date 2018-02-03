using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ITB.Business.Repos
{
    // Database Name
    // Connection String
    // This is MongoDB representation of the db. This is the only coupling point with the db.
    public class MongoSession<T> where T : new()
    {
        private MongoClient client;
        private IMongoCollection<T> collection;

        public MongoSession()
        {
            this.client = new MongoClient();
            this.collection = client.GetDatabase("itbay")
                .GetCollection<T>(typeof(T).Name);
        }

        /// <summary>
        /// Gets data from the database
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>
        /// Data of type <T>
        /// </returns>
        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return collection.Find<T>(predicate).ToList();
        }

        /// <summary>
        /// Saves data to the database
        /// </summary>
        /// <param name="item"></param>
        public void Save(T item)
        {
            if (typeof(T).IsSubclassOf(typeof(BaseMongoId)))
            {
                BaseMongoId id = item as BaseMongoId;
                if (id.Id == null)
                    collection.InsertOne(item);
                else
                    collection.ReplaceOne(new BsonDocument("_id", ObjectId.Parse(id.Id)), item, new UpdateOptions { IsUpsert = true });
            }
            else
                collection.InsertOne(item);
        }
    }
}

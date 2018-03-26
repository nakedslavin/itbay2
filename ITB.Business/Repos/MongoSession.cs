using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Authentication;
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

        public MongoSession(string collectionName = null)
        {
            string connectionString =
  @"mongodb://sa:Letmein1@ds040637.mlab.com:40637/itbay?3t.connection.name=lab-bay&3t.connectTimeout=10000&3t.uriVersion=2&3t.connectionMode=direct&readPreference=primary&3t.socketTimeout=0&3t.databases=itbay";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            this.client = new MongoClient(settings);
            collectionName = collectionName ?? typeof(T).Name;
            this.collection = client.GetDatabase("itbay")
                .GetCollection<T>(collectionName);
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

        /// <summary>
        /// Delete an item from the collection
        /// </summary>
        /// <param name="item"></param>
        public void Delete(T item)
        {
            if (typeof(T).IsSubclassOf(typeof(BaseMongoId)))
            {
                BaseMongoId id = item as BaseMongoId;
                collection.DeleteOne(new BsonDocument("_id", ObjectId.Parse(id.Id)));
            }
        }
    }
}

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoRivers.Library.Utility;

namespace TwoRivers.Library
{

    public static class MongoDataManager
    {
        private static MongoClient _Client;
        private static MongoServer _Server;
        private static MongoDatabase _DB;

        private static bool _Init = false;

        private static void Init()
        {
            if (_Init == false)
            {
                _Client = new MongoClient(ConfigurationManager.ConnectionStrings["Mongo_Server"].ConnectionString);
                //_Server = _Client.GetServer();
                _DB = _Server.GetDatabase(ConfigurationManager.AppSettings["Mongo_DB"]);

                _Init = true;
            }
        }

        public static MongoCollection Collection(string collectionName)
        {
            DebugCounter.Count($"Mongo Collection ({collectionName})");
            Init();

            Debug.WriteLine("Collection\t" + collectionName);

            return _DB.GetCollection(collectionName);
        }

        public static MongoCollection<T> Collection<T>(string collectionName)
        {
            DebugCounter.Count($"Mongo Collection ({collectionName})");
            Init();

            Debug.WriteLine("Collection\t" + collectionName);

            return _DB.GetCollection<T>(collectionName);
        }

        public static IEnumerable<T> QueryableCollection<T>(string collectionName)
        {
            DebugCounter.Count("Mongo QueryableCollection");
            Init();

            return _DB.GetCollection<T>(collectionName).AsQueryable<T>();
        }

        public static IMongoCollection<T> Collection<T>(string connection, string database, string collection)
        {
            DebugCounter.Count($"Mongo Collection ({collection})");
            Debug.WriteLine("Collection\t" + collection);

            var client = new MongoClient(connection);
            var db = client.GetDatabase(database);
            return db.GetCollection<T>(collection);
        }

    }
}

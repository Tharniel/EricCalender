using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Kalender.Data
{
    internal class DB
    {

        internal static MongoClient GetClient()
        {
            string connectionString = "COnnstring";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);

            return mongoClient;
        }

        public static IMongoCollection<Models.User> UserCollection()
        {
            var client = GetClient();

            var database = client.GetDatabase("CalenderDB");

            IMongoCollection<Models.User> userCollection = database.GetCollection<Models.User>("User");

            return userCollection;

        }
        public static IMongoCollection<Models.Event> TaskCollection()
        {
            var client = GetClient();

            var database = client.GetDatabase("CalenderDB");

            var taskCollection = database.GetCollection<Models.Event>("Events");

            return taskCollection;

        }

        public static async Task<List<Models.Event>> GetEventsFromDB()
        {
            var client = GetClient();
            var database = client.GetDatabase("CalenderDB");
            var taskCollection = database.GetCollection<Models.Event>("Events");
            var user = Singletons.Authorized.GetAuthStatus().WhoIsUser();
            var filter = Builders<Models.Event>.Filter.Eq("Username", user);

            var result = await taskCollection.FindAsync(filter);

            return await result.ToListAsync();
        }
    } 
}

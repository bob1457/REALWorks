using Microsoft.Extensions.Options;
using MongoDB.Driver;
using REALWorks.Asset.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Data
{
    public class DbContext
    {
        private readonly IMongoDatabase _datbase = null;

        public DbContext(IOptions<Settings> settings)
        {
            //var client = new MongoClient(settings.Value.ConnectionString);
            var client = new MongoClient("mongodb://localhost:27017");
            if (client != null)
            {
                _datbase = client.GetDatabase("AssetDb");
            }
        }

        public IMongoCollection<Property> Property
        {
            get
            {
                return _datbase.GetCollection<Property>("Property");
            }
        }

        //public object PropertyImage { get; internal set; }

        public IMongoCollection<PropertyImage> PropertyImage
        {
            get
            {
                return _datbase.GetCollection<PropertyImage>("PropertyImage");
            }
        }
    }
}

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
        private readonly IMongoDatabase _database = null;

        public DbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            //var client = new MongoClient("mongodb://localhost:27017");
            if (client != null)
            {
                //_datbase = client.GetDatabase("AssetDb");
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Property> Property
        {
            get
            {
                return _database.GetCollection<Property>("Property");
            }
        }

        //public object PropertyImage { get; internal set; }

        public IMongoCollection<PropertyImage> PropertyImage
        {
            get
            {
                return _database.GetCollection<PropertyImage>("PropertyImage");
            }
        }

        public IMongoCollection<ManagementContract> ManagementContract
        {
            get
            {
                return _database.GetCollection<ManagementContract>("ManagementContract");
            }
        }

        public IMongoCollection<Tenant> Tenant
        {
            get
            {
                return _database.GetCollection<Tenant>("Teant");
            }
        }

        public IMongoCollection<Owner> Owner
        {
            get
            {
                return _database.GetCollection<Owner>("Owner");
            }
        }
    }
}

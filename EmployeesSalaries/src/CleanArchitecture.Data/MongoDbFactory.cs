using CleanArchitecture.Domain.SeedWork;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace CleanArchitecture.Data
{
    public class MongoDbFactory
    {
        private readonly IConfiguration _configuration;

        public MongoDbFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IMongoDatabase GetDatabase()
        {
            var url = new MongoUrl(_configuration.GetConnectionString("Mongo"));
            var client = new MongoClient(url);
            var database = client.GetDatabase("EmployeesSalaries_CleanArchitecture");

            var conventionPack = new ConventionPack {
                new IgnoreExtraElementsConvention(true)
            };

            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, x => true);

            BsonClassMap.RegisterClassMap<Entity>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

            return database;
        }
    }
}

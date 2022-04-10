using MongoDB.Driver;

namespace CleanArchitecture.Data.Repositories
{
    public abstract class Repository<IAggregateRoot>
    {
        protected readonly IMongoCollection<IAggregateRoot> Collection;

        public Repository(IMongoDatabase database, string collectionName)
        {
            Collection = database.GetCollection<IAggregateRoot>(collectionName);
        }
    }
}

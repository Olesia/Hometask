using Hometask.Common.Interfaces;
using Hometask.Shared;

namespace Hometask.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IApplicationDbContext _dbContext;

        public Repository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IEnumerable<T> List(string collectionName)
        {
            return _dbContext.Database.GetCollection<T>(collectionName).FindAll(); ;
        }

        public virtual T GetById(Guid id, string collectionName)
        {
            return _dbContext.Database.GetCollection<T>(collectionName).Query().Where(c=>c.Id == id).FirstOrDefault();
        }

        public Guid Insert(T entity, string collectionName)
        {
            return _dbContext.Database.GetCollection<T>(collectionName)
                .Insert(entity);
        }
       
        public bool Delete(Guid id, string collectionName)
        {
            return _dbContext.Database.GetCollection<T>(collectionName)
                .Delete(id);
        }
    }
}

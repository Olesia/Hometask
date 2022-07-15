using Hometask.Common.Interfaces;
using Hometask.Shared;
using System.Linq.Expressions;

namespace Hometask.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IApplicationDbContext _dbContext;

        public Repository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IEnumerable<T> ListFiltered(string collectionName, Expression<Func<T, bool>>? predicate)
        {
            IEnumerable<T> result = predicate != null ?
                _dbContext.Database.GetCollection<T>(collectionName).Query().Where(predicate).ToList() :
                _dbContext.Database.GetCollection<T>(collectionName).FindAll().ToList();
            return result;
        }

        public bool Insert(T entity, string collectionName)
        {
            var id = _dbContext.Database.GetCollection<T>(collectionName)
                .Insert(entity);
            return id != null;
        }

        public bool Update(T entity, string collectionName)
        {
           var result = _dbContext.Database.GetCollection<T>(collectionName)
               .Update(entity);
           return result;
        }

        public bool Delete(Guid id, string collectionName)
        {
            return _dbContext.Database.GetCollection<T>(collectionName)
                .Delete(id);
        }
    }
}

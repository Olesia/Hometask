using Hometask.Shared;
using System.Linq.Expressions;

namespace Hometask.Common.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        //IEnumerable<T> ListAll(string collectionName);
        IEnumerable<T> ListFiltered(string collectionName, Expression<Func<T, bool>> predicate);
        //T GetById(Guid id, string collectionName);
        bool Insert(T entity, string collectionName);
        bool Delete(Guid id, string collectionName);
    }
}

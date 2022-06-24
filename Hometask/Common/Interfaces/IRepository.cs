using Hometask.Shared;

namespace Hometask.Common.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> List(string collectionName);
        T GetById(Guid id, string collectionName);
        Guid Insert(T entity, string collectionName);
        bool Delete(Guid id, string collectionName);
    }
}

using LiteDB;

namespace Hometask.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        ILiteDatabase Database { get; }
    }
}

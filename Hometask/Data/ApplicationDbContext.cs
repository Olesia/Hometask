using Hometask.Common.Interfaces;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Hometask.Data
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public ILiteDatabase Database { get; }

        public ApplicationDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
        }
    }
}

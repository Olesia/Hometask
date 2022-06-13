using Hometask.DAL.Entities;
using LiteDB;

namespace Hometask.DAL.Repositories
{
    internal class ItemsRepository
    {
        public void CreateAllItems()
        {
            using (var db = new LiteDatabase(@"CartDB.db"))
            {
                var col = db.GetCollection<Item>("items");
                col.DeleteAll();
                col.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #1", Price = 10, Quantity = 5 });
                col.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #2", Price = 20, Quantity = 10 });
                col.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #3", Price = 30, Quantity = 15 });
                col.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #4", Price = 40, Quantity = 20 });
                col.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #5", Price = 50, Quantity = 25 });
            }
        }

        public IEnumerable<Item> GetAllItems()
        {
            using (var db = new LiteDatabase(@"CartDB.db"))
            {
                var items = db.GetCollection<Item>("items").FindAll().ToList();
                return items;
            }
        }
    }
}

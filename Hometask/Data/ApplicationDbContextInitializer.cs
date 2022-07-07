
using Hometask.Common;
using Hometask.Common.Interfaces;
using Hometask.DAL.Entities;

namespace Hometask.Data
{
    public class ApplicationDbContextInitialiser
    {
        private readonly IApplicationDbContext _context;

        public ApplicationDbContextInitialiser(IApplicationDbContext context)
        {
            _context = context;
        }

        //public void SeedItems()
        //{
        //    var itemsList = _context.Database.GetCollection<Item>(Constants.ItemsCollectionName);
        //    var cartItemsList = _context.Database.GetCollection<CartItem>(Constants.CartItemsCollectionName);

        //    itemsList.DeleteAll();
        //    cartItemsList.DeleteAll();  
            
        //    itemsList.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #1", Price = 10, Quantity = 5 });
        //    itemsList.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #2", Price = 20, Quantity = 10 });
        //    itemsList.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #3", Price = 30, Quantity = 15 });
        //    itemsList.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #4", Price = 40, Quantity = 20 });
        //    itemsList.Insert(new Item() { Id = Guid.NewGuid(), Name = "item #5", Price = 50, Quantity = 25 });
        //}
    }
}

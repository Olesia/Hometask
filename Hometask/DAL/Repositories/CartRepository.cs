
using Hometask.DAL.Entities;
using LiteDB;

namespace Hometask.DAL.Repositories
{
    internal class CartRepository
    {
        public void CreateCart(Guid id)
        {
            using (var db = new LiteDatabase(@"CartDB.db"))
            {
                var cartList = db.GetCollection<Cart>("carts");
                cartList.DeleteAll();
                cartList.Insert(new Cart { Id = id });
            }
        }
    }
}

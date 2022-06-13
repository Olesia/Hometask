using Hometask.DAL.Entities;
using LiteDB;

namespace Hometask.DAL.Repositories
{
    internal class CartItemRepository
    {
        public bool CreateCartItem(Guid cartId, Guid itemId, int quantity)
        {
            try
            {
                using (var db = new LiteDatabase(@"CartDB.db"))
                {
                    var col = db.GetCollection<CartItem>("cartItems");
                    var cart = new CartItem
                    {
                        Id = Guid.NewGuid(),
                        CartId = cartId,
                        ItemId = itemId,
                        QuantityInTheCart = quantity
                    };
                    col.Insert(cart);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCartItem(Guid cartId, Guid itemId)
        {
            try
            {
                using (var db = new LiteDatabase(@"CartDB.db"))
                {
                    var cartItemsList = db.GetCollection<CartItem>("cartItems");
                    var idToDelete = cartItemsList.Query().Where(c => c.CartId == cartId && c.ItemId == itemId).FirstOrDefault().Id;
                    cartItemsList.Delete(idToDelete);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

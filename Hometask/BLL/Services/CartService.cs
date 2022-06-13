using Hometask.BLL.Dto;
using Hometask.DAL.Repositories;

namespace Hometask.BLL.Services
{
    internal class CartService
    {
        CartRepository сartRepository = new CartRepository();
        CartItemRepository сartItemRepository = new CartItemRepository();

        public CartDto CreateCart(Guid cartId)
        {
            сartRepository.CreateCart(cartId);
            var cart = new CartDto() { Id = cartId };
            return cart;
        }

        public bool AddItemToTheCart(CartDto cart, ItemDto item, int quantity)
        {
            try
            {
                cart.ItemsList.Add(item);
                сartItemRepository.CreateCartItem(cart.Id, item.Id, quantity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteItemFromTheCart(CartDto cart, ItemDto item)
        {
            try
            {
                cart.ItemsList.Remove(item);
                сartItemRepository.DeleteCartItem(cart.Id, item.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

using Hometask.BLL.Dto;

namespace Hometask.Common.Interfaces
{
    public interface ICartService
    {
        CartDto GetCartInfo(string cartId);
        IEnumerable<CartItemDto> GetCartItems(string cartId);
        bool AddCartItem(CartItemDto cartItemDto);
        bool UpdateCartItems(ItemDto cartItemDto);
        bool DeleteCartItem(string cartId, int cartItemId);
    }
}

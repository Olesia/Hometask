using Hometask.BLL.Dto;

namespace Hometask.Common.Interfaces
{
    public interface ICartItemSevice
    {
        IEnumerable<ItemDto> GetCartItemsList();
        Guid AddCartItem(CartItemDto cartItemDto);
        bool DeleteCartItem(Guid id);
    }
}

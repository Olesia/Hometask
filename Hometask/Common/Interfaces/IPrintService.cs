using Hometask.BLL.Dto;

namespace Hometask.Common.Interfaces
{
    public interface IPrintService
    {
        void PrintItem(CartItemDto item);
        void PrintItemsList(IEnumerable<CartItemDto> itemsList);
    };
}

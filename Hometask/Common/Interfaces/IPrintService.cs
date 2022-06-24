using Hometask.BLL.Dto;

namespace Hometask.Common.Interfaces
{
    public interface IPrintService
    {
        void PrintItem(ItemDto item);
        void PrintItemsList(IEnumerable<ItemDto> itemsList);
    };
}


using Hometask.BLL.Dto;

namespace Hometask.Common.Interfaces
{
    public interface IItemService
    {
        ItemDto GetItemById(Guid id);
        IEnumerable<ItemDto> GetAllItems();
    }
}

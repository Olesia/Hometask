using Hometask.BLL.Dto;
using Hometask.DAL.Repositories;

namespace Hometask.BLL.Services
{
    internal class ItemsService
    {
        ItemsRepository itemRepository = new ItemsRepository();
        public void CreateAllItems()
        {
            itemRepository.CreateAllItems();
        }

        public IEnumerable<ItemDto> GetAllItems()
        {
            var itemsList = itemRepository.GetAllItems().Select(t => new ItemDto
            {
                Id = t.Id,
                Name = t.Name,
                Price = t.Price,
                Quantity = t.Quantity,
                Image = t.Image,

            }).ToList().OrderBy(c => c.Name);

            return itemsList;
        }

    }
}

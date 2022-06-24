using AutoMapper;
using Hometask.BLL.Dto;
using Hometask.Common;
using Hometask.Common.Interfaces;
using Hometask.DAL.Entities;

namespace Hometask.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
       
        public ItemDto GetItemById(Guid id)
        {
            var item = _itemRepository.GetById(id, Constants.ItemsCollectionName);
            var itemDto = _mapper.Map<ItemDto>(item);
            return itemDto;
        }

        public IEnumerable<ItemDto> GetAllItems()
        {
            var itemsList = _itemRepository.List(Constants.ItemsCollectionName)
                .Select(t => _mapper.Map<ItemDto>(t)).ToList();

            return itemsList;
        }
    }
}

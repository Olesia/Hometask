using AutoMapper;
using Hometask.BLL.Dto;
using Hometask.Common;
using Hometask.Common.Interfaces;
using Hometask.DAL.Entities;

namespace Hometask.BLL.Services
{
    public class CartItemService : ICartItemSevice
    {
        private readonly IRepository<CartItem> _сartItemRepository;
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public CartItemService(IRepository<CartItem> сartItemRepository, IRepository<Item> itemRepository, IMapper mapper)
        {
            _сartItemRepository = сartItemRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public IEnumerable<ItemDto> GetCartItemsList()
        {
            try
            {
                var itemsIds =_сartItemRepository.List(Constants.CartItemsCollectionName).Select(c=>c.ItemId);
                var cartItems = _itemRepository.List(Constants.ItemsCollectionName).Where(c => itemsIds.Contains(c.Id));
                var result = _mapper.Map<IEnumerable<ItemDto>>(cartItems);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Guid AddCartItem(CartItemDto cartItemDto)
        {
            try
            {
                var cartItem = _mapper.Map<CartItem>(cartItemDto);

                return _сartItemRepository.Insert(cartItem, Constants.CartItemsCollectionName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCartItem(Guid cartItemId)
        {
            try
            {
                _сartItemRepository.Delete(cartItemId, Constants.CartItemsCollectionName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

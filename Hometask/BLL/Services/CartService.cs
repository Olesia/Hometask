using AutoMapper;
using Hometask.BLL.Dto;
using Hometask.Common;
using Hometask.Common.Interfaces;
using Hometask.DAL.Entities;
using System.Linq.Expressions;

namespace Hometask.BLL.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<CartItem> _сartItemRepository;
        private readonly IMapper _mapper;

        public CartService(IRepository<CartItem> сartItemRepository, IMapper mapper)
        {
            _сartItemRepository = сartItemRepository;
            _mapper = mapper;
        }

        public CartDto GetCartInfo(string id)
        {
            Expression<Func<CartItem, bool>>? cartIdFilter = e => e.CartId == id;
            
            var cartItems =_сartItemRepository.ListFiltered(Constants.CartItemsCollectionName, cartIdFilter);
            var mappedItems = _mapper.Map<IEnumerable<CartItemDto>>(cartItems);

            if (!cartItems.Any())
            {
                throw new KeyNotFoundException();
            }

            return new CartDto()
            {
                Id = id,
                CartItems = mappedItems
            };
        }

        public IEnumerable<CartItemDto> GetCartItems(string cartId)
        {
            Expression<Func<CartItem, bool>>? cartIdFilter = e => e.CartId == cartId;

            var cartItems = _сartItemRepository.ListFiltered(Constants.CartItemsCollectionName, cartIdFilter);
            var mappedItems = _mapper.Map<IEnumerable<CartItemDto>>(cartItems);

            if (!cartItems.Any())
            {
                throw new KeyNotFoundException();
            }

            return mappedItems;
        }

        public bool AddCartItem(CartItemDto cartItemDto)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemDto);
            return _сartItemRepository.Insert(cartItem, Constants.CartItemsCollectionName);
        }

        public bool UpdateCartItems(ItemDto itemDto)
        {
            Expression<Func<CartItem, bool>>? filter = e => e.ExternalId == itemDto.Id;
            var existedCartItems = _сartItemRepository.ListFiltered(Constants.CartItemsCollectionName, filter);

            if (!existedCartItems.Any())
            {
                throw new KeyNotFoundException($"No cart item with id: { itemDto.Id } found");
            }

            bool result = true;
            foreach (var item in existedCartItems)
            {
                item.Name = itemDto.Name;
                item.Image = itemDto.Image;
                item.Price = itemDto.Price;
                var isUpdated = _сartItemRepository.Update(item, Constants.CartItemsCollectionName);
                result = result && isUpdated;
            }

            return result;
        }

        public bool DeleteCartItem(string cartId, int itemId)
        {
            Expression<Func<CartItem, bool>> ? filter = e => e.CartId == cartId && e.ExternalId == itemId;
            var cartItemId = _сartItemRepository.ListFiltered(Constants.CartItemsCollectionName, filter).Select(c => c.Id).SingleOrDefault();
            if (cartItemId == default(Guid))
            {
                throw new KeyNotFoundException();
            }
            _сartItemRepository.Delete(cartItemId, Constants.CartItemsCollectionName);
            return true;
        }
    }
}

using AutoMapper;
using Hometask.BLL.Dto;
using Hometask.DAL.Entities;

namespace Hometask.BLL.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemDto, CartItem>();
        }
    }
}

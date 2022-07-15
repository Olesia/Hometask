using AutoMapper;
using Hometask.BLL.Dto;
using Hometask.DAL.Entities;

namespace Hometask.BLL.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemDto, CartItem>();
            CreateMap<ItemDto, CartItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CartId, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.Ignore());
            CreateMap<CartItem, ItemDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Amount, opt => opt.Ignore());
        }
    }
}

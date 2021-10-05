using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Commands;
using ApplicationDomainServices.Commands.AccountCommands;
using ApplicationDomainServices.Commands.ProductCommands;
using AutoMapper;

namespace ApplicationDomainServices.Mapper
{
    public class ObjMapper : Profile
    {
        public ObjMapper()
        {
            CreateMap<Account, AccountDto>()
                .ReverseMap();
            CreateMap<Account, CreateAccountCommand>()
                .ReverseMap();
            CreateMap<Address, AddressDto>()
                .ReverseMap();
            CreateMap<Contact, ContactDto>()
                .ReverseMap();
            CreateMap<ShippingAddress, ShippingAddressDto>()
                .ReverseMap();
            CreateMap<Item, AddItemCommand>()
                .ReverseMap();
            CreateMap<Item, ItemDto>()
                .ReverseMap();
            CreateMap<LikedItem, LikedItemDto>()
                .ReverseMap();
            CreateMap<MaterialType, AddMaterialTypesCommand>()
                .ReverseMap();
        }
    }
}

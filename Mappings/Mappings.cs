using AutoMapper;
using ShoppingList.Dtos;
using ShoppingList.Entities;

namespace ShoppingList.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<User, RegisterDto>()
                .ForMember(d => d.Id, o => o.MapFrom(a => a.Id))
                .ForMember(d=>d.Name , o=> o.MapFrom(a=> a.Name))
                .ForMember(d=>d.LastName,o=>o.MapFrom(a=>a.LastName))
                .ForMember(d => d.UserRoles, o => o.MapFrom(a => a.UserRoles))
                .ForMember(d => d.Email, o => o.MapFrom(a => a.Email))
                .ForMember(d => d.Phone, o => o.MapFrom(a => a.Phone))
                .ForMember(d => d.Gender, o => o.MapFrom(a => a.Gender))
                .ForMember(d => d.UserName, o => o.MapFrom(a => a.UserName))
                .ForMember(d => d.Password, o => o.MapFrom(a => a.Password)); ;
            
            CreateMap<Brand, BrandDto>()
                .ForMember(d => d.Id, o => o.MapFrom(a => a.Id))
                .ForMember(d => d.NameOfBrand, o => o.MapFrom(a => a.NameOfBrand));

            CreateMap<ListShop, ListShopDto>()
                .ForMember(d => d.Id, o => o.MapFrom(a => a.Id))
                .ForMember(d => d.Date, o => o.MapFrom(a => a.Date))
                .ForMember(d => d.Count, o => o.MapFrom(a => a.Count));
            CreateMap<Order,OrderDto>()
                .ForMember(d => d.Id, o => o.MapFrom(a => a.Id))
                .ForMember(d => d.Total, o => o.MapFrom(a => a.Total))
                .ForMember(d => d.Date, o => o.MapFrom(a => a.Date));

            CreateMap<Products,ProductsDto>()
                .ForMember(d => d.Id, o => o.MapFrom(a => a.Id))
                .ForMember(d => d.NameOfProducts, o => o.MapFrom(a => a.NameOfProducts))
                .ForMember(d => d.Price, o => o.MapFrom(a => a.Price))
                .ForMember(d => d.Image, o => o.MapFrom(a => a.Image));

            CreateMap<Supermarket,SupermarketDto>()
                .ForMember(d => d.Id, o => o.MapFrom(a => a.Id))
                .ForMember(d => d.NameOfSupermarket, o => o.MapFrom(a => a.NameOfSupermarket));
        }
    }
}

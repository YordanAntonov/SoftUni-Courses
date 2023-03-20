using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();

            this.CreateMap<ImportProductDto, Product>();

            this.CreateMap<ImportCategoryDto, Category>();

            this.CreateMap<ImportCategoriesProductsDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.Seller, opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<Product, ExportUserSoldProductsDto>()
                .ForMember(d => d.ItemName, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.BuyerFirstName, opt => opt.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName, opt => opt.MapFrom(s => s.Buyer!.LastName));

            this.CreateMap<User, ExportUsersDto>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.ProductsSold, opt => opt.MapFrom(s => s.ProductsSold));

            this.CreateMap<Category, ExportCategotyDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductCount, opt => opt.MapFrom(s => s.CategoriesProducts.Count))
                .ForMember(d => d.AveragePrice, opt => opt.MapFrom(s => s.CategoriesProducts.Average(p => p.Product.Price).ToString("f2")))
                .ForMember(d => d.TotalRevenue, opt => opt.MapFrom(s => s.CategoriesProducts.Sum(p => p.Product.Price).ToString("f2")));

                
                
        }
    }

}

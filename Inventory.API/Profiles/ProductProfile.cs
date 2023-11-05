using AutoMapper;
using Inventory.API.Contracts;
using Inventory.API.Data.Entities;

namespace Inventory.API.Profiles;


public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // CreateMap<Product, CreateProductRequest>();
        CreateMap<CreateProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();
    }
}
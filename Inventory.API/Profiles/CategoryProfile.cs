using AutoMapper;
using Inventory.API.Contracts;
using Inventory.API.Data.Entities;

namespace Inventory.API.Profiles;


public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryRequest, Category>();       
    }
}
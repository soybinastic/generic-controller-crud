using AutoMapper;
using Inventory.API.Common;
using Inventory.API.Contracts;
using Inventory.API.Data;
using Inventory.API.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Inventory.API.Controllers;


public class CategoryController : ModelBaseController<Category, CategoryRequest, CategoryRequest>
{
    public CategoryController(
        InventoryContext inventoryContext, 
        IMapper mapper) : base(inventoryContext, mapper) {}
}
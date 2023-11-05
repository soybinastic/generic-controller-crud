using AutoMapper;
using Inventory.API.Common;
using Inventory.API.Contracts;
using Inventory.API.Data;
using Inventory.API.Data.Entities;

namespace Inventory.API.Controllers;

public class ProductController : ModelBaseController<Product, CreateProductRequest, UpdateProductRequest>
{
    public ProductController(InventoryContext inventoryContext, IMapper mapper) 
        : base(inventoryContext, mapper) {}
}
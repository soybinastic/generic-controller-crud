using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Contracts;


public class CreateProductRequest
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public double Price { get; set; }
}
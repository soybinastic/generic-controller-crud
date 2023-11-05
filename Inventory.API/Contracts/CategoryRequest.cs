using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Contracts;

public class CategoryRequest
{
    [Required]
    public string Title { get; set; } = null!;
    // public int ProductId { get; set; }
}
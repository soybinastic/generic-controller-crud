
namespace Inventory.API.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
}
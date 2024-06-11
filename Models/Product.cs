using System.ComponentModel.DataAnnotations;
// Product Class with unique Identiy 
namespace invoice_master.Models;
public class Product
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(50), MinLength(4)]
    public string? Name { get; set; }

    [Required]
    public decimal Price { get; set; }

    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

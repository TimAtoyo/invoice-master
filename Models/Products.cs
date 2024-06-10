using System.ComponentModel.DataAnnotations;
// Product Class with unique Identiy 
public class Product
{
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public decimal Price { get; set; }
}

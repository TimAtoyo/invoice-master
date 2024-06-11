using invoice_master.Data;
using invoice_master.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var Products = await _context.Products.ToListAsync();
        return View(Products);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product addedProduct)
    {
        var product = new Product()
        {
            Name = addedProduct.Name,
            Price = addedProduct.Price,
            Description = addedProduct.Description,
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult View(Guid Id)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid Id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);

        if (product != null)
        {
            var updateProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
            };

            return View(product);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Update(Product product)
    {
        var updateProduct = await _context.Products.FindAsync(product.Id);

        if (updateProduct != null)
        {
            {
                updateProduct.Name = product.Name;
                updateProduct.Price = product.Price;
                updateProduct.Description = product.Description;
                await _context.SaveChangesAsync();
                return Redirect("Index");
            };

        }
                return RedirectToAction("Index");
    }

}

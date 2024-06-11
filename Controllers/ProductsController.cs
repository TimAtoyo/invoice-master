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

    // [HttpPost]
    //     public IActionResult Create()
    //     {
    //         return View();
    //     }

    // [HttpPost]
    // public IActionResult Create(Product product)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _context.Products.Add(product);
    //         _context.SaveChanges();
    //         return RedirectToAction(nameof(Index));
    //     }
    //     return View(product);
    // }
}

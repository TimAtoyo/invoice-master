using invoice_master.Data;
using invoice_master.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }
    // GET: Products/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    // POST: Products/Create
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        var newproduct = new Product(){
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,

        };
                await _context.Products.AddAsync(newproduct);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
    }



    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var Products = await _context.Products.ToListAsync();
        return View(Products);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
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


    // The method takes an id parameter and a Product object. 
    // The Product object is bound to the form data using the [Bind] attribute.
    
        [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> EditPost(Guid id, [Bind("Id,Name,Price,Description")] Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }
        // This ensures that the data posted from the form adheres to the validation rules defined in the Product model.
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch{

            }
        }
        return View(product);
    }


    // GET: Products/Delete/Guid
    [HttpGet]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .FirstOrDefaultAsync(m => m.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}

using invoice_master.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    // public IActionResult Index()
    // {
    //     var products = _context.Products.ToList();
    //     return View(products);
    // }

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

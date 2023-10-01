using System.Diagnostics;
using _1.AdsWeb.MVC.Models;
using _2.AdsWeb.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1.AdsWeb.MVC.Controllers;

public class ContactController : Controller
{
    private readonly ILogger<ContactController> _logger;
    private readonly ApplicationDbContext _dbContext;
    
    public ContactController(ILogger<ContactController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    public async Task<IActionResult> Index()
    {
        var lstProducts = await _dbContext.Products.ToListAsync();
        ViewBag.Products = lstProducts;
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
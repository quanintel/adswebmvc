using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _1.AdsWeb.MVC.Models;
using _2.AdsWeb.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace _1.AdsWeb.MVC.Controllers;

public class AboutController : Controller
{
    private readonly ILogger<AboutController> _logger;
    private readonly AdswebContext _dbContext;
    
    public AboutController(ILogger<AboutController> logger, AdswebContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    public async Task<IActionResult> Index()
    {
        var lstProducts = await _dbContext.Products.ToListAsync();
        for (int i = 0; i < 100; i++)
        {
            lstProducts.Add(lstProducts.First());
        }
        ViewBag.Products = lstProducts;
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
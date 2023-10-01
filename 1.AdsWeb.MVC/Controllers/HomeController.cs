using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _1.AdsWeb.MVC.Models;
using _2.AdsWeb.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace _1.AdsWeb.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;
    private readonly IWebHostEnvironment _appEnvironment;
    
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, IWebHostEnvironment appEnvironment)
    {
        _logger = logger;
        _dbContext = dbContext;
        _appEnvironment = appEnvironment;
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
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
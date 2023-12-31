﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _1.AdsWeb.MVC.Models;
using _2.AdsWeb.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace _1.AdsWeb.MVC.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;
    private readonly ApplicationDbContext _dbContext;
    
    public ProductsController(ILogger<ProductsController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    public async Task<IActionResult> Index(string url)
    {
        var lstProducts = await _dbContext.Products.ToListAsync();
        ViewBag.Products = lstProducts;
        var objProduct = lstProducts.FirstOrDefault(x => x.Url.Equals(url));
        return View(objProduct ?? new Product());
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
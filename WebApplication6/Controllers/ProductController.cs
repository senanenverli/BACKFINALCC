﻿using WebApplication6.Context;
using WebApplication6.Models;
using WebApplication6.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplication6.Controllers;

public class ProductController : Controller
{
    private readonly RioDbContext _context;

    public ProductController(RioDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> ProductDetail(int id)
    {
        var products = await _context.Products.Where(p => p.isStocked).Include(p => p.Category).Include(p => p.Brand).FirstOrDefaultAsync(p => p.Id == id);
		if (products == null)
        {
            return NotFound();
        }

        ProductDetailViewModel model = new()
        {
            Title = products.Title,
            Description = products.Description,
            Price = products.Price,
            Rating = products.Rating,
            SKU = products.SKU,
            CategoryName = products.Category.CategoryName,
            BrandName = products.Brand.BrandName,
            Features = products.Features,
            Material = products.Material,
            ClaimedSize = products.ClaimedSize,
            RecommendedUse = products.RecommendedUse,
            Manufacturer = products.Manufacturer,
            
        };
        await _context.SaveChangesAsync();
        return View(model);
    }
}

using WebApplication6.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MimeKit.Tnef;
using WebApplication6.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using WebApplication6.ViewModel;

namespace WebApplication6.Controllers;

public class ShopController : Controller
{
    private readonly RioDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    public ShopController(RioDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products.Where(p => p.isStocked).Where(p => !p.isDeleted).Include(p => p.Category).ToListAsync();          
        return View(products);
    }
    [Authorize]
    public async Task<IActionResult> AddProductToBasket(int productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId && !p.isDeleted);
        if(product == null)
        {
             return NotFound();
        }
        var user = await _userManager.FindByNameAsync(User.Identity.Name);

        var basketItem = await _context.BasketItems.FirstOrDefaultAsync(b => b.ProductId == productId && b.AppUserId == user.Id);
        if (basketItem == null)
        {

            BasketItem newasketItem = new BasketItem()
            {
                ProductId = productId,
                AppUserId = user.Id,
                Count = 1,
                CreatedDate = DateTime.UtcNow,
            };

             await _context.BasketItems.AddAsync(newasketItem);
        }
        else
        {
            basketItem.Count++;
        }
        await _context.SaveChangesAsync();


        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Search(SearchViewModel model)
    {
        if (model != null)
        {
            var searchTerm = model.SearchTerm.ToLower();
            var filteredProducts = await _context.Products.Where(p => p.Title.ToLower().Contains(searchTerm)).Where(p => !p.isDeleted).Include(p => p.Category).ToListAsync();
            return View(filteredProducts);
        }
        else
        {
            return View(null);
        }
    }

}

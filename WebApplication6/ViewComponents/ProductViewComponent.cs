using WebApplication6.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication6.ViewComponents;

public class ProductViewComponent : ViewComponent
{
    private readonly RioDbContext _context;

    public ProductViewComponent(RioDbContext context)
    {
        _context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var products = await _context.Products.Where(p => p.isStocked).Where(p => !p.isDeleted).Include(p => p.Category).ToListAsync();
        return View(products);
    }
}

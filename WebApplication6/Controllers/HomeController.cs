using WebApplication6.Context;
using WebApplication6.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private readonly RioDbContext _context;
            
        public HomeController(RioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Where(p => p.isStocked).Where(p => !p.isDeleted).Include(p => p.Category).ToListAsync();
            var categories = await _context.Categories.Where(p => !p.isDeleted).ToListAsync();
            HomePageViewModel model = new()
            {
                Products = products,
                Categories = categories

            };
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Context;

public class RioDbContext : IdentityDbContext<AppUser>
{
    public RioDbContext(DbContextOptions<RioDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } 
    public DbSet<ProductImage> ProductImages { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } 
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BasketItem> BasketItems{ get; set; } = null!;
	public DbSet<Setting> Settings { get; set; } = null!;
}

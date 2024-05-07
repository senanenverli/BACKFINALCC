using WebApplication6.Models;
using System.Drawing;

namespace WebApplication6.ViewModels
{
	public class ProductImageViewModel
	{
		public List<Product> Products { get; set; }
		public ICollection<ProductImage> ProductImages { get; set; }
		public string SearchItem { get; set; }
		public ICollection<BasketItem>? BasketItems { get; set; }
	}
}
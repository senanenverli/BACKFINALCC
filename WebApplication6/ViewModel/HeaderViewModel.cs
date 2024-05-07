using WebApplication6.Models;

namespace WebApplication6.ViewModel
{
	public class HeaderViewModel
	{
		public Dictionary<string, string> Settings { get; set; }
		public List<BasketItem> BasketItems { get; set; }	
	}
}

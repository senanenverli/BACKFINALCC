using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Areas.Admin.ViewModel
{
    public class CategoryViewModel
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}

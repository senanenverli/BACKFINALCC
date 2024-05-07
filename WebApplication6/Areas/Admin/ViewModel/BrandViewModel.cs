using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Areas.Admin.ViewModel
{
    public class BrandViewModel
    {
        [Required]
        public string BrandName { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Areas.Admin.ViewModel
{
    public class CategoryUpdateViewModel
    {
        [Required]
        public string CategoryName { get; set; }
        public IFormFile? Image { get; set; }
    }
}

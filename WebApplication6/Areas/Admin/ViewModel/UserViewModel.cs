using WebApplication6.Helpers.Enums;
using WebApplication6.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Areas.Admin.ViewModel
{
    public class UserViewModel
    {
        public AppUser User { get; set; }
        public IList<string> Roles { get; set; } = null!;
    }
}

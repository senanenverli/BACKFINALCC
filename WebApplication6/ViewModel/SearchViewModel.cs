using System.ComponentModel.DataAnnotations;

namespace WebApplication6.ViewModel;

public class SearchViewModel
{
    [Required]
    public string SearchTerm { get; set; }
}
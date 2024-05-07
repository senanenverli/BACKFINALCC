﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication6.ViewModel;

public class CommentViewModel
{
    [Required]
    public string Comments { get; set; }
    [Required]
    public string Name { get; set; }
    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
}

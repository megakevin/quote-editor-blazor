using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QuoteEditorBlazor.Models;

public class User : IdentityUser
{
    [Required]
    public int CompanyID { get; set; }

    public Company Company { get; set; }
}
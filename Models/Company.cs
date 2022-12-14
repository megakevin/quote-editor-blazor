using System.ComponentModel.DataAnnotations;

namespace QuoteEditorBlazor.Models;

public class Company
{
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }

    public ICollection<Quote> Quotes { get; set; }
    public ICollection<User> Users { get; set; }
}

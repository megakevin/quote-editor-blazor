using System.ComponentModel.DataAnnotations;

namespace QuoteEditorBlazor.Models;

public class Company
{
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
}

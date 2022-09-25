using System.ComponentModel.DataAnnotations;

namespace QuoteEditorBlazor.Models;

public class Quote
{
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
}
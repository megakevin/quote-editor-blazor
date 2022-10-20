using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace QuoteEditorBlazor.Models;

[Index(nameof(Date), nameof(QuoteID), IsUnique = true)]
[Index(nameof(Date), IsUnique = false)]
public class LineItemDate
{
    public int ID { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public int QuoteID { get; set; }

    public Quote Quote { get; set; }
    public ICollection<LineItem> LineItems { get; set; }
}

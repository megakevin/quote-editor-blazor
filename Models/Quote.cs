using System.ComponentModel.DataAnnotations;

namespace QuoteEditorBlazor.Models;

public class Quote
{
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int CompanyID { get; set; }

    public Company Company { get; set; }

    public ICollection<LineItemDate> LineItemDates { get; set; }

    public decimal TotalPrice
    {
        get
        {
            return LineItemDates.SelectMany(lid => lid.LineItems).Sum(li => li.TotalPrice);
        }
    }
}
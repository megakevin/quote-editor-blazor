using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace QuoteEditorBlazor.Models;

public class LineItem
{
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    [Required]
    [Precision(10, 2)]
    [Range(0, Double.MaxValue)]
    public decimal UnitPrice { get; set; }
    public int LineItemDateID { get; set; }

    public LineItemDate LineItemDate { get; set; }

    public decimal TotalPrice
    {
        get
        {
            return Quantity * UnitPrice;
        }
    }
}
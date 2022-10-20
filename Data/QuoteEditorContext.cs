using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuoteEditorBlazor.Models;

namespace QuoteEditorBlazor.Data;

public class QuoteEditorContext : IdentityUserContext<User>
{
    public QuoteEditorContext(DbContextOptions<QuoteEditorContext> options) : base(options)
    {
        
    }

    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<LineItemDate> LineItemDates { get; set; }
    public DbSet<LineItem> LineItems { get; set; }
}
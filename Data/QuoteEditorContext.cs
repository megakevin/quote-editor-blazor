
using Microsoft.EntityFrameworkCore;
using QuoteEditorBlazor.Models;

namespace QuoteEditorBlazor.Data;

class QuoteEditorContext : DbContext
{
    public QuoteEditorContext(DbContextOptions<QuoteEditorContext> options) : base(options)
    {
        
    }

    public DbSet<Quote> Quotes { get; set; }
}
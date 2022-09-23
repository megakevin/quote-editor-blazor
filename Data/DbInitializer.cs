using QuoteEditorBlazor.Models;

namespace QuoteEditorBlazor.Data;

public static class DbInitializer
{
    public static void Initialize(QuoteEditorContext context)
    {
        if (context.Quotes.Any()) return; // DB has been seeded

        var quotes = new Quote[]
        {
            new Quote { Name = "First quote" },
            new Quote { Name = "Second quote" },
            new Quote { Name = "Third quote" }
        };

        context.Quotes.AddRange(quotes);
        context.SaveChanges();
    }
}

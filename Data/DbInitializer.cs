using Microsoft.AspNetCore.Identity;
using QuoteEditorBlazor.Models;

namespace QuoteEditorBlazor.Data;

public static class DbInitializer
{
    public async static Task Initialize(QuoteEditorContext context, UserManager<User> userManager)
    {
        if (context.Quotes.Any()) return; // DB has been seeded

        var companies = new Company[] {
            new Company { Name = "KPMG" },
            new Company { Name = "PwC" }
        };

        context.Companies.AddRange(companies);

        var quotes = new Quote[]
        {
            new Quote { Name = "First quote", Company = companies[0] },
            new Quote { Name = "Second quote", Company = companies[0] },
            new Quote { Name = "Third quote", Company = companies[0] }
        };

        context.Quotes.AddRange(quotes);

        context.SaveChanges();

        await userManager.CreateAsync(
            new User() {
                UserName = "accountant@kpmg.com",
                Email = "accountant@kpmg.com",
                Company = companies[0]
            },
            "password"
        );

        await userManager.CreateAsync(
            new User() {
                UserName = "manager@kpmg.com",
                Email = "manager@kpmg.com",
                Company = companies[0]
            },
            "password"
        );

        await userManager.CreateAsync(
            new User() {
                UserName = "eavesdropper@pwc.com",
                Email = "eavesdropper@pwc.com",
                Company = companies[1]
            },
            "password"
        );
    }
}

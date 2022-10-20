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

        var lineItemDates = new LineItemDate[]
        {
            new LineItemDate { Quote = quotes[0], Date = DateOnly.FromDateTime(DateTime.Today) },
            new LineItemDate { Quote = quotes[0], Date = DateOnly.FromDateTime(DateTime.Today).AddDays(7) }
        };
        context.LineItemDates.AddRange(lineItemDates);

        var lineItems = new LineItem[]
        {
            new LineItem
            {
                LineItemDate = lineItemDates[0],
                Name = "Meeting room",
                Description = "A cosy meeting room for 10 people",
                Quantity = 1,
                UnitPrice = 1000
            },
            new LineItem
            {
                LineItemDate = lineItemDates[0],
                Name = "Meal tray",
                Description = "Our delicious meal tray",
                Quantity = 10,
                UnitPrice = 25
            },
            new LineItem
            {
                LineItemDate = lineItemDates[1],
                Name = "Meeting room",
                Description = "A cosy meeting room for 10 people",
                Quantity = 1,
                UnitPrice = 1000
            },
            new LineItem
            {
                LineItemDate = lineItemDates[1],
                Name = "Meal tray",
                Description = "Our delicious meal tray",
                Quantity = 10,
                UnitPrice = 25
            },
        };
        context.LineItems.AddRange(lineItems);

        context.SaveChanges();

        await userManager.CreateAsync(
            new User() {
                UserName = "accountant@kpmg.com",
                Email = "accountant@kpmg.com",
                CompanyID = companies[0].ID
            },
            "password"
        );

        await userManager.CreateAsync(
            new User() {
                UserName = "manager@kpmg.com",
                Email = "manager@kpmg.com",
                CompanyID = companies[0].ID
            },
            "password"
        );

        await userManager.CreateAsync(
            new User() {
                UserName = "eavesdropper@pwc.com",
                Email = "eavesdropper@pwc.com",
                CompanyID = companies[0].ID
            },
            "password"
        );
    }
}

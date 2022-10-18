using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Connections.Client;
using Microsoft.AspNetCore.SignalR.Client;

namespace QuoteEditorBlazor.Hubs;

public class QuotesHubConnectionBuilder
{
    IHttpContextAccessor httpContextAccessor;
    NavigationManager navigation;

    public QuotesHubConnectionBuilder(IHttpContextAccessor httpContextAccessor, NavigationManager navigation)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.navigation = navigation;
    }

    public HubConnection Build()
    {
        return new HubConnectionBuilder()
            .WithUrl(navigation.ToAbsoluteUri("/quoteshub"), AddCookies)
            .Build();
    }

    private void AddCookies(HttpConnectionOptions options)
    {
        foreach (var cookie in Request.Cookies)
        {
            options.Cookies.Add(new System.Net.Cookie(cookie.Key, cookie.Value, "/", Request.Host.Host));
        }
    }

    private HttpRequest Request
    {
        get => httpContextAccessor.HttpContext.Request;
    }
}
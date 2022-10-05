using Microsoft.AspNetCore.SignalR;

namespace BlazorServerSignalRApp.Server.Hubs
{
    public class QuotesHub : Hub
    {
        public async Task NotifyQuotesChanged()
        {
            await Clients.All.SendAsync("QuotesChanged");
        }
    }
}

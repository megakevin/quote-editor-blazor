using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using QuoteEditorBlazor.Areas.Identity.Claims;

namespace BlazorServerSignalRApp.Server.Hubs
{
    public class QuotesHub : Hub
    {
        [Authorize]
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GetCompanyQuotesGroupName());
            await base.OnConnectedAsync();
        }

        [Authorize]
        public async Task NotifyQuotesChanged()
        {
            await Clients.OthersInGroup(GetCompanyQuotesGroupName()).SendAsync("QuotesChanged");
        }

        private string GetCompanyQuotesGroupName()
        {
            var currentCompanyID = Context.User.GetCompanyID();
            return $"{currentCompanyID}_quotes";
        }
    }
}

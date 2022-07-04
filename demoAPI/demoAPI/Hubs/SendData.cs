using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace demoAPI.Hubs
{
    public class SendData : Hub
    {   
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("hello");
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
        
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
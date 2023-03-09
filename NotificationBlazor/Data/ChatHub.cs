using Microsoft.AspNetCore.SignalR;

namespace NotificationBlazor.Data
{
    public class ChatHub: Hub
    {
        public async Task Sendmessage(string sender, string reciever, string msgTitle, string msgBody)
        {
            await Clients.All.SendAsync("ReceiveMessage",sender,reciever,msgTitle,msgBody);
        }
    }
}

using Microsoft.AspNetCore.SignalR;

namespace BugalDaily.Views.SignalR
{
    public class ChatHub : Hub
    {
       
        public async Task SendComment(string username, string message)
        {
            var time = DateTime.Now.ToString("HH:mm:ss");
            await Clients.All.SendAsync("ReceiveComment", username, message, time);
        }
    }
}

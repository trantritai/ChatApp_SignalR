using System;
using Microsoft.AspNetCore.SignalR;
using static ChatApp.API.ChatHubs.ChatHub;

namespace ChatApp.API.ChatHubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public async Task BroadcastAsync(ChatMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            await Clients.All.MessageReceivedFromHub(message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.NewUserConnected("a new user connected");
        }

        public interface IChatHub
        {
            Task MessageReceivedFromHub(ChatMessage message);

            Task NewUserConnected(string message);
        }

        public class ChatMessage
        {
            public string Text { get; set; }
            public Guid ConnectionId { get; set; }
            public DateTime DateTime { get; set; }
        }
    }
}


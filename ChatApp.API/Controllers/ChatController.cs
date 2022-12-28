using ChatApp.API.ChatHubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using static ChatApp.API.ChatHubs.ChatHub;

namespace ChatApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IHubContext<ChatHub> hubContext;

    public ChatController(IHubContext<ChatHub> hubContext)
    {
        this.hubContext = hubContext;
    }

    [HttpPost(Name = "Send Message")]
    public async Task SendMessage(ChatMessage message)
    {
        await this.hubContext.Clients.All.SendAsync("messageReceivedFromApi", message);
    }
}


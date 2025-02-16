using Cel.SignalR.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Cel.SignalR.Infra.SignalR;

public class ChatHubContext : Hub<IChatHubContext>, IHubContext
{
    public static string HubName = "chatHub";
    private readonly IHubContext<ChatHubContext, IChatHubContext> _hubContext;

    public ChatHubContext(IHubContext<ChatHubContext, IChatHubContext> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessage(string channelName, string user, string message)
    {
        await _hubContext.Clients.Group(channelName).ReceiveChannelMessage(user, message);
    }

    public async Task JoinChannel(string channelName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, channelName);
    }

    public async Task LeaveChannel(string channelName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, channelName);
    }

    // TO test front
    public async Task SendMessageToChannel(string channelName, string user, string message)
    {
        await Clients.Group(channelName).ReceiveChannelMessage(user, message);
    }
}

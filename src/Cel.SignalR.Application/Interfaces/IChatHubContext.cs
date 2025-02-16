namespace Cel.SignalR.Application.Interfaces;

public interface IChatHubContext
{
    Task ReceiveChannelMessage(string user, string message);
}

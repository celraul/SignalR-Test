namespace Cel.SignalR.Application.Interfaces;

public interface IHubContext
{
    Task SendMessage(string channelName, string user, string message);
}

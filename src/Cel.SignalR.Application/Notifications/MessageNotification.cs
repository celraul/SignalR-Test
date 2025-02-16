using Cel.SignalR.Application.Common;
using Cel.SignalR.Application.Interfaces;
using Cel.SignalR.Domain.Entities;
using MediatR;
using System.Text.Json;

namespace Cel.SignalR.Application.Notifications;

public record MessageNotification(Message Message) : INotification;

public class MessageNotificationHandler : INotificationHandler<MessageNotification>
{
    private readonly IHubContext _hubContext;

    public MessageNotificationHandler(IHubContext hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task Handle(MessageNotification notification, CancellationToken cancellationToken)
    {
        string message = JsonSerializer.Serialize(notification.Message);

        await _hubContext.SendMessage(AppConsts.ChannelName, notification.Message.User.Name, message);
    }
}

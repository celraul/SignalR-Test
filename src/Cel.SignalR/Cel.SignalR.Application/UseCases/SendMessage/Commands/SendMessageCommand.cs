using Cel.SignalR.Application.Models.Message;
using MediatR;

namespace Cel.SignalR.Application.UseCases.SendMessage.Commands;

public record SendMessageCommand(MessageModel MessageModel) : IRequest<bool> { }

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
{
    public SendMessageCommandHandler()
    {

    }

    public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

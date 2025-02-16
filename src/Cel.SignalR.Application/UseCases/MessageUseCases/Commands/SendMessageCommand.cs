using AutoMapper;
using Cel.SignalR.Application.Interfaces;
using Cel.SignalR.Application.Models.Message;
using Cel.SignalR.Application.Notifications;
using Cel.SignalR.Domain.Entities;
using MediatR;

namespace Cel.SignalR.Application.UseCases.MessageUseCases.Commands;

public record SendMessageCommand(MessageModel MessageModel) : IRequest<bool> { }

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
{
    private readonly IRepository<Message> _repository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public SendMessageCommandHandler(IRepository<Message> repository, IMapper mapper, IMediator mediator)
    {
        _repository = repository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        Message message = _mapper.Map<Message>(request.MessageModel);
        await _repository.AddAsync(message);

        // Notify
        await _mediator.Publish(new MessageNotification(message));

        return true;
    }
}

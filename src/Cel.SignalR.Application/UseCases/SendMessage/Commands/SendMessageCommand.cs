using AutoMapper;
using Cel.SignalR.Application.Interfaces;
using Cel.SignalR.Application.Models.Message;
using Cel.SignalR.Domain.Entities;
using MediatR;

namespace Cel.SignalR.Application.UseCases.SendMessage.Commands;

public record SendMessageCommand(MessageModel MessageModel) : IRequest<bool> { }

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
{
    private readonly IRepository<Message> _repository;
    private readonly IMapper _mapper;

    public SendMessageCommandHandler(IRepository<Message> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        Message message = _mapper.Map<Message>(request.MessageModel);
        await _repository.AddAsync(message);
        // Notify

        return true;
    }
}

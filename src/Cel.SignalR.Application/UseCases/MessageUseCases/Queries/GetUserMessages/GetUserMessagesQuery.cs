using AutoMapper;
using Cel.SignalR.Application.Interfaces;
using Cel.SignalR.Application.Models.Message;
using Cel.SignalR.Domain.Entities;
using MediatR;

namespace Cel.SignalR.Application.UseCases.MessageUseCases.Queries.GetUserMessages;

public record GetUserMessagesQuery(string UserId) : IRequest<List<MessageModel>>;

public class GetUserMessagesQueryHandler : IRequestHandler<GetUserMessagesQuery, List<MessageModel>>
{
    private readonly IRepository<Message> _repository;
    private readonly IMapper _mapper;

    public GetUserMessagesQueryHandler(IRepository<Message> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<MessageModel>> Handle(GetUserMessagesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Message> userMessages = await _repository.FindAsync(x => x.Receivers.Any(r => r.Id.Equals(request.UserId)));

        return _mapper.Map<List<MessageModel>>(userMessages);
    }
}

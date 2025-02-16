using AutoMapper;
using Cel.SignalR.Application.Models.Message;
using Cel.SignalR.Application.Models.User;
using Cel.SignalR.Domain.Entities;

namespace Cel.SignalR.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MessageModel, Message>().ReverseMap();
        CreateMap<UserModel, User>().ReverseMap();
    }
}

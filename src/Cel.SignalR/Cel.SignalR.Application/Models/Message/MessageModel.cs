using Cel.SignalR.Application.Models.Users;

namespace Cel.SignalR.Application.Models.Message;

public class MessageModel
{
    public UserModel User { get; set; } = new();
    public UserModel Receiver { get; set; } = new();
    public DateTime Date { get; set; } = DateTime.Now;
    public string Body { get; set; } = string.Empty;
}

using Cel.SignalR.Application.Models.User;

namespace Cel.SignalR.Application.Models.Message;

public class MessageModel
{
    public UserModel User { get; set; } = new();
    public List<UserModel> Receivers { get; set; } = [];
    public DateTime Date { get; set; } = DateTime.Now;
    public string Body { get; set; } = string.Empty;
}

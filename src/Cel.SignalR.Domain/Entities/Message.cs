namespace Cel.SignalR.Domain.Entities;

public class Message : BaseEntity
{
    public User User { get; set; } = new();
    public List<User> Receivers { get; set; } = [];
    public DateTime Date { get; set; } = DateTime.Now;
    public string Body { get; set; } = string.Empty;
}

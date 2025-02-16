using System.ComponentModel.DataAnnotations;

namespace Cel.SignalR.Domain.Entities;

public class BaseEntity
{
    [Key]
    public string Id { get; set; } = Ulid.NewUlid().ToString();
}

using Cel.SignalR.Application.Interfaces;
using Cel.SignalR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cel.SignalR.Infra.EntityCore;

public class MemoryDbContext : DbContext, IMemoryDbContext
{
    public MemoryDbContext(DbContextOptions<MemoryDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
}

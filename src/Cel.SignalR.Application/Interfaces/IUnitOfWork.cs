﻿using Cel.SignalR.Domain.Entities;

namespace Cel.SignalR.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : BaseEntity;
    Task<int> SaveChangesAsync();
}
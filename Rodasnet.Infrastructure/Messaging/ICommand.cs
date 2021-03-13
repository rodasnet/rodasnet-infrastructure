using System;

namespace Rodasnet.Infrastructure.Messaging
{   
    public interface ICommand
    {
        Guid Id { get; }
    }
}
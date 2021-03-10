namespace Rodasnet.Infrastructure.Messaging
{
    using System;

    public interface ICommand
    {
        Guid Id { get; }
    }
}
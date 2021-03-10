namespace Rodasnet.Infrastructure.Messaging
{
    using System;

    public interface IEvent
    {
        Guid SourceId { get; }
    }
}

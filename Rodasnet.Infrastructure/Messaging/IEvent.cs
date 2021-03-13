using System;

namespace Rodasnet.Infrastructure.Messaging
{
    public interface IEvent
    {
        Guid SourceId { get; }
    }
}

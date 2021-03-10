using Rodasnet.Infrastructure.Messaging;
using System;

namespace Rodasnet.Infrastructure.UnitTests
{
    public class ImplEvent : IEvent
    {
        public Guid SourceId { get; }
        public Guid PropEvent_1 { get; }
    }

    public class ImplEvent_2 : IEvent
    {
        public Guid SourceId { get; }
        public Guid PropEvent_2 { get; }
    }
}

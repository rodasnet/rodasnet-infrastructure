using Rodasnet.Infrastructure.Messaging;
using System;

namespace ConsoleAppUserTest
{
    public class ImplEvent : IEvent
    {
        public Guid SourceId { get; set; }
        public Guid PropEvent_1 { get; set; }
    }

    public class ImplEvent_2 : IEvent
    {
        public Guid SourceId { get; }
        public Guid PropEvent_2 { get; }
    }
}

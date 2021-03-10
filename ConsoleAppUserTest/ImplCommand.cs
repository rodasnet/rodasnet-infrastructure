using Rodasnet.Infrastructure.Messaging;
using System;

namespace ConsoleAppUserTest
{
    public class ImplCommand : ICommand
    {
        public Guid Id { get; set; }

        public Guid Prop2 { get; set; }

        public Guid Prop3 { get; set; }
        
        public Guid Prop4 { get; set; }
        
        public Guid Prop5 { get; set; }
    }
}

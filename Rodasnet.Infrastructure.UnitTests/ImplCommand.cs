using Rodasnet.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodasnet.Infrastructure.UnitTests
{
    public class ImplCommand : ICommand
    {
        public Guid Id { get; set; }

        public Guid GuidProp { get; set; }
        
        public String StringProp { get; set; }
        
        public List<int> IntListProp { get; set; }
        
        public int IntProp { get; set; }
        
        public object ObjProp { get; set; }
        
        public float FloatProp { get; set; }
    }
}

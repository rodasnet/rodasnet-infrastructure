using System;
using System.Collections.Generic;
using System.Text;

namespace Rodasnet.Infrastructure.Messaging
{
    public class SessionConfiguration
    {
        public string Policy { get; set; }
        public string Key { get; set; }
        public string NamespaceUrl { get; set; }
        public string Topic { get; set; }
        public string Link { get; set; }
    }
}

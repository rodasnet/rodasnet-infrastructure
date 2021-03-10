using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Rodasnet.Infrastructure.Messaging;

namespace Rodasnet.Infrastructure.Processes
{
    public interface IAzureBusProcessor
    {
        // Original implementation uses using Microsoft.Azure.ServiceBus;
        Task ProcessMessagesAsync(Message message, CancellationToken cancellationToken);
        // Original implementation uses using Microsoft.Azure.ServiceBus;
        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs e);
        
    }
}

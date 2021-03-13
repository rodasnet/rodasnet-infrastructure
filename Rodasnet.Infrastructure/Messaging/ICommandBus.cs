using System.Collections.Generic;

namespace Rodasnet.Infrastructure.Messaging
{
    public interface ICommandBus
    {
        void Send(Envelope<ICommand> command);

        void Send(IEnumerable<Envelope<ICommand>> command);
    }
}
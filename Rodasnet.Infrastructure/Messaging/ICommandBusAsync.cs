using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.Messaging
{
    public interface ICommandBusAsync
    {
        Task SendAsync(Envelope<ICommand> command);

        Task SendAsync(IEnumerable<Envelope<ICommand>> command);
    }
}
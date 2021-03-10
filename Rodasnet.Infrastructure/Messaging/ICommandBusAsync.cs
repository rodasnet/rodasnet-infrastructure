namespace Rodasnet.Infrastructure.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommandBusAsync
    {
        Task SendAsync(Envelope<ICommand> command);

        Task SendAsync(IEnumerable<Envelope<ICommand>> command);
    }
}
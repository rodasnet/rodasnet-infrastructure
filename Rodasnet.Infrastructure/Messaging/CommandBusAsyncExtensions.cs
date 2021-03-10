namespace Rodasnet.Infrastructure.Messaging
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides usability overloads for <see cref="ICommandBusAsync"/>
    /// </summary>
    public static class CommandBusAsyncExtensions
    {
        public static async Task SendAsync(this ICommandBusAsync bus, ICommand command)
        {
            await bus.SendAsync(new Envelope<ICommand>(command));
        }

        public static async Task SendAsync(this ICommandBusAsync bus, IEnumerable<ICommand> commands)
        {
            await bus.SendAsync(commands.Select(x => new Envelope<ICommand>(x)));
        }
    }
}

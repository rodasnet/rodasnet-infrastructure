namespace Rodasnet.Infrastructure.Messaging
{
    using System.Threading.Tasks;
    using System;

    public interface IMessageSenderAsync
    {
        /// <summary>
        /// Sends the specified message asynchronously.
        /// </summary>
        Task SendAsync(Message message);

        /// <summary>
        /// Sends the specified message asynchronously.
        /// </summary>
        Task SendAsync(Message message, Action successCallback, Action<Exception> exceptionCallback);

        /// <summary>
        /// Notifies that the sender is retrying due to a transient fault.
        /// </summary>
        event EventHandler Retrying;
    }
}

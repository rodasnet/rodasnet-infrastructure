namespace Rodasnet.Infrastructure.Messaging
{
    using System;

    interface IMessageSender
    {
        /// <summary>
        /// Sends the specified message synchronously.
        /// </summary>
        void Send(Func<BrokeredMessage> messageFactory);

        /// <summary>
        /// Notifies that the sender is retrying due to a transient fault.
        /// </summary>
        event EventHandler Retrying;
    }

    public class BrokeredMessage
    {
    }
}

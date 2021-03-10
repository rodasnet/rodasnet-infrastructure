namespace Rodasnet.Infrastructure.Messaging
{
    using System;

    public abstract class Envelope
    {
        /// <summary>
        /// Creates an envelope for the given body.
        /// </summary>
 
        public static Envelope<T> Create<T>(T body)
        {
            return new Envelope<T>(body);
        }
    }


    /// <summary>
    /// Provides the envelope for an object that will be sent to a bus.
    /// </summary>
    public class Envelope<T> : Envelope
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{T}"/> class.
        /// </summary>
        public Envelope(T body)
        {
            this.Body = body;
        }

        public T Body { get; private set; }

        public TimeSpan TimeToLive { get; set; }

        public string CorrelationId { get; set; }

        public string MessageId { get; set; }

        public static implicit operator Envelope<T>(T body)
        {
            return Envelope.Create(body);
        }
    }
}

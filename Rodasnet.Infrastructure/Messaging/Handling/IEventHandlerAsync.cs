// ==============================================================================================================
// Microsoft patterns & practices
// CQRS Journey project
// ==============================================================================================================
// ©2012 Microsoft. All rights reserved. Certain content used with permission from contributors
// http://go.microsoft.com/fwlink/p/?LinkID=258575
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance 
// with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software distributed under the License is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and limitations under the License.
// ==============================================================================================================

namespace Rodasnet.Infrastructure.Messaging.Handling
{
    using System.Threading.Tasks;

    /// <summary>
    /// Marker interface that makes it easier to discover handlers via reflection.
    /// </summary>
    ///  
    public interface IEventHandlerAsync 
    {
    }

    public interface IEventHandlerAsync<T> : IEventHandlerAsync where T : IEvent
    {
        Task HandleAsync(T @event);
    }

    public interface IEnvelopedEventHandlerAsync<T> : IEventHandlerAsync
        where T : IEvent
    {
        Task HandleAsync(Envelope<T> envelope);
    }

    // Experiment with ABSTRACT CLASS
    // Abstract class in unnecessary and work with placeholder interface
    // as long as placeholder interface is cast to generic interface before using
    //public abstract class AbstractProcessManagerRouter : IEventHandlerAsync
    //{
        
    //    public AbstractProcessManagerRouter()
    //    {
    //    }

        //public abstract Task HandleAsync(T @event);

        //// TODO: Fix problem where I have to implement two HandleAsync(IEvent thingz)
        //public Task HandleAsync(IEvent deserializedMessage)
        //{
        //    throw new NotImplementedException();
        //}
    //} 
}

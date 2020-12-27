using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkModules;
using TextTransliteration;

namespace ClientHandlers
{
    /// <summary>
    /// Type for handling the event of receiving a message from the server
    /// </summary>

    public class LambdaClientHandler
    {
        /// <summary>
        /// Creates an instance of the AnonimousClientHandler class
        /// </summary>

        public LambdaClientHandler()
        {
            Messages = new List<string>();
        }

        /// <summary>
        /// List of messages from server
        /// </summary>

        public List<string> Messages { get; private set; }

        /// <summary>
        /// Subscribes a type to an event
        /// </summary>
        /// <param name="client">Given client</param>

        public void SubscribeToEvent(Client client)
        {
            ReceiveHandler handler = (message) => Messages.Add(TextRecoder.RecodeText(message));
            client.ReceiveMessageFromServer += handler;
        }
    }
}

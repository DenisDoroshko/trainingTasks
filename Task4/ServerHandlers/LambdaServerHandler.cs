using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkModules;

namespace ServerHandlers
{
    /// <summary>
    /// Type for handling the event of receiving a message from the client
    /// </summary>

    public class LambdaServerHandler
    {
        /// <summary>
        /// Creates an instance of the LambdaServerHandler class
        /// </summary>

        public LambdaServerHandler()
        {
            Clients = new List<ClientInfo>();
        }

        /// <summary>
        /// List of clients
        /// </summary>

        public List<ClientInfo> Clients { get; set; }

        /// <summary>
        /// Subscribes a type to an event
        /// </summary>
        /// <param name="server">Given  server</param>

        public void SubscribeToEvent(Server server)
        {
            ReceiveHandler handler = (message) => GetClient(message).Messages.Add(message.Split(':')[1].Trim());
            server.ReceiveMessageFromClient += handler;
        }

        /// <summary>
        /// Gets a client by name and id or creates a new client
        /// </summary>
        /// <param name="message">Given message</param>
        /// <returns>Found or created client</returns>
        
        private ClientInfo GetClient(string message)
        {
            var identification = message.Split(':')[0].Trim();
            var client = Clients.Find(item => item.Identification == identification);
            if (client == null)
            {
                client = new ClientInfo(identification);
                Clients.Add(client);
            }
            return client;
        }
    }
}

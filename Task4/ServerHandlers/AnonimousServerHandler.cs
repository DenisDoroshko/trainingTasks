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
    
    public class AnonimousServerHandler
    {
        /// <summary>
        /// Creates an instance of the AnonimousServerHandler class
        /// </summary>
        
        public AnonimousServerHandler()
        {
            Clients = new List<ClientInfo>();
        }

        /// <summary>
        /// List of clients
        /// </summary>
        
        public List<ClientInfo> Clients {get;set;}
        
        /// <summary>
        /// Subscribes a type to an event
        /// </summary>
        /// <param name="server">Given  server</param>
        
        public void SubscribeToEvent(Server server)
        {
            ReceiveHandler handler = delegate (string message)
            {
                var identification = message.Split(':')[0].Trim();
                var content = message.Split(':')[1].Trim();
                var client = Clients.Find(item => item.Identification == identification);
                if (client != null) 
                {
                    client.Messages.Add(content);
                }
                else
                {
                    client = new ClientInfo(identification);
                    client.Messages.Add(content);
                    Clients.Add(client);
                }
            };
            server.ReceiveMessageFromClient += handler;
        }
    }
}

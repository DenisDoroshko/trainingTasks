using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkModules;

namespace ServerHandlers
{
    public class ServerHandler
    {
        public List<ClientInfo> Clients {get;set;}
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

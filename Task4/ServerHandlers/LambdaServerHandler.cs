using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkModules;

namespace ServerHandlers
{
    public class LambdaServerHandler
    {
        public List<ClientInfo> Clients { get; set; }
        public void SubscribeToEvent(Server server)
        {
            ReceiveHandler handler = (message) => GetClient(message).Messages.Add(CutContent(message));
            server.ReceiveMessageFromClient += handler;
        }
        private string CutIdentification(string data)
        {
            string identification = data.Split(':')[0].Trim();
            return identification;
        }
        private string CutContent(string data)
        {
            string content = data.Split(':')[1].Trim();
            return content;
        }
        private ClientInfo FindClient(string identification)
        {
            return Clients.Find(item => item.Identification == identification);
        }
        private ClientInfo GetClient(string message)
        {
            var identification = CutIdentification(message);
            var client = FindClient(identification);
            if (client == null)
                client = new ClientInfo(identification);
            return client;
        }
    }
}

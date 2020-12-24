using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkModules;
using TextTransliteration;

namespace ClientHandlers
{
    public class LambdaClientHandler
    {
        public LambdaClientHandler()
        {
            Messages = new List<string>();
        }
        public List<string> Messages { get; private set; }
        public void SubscribeToEvent(Client client)
        {
            ReceiveHandler handler = (message) => Messages.Add(TextRecoder.RecodeText(message));
            client.ReceiveMessageFromServer += handler;
        }
    }
}

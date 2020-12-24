using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTransliteration;
using NetworkModules;

namespace ClientHandlers
{
    class AnonimousClientHandler
    {
        public AnonimousClientHandler()
        {
            Messages = new List<string>();
        }
        public List<string> Messages { get; private set; }
        public void SubscribeToEvent(Client client)
        {
            ReceiveHandler handler = delegate (string message)
            {
                var recodedText= TextRecoder.RecodeText(message);
                Messages.Add(recodedText);
                Console.WriteLine(recodedText);
            };
            client.ReceiveMessageFromServer += handler;
        }
    }
}

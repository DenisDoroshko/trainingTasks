using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using NetworkModules;

namespace NetworkModules
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerHandler handler = new ServerHandler();
            Server server = new Server("127.0.0.1", 8005);
            handler.SubscribeToEvent(server);
            server.StartWork("Сообщение доставлено");
            Console.WriteLine(handler.Clients[0].Identification);
            Console.Read();
        }
    }
}

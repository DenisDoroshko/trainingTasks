using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkModules;
using ClientHandlers;
using ServerHandlers;
using System.Threading;

namespace Check
{
    class Program
    {
        static void Main(string[] args)
        {
            LambdaServerHandler handler = new LambdaServerHandler();
            AnonimousServerHandler handler2 = new AnonimousServerHandler();
            LambdaClientHandler handler3 = new LambdaClientHandler();
            AnonimousClientHandler handler4 = new AnonimousClientHandler();
            Server server = new Server("127.168.0.1", 8004);
            handler.SubscribeToEvent(server);
            handler2.SubscribeToEvent(server);
            Thread serverThread = new Thread(()=>server.StartWork("Текст записан на транслите. English text"));
            serverThread.Start();
            Client client1 = new Client("Иван");
            handler3.SubscribeToEvent(client1);
            Client client2 = new Client("Иван");
            handler4.SubscribeToEvent(client2);
            client1.SendMessage("Привет", "127.168.0.1", 8004);
            client1.SendMessage("Ухожу", "127.168.0.1", 8004);
            client2.SendMessage("Тоже Привет", "127.168.0.1", 8004);
            foreach(var item in handler.Clients)
            {
                foreach(var mes in item.Messages)
                {
                    Console.WriteLine(mes);
                }
            }
            foreach (var item in handler2.Clients)
            {
                foreach (var mes in item.Messages)
                {
                    Console.WriteLine("2)"+mes);
                }
            }
            foreach (var mes in handler3.Messages)
            {
                Console.WriteLine("" + mes);
            }
            foreach (var mes in handler4.Messages)
            {
                Console.WriteLine("2)" + mes);
            }
            Console.Read();
        }
    }
}

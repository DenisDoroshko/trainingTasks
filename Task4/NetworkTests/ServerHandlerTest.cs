using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkModules;
using ServerHandlers;
using System.Threading;

namespace NetworkTests
{
    [TestClass]
    public class ServerHandlerTest
    {
        [DataTestMethod]
        [DataRow("127.0.0.1",8004,"Привет","Другой привет")]
        [DataRow("127.0.0.2", 8005, "Good morning", "Good night")]
        [DataRow("127.0.0.3", 10005, "Bye", "Goodbye")]
        public void AnonimousClientHandlerTest(string address,int port,string firstMessage, string secondMessage)
        {
            //Arange
            bool expected = true;
            Server server = new Server(address, port);
            Thread serverThread = new Thread(() => server.StartWork("Ваше сообщение получено"));
            serverThread.Start();
            var serverHandler = new AnonimousServerHandler();
            serverHandler.SubscribeToEvent(server);
            var firstClient = new Client("Иван");
            var secondClient = new Client("Алексей");
            bool result = true;
            //Act
            firstClient.SendMessage(firstMessage,address, port);
            secondClient.SendMessage(secondMessage, address, port);
            if (serverHandler.Clients.Count == 2)
            {
                foreach (var mes in serverHandler.Clients[0].Messages)
                {
                    if (mes != firstMessage)
                        result = false;
                }
                foreach (var mes in serverHandler.Clients[1].Messages)
                {
                    if (mes != secondMessage)
                        result = false;
                }
            }
            else
            {
                result = false;
            }
            //Assert
            Assert.AreEqual(expected,result);
        }
        [DataTestMethod]
        [DataRow("127.0.1.5", 6005, "Привет сервер", "Привет")]
        [DataRow("127.0.1.15", 4600, "Good morning", "Good night")]
        [DataRow("127.0.1.38", 11111, "Hello", "Hi")]
        public void LambdaClientHandlerTest(string address, int port, string firstMessage, string secondMessage)
        {
            //Arange
            bool expected = true;
            Server server = new Server(address, port);
            Thread serverThread = new Thread(() => server.StartWork("Ваше сообщение получено"));
            serverThread.Start();
            var serverHandler = new LambdaServerHandler();
            serverHandler.SubscribeToEvent(server);
            var firstClient = new Client("Petr");
            var secondClient = new Client("Ivan");
            bool result = true;
            //Act
            firstClient.SendMessage(firstMessage, address, port);
            secondClient.SendMessage(secondMessage, address, port);
            if (serverHandler.Clients.Count == 2)
            {
                foreach (var mes in serverHandler.Clients[0].Messages)
                {
                    if (mes != firstMessage)
                        result = false;
                }
                foreach (var mes in serverHandler.Clients[1].Messages)
                {
                    if (mes != secondMessage)
                        result = false;
                }
            }
            else
            {
                result = false;
            }
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

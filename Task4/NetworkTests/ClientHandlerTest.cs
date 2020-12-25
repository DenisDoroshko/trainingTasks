using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkModules;
using ServerHandlers;
using ClientHandlers;
using System.Threading;

namespace NetworkTests
{
    [TestClass]
    public class ClientHandlerTest
    {
        [DataTestMethod]
        [DataRow("127.0.1.1", 8004,"Ваше сообщение получено" ,"Vashe soobschenie polucheno",10)]
        [DataRow("127.0.2.2", 8005, "Соединение установлено", "Soedinenie ustanovleno",15)]
        [DataRow("127.0.3.3", 8006, "Успешно доставлено!","Uspeshno dostavleno!",11)]
        public void AnonimousClientHandlerTest(string address, int port,string messageFromServer,string expectedMessage,int expectedNumber)
        {
            //Arange
            bool expected = true;
            Server server = new Server(address, port);
            Thread serverThread = new Thread(() => server.StartWork(messageFromServer));
            serverThread.Start();
            var clientHandler = new AnonimousClientHandler();
            var firstClient = new Client("Денис");
            clientHandler.SubscribeToEvent(firstClient);
            var secondClient = new Client("Дмитрий");
            clientHandler.SubscribeToEvent(secondClient);
            bool result = true;
            //Act
            for (var i = 0; i < expectedNumber; i++)
            {
                firstClient.SendMessage("Hello", address, port);
                secondClient.SendMessage("Hello", address, port);
            }
            if (clientHandler.Messages.Count != expectedNumber*2)
            {
                result = false;
            }
            foreach(var message in clientHandler.Messages)
            {
                if(message != expectedMessage)
                {
                    result = false;
                }
            }
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("127.0.1.1", 8004, "Соединение установлено", "Soedinenie ustanovleno", 25)]
        [DataRow("127.0.2.2", 8005, "Сообщение получено.", "Soobschenie polucheno.", 21)]
        [DataRow("127.0.3.3", 8006, "Успешно доставлено!", "Uspeshno dostavleno!", 2)]
        public void LambdaClientHandlerTest(string address, int port, string messageFromServer, string expectedMessage, int expectedNumber)
        {
            //Arange
            bool expected = true;
            Server server = new Server(address, port);
            Thread serverThread = new Thread(() => server.StartWork(messageFromServer));
            serverThread.Start();
            var clientHandler = new LambdaClientHandler();
            var firstClient = new Client("Roman");
            clientHandler.SubscribeToEvent(firstClient);
            var secondClient = new Client("Artem");
            clientHandler.SubscribeToEvent(secondClient);
            bool result = true;
            //Act
            for (var i = 0; i < expectedNumber; i++)
            {
                firstClient.SendMessage("Hi", address, port);
                secondClient.SendMessage("Hi", address, port);
            }
            if (clientHandler.Messages.Count != expectedNumber * 2)
            {
                result = false;
            }
            foreach (var message in clientHandler.Messages)
            {
                if (message != expectedMessage)
                {
                    result = false;
                }
            }
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace NetworkModules
{
    public class Client:NetworkModule
    {
        public event ReceiveHandler ReceiveMessageFromServer;
        public string Name { get; private set; }
        public string ID { get; private set; }
        public Client(string name)
        {
            Name = name;
            ID = Guid.NewGuid().ToString();
        }
        
        public void SendMessage(string message,string address,int port)
        {
            ConnectToServer(address, port);
            byte[] data = Encoding.Unicode.GetBytes($"{Name} {ID}: {message}");
            if (CurrentSocket != null) 
            {
                CurrentSocket.Send(data);
                GetMessage();
            }
        }
        private void ConnectToServer(string address, int port)
        {
            IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse(address), port);
            CurrentSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            CurrentSocket.Connect(serverPoint);
        }
        public void GetMessage()
        {
            byte[]  data = new byte[256];
            StringBuilder message = new StringBuilder();
            do
            {
                int bytesNumber = CurrentSocket.Receive(data, data.Length, 0);
                message.Append(Encoding.Unicode.GetString(data, 0, bytesNumber));
            }
            while (CurrentSocket.Available > 0);
            if (message.Length != 0)
            {
                ReceiveMessageFromServer?.Invoke($"{message}");
            }
        }
    }
}

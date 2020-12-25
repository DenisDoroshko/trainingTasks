using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace NetworkModules
{
    /// <summary>
    /// Class representing a client of the network
    /// </summary>
    
    public class Client:NetworkModule
    {
        /// <summary>
        /// Event of receiving a message from the server
        /// </summary>
        
        public event ReceiveHandler ReceiveMessageFromServer;

        /// <summary>
        /// Name of a client
        /// </summary>
        
        public string Name { get; private set; }

        /// <summary>
        /// ID of a client
        /// </summary>
        
        public string ID { get; private set; }

        /// <summary>
        /// Creates an instance of the Client class
        /// </summary>
        /// <param name="name">Name of the client</param>
        
        public Client(string name)
        {
            Name = name;
            ID = Guid.NewGuid().ToString();
        }
        
        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="message">Given message</param>
        /// <param name="address">Address</param>
        /// <param name="port">Port</param>
        
        public void SendMessage(string message,string address,int port)
        {
            try
            {
                ConnectToServer(address, port);
                byte[] data = Encoding.Unicode.GetBytes($"{Name} {ID}: {message}");
                if (CurrentSocket != null)
                {
                    CurrentSocket.Send(data);
                    GetMessage();
                }
            }
            catch
            {
                CurrentSocket.Close();
            }
        }

        /// <summary>
        /// Connects to the server
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="port">Port</param>
        
        private void ConnectToServer(string address, int port)
        {
            IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse(address), port);
            CurrentSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            CurrentSocket.Connect(serverPoint);
        }

        /// <summary>
        /// Gets message from the server
        /// </summary>
        
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

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace NetworkModules
{
    public class Server:NetworkModule
    {
        public event ReceiveHandler ReceiveMessageFromClient;
        public string Address { get; private set; }
        public int Port { get; private set; }
        public Server(string address,int port)
        {
            Address = address;
            Port = port;
        }
        public void StartWork(string answerForClients)
        {
            IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse(Address), Port);
            CurrentSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            CurrentSocket.Bind(serverPoint);
            CurrentSocket.Listen(10);
            while (true)
            {
                Socket handler = CurrentSocket.Accept();
                StringBuilder message = new StringBuilder();
                byte[] data = new byte[256];
                do
                {
                    int bytes = handler.Receive(data);
                    message.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (handler.Available > 0);

                Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + message.ToString());
                if (message.Length != 0)
                {
                    ReceiveMessageFromClient?.Invoke($"{ message}");
                    SendAnswer(handler, answerForClients);
                }
            }
        }
        private void SendAnswer(Socket socket,string answer)
        {
            byte[] data = Encoding.Unicode.GetBytes(answer);
            socket.Send(data);
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}

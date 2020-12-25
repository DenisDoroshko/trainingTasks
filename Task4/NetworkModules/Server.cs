using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace NetworkModules
{
    /// <summary>
    /// Class representing a server of the network
    /// </summary>

    public class Server:NetworkModule
    {
        /// <summary>
        /// Event of receiving a message from the client
        /// </summary>

        public event ReceiveHandler ReceiveMessageFromClient;

        /// <summary>
        /// Server adress
        /// </summary>
        
        public string Address { get; private set; }

        /// <summary>
        /// Using port
        /// </summary>
        
        public int Port { get; private set; }

        /// <summary>
        /// Creates an instance of the Server class
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="port">Port</param>
        
        public Server(string address,int port)
        {
            Address = address;
            Port = port;
        }

        /// <summary>
        /// Runs the server
        /// </summary>
        /// <param name="answerForClients">Answer for clients</param>
        
        public void StartWork(string answerForClients)
        {
            try
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
                    if (message.Length != 0)
                    {
                        ReceiveMessageFromClient?.Invoke($"{ message}");
                        SendAnswer(handler, answerForClients);
                    }
                }
            }
            catch
            {

                CurrentSocket.Close();
            }
        }

        /// <summary>
        /// Sends answer to the client
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="answer"></param>
        
        private void SendAnswer(Socket socket,string answer)
        {
            byte[] data = Encoding.Unicode.GetBytes(answer);
            socket.Send(data);
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}

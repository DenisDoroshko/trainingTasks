using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace NetworkModules
{
    /// <summary>
    /// Receive message delegate
    /// </summary>
    /// <param name="message">Given message</param>
    
    public delegate void ReceiveHandler(string message);

    /// <summary>
    /// Class representing network modules
    /// </summary>
    
    public abstract class NetworkModule
    {
        /// <summary>
        /// Current socket
        /// </summary>
        
        public Socket CurrentSocket { get; protected set; } = null;
    }
}

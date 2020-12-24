using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace NetworkModules
{
    public delegate void ReceiveHandler(string message);
    public abstract class NetworkModule
    {
        public Socket CurrentSocket { get; protected set; } = null;
    }
}

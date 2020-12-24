using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHandlers
{
    public class ClientInfo
    {
        public ClientInfo(string identification)
        {
            Identification = identification;
            Messages = new List<string>();
        }
        public string Identification { get; set; }
        public List<string> Messages { get; set; }
    }
}

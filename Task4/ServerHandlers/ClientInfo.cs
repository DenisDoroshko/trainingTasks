using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHandlers
{
    /// <summary>
    /// Class for storing client information
    /// </summary>
    
    public class ClientInfo
    {
        /// <summary>
        /// Creates an instance of the ClientInfo class
        /// </summary>
        /// <param name="identification">Name and id of a client</param>
        
        public ClientInfo(string identification)
        {
            Identification = identification;
            Messages = new List<string>();
        }

        /// <summary>
        /// Name and id of a client
        /// </summary>
        
        public string Identification { get; set; }

        /// <summary>
        /// Messages from this client
        /// </summary>
        
        public List<string> Messages { get; set; }
    }
}

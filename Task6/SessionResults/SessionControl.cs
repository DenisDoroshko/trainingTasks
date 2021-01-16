using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    /// <summary>
    /// The class representing a session control
    /// </summary>
    
    public abstract class SessionControl:IData
    {
        /// <summary>
        /// Creates an instance of the SessionControl class
        /// </summary>
        
        public SessionControl()
        {

        }

        /// <summary>
        /// Private field of a group id
        /// </summary>

        private Guid id;

        /// <summary>
        /// Group id
        /// </summary>

        public Guid Id { get => id; set { id = value; IsChanged = true; } }

        /// <summary>
        /// Private field of a session control name
        /// </summary>

        private string name;

        /// <summary>
        /// Session control name
        /// </summary>
        
        public string Name { get => name; set { name = value; IsChanged = true; } }

        /// <summary>
        /// Private field of a data
        /// </summary>

        private DateTime date;

        /// <summary>
        /// Session contol date
        /// </summary>
        
        public DateTime Date { get => date; set { date = value; IsChanged = true; } }

        /// <summary>
        /// Private field of a session id
        /// </summary>

        private Guid sessionId;

        /// <summary>
        /// Session id
        /// </summary>

        public Guid SessionId { get => sessionId; set { sessionId = value; IsChanged = true; } }

        /// <summary>
        /// Is the group changed
        /// </summary>

        public bool IsChanged;
    }
}

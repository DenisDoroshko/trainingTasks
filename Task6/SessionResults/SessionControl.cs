using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    public enum SessionControlTypes 
    {
        None,
        Exam,
        Credit
    }

    public abstract class SessionControl:IData
    {
        public SessionControl()
        {

        }
        private int id;
        public int Id { get => id; set { id = value; isSaved = false; } }
        public virtual SessionControlTypes Type { get;}
        private string name;
        public string Name { get => name; set { name = value; isSaved = false; } }
        private DateTime date;
        public DateTime Date { get => date; set { date = value; isSaved = false; } }
        private int sessionId;
        public int SessionId { get => sessionId; set { sessionId = value; isSaved = false; } }
        public bool isSaved = false;
    }
}

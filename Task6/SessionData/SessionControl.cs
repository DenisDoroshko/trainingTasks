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
        public int Id { get; set; }
        public virtual SessionControlTypes Type { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int SessionId { get; set; }
    }
}

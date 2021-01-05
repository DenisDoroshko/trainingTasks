using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    public class Exam:SessionControl
    {
        public Exam(int id,string name,DateTime date,int sessionId,int? mark)
        {
            Id = id;
            Name = name;
            Date = date;
            SessionId = sessionId;
            Mark = mark;
        }
        private SessionControlTypes type = SessionControlTypes.Exam;
        public override SessionControlTypes Type { get => type;}
        public int? Mark { get; set; }
    }
}

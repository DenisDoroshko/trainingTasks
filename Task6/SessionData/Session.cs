using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    public class Session:IData
    {
        public Session(int id,int number,int ownerId)
        {
            Id = id;
            Number = number;
            OwnerId = ownerId;
        }
        public int Id { get; set; }
        public int Number { get; set; }
        public int OwnerId { get; set; }
        public List<Exam> Exams;
        public List<Credit> Credits;
    }
}

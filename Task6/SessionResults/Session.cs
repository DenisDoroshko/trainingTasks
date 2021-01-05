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
        private int id;
        public int Id { get => id; set { id = value; isSaved = false; } }
        private int number;
        public int Number { get => number; set { number = value; isSaved = false; } }
        private int ownerId;
        public int OwnerId { get => ownerId; set { ownerId = value; isSaved = false; } }
        public List<Exam> Exams;
        public List<Credit> Credits;
        public bool isSaved = false;
    }
}

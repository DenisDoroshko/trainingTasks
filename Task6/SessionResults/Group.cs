using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    public class Group:IData
    {
        public Group(int id,string groupName)
        {
            Id = id;
            GroupName = groupName;
        }
        private int id;
        public int Id { get => id; set { id = value; isSaved = false; } }
        private string groupName;
        public string GroupName { get => groupName; set { groupName = value; isSaved = false; } }

        public List<Student> Students;
        public List<Session> Sessions;
        public bool isSaved = false;
    }
}

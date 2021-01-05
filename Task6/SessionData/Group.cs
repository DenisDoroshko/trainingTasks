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
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<Student> Students;
        public List<Session> Sessions;

    }
}

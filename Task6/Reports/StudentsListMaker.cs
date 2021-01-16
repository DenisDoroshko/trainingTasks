using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace Reports
{
    public static class StudentsListMaker
    {
        public static List<Student> MakeExpelledList(List<Group> groups)
        {
            var expelledList = new List<Student>();
            foreach(var group in groups)
            {
                foreach(var student in group.Students)
                {
                    bool isExpelled = false;
                    foreach(var session in student.Sessions)
                    {
                        if (!CheckSession(session))
                            isExpelled = true;
                    }
                    if(isExpelled)
                        expelledList.Add(student);
                }
            }
            return expelledList;
        }
        private static bool CheckSession(Session session)
        {
            bool isPassed = true;
            if (session.Exams.All(i => i.Mark != null) && session.Credits.All(i => i.Creditation != null))
            {
                if (session.Credits.All(i => i.Creditation == CreditationTypes.Credited))
                {
                    if (session.Exams.Any(i => i.Mark < 4))
                        isPassed = false;
                }
                else
                {
                    isPassed = false;
                }

            }
            return isPassed;
        }
    }
}

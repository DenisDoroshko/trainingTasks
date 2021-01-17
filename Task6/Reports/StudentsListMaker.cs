using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace Reports
{
    /// <summary>
    /// Representts a class for a making students expelled list
    /// </summary>
    
    public static class StudentsListMaker
    {
        /// <summary>
        /// Makes students expelled list
        /// </summary>
        /// <param name="groups">Group</param>
        /// <returns>Expelled list</returns>
        
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

        /// <summary>
        /// Checks student session
        /// </summary>
        /// <param name="session">Session</param>
        /// <returns>True if the specified session is passed; otherwise, false</returns>
        
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

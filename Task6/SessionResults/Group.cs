using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    /// <summary>
    /// The class representing a group
    /// </summary>
    
    public class Group:IData
    {
        /// <summary>
        /// Creates an instance of the Group class
        /// </summary>
        /// <param name="id">Group id</param>
        /// <param name="groupName">Group name</param>
        
        public Group(Guid id,string groupName)
        {
            Id = id;
            GroupName = groupName;
            Students = new List<Student>();
            Sessions = new List<Session>();
            IsChanged = false;
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
        /// Private field of a group name
        /// </summary>
        
        private string groupName;

        /// <summary>
        /// Group name
        /// </summary>
        
        public string GroupName { get => groupName; set { groupName = value; IsChanged = true; } }

        /// <summary>
        /// Group students
        /// </summary>
        
        public List<Student> Students;

        /// <summary>
        /// Group sessions
        /// </summary>
        
        public List<Session> Sessions;

        /// <summary>
        /// Is the group changed
        /// </summary>
        
        public bool IsChanged = false;

        /// <summary>
        /// Add sessions to students
        /// </summary>
        /// <param name="sessionNumber">Number of added session</param>
        /// <returns>Added sessions</returns>
        
        public List<Session> SetSession(int sessionNumber)
        {
            var newSessions = new List<Session>();
            var session = Sessions.FirstOrDefault(k => k.Number == sessionNumber);
            if (session != null)
            {
                for (var i = 0; i < Students.Count; i++)
                {
                    var newSession = session.MakeEmptyCopy(Students[i].Id);
                    Students[i].Sessions.Add(newSession);
                    newSessions.Add(newSession);
                }
            }
            return newSessions;
        }

        /// <summary>
        /// Redefining the Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false</returns>

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Group group = (Group)obj;
                return Id == group.Id && GroupName == group.GroupName && Students.SequenceEqual(group.Students)
                    && Sessions.SequenceEqual(group.Sessions);
            }
        }

        /// <summary>
        /// Redefining the GetHashCode method that calculates the hash code of the current object
        /// </summary>
        /// <returns>Hash code of the current object</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

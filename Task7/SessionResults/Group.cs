using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;

namespace SessionData
{
    /// <summary>
    /// The class representing a group
    /// </summary>
    
    [Table(Name ="Groups")]
    public class Group:IData
    {
        /// <summary>
        /// Creates an instance of the Group class
        /// </summary>
        
        public Group()
        {

        }

        /// <summary>
        /// Creates an instance of the Group class
        /// </summary>
        /// <param name="id">Group id</param>
        /// <param name="groupName">Group name</param>
        /// /// <param name="specialty">Specialty</param>

        public Group(Guid id, string groupName, string specialty)
        {
            Id = id;
            GroupName = groupName;
            Specialty = specialty;
        }

        /// <summary>
        /// Group id
        /// </summary>
        
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Group name
        /// </summary>

        [Column]
        public string GroupName { get; set; }

        /// <summary>
        /// Specialty
        /// </summary>
        
        [Column]
        public string Specialty { get; set; }

        /// <summary>
        /// Group students
        /// </summary>

        public List<Student> Students = new List<Student>();

        /// <summary>
        /// Group sessions
        /// </summary>
        
        public List<Session> Sessions = new List<Session>();

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

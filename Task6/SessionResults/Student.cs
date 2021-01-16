using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    /// <summary>
    /// Sex of the student
    /// </summary>
    
    public enum Sexes
    {
        /// <summary>
        /// Sex not specified
        /// </summary>
        
        None,

        /// <summary>
        /// Male
        /// </summary>
       
        Male,

        /// <summary>
        /// Female
        /// </summary>
        
        Female
    }

    /// <summary>
    /// The class representing a student
    /// </summary>
    
    public class Student:IData
    {
        /// <summary>
        /// Creates an instance of the Student class
        /// </summary>
        /// <param name="id">Student id</param>
        /// <param name="fullName">Student name</param>
        /// <param name="sex">Student sex</param>
        /// <param name="birthDate">Student birthdate</param>
        /// <param name="gropuId">Group id</param>
        
        public Student(Guid id,string fullName,Sexes sex,DateTime birthDate,Guid gropuId)
        {
            Id = id;
            FullName = fullName;
            Sex = sex;
            BirthDate = birthDate;
            GroupId = gropuId;
            Sessions = new List<Session>();
            IsChanged = false;
        }

        /// <summary>
        /// Private field of a student id
        /// </summary>

        private Guid id;

        /// <summary>
        /// Student id
        /// </summary>

        public Guid Id { get => id; set {id=value;IsChanged = true; } }

        /// <summary>
        /// Private field of a student name
        /// </summary>

        private string fullName;

        /// <summary>
        /// Student name
        /// </summary>

        public string FullName { get => fullName; set { fullName = value; IsChanged = true; } }

        /// <summary>
        /// Private field of a student sex
        /// </summary>

        private Sexes sex;

        /// <summary>
        /// Student sex
        /// </summary>

        public Sexes Sex { get => sex; set { sex = value; IsChanged = true; } }

        /// <summary>
        /// Private field of a student birthdate
        /// </summary>
        
        private DateTime birthDate;

        /// <summary>
        /// Birthdate of the student
        /// </summary>

        public DateTime BirthDate { get => birthDate; set { birthDate = value; IsChanged = true; } }

        /// <summary>
        /// Private field of a group id
        /// </summary>

        private Guid groupId;

        /// <summary>
        /// Group id
        /// </summary>

        public Guid GroupId { get => groupId; set { groupId = value; IsChanged = true; } }

        /// <summary>
        /// Student sessions
        /// </summary>
        
        public List<Session> Sessions;

        /// <summary>
        /// Is the session changed
        /// </summary>

        public bool IsChanged;

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
                Student student = (Student)obj;
                return Id == student.Id && FullName ==student.FullName && BirthDate == student.BirthDate &&
                    GroupId == student.GroupId && Sessions.SequenceEqual(student.Sessions);
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

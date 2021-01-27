using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

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
    
    [Table(Name = "Students")]
    public class Student:IData
    {
        /// <summary>
        /// Creates an instance of the Student class
        /// </summary>
        
        public Student()
        {

        }

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
        }

        /// <summary>
        /// Student id
        /// </summary>
        
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Student name
        /// </summary>
        
        [Column]
        public string FullName { get; set;}

        /// <summary>
        /// Student sex
        /// </summary>
        
        [Column]
        public Sexes Sex { get; set; }

        /// <summary>
        /// Birthdate of the student
        /// </summary>
        
        [Column]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Group id
        /// </summary>
       
        [Column]
        public Guid GroupId { get; set; }

        /// <summary>
        /// Student sessions
        /// </summary>
        
        public List<Session> Sessions = new List<Session>();

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SessionData
{
    /// <summary>
    /// Session owners
    /// </summary>
    public enum Owners 
    {
        /// <summary>
        /// Group
        /// </summary>
        
        Group,

        /// <summary>
        /// Student
        /// </summary>
        
        Student
    }

    /// <summary>
    /// The class representing a session
    /// </summary>
    
    [Table(Name = "Sessions")]
    public class Session:IData
    {
        /// <summary>
        ///  Creates an instance of the Session class
        /// </summary>
        
        public Session()
        {

        }

        /// <summary>
        /// Creates an instance of the Session class
        /// </summary>
        /// <param name="id">Session id</param>
        /// <param name="number">Session number</param>
        /// <param name="ownerType">Owner type</param>
        /// <param name="ownerId">Owner id</param>
        
        public Session(Guid id,int number, Owners ownerType, Guid? ownerId)
        {
            Id = id;
            Number = number;
            OwnerType = ownerType;
            if (ownerType == Owners.Group)
            {
                GroupId = ownerId;
            }
            else
            {
                StudentId = ownerId;
            }
        }

        /// <summary>
        /// Session id
        /// </summary>
        
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Session number
        /// </summary>
        
        [Column]
        public int Number { get; set; }

        /// <summary>
        /// Studend id
        /// </summary>
        
        [Column]
        public Guid? StudentId { get; set; }

        /// <summary>
        /// Group id
        /// </summary>
        
        [Column]
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Owner type
        /// </summary>
        
        [Column]
        public Owners OwnerType { get; set; }

        /// <summary>
        /// Session exams
        /// </summary>
        
        public List<Exam> Exams = new List<Exam>();


        /// <summary>
        /// Session credits
        /// </summary>
        
        public List<Credit> Credits = new List<Credit>();

        /// <summary>
        /// Make empty copy of this session
        /// </summary>
        /// <param name="ownerId">Owner id</param>
        /// <returns>Empy copy</returns>
        
        public Session MakeEmptyCopy(Guid ownerId)
        {
            var session = new Session(Guid.NewGuid(), this.Number, Owners.Student, ownerId);
            session.Exams = new List<Exam>();
            for (var i = 0; i < Exams.Count; i++)
                session.Exams.Add(new Exam(Guid.NewGuid(),Exams[i].Name, null,Exams[i].Date,Exams[i].Examiner,session.Id));
            session.Credits = new List<Credit>();
            for (var i = 0; i < Credits.Count; i++)
                session.Credits.Add(new Credit(Guid.NewGuid(), Credits[i].Name, null,Credits[i].Date,Credits[i].Examiner, session.Id));
            return session;
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
                Session session = (Session)obj;
                return Id == session.Id && Number == session.Number && StudentId == session.StudentId &&
                    GroupId == session.GroupId && OwnerType==session.OwnerType && Exams.SequenceEqual(session.Exams) 
                    && Credits.SequenceEqual(session.Credits);
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

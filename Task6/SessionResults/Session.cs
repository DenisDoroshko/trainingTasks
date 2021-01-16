using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    
    public class Session:IData
    {
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
            Exams = new List<Exam>();
            Credits = new List<Credit>();
            OwnerType = ownerType;
            if (ownerType == Owners.Group)
            {
                GroupId = ownerId;
            }
            else
            {
                StudentId = ownerId;
            }
            IsChanged = false;
        }

        /// <summary>
        /// Private field of a group id
        /// </summary>

        private Guid id;

        /// <summary>
        /// Session id
        /// </summary>

        public Guid Id { get => id; set { id = value; IsChanged = true; } }

        /// <summary>
        /// Private field of a session number
        /// </summary>

        private int number;

        /// <summary>
        /// Session number
        /// </summary>

        public int Number { get => number; set { number = value; IsChanged = true; } }

        /// <summary>
        /// Private field of a student id
        /// </summary>

        private Guid? studentId;

        /// <summary>
        /// Studend id
        /// </summary>

        public Guid? StudentId { get => studentId; set { studentId = value; IsChanged = true; } }

        /// <summary>
        /// Private field of a group id
        /// </summary>

        private Guid? groupId;

        /// <summary>
        /// Group id
        /// </summary>

        public Guid? GroupId { get => groupId; set { groupId = value; IsChanged = true; } }

        /// <summary>
        /// Owner type
        /// </summary>
        
        public Owners OwnerType { get; }

        /// <summary>
        /// Session exams
        /// </summary>
        
        public List<Exam> Exams;


        /// <summary>
        /// Session credits
        /// </summary>
        
        public List<Credit> Credits;

        /// <summary>
        /// Is the session changed
        /// </summary>

        public bool IsChanged;

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
                session.Exams.Add(new Exam(Guid.NewGuid(),Exams[i].Name, null,Exams[i].Date,session.Id));
            session.Credits = new List<Credit>();
            for (var i = 0; i < Credits.Count; i++)
                session.Credits.Add(new Credit(Guid.NewGuid(), Credits[i].Name, null,Credits[i].Date, session.Id));
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

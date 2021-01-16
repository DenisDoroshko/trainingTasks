using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    /// <summary>
    /// The class representing an exam
    /// </summary>
    
    public class Exam:SessionControl
    {
        /// <summary>
        /// Creates an instance of the Exam class
        /// </summary>
        /// <param name="id">Exam id</param>
        /// <param name="name">Exam name</param>
        /// <param name="mark">Exam mark</param>
        /// <param name="date">Exam date</param>
        /// <param name="sessionId">Session id</param>
        
        public Exam(Guid id,string name, int? mark,DateTime date, Guid sessionId)
        {
            Id = id;
            Name = name;
            Mark = mark;
            Date = date;
            SessionId = sessionId;
            IsChanged = false;
        }

        /// <summary>
        /// Private field of the exam mark
        /// </summary>

        private int? mark;

        /// <summary>
        /// Exam mark
        /// </summary>
        
        public int? Mark { get => mark; set { mark = value; IsChanged = true; } }

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
                Exam exam = (Exam)obj;
                return Id == exam.Id && Name == exam.Name && Date == exam.Date && 
                    SessionId == exam.SessionId && Mark == exam.Mark;
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

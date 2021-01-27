using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SessionData
{
    /// <summary>
    /// The class representing an exam
    /// </summary>
    
    [Table(Name = "Exams")]
    public class Exam
    {
        /// <summary>
        /// Creates an instance of the Exam class
        /// </summary>
        
        public Exam()
        {

        }

        /// <summary>
        /// Creates an instance of the Exam class
        /// </summary>
        /// <param name="id">Exam id</param>
        /// <param name="name">Exam name</param>
        /// <param name="mark">Exam mark</param>
        /// <param name="date">Exam date</param>
        /// <param name="examiner">Examiner name</param>
        /// <param name="sessionId">Session id</param>

        public Exam(Guid id,string name, int? mark,DateTime date,string examiner, Guid sessionId)
        {
            Id = id;
            Name = name;
            Mark = mark;
            Date = date;
            Examiner = examiner;
            SessionId = sessionId;
        }

        /// <summary>
        /// Group id
        /// </summary>

        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public Guid Id { get; set; }


        /// <summary>
        /// Session control name
        /// </summary>

        [Column]
        public string Name { get; set; }

        /// <summary>
        /// Session contol date
        /// </summary>

        [Column]
        public DateTime Date { get; set; }

        /// <summary>
        /// Session id
        /// </summary>

        [Column]
        public Guid SessionId { get; set; }

        /// <summary>
        /// Examiner name
        /// </summary>

        [Column]
        public string Examiner { get; set; }

        /// <summary>
        /// Exam mark
        /// </summary>
        
        [Column]
        public int? Mark { get; set; }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SessionData
{
    /// <summary>
    /// Creditation types
    /// </summary>
    
    public enum CreditationTypes
    {
        /// <summary>
        /// Not credited
        /// </summary>
        
        NotCredited,

        /// <summary>
        /// Credited
        /// </summary>
        
        Credited
    }

    /// <summary>
    /// The class representing a credit
    /// </summary>
    
    [Table(Name = "Credits")]
    public class Credit
    {
        /// <summary>
        /// Creates an instance of the Credit class
        /// </summary>
        
        public Credit()
        {

        }

        /// <summary>
        /// Creates an instance of the Credit class
        /// </summary>
        /// <param name="id">Credit id</param>
        /// <param name="name">Credit name</param>
        /// <param name="creditation">Creditation</param>
        /// <param name="date">Date of the credit</param>
        /// <param name="examiner">Examiner name</param>
        /// <param name="sessionId">Session id</param>

        public Credit(Guid id, string name, CreditationTypes? creditation, DateTime date, string examiner, Guid sessionId)
        {
            Id = id;
            Name = name;
            Creditation = creditation;
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
        /// Is the group changed
        /// </summary>

        public bool IsChanged;

        /// <summary>
        /// Credittation
        /// </summary>
        
        [Column]
        public CreditationTypes? Creditation { get; set; }

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
                Credit credit= (Credit)obj;
                return Id == credit.Id && Name == credit.Name && Date == credit.Date &&
                    SessionId == credit.SessionId && Creditation == credit.Creditation;
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

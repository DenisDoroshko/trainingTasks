using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class Credit : SessionControl
    {
        /// <summary>
        /// Creates an instance of the Credit class
        /// </summary>
        /// <param name="id">Credit id</param>
        /// <param name="name">Credit name</param>
        /// <param name="creditation">Creditation</param>
        /// <param name="date">Date of the credit</param>
        /// <param name="sessionId">Session id</param>
        
        public Credit(Guid id, string name, CreditationTypes? creditation, DateTime date, Guid sessionId)
        {
            Id = id;
            Name = name;
            Creditation = creditation;
            Date = date;
            SessionId = sessionId;
        }

        /// <summary>
        /// Private field of the creditation
        /// </summary>
        
        private CreditationTypes? creditation;

        /// <summary>
        /// Credittation
        /// </summary>
        
        public CreditationTypes? Creditation { get => creditation; set { creditation = value; IsChanged = true; } }

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

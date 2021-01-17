using System;
using System.Collections.Generic;
using SessionData;

namespace SessionDataFactory
{
    /// <summary>
    /// Representts a class for a creating session
    /// </summary>

    public class SessionCreator:BaseCreator
    {
        /// <summary>
        /// Creates a credit
        /// </summary>
        /// <param name="values">Specified values</param>
        /// <returns>The instance of the Session class</returns>

        public override IData Create(List<object> values)
        {
            try
            {
                Guid id = (Guid)values[0];
                int number = (int)values[1];
                Owners ownerType = (Owners)(int)values[2];
                Guid? ownerId = values[3] != DBNull.Value ? (Guid?)values[3] : (Guid?)values[4];
                return new Session(id,number, ownerType, ownerId);
            }
            catch
            {
                return null;
            }
        }
    }
}

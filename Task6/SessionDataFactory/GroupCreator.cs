using SessionData;
using System;
using System.Collections.Generic;

namespace SessionDataFactory
{
    /// <summary>
    /// Representts a class for a creating groups
    /// </summary>

    public class GroupCreator:BaseCreator
    {
        /// <summary>
        /// Creates a credit
        /// </summary>
        /// <param name="values">Specified values</param>
        /// <returns>The instance of the Group class</returns>
        
        public override IData Create(List<object> values)
        {
            try
            {
                Guid id = (Guid)values[0];
                string groupName = ((string)values[1]).Trim();
                return new Group(id, groupName);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Mistake "+ex.Message);
                return null;
            }
        }
    }
}

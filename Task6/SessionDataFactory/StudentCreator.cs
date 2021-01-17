using System;
using System.Collections.Generic;
using SessionData;

namespace SessionDataFactory
{
    /// <summary>
    /// Representts a class for a creating session
    /// </summary>

    public class StudentCreator:BaseCreator
    {
        /// <summary>
        /// Creates a credit
        /// </summary>
        /// <param name="values">Specified values</param>
        /// <returns>The instance of the Student class</returns>

        public override IData Create(List<object> values)
        {
            try
            {
                Guid id = (Guid)values[0];
                string name = ((string)values[1]).Trim();
                Sexes sex = (Sexes)(int)values[2];
                var date=(DateTime)values[3];
                Guid groupId = (Guid)values[4];
                return new Student(id, name, sex, date, groupId);
            }
            catch
            {
                return null;
            }
        }
    }
}

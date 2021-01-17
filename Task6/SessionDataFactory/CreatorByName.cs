using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace SessionDataFactory
{
    /// <summary>
    /// Session data types
    /// </summary>

    public enum SessionDataTypes
    {
        /// <summary>
        /// None
        /// </summary>

        None,

        /// <summary>
        /// Group
        /// </summary>

        Group,

        /// <summary>
        /// Student
        /// </summary>

        Student,

        /// <summary>
        /// Session
        /// </summary>

        Session,

        /// <summary>
        /// Exam
        /// </summary>

        Exam,

        /// <summary>
        /// Credit
        /// </summary>

        Credit
    }

    /// <summary>
    /// Representts a class for a creating session data objects by specified type
    /// </summary>
    
    public static class CreatorByName
    {
        /// <summary>
        /// Creates session data object by specified type
        /// </summary>
        /// <param name="selectedType">Name of selected type</param>
        /// <param name="values">Values for creating</param>
        /// <returns>Session data object</returns>
        
        public static IData CreateByName(Type selectedType, List<object> values)
        {
            SessionDataTypes type;
            Enum.TryParse(selectedType.Name, out type);
            IData element = null; ;
            switch (type)
            {
                case SessionDataTypes.Group:
                    element = (new GroupCreator()).Create(values);
                    break;
                case SessionDataTypes.Student:
                    element = (new StudentCreator()).Create(values);
                    break;
                case SessionDataTypes.Session:
                    element = (new SessionCreator()).Create(values);
                    break;
                case SessionDataTypes.Exam:
                    element = (new ExamCreator()).Create(values);
                    break;
                case SessionDataTypes.Credit:
                    element = (new CreditCreator()).Create(values);
                    break;
            }
            return element;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace SessionDataFactory
{
    public enum SessionDataTypes
    {
        None,
        Group,
        Student,
        Session,
        Exam,
        Credit
    }
    public abstract class BaseCreator
    {
        public abstract IData Create(List<object> values);
        public static IData CreateByName(string className,List<object> values)
        {
            SessionDataTypes type;
            Enum.TryParse(className, out type);
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

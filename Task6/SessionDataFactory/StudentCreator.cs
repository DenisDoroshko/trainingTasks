using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace SessionDataFactory
{
    public class StudentCreator:BaseCreator
    {
        public override IData Create(List<object> values)
        {
            try
            {
                int id = (int)values[0];
                string name = (string)values[1];
                Sexes sex;
                Enum.TryParse((string)values[2],out sex);
                var date=DateTime.Parse((string)values[3]);
                int groupId = (int)values[4];
                return new Student(id, name, sex, date, groupId);
            }
            catch
            {
                return null;
            }
        }
    }
}

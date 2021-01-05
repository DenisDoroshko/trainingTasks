using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace SessionDataFactory
{
    public class CreditCreator:BaseCreator
    {
        public override IData Create(List<object> values)
        {
            try
            {
                int id = (int)values[0];
                string name = (string)values[1];
                var date = DateTime.Parse((string)values[2]);
                int sessionId = (int)values[3];
                int mark = (int)values[4];
                CreditationTypes creditation;
                Enum.TryParse((string)values[5], out creditation);
                return new Credit(id, name, date, sessionId, creditation);
                
            }
            catch
            {
                return null;
            }
        }
    }
}

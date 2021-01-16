using System;
using System.Collections.Generic;
using SessionData;

namespace SessionDataFactory
{
    public class CreditCreator:BaseCreator
    {
        public override IData Create(List<object> values)
        {
            try
            {
                Guid id = (Guid)values[0];
                string name = ((string)values[1]).Trim();
                CreditationTypes? creditation;
                if (values[2] != DBNull.Value)
                    creditation = (CreditationTypes?)(int)values[2];
                else
                    creditation = null;
                var date = (DateTime)values[3];
                Guid sessionId = (Guid)values[4];
                return new Credit(id, name, creditation, date, sessionId);
            }
            catch
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace SessionDataFactory
{
    class SessionCreator:BaseCreator
    {
        public override IData Create(List<object> values)
        {
            try
            {
                int id = (int)values[0];
                int number = (int)values[1];
                int ownerId = (int)values[1];
                return new Session(id,number, ownerId);
            }
            catch
            {
                return null;
            }
        }
    }
}

using SessionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionDataFactory
{
    class GroupCreator:BaseCreator
    {
        public override IData Create(List<object> values)
        {
            try
            {
                int id = (int)values[0];
                string groupName = (string)values[1];
                return new Group(id, groupName);
            }
            catch
            {
                return null;
            }
        }
    }
}

using SessionData;
using System;
using System.Collections.Generic;

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
                return new Group(id, groupName) { isSaved = true };
            }
            catch
            {
                return null;
            }
        }
    }
}

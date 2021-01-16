using SessionData;
using System;
using System.Collections.Generic;

namespace SessionDataFactory
{
    public class GroupCreator:BaseCreator
    {
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

using System;
using System.Collections.Generic;
using SessionData;

namespace SessionDataFactory
{
    public class SessionCreator:BaseCreator
    {
        public override IData Create(List<object> values)
        {
            try
            {
                Guid id = (Guid)values[0];
                int number = (int)values[1];
                Owners ownerType = (Owners)(int)values[2];
                Guid? ownerId = values[3] != DBNull.Value ? (Guid?)values[3] : (Guid?)values[4];
                return new Session(id,number, ownerType, ownerId);
            }
            catch
            {
                return null;
            }
        }
    }
}

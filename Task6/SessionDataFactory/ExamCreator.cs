using System;
using System.Collections.Generic;
using SessionData;

namespace SessionDataFactory
{
    public class ExamCreator:BaseCreator
    {
        public override IData Create(List<object> values)
        {
            try
            {
                Guid id = (Guid)values[0];
                string name = ((string)values[1]).Trim();
                int? mark = values[2] != DBNull.Value ? (int?)values[2] : null;
                var date = (DateTime)values[3];
                Guid sessionId = (Guid)values[4];
                return new Exam(id, name, mark, date, sessionId);
            }
            catch
            {
                return null;
            }
        }
    }
}

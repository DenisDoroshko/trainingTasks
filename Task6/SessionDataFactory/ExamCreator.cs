using System;
using System.Collections.Generic;
using SessionData;

namespace SessionDataFactory
{
    class ExamCreator:BaseCreator
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
                return new Exam(id, name, date, sessionId, mark) { isSaved = true };
            }
            catch
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    public enum CreditationTypes
    {
        NotCredited,
        Credited
    }

    public class Credit : SessionControl
    {
        public Credit(int id, string name, DateTime date, int sessionId, CreditationTypes? creditation)
        {
            Id = id;
            Name = name;
            Date = date;
            SessionId = sessionId;
            Creditation = creditation;
        }
        private SessionControlTypes type = SessionControlTypes.Credit;
        public override SessionControlTypes Type { get => type; }
        private CreditationTypes? creditation;
        public CreditationTypes? Creditation { get => creditation; set { creditation = value; isSaved = false; } }
    }
}

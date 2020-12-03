using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    public class NotEqualNamesException:Exception
    {
        public NotEqualNamesException() : base("Names are not equal")
        {
        }
        public NotEqualNamesException(string message) : base(message)
        {
        }
    }
}

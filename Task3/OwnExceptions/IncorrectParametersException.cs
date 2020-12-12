using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    public class IncorrectParametersException:Exception
    {
        public IncorrectParametersException() : base("Incorrect parameters error")
        {
        }
        public IncorrectParametersException(string message) : base(message)
        {
        }
    }
}

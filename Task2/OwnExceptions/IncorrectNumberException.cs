using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    public class IncorrectNumberException:Exception
    {
        public IncorrectNumberException() : base("Number of products is less then given number")
        {
        }
        public IncorrectNumberException(string message) : base(message)
        {
        }
    }
}

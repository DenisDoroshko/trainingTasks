using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    public class CutFigureException:Exception
    {
        public CutFigureException() : base("The figure being cut is larger then original figure")
        {
        }
        public CutFigureException(string message) : base(message)
        {
        }
    }
}

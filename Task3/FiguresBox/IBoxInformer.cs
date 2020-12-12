using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresBox
{
    public interface IBoxInformer
    {
        int ShowQuantity();
        double ShowAreaSum();
        double ShowPerimeterSum();
    }
}

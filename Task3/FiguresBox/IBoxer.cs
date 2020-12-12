using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FiguresBox
{
    interface IBoxer
    {
        bool AddFigure();
        string ShowByNumber();
        Figure ExtractByNumber();
        bool ReplaceByNumber();
        Figure FindEquivalent();
    }
}

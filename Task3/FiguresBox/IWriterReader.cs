using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FiguresBox
{
    public interface IWriterReader
    {
        void SaveByStreamWriter(MaterialTypes type);
        void SaveByXmlWriter(MaterialTypes type);
        List<Figure> LoadByStreamReader();
        List<Figure> LoadByXmlReader();
    }
}

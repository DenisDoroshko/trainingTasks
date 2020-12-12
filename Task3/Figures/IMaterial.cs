using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public enum MaterialTypes
    {
        Paper,
        Plastic,
        Film
    }
    public interface IMaterial
    {
        List<Figure> ReadWithXmlReader();
        void WriteWithXmlReader();
    }
}

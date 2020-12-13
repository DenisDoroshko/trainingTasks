using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FiguresBox
{
    /// <summary>
    /// The interface for working with xml files
    /// </summary>
    public interface IWriterReader
    {

        /// <summary>
        /// Saves figures using StreamWtirer
        /// </summary>
        /// <param name="path">File path</param>

        void SaveByStreamWriter(string path);

        /// <summary>
        /// Saves figures using StreamWtirer by specified material
        /// </summary>
        /// <param name="material">Specified material</param>
        /// <param name="path">File path</param>

        void SaveByStreamWriter(MaterialTypes material,string path);

        /// <summary>
        /// Saves figures using XmlWtirer
        /// </summary>
        /// <param name="path">File path</param>

        void SaveByXmlWriter(string path);

        /// <summary>
        /// Saves figures using StreamWtirer by specified material
        /// </summary>
        /// <param name="material">Specified material</param>
        /// <param name="path">File path</param>

        void SaveByXmlWriter(MaterialTypes material,string path);

        /// <summary>
        /// Loads figures using StreamReader
        /// </summary>
        /// <param name="path">File path</param>

        void LoadByStreamReader(string path);

        /// <summary>
        /// Loads figures using XmlReader
        /// </summary>
        /// <param name="path">File path</param>

        void LoadByXmlReader(string path);
    }
}

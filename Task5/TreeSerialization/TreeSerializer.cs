using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace TreeSerialization
{
    /// <summary>
    /// Represents a class for serializing and deserializing a tree
    /// </summary>
    
    public class TreeSerializer
    {
        /// <summary>
        /// Serializes a tree to xml file
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="filePath">File path</param>
        /// <param name="tree">Tree</param>
        
        public static void SerializeToXml<T>(string filePath,T tree)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fs, tree);
            }
        }

        /// <summary>
        /// Deserializes a tree from xml file
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="filePath">File path</param>
        /// <param name="tree">Tree</param>
        
        public static void DeserializeFromXml<T>(string filePath,out T tree)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                tree= (T)formatter.Deserialize(fs);
            }
        }
    }
}

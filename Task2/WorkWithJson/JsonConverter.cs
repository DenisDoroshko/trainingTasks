using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Products;

namespace WorkWithJson
{
    /// <summary>
    /// Provides methods for working with json files
    /// </summary>
    
    public static class JsonConverter
    {
        /// <summary>
        /// Writes information to a json text file
        /// </summary>
        /// <param name="products">Written products</param>
        /// <param name="path">Path to json file</param>

        public static void WriteToJson(List<Product> products,string path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string Serialized = JsonConvert.SerializeObject(products, settings);
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(Serialized);
            }
        }

        /// <summary>
        /// Reads information from a json text file
        /// </summary>
        /// <returns>List of products</returns>
        
        public static List<Product> ReadFromJson(string path)
        {
            string jsonInfo = null;
            using (var sr = new StreamReader(path))
            {
                jsonInfo = sr.ReadToEnd();
            }
            List<Product> products = null;
            if (jsonInfo != null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                products = JsonConvert.DeserializeObject<List<Product>>(jsonInfo, settings);
            }
            return products;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransliteration
{   
    /// <summary>
    /// Class for writing Russian letters in transliteration
    /// </summary>
    
    public class TextRecoder
    {
        /// <summary>
        /// Writes Russian letters in transliteration
        /// </summary>
        /// <param name="text">Given text</param>
        /// <returns>Russian letters in transliteration</returns>
        
        public static string RecodeText(string text)
        {
            StringBuilder transliteText = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (transliter.ContainsKey(text[i]))
                {
                    transliteText.Append(transliter[text[i]]);
                }
                else
                {
                    transliteText.Append(text[i].ToString());
                }
            }
            return transliteText.ToString();
        }

        /// <summary>
        /// Letter matching dictionary
        /// </summary>
        
        private static Dictionary<char, string> transliter = new Dictionary<char, string>()
        {
            ['а'] = "a",
            ['б'] = "b",
            ['в'] = "v",
            ['г'] = "g",
            ['д'] = "d",
            ['е'] = "e",
            ['ё'] = "yo",
            ['ж'] = "zh",
            ['з'] = "z",
            ['и'] = "i",
            ['й'] = "j",
            ['к'] = "k",
            ['л'] = "l",
            ['м'] = "m",
            ['н'] = "n",
            ['о'] = "o",
            ['п'] = "p",
            ['р'] = "r",
            ['с'] = "s",
            ['т'] = "t",
            ['у'] = "u",
            ['ф'] = "f",
            ['х'] = "h",
            ['ц'] = "c",
            ['ч'] = "ch",
            ['ш'] = "sh",
            ['щ'] = "sch",
            ['ъ'] = "j",
            ['ы'] = "i",
            ['ь'] = "j",
            ['э'] = "e",
            ['ю'] = "yu",
            ['я'] = "ya",
            ['А'] = "A",
            ['Б'] = "B",
            ['В'] = "V",
            ['Г'] = "G",
            ['Д'] = "D",
            ['Е'] = "E",
            ['Ё'] = "Yo",
            ['Ж'] = "Zh",
            ['З'] = "Z",
            ['И'] = "I",
            ['Й'] = "J",
            ['К'] = "K",
            ['Л'] = "L",
            ['М'] = "M",
            ['Н'] = "N",
            ['О'] = "O",
            ['П'] = "P",
            ['Р'] = "R",
            ['С'] = "S",
            ['Т'] = "T",
            ['У'] = "U",
            ['Ф'] = "F",
            ['Х'] = "H",
            ['Ц'] = "C",
            ['Ч'] = "Ch",
            ['Ш'] = "Sh",
            ['Щ'] = "Sch",
            ['Ъ'] = "J",
            ['Ы'] = "I",
            ['Ь'] = "J",
            ['Э'] = "E",
            ['Ю'] = "Yu",
            ['Я'] = "Ya"
        };
    }
}

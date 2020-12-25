using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextTransliteration;

namespace NetworkTests
{
    [TestClass]
    public class TextTransliterationTest
    {
        [DataTestMethod]
        [DataRow("Привет мир. Кодирование текста. Text coding", "Privet mir. Kodirovanie teksta. Text coding")]
        [DataRow("Текст успешно перекодирован латиницей!", "Tekst uspeshno perekodirovan latinicej!")]
        [DataRow("Текст записан на транслите. English text", "Tekst zapisan na translite. English text")]
        public void LambdaClientHandlerTest( string givenText, string expected)
        {
            //Arange
            string result = TextRecoder.RecodeText(givenText);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

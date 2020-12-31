using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeSerialization;
using Students;
using BinaryTrees;
namespace UnitTests
{
    [TestClass]
    public class SerializationTest
    {
        [DataTestMethod]
        [DataRow("18.12.2020", "15.12.2020", "13.12.2020")]
        [DataRow("11.06.2015", "23.11.2016", "12.10.2018")]
        [DataRow("11.06.2015", "23.11.2016", "12.10.2018")]
        public void SerializeDeserializeTree(string firstDate, string secondDate, string thirdDate)
        {
            //Arange
            var expected = true;
            var tree = new BinaryTree<Student>();
            var firstStudent = new Student("Ivanov Petr", "OOP", DateTime.Parse(firstDate), 8);
            var secondStudent = new Student("Ivanov Ivan", "OOP", DateTime.Parse(secondDate), 7);
            var thirdStudent = new Student("Ivanov Alexander", "OOP", DateTime.Parse(thirdDate), 9);
            tree.Add(firstStudent);
            tree.Add(secondStudent);
            tree.Add(thirdStudent);
            bool actual = true;
            //Act
            TreeSerializer.SerializeToXml("test.xml", tree);
            BinaryTree<Student> deserializedTree;
            TreeSerializer.DeserializeFromXml("test.xml", out deserializedTree);
            var initialData = tree.ShowSortedData();
            var deserializedTreeData = deserializedTree.ShowSortedData();
            for (var i = 0; i < initialData.Count; i++)
                if (!initialData[i].Equals(deserializedTreeData[i]))
                    actual = false;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

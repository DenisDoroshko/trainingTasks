using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTrees;
using Students;
using System.Collections.Generic;
namespace UnitTests
{
    [TestClass]
    public class TreeTest
    {
        [DataTestMethod]
        [DataRow(15,51,49, 15)]
        [DataRow(8, 10,9, 8)]
        [DataRow(121, 130,122,121)]
        public void AddIntNode(int expected,int rootNode,int leftNode,int leftNodeChild)
        {
            //Arange
            var tree = new BinaryTree<int>();
            //Act
            tree.Add(rootNode);
            tree.Add(leftNode);
            tree.Add(leftNodeChild);
            int actual = tree.RootNode.LeftNode.LeftNode.Data;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("18.12.2020", "20.12.2020")]
        [DataRow("20.12.2020", "25.12.2020")]
        [DataRow("10.06.2015", "03.11.2016")]
        public void AddStudentNode(string rootDate,string nodeDate)
        {
            //Arange
            var expected = new Student("Ivanov Alexander", "OOP", DateTime.Parse(nodeDate), 10);
            var tree = new BinaryTree<Student>();
            var rootStudent = new Student("Ivanov Petr", "OOP", DateTime.Parse(rootDate), 10);
            var rightStudent = new Student("Ivanov Alexander","OOP",DateTime.Parse(nodeDate),10);
            //Act
            tree.Add(rootStudent);
            tree.Add(rightStudent);
            var actual = tree.RootNode.RightNode.Data;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(4,5,1, 1,4,5)]
        [DataRow(146, 128,13,13,128,146)]
        [DataRow(1500,1233,994, 994,1233,1500)]
        public void ShowSortedData(int firstValue,int secondValue,int thirdValue,int firstSortedValue,int secondSortedValue,int thirdSortedValue)
        {
            //Arange
            var expected = true;
            List<int> expectedSortedValues =new List<int>(3){ firstSortedValue, secondSortedValue, thirdSortedValue };
            var tree = new BinaryTree<int>();
            tree.Add(firstValue);
            tree.Add(secondValue);
            tree.Add(thirdValue);
            bool actual = true;
            //Act
            var actualData = tree.ShowSortedData();
            for (var i = 0; i < expectedSortedValues.Count; i++)
                if (actualData[i] != expectedSortedValues[i])
                    actual = false;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("18.12.2020", "20.12.2020", "22.12.2020")]
        [DataRow("20.12.2020", "25.12.2020", "31.12.2020")]
        [DataRow("10.06.2015", "03.11.2016", "12.10.2018")]
        public void BalanceTree(string rootDate, string rightNodeDate,string rightNodeChildDate)
        {
            //Arange
            var expected = new Student("Ivanov Ivan", "OOP", DateTime.Parse(rightNodeDate), 10);
            var tree = new BinaryTree<Student>();
            var rootStudent = new Student("Ivanov Petr", "OOP", DateTime.Parse(rootDate), 10);
            var rightStudent = new Student("Ivanov Ivan", "OOP", DateTime.Parse(rightNodeDate), 10);
            var rightStudentChild = new Student("Ivanov Alexander", "OOP", DateTime.Parse(rightNodeChildDate), 10);
            tree.Add(rootStudent);
            tree.Add(rightStudent);
            tree.Add(rightStudentChild);
            //Act
            tree.BalanceTree();
            var actual = tree.RootNode.Data;
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionData;
using Sorters;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class SortersTest
    {
        [DataTestMethod]
        [DataRow("Stepanov Ivan", "Borisov Ivan", "Alexandrov Ivan")]
        [DataRow("Fedorov Ivan", "Artemov Ivan", "Alexandrov Ivan")]
        [DataRow("Petrov Ivan", "Olegov Ivan", "Denisov Ivan")]
        public void SortBySelectedType(string firstName,string secondName,string thirdName)
        {
            //Arange
            bool expected = true;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22");
            var firstStudent = new Student(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), firstName, 0, new DateTime(2001, 10, 12), group.Id);
            var secondStudent = new Student(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), secondName, 0, new DateTime(2001, 10, 12), group.Id);
            var thirdStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), thirdName, 0, new DateTime(2001, 10, 12), group.Id);
            group.Students = new List<Student> { firstStudent, secondStudent, thirdStudent };
            var expectedList = new List<Student> { thirdStudent, secondStudent,  firstStudent };
            bool result = false;
            //Act
            SortSelector.SortBy(SortTypes.SortByName, group);
            if (expectedList.SequenceEqual(group.Students))
                result = true;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("20.12.2000", "22.12.2000", "21.12.2000")]
        [DataRow("12.04.1999", "12.04.2002", "12.04.2001")]
        [DataRow("12.12.1998", "15.04.2005", "13.07.2002")]
        public void SortByBirthDate(string firstDate, string secondDate, string thirdDate)
        {
            //Arange
            bool expected = true;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22");
            var firstStudent = new Student(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), "Ivanov Ivan", 0, DateTime.Parse(firstDate), group.Id);
            var secondStudent = new Student(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "Ivanov Ivan", 0, DateTime.Parse(secondDate), group.Id);
            var thirdStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, DateTime.Parse(thirdDate), group.Id);
            group.Students = new List<Student> { firstStudent, secondStudent, thirdStudent };
            var expectedList = new List<Student> { firstStudent, thirdStudent, secondStudent  };
            bool result = false;
            //Act
            SorterByBirthDate sorter = new SorterByBirthDate();
            sorter.Sort(group);
            if (expectedList.SequenceEqual(group.Students))
                result = true;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(1, 0, 1)]
        public void SortBySex(int firstSex, int secondSex, int thirdSex)
        {
            //Arange
            bool expected = true;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22");
            var firstStudent = new Student(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), "Ivanov Ivan",(Sexes)firstSex, new DateTime(2001, 10, 12), group.Id);
            var secondStudent = new Student(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "Ivanov Ivan", (Sexes)secondSex, new DateTime(2001, 10, 12), group.Id);
            var thirdStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", (Sexes)thirdSex, new DateTime(2001, 10, 12), group.Id);
            group.Students = new List<Student> { firstStudent, secondStudent, thirdStudent };
            var expectedList = new List<Student> { secondStudent,firstStudent, thirdStudent };
            bool result = false;
            //Act
            SorterBySex sorter = new SorterBySex();
            sorter.Sort(group);
            if (expectedList.SequenceEqual(group.Students))
                result = true;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("Stepanov Ivan", "Borisov Ivan", "Alexandrov Ivan")]
        [DataRow("Fedorov Ivan", "Artemov Ivan", "Alexandrov Ivan")]
        [DataRow("Petrov Ivan", "Olegov Ivan", "Denisov Ivan")]
        public void SortByName(string firstName, string secondName, string thirdName)
        {
            //Arange
            bool expected = true;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22");
            var firstStudent = new Student(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), firstName, 0, new DateTime(2001, 10, 12), group.Id);
            var secondStudent = new Student(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), secondName, 0, new DateTime(2001, 10, 12), group.Id);
            var thirdStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), thirdName, 0, new DateTime(2001, 10, 12), group.Id);
            group.Students = new List<Student> { firstStudent, secondStudent, thirdStudent };
            var expectedList = new List<Student> { thirdStudent, secondStudent, firstStudent };
            bool result = false;
            //Act
            SorterByName sorter = new SorterByName();
            sorter.Sort(group);
            if (expectedList.SequenceEqual(group.Students))
                result = true;
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

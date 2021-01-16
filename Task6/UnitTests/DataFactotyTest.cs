using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionDataFactory;
using System.Collections.Generic;
using SessionData;

namespace UnitTests
{
    [TestClass]
    public class DataFactotyTest
    {
        [DataTestMethod]
        [DataRow("639d3794-d2ad-49ac-af4d-07da23e15169", "OOP", 10, "12.12.2021", "d15197cb-24ac-45b1-8986-0be3f0290cd3")]
        [DataRow("d508263b-d495-4ac3-8248-3f7adc43b33e", "Math",7, "12.01.2021", "bc81c2b7-15bb-4f16-aa29-5daa2e9a6e68")]
        [DataRow("de39bc98-f28f-4c5f-be77-6564a1d7d036", "Economic",4, "24.12.2021", "98cdd896-e098-4835-a969-9f9b4f768011")]
        public void CreateByName(string value1,string value2, int value3,string value4, string value5)
        {
            //Arange
            Exam expected = new Exam(Guid.Parse(value1), value2, value3, DateTime.Parse(value4), Guid.Parse(value5));
            List<object> values = new List<object>() { Guid.Parse(value1), value2, value3, DateTime.Parse(value4), Guid.Parse(value5) };
            //Act
            var result = BaseCreator.CreateByName("Exam",values);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("639d3794-d2ad-49ac-af4d-07da23e15169", "ITP-22")]
        [DataRow("d508263b-d495-4ac3-8248-3f7adc43b33e", "ITI-22")]
        [DataRow("de39bc98-f28f-4c5f-be77-6564a1d7d036", "IP-31")]
        public void CreateGroup(string value1, string value2)
        {
            //Arange
            Group expected = new Group(Guid.Parse(value1), value2);
            List<object> values = new List<object>() { Guid.Parse(value1), value2};
            var creator = new GroupCreator();
            //Act
            var result = creator.Create(values);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("639d3794-d2ad-49ac-af4d-07da23e15169", "OOP", 10, "12.12.2021", "d15197cb-24ac-45b1-8986-0be3f0290cd3")]
        [DataRow("d508263b-d495-4ac3-8248-3f7adc43b33e", "Math", 7, "12.01.2021", "bc81c2b7-15bb-4f16-aa29-5daa2e9a6e68")]
        [DataRow("de39bc98-f28f-4c5f-be77-6564a1d7d036", "Economic", 4, "24.12.2021", "98cdd896-e098-4835-a969-9f9b4f768011")]
        public void CreateExam(string value1, string value2, int value3, string value4, string value5)
        {
            //Arange
            Exam expected = new Exam(Guid.Parse(value1), value2, value3, DateTime.Parse(value4), Guid.Parse(value5));
            List<object> values = new List<object>() { Guid.Parse(value1), value2, value3, DateTime.Parse(value4), Guid.Parse(value5) };
            var creator = new ExamCreator();
            //Act
            var result = creator.Create(values);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("639d3794-d2ad-49ac-af4d-07da23e15169", "OOP", 1, "12.12.2021", "d15197cb-24ac-45b1-8986-0be3f0290cd3")]
        [DataRow("d508263b-d495-4ac3-8248-3f7adc43b33e", "Math", 0, "12.01.2021", "bc81c2b7-15bb-4f16-aa29-5daa2e9a6e68")]
        [DataRow("de39bc98-f28f-4c5f-be77-6564a1d7d036", "Economic", 1, "24.12.2021", "98cdd896-e098-4835-a969-9f9b4f768011")]
        public void CreateCredit(string value1, string value2, int value3, string value4, string value5)
        {
            //Arange
            Credit expected = new Credit(Guid.Parse(value1), value2,(CreditationTypes)value3, DateTime.Parse(value4), Guid.Parse(value5));
            List<object> values = new List<object>() { Guid.Parse(value1), value2, (CreditationTypes)value3, DateTime.Parse(value4), Guid.Parse(value5) };
            var creator = new CreditCreator();
            //Act
            var result = creator.Create(values);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("639d3794-d2ad-49ac-af4d-07da23e15169", "Ivanov Ivan", 0, "12.04.2002", "d15197cb-24ac-45b1-8986-0be3f0290cd3")]
        [DataRow("d508263b-d495-4ac3-8248-3f7adc43b33e", "Petrov Ivan", 1, "12.01.2001", "bc81c2b7-15bb-4f16-aa29-5daa2e9a6e68")]
        [DataRow("de39bc98-f28f-4c5f-be77-6564a1d7d036", "Sergeev Denis", 0, "24.03.1999", "98cdd896-e098-4835-a969-9f9b4f768011")]
        public void CreateStudent(string value1, string value2, int value3, string value4, string value5)
        {
            //Arange
            Student expected = new Student(Guid.Parse(value1), value2, (Sexes)value3, DateTime.Parse(value4), Guid.Parse(value5));
            List<object> values = new List<object>() { Guid.Parse(value1), value2, (Sexes)value3, DateTime.Parse(value4), Guid.Parse(value5) };
            var creator = new StudentCreator();
            //Act
            var result = creator.Create(values);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("639d3794-d2ad-49ac-af4d-07da23e15169", 1,0, "d15197cb-24ac-45b1-8986-0be3f0290cd3")]
        [DataRow("d508263b-d495-4ac3-8248-3f7adc43b33e", 2,0, "bc81c2b7-15bb-4f16-aa29-5daa2e9a6e68")]
        [DataRow("de39bc98-f28f-4c5f-be77-6564a1d7d036", 3,1, "98cdd896-e098-4835-a969-9f9b4f768011")]
        public void CreateSession(string value1, int value2,int value3, string value4)
        {
            //Arange
            Session expected = new Session(Guid.Parse(value1), value2,(Owners)value3,Guid.Parse(value4));
            List<object> values = new List<object>() { Guid.Parse(value1), value2, (Owners)value3, Guid.Parse(value4)};
            var creator = new SessionCreator();
            //Act
            var result = creator.Create(values);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

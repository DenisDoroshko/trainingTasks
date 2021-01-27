using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionData;
using Reports;
using System.Collections.Generic;
using System.Linq;
using Sorters;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class RepotsTest
    {
        private string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [DataTestMethod]
        [DataRow(5, 10)]
        [DataRow(6, 6)]
        [DataRow(5, 9)]
        public void AddAverageBySpecialty(int firstMark,int secondMark)
        {
            //Arange
            double expected = (firstMark + secondMark) / 2.0;
            Group firstGroup = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22", "Information Technology");
            Group secondGroup = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-21", "Information Technology");
            Session session = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 1, Owners.Group, firstGroup.Id);
            Student firstStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), firstGroup.Id);
            Student secondStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Petrov Petr", 0, new DateTime(2001, 10, 12), secondGroup.Id);
            Exam exam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OOP", null, new DateTime(2001, 10, 12), "Petrov Alexey", session.Id);
            session.Exams.Add(exam);
            firstGroup.Sessions.Add(session);
            firstGroup.Students.Add(firstStudent);
            secondGroup.Sessions.Add(session);
            secondGroup.Students.Add(secondStudent);
            firstGroup.SetSession(1);
            secondGroup.SetSession(1);
            firstStudent.Sessions[0].Exams[0].Mark = firstMark;
            secondStudent.Sessions[0].Exams[0].Mark = secondMark;
            var groups = new List<Group>() { firstGroup,secondGroup };
            //Act
            DataSaver.SaveAsXlsx($"{path}\\averageTest.xlsx", groups, 1, SortTypes.None);
            AverageMarkSaver.AddAverageBySpecialty($"{path}\\averageTest.xlsx",groups,1);
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workBook = excel.Workbooks.Open($"{path}\\averageTest.xlsx");
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
            double result = workSheet.Cells[2, 2].Value;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("Stepanov Ivan",10, 10)]
        [DataRow("Fedorov Ivan",6, 6)]
        [DataRow("Sidorov Ivan",5,2)]
        public void AddAverageByExaminer(string examinerName, int firstMark,int secondMark)
        {
            //Arange
            double expected = (firstMark + secondMark) / 2.0;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22", "Information Technology");
            Session session = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 1, Owners.Group, group.Id);
            Student firstStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Student secondStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Petrov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Exam exam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OOP", null, new DateTime(2001, 10, 12), examinerName, session.Id);
            session.Exams.Add(exam);
            group.Sessions.Add(session);
            group.Students.Add(firstStudent);
            group.Students.Add(secondStudent);
            group.SetSession(1);
            firstStudent.Sessions[0].Exams[0].Mark = firstMark;
            secondStudent.Sessions[0].Exams[0].Mark = secondMark;
            var groups = new List<Group>() { group };
            //Act
            DataSaver.SaveAsXlsx($"{path}\\averageExaminerTest.xlsx", groups, 1, SortTypes.None);
            AverageMarkSaver.AddAverageByExaminer($"{path}\\averageExaminerTest.xlsx", groups, 1);
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workBook = excel.Workbooks.Open($"{path}\\averageExaminerTest.xlsx");
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
            double result = workSheet.Cells[2, 2].Value;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(4, 10)]
        [DataRow(8, 6)]
        [DataRow(6, 2)]
        public void MakeDynamicsReport(int firstMark,int secondMark)
        {
            //Arange
            bool expected = true;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22", "Information Technology");
            Session firstSession = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 1, Owners.Group, group.Id);
            Session secondSession = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 2, Owners.Group, group.Id);
            Student student = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Exam firstExam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OOP", null, new DateTime(2019, 10, 12), "Petrov Alexey", firstSession.Id);
            Exam secondExam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OOP", null, new DateTime(2020, 10, 12), "Petrov Alexey", secondSession.Id);
            firstSession.Exams.Add(firstExam);
            secondSession.Exams.Add(secondExam);
            group.Sessions.Add(firstSession);
            group.Sessions.Add(secondSession);
            group.Students.Add(student);
            group.SetSession(1);
            group.SetSession(2);
            student.Sessions[0].Exams[0].Mark = firstMark;
            student.Sessions[1].Exams[0].Mark = secondMark;
            var groups = new List<Group>() { group };
            //Act
            DynamicsReportMaker.MakeDynamicsReport($"{path}\\dynamicsTest.xlsx", groups, SortingMode.Off);
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workBook = excel.Workbooks.Open($"{path}\\dynamicsTest.xlsx");
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
            bool result = false;
            if (workSheet.Cells[2, 2].Value == firstMark && workSheet.Cells[2, 3].Value == secondMark)
                result = true;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("Stepanov Ivan", 10)]
        [DataRow("Fedorov Ivan", 6)]
        [DataRow("Petrov Ivan", 2)]
        public void SaveAsXlsx(string studentName,int mark)
        {
            //Arange
            bool expected = true;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22","Information Technology");
            Session session = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 1, Owners.Group, group.Id);
            Student student = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), studentName, 0, new DateTime(2001, 10, 12), group.Id);
            Exam exam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"),"OOP",null, new DateTime(2001, 10, 12),"Petrov Alexey",session.Id);
            session.Exams.Add(exam);
            group.Sessions.Add(session);
            group.Students.Add(student);
            group.SetSession(1);
            student.Sessions[0].Exams[0].Mark =mark;
            var groups = new List<Group>() { group};
            //Act
            DataSaver.SaveAsXlsx($"{path}\\saverTest.xlsx", groups, 1, SortTypes.None);
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workBook = excel.Workbooks.Open($"{path}\\saverTest.xlsx");
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
            bool result = false;
            if (workSheet.Cells[2, 1].Value == student.FullName && workSheet.Cells[2, 2].Value == student.Sessions[0].Exams[0].Mark)
                result = true;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(4, 8,6,6,8,4)]
        [DataRow(7, 8, 9, 8, 9, 7)]
        [DataRow(4, 3, 5, 4, 5, 3)]
        public void MakePivotTable(int firstMark,int secondMark,int thirdMark,int average,int max,int min)
        {
            //Arange
            bool expected = true;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22", "Information Technology");
            Session session = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 1, Owners.Group, group.Id);
            Student student = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Exam firstExam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OOP", null, new DateTime(2001, 10, 12),"Petrov Alexey", session.Id);
            Exam secondExam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "Math", null, new DateTime(2001, 10, 12), "Petrov Alexey", session.Id);
            Exam thirdExam =new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OS", null, new DateTime(2001, 10, 12), "Petrov Alexey", session.Id);
            session.Exams = new List<Exam>() { firstExam ,secondExam,thirdExam};
            group.Sessions.Add(session);
            group.Students.Add(student);
            group.SetSession(1);
            student.Sessions[0].Exams[0].Mark = firstMark;
            student.Sessions[0].Exams[1].Mark = secondMark;
            student.Sessions[0].Exams[2].Mark = thirdMark;
            var groups = new List<Group>() { group };
            //Act
            DataSaver.SaveAsXlsx($"{path}\\saverTest.xlsx", groups, 1, SortTypes.None);
            PivotTableMaker.MakePivotTable($"{path}\\saverTest.xlsx");
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workBook = excel.Workbooks.Open($"{path}\\saverTest.xlsx");
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
            bool result = false;
            if (workSheet.Cells[2, 2].Value == average && workSheet.Cells[2, 3].Value == max && workSheet.Cells[2, 4].Value == min)
                result = true;
            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        [DataRow(10, 10,2)]
        [DataRow(2, 2,3)]
        [DataRow(10, 9,7)]
        public void MakeStudentsList(int firstMark,int secondMark,int thirdMark)
        {
            //Arange
            bool expected = true;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22", "Information Technology");
            Session session = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 1, Owners.Group, group.Id);
            Student firstStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Student secondStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Student thirdStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Exam exam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OOP", null, new DateTime(2001, 10, 12),"Petrov Alexey", session.Id);
            session.Exams.Add(exam);
            group.Sessions.Add(session);
            group.Students = new List<Student>() { firstStudent,secondStudent,thirdStudent};
            group.SetSession(1);
            firstStudent.Sessions[0].Exams[0].Mark = firstMark;
            secondStudent.Sessions[0].Exams[0].Mark = secondMark;
            thirdStudent.Sessions[0].Exams[0].Mark = thirdMark;
            var expectedList = new List<Student>();
            foreach (var student in group.Students)
                if (student.Sessions[0].Exams[0].Mark < 4)
                    expectedList.Add(student);
            var groups = new List<Group>() { group };
            //Act
            var expelledList = StudentsListMaker.MakeExpelledList(groups);
            bool result = false;
            if (expelledList.SequenceEqual(expectedList))
                result = true;
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

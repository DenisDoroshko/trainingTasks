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
        [DataRow("Stepanov Ivan", 10)]
        [DataRow("Fedorov Ivan", 6)]
        [DataRow("Petrov Ivan", 2)]
        public void SaveAsXlsx(string studentName,int mark)
        {
            //Arange
            bool expected = true;
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22");
            Session session = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 1, Owners.Group, group.Id);
            Student student = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), studentName, 0, new DateTime(2001, 10, 12), group.Id);
            Exam exam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"),"OOP",null, new DateTime(2001, 10, 12),session.Id);
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
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22");
            Session session = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 1, Owners.Group, group.Id);
            Student student = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Exam firstExam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OOP", null, new DateTime(2001, 10, 12), session.Id);
            Exam secondExam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "Math", null, new DateTime(2001, 10, 12), session.Id);
            Exam thirdExam =new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OS", null, new DateTime(2001, 10, 12), session.Id);
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
            Group group = new Group(Guid.Parse("98cdd896-e098-4835-a969-9f9b4f768011"), "ITP-22");
            Session session = new Session(Guid.Parse("639d3794-d2ad-49ac-af4d-07da23e15169"), 1, Owners.Group, group.Id);
            Student firstStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Student secondStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Student thirdStudent = new Student(Guid.Parse("de39bc98-f28f-4c5f-be77-6564a1d7d036"), "Ivanov Ivan", 0, new DateTime(2001, 10, 12), group.Id);
            Exam exam = new Exam(Guid.Parse("d508263b-d495-4ac3-8248-3f7adc43b33e"), "OOP", null, new DateTime(2001, 10, 12), session.Id);
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

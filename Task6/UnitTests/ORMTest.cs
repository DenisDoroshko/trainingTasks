﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
using ORM;
using System.Reflection;

namespace UnitTests
{
    [TestClass]
    public class ORMTest
    {
        private static string sqlServerPath = @".\SQLEXPRESS";
        public static void MakeDB()
        {
            SqlConnection connection = new SqlConnection($"Server={sqlServerPath};Integrated security=True;database=master");
            string script = File.ReadAllText(@"..\..\..\scriptSql.sql");
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            script =script.Replace(@"D:\", $@"{currentPath}\");
            var commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            connection.Open();
            bool isExist = false;
            for(var i = 0; i < commandStrings.Length && !isExist; i++) 
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(commandStrings[i].Trim()))
                    {
                        SqlCommand command = new SqlCommand(commandStrings[i], connection);
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    isExist = true;
                }
            }
            connection.Close();
        }
        public static void DeleteDB()
        {
            using (SqlConnection connection = new SqlConnection($"Server={sqlServerPath};Integrated security=True;database=master"))
            {
                connection.Open();
                string sqlCommandText = "ALTER DATABASE dbTask6\nSET SINGLE_USER WITH ROLLBACK IMMEDIATE;\nDROP DATABASE [dbTask6]";
                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        [DataTestMethod]
        [DataRow("ITI-41")]
        [DataRow("ITP-32")]
        [DataRow("EP-41")]
        public void InsertElement(string groupName)
        {
            //Arange
            var initialGroup = new SessionData.Group(Guid.NewGuid(), groupName);
            //Act
            MakeDB();
            DataRepository repository = new DataRepository($"data source ={sqlServerPath}; Initial Catalog =dbTask6; Integrated Security = True");
            repository.Insert(initialGroup);
            repository.SaveAllChanges();
            var resultGroup = repository.FindById<SessionData.Group>(initialGroup.Id);
            DeleteDB();
            //Assert
            Assert.AreEqual(initialGroup, resultGroup);
        }

        [DataTestMethod]
        [DataRow("Ivanov Ivan")]
        [DataRow("Petrov Ivan")]
        [DataRow("Sergeev Ivan")]
        public void DeleteElement(string name)
        {
            //Arange
            Student expected = null;
            SessionData.Group group= new SessionData.Group(Guid.NewGuid(), "IP-22");
            var initialStudent = new Student(Guid.NewGuid(), name,Sexes.Male,new DateTime(2020,12,12), group.Id);
            //Act
            MakeDB();
            DataRepository repository = new DataRepository($"data source ={sqlServerPath}; Initial Catalog =dbTask6; Integrated Security = True");
            repository.Insert(group);
            repository.Insert(initialStudent);
            repository.Delete(initialStudent);
            repository.SaveAllChanges();
            var resultStudent = repository.FindById<Student>(initialStudent.Id);
            DeleteDB();
            //Assert
            Assert.AreEqual(expected, resultStudent);
        }

        [DataTestMethod]
        [DataRow("Ivanov Ivan")]
        [DataRow("Petrov Ivan")]
        [DataRow("Sergeev Ivan")]
        public void UpdateElement(string name)
        {
            //Arange
            SessionData.Group group = new SessionData.Group(Guid.NewGuid(), "IP-22");
            var initialStudent = new Student(Guid.NewGuid(), name, Sexes.Male, new DateTime(2020, 12, 12), group.Id);
            //Act
            MakeDB();
            DataRepository repository = new DataRepository($"data source ={sqlServerPath}; Initial Catalog =dbTask6; Integrated Security = True");
            repository.Insert(group);
            repository.Insert(initialStudent);
            initialStudent.FullName = "New Name";
            repository.Update(initialStudent);
            repository.SaveAllChanges();
            var resultStudent = repository.FindById<Student>(initialStudent.Id);
            DeleteDB();
            //Assert
            Assert.AreEqual(initialStudent, resultStudent);
        }

        [DataTestMethod]
        [DataRow("IP-41", "ITI-41")]
        [DataRow("ITP-32", "IP-21")]
        [DataRow("ITI-41", "ITI-41")]
        public void Getlements(string firstName,string secondName)
        {
            //Arange
            bool expected = false;
            var firstGroup = new SessionData.Group(Guid.NewGuid(),firstName);
            var secondGroup = new SessionData.Group(Guid.NewGuid(), secondName);
            bool result = false;
            //Act
            MakeDB();
            DataRepository repository = new DataRepository($"data source ={sqlServerPath}; Initial Catalog =dbTask6; Integrated Security = True");
            repository.Insert(firstGroup);
            repository.Insert(secondGroup);
            repository.SaveAllChanges();
            var resultGroups = repository.Get<SessionData.Group>();
            if (repository.Groups.SequenceEqual(resultGroups))
                result = true;
            DeleteDB();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("OOP")]
        [DataRow("Math")]
        [DataRow("History")]
        public void SetSession(string  examName)
        {
            //Arange
            string expected = examName;
            var group = new SessionData.Group(Guid.NewGuid(), "ITP-33");
            var student = new Student(Guid.Parse("165fec7b-be0a-467f-b68d-9e17ab86c846"), "Ivanov Ivan", Sexes.Male, new DateTime(2020, 12, 12), group.Id);
            var session = new Session(Guid.NewGuid(), 1, Owners.Group, group.Id);
            var exam = new Exam(Guid.NewGuid(), examName, null, new DateTime(2020, 12, 12), session.Id);
            session.Exams.Add(exam);
            //Act
            MakeDB();
            DataRepository repository = new DataRepository($"data source ={sqlServerPath}; Initial Catalog =dbTask6; Integrated Security = True");
            repository.Insert(group);
            repository.SaveAllChanges();
            repository.Insert(student);
            repository.Insert(session);
            repository.SaveAllChanges();
            repository.Insert(exam);
            repository.SaveAllChanges();
            repository.SetSession(repository.FindById<SessionData.Group>(group.Id),1);
            repository.SaveAllChanges();
            DeleteDB();
            var result = repository.FindById<Student>(student.Id).Sessions[0].Exams[0].Name;
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

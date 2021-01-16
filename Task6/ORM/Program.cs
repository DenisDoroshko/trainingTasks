using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;
using Reports;
using Sorters;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataRepository myData = new DataRepository("data source =.\\SQLEXPRESS; Initial Catalog =task6db; Integrated Security = True");
            //myData.Insert(new Group(Guid.NewGuid(), "IP-21"));
            //myData.Insert(new Group(Guid.NewGuid(), "ITP-21"));
            //myData.Insert(new Group(Guid.NewGuid(), "ITI-21"));
            //myData.SaveAllChanges();
            //myData.Insert(new Student(Guid.NewGuid(), "Ivanov Denis", Sexes.Male, DateTime.Parse("20.12.2000"), myData.Groups[0].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Petrov Alexander", Sexes.Male, DateTime.Parse("20.03.2001"), myData.Groups[0].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Ivanova Alexandra", Sexes.Female, DateTime.Parse("12.11.2000"), myData.Groups[0].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Denisov Sergei", Sexes.Male, DateTime.Parse("15.12.2000"), myData.Groups[0].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Pushkina Olga", Sexes.Female, DateTime.Parse("03.10.2000"), myData.Groups[0].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Ivanova Karina", Sexes.Female, DateTime.Parse("15.12.2000"), myData.Groups[0].Id));

            //myData.Insert(new Student(Guid.NewGuid(), "Ivanov Boris", Sexes.Male, DateTime.Parse("20.12.2000"), myData.Groups[1].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Alexandrow Alexander", Sexes.Male, DateTime.Parse("20.03.2001"), myData.Groups[1].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Elizarov Alexander", Sexes.Male, DateTime.Parse("12.11.2000"), myData.Groups[1].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Denisov Sergei", Sexes.Male, DateTime.Parse("15.12.2000"), myData.Groups[1].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Pushkina Olga", Sexes.Female, DateTime.Parse("03.10.2000"), myData.Groups[1].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Ivanova Karina", Sexes.Female, DateTime.Parse("15.12.2000"), myData.Groups[1].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Borisov Nikita", Sexes.Male, DateTime.Parse("03.10.2000"), myData.Groups[1].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Borisova Karina", Sexes.Female, DateTime.Parse("15.12.2000"), myData.Groups[1].Id));

            //myData.Insert(new Student(Guid.NewGuid(), "Ivanova Karina", Sexes.Female, DateTime.Parse("15.12.2000"), myData.Groups[2].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Borisov Nikita", Sexes.Male, DateTime.Parse("03.10.2000"), myData.Groups[2].Id));
            //myData.Insert(new Student(Guid.NewGuid(), "Borisova Karina", Sexes.Female, DateTime.Parse("15.12.2000"), myData.Groups[2].Id));
            //var ses1 = new Session(Guid.NewGuid(), 1, myData.Groups[0].Id, Owners.Group);
            //myData.Insert(ses1);
            //var ses2 = new Session(Guid.NewGuid(), 1, myData.Groups[1].Id, Owners.Group);
            //myData.Insert(ses2);
            //var ses3 = new Session(Guid.NewGuid(), 1, myData.Groups[2].Id, Owners.Group);
            //myData.Insert(ses3);
            //myData.SaveAllChanges();
            //myData.Insert(new Exam(Guid.NewGuid(), "OOP", DateTime.Parse("15.01.2021"), ses1.Id, null));
            //myData.Insert(new Exam(Guid.NewGuid(), "KS", DateTime.Parse("10.01.2021"), ses1.Id, null));
            //myData.Insert(new Exam(Guid.NewGuid(), "Economic", DateTime.Parse("19.01.2021"), ses1.Id, null));
            //myData.Insert(new Credit(Guid.NewGuid(), "Math", DateTime.Parse("19.12.2020"), ses1.Id, null));

            //myData.Insert(new Exam(Guid.NewGuid(), "OAIP", DateTime.Parse("15.01.2021"), ses2.Id, null));
            //myData.Insert(new Exam(Guid.NewGuid(), "Math", DateTime.Parse("10.01.2021"), ses2.Id, null));
            //myData.Insert(new Exam(Guid.NewGuid(), "OS", DateTime.Parse("19.01.2021"), ses2.Id, null));
            //myData.Insert(new Credit(Guid.NewGuid(), "Python", DateTime.Parse("19.12.2020"), ses2.Id, null));
            //myData.Insert(new Credit(Guid.NewGuid(), "PE", DateTime.Parse("25.12.2020"), ses2.Id, null));

            //myData.Insert(new Exam(Guid.NewGuid(), "English", DateTime.Parse("15.01.2021"), ses3.Id, null));
            //myData.Insert(new Exam(Guid.NewGuid(), "Economic", DateTime.Parse("10.01.2021"), ses3.Id, null));
            //myData.Insert(new Exam(Guid.NewGuid(), "OS", DateTime.Parse("19.01.2021"), ses3.Id, null));
            //myData.Insert(new Credit(Guid.NewGuid(), "Python", DateTime.Parse("24.12.2020"), ses3.Id, null));
            //myData.Insert(new Credit(Guid.NewGuid(), "History", DateTime.Parse("19.12.2020"), ses3.Id, null));
            //myData.Insert(new Credit(Guid.NewGuid(), "PE", DateTime.Parse("26.12.2020"), ses3.Id, null));

            //myData.SaveAllChanges();
            //myData.SetSession(myData.Groups[0], 1);
            //myData.SetSession(myData.Groups[1], 1);
            //myData.SetSession(myData.Groups[2], 1);
            //myData.SaveAllChanges();
            //Console.WriteLine(myData.Students[0].Sessions[0].Exams[0].Mark);
            //myData.SaveAllChanges();
            //DataSaver.SaveAsXlsx("D:\\save9.xlsx", myData.Groups, 1, SortTypes.SortBySex);
            //PivotTableMaker.MakePivotTable("D:\\save9.xlsx");
            DataBaseMaker.MakeDB();
            Console.WriteLine("full");
            Console.ReadLine();
        }
    }
}

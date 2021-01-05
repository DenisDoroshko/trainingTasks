using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SessionData;
using System.Reflection;

namespace ORM
{
    public class DataRepository:IDAO
    {
        private AccessDB access;
        public DataRepository(string stringConnection)
        {
            access = new AccessDB(stringConnection);
            Groups = Get<Group>();
            Students = Get<Student>();
            Sessions = Get<Session>();
            Exams = Get<Exam>();
            Credits = Get<Credit>();
            SetLinks();
        }
        public List<Group> Groups { get; set; }
        public List<Student> Students { get; set; }
        public List<Session> Sessions { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Credit> Credits { get; set; }
        public void Insert<T>(T element)
        {
            access.Insert(element);
        }
        public void Update<T>(T element)
        {
            access.Update(element);
        }
        public void Delete<T>(T element)
        {
            access.Delete(element);
        }
        public List<T> Get<T>()
        {
            return access.Get<T>();
        }
        public void SaveAllChanges()
        {
            SaveChanges(Groups);
            SaveChanges(Students);
            SaveChanges(Sessions);
            SaveChanges(Exams);
            SaveChanges(Credits);
        }
        private void SaveChanges<T>(List<T> elements)
        {
            for(var i = 0; i < elements.Count; i++) 
            {
                FieldInfo field = typeof(T).GetField("IsSaved");
                bool isSaved = (bool)field.GetValue(elements[i]);
                if (isSaved == false)
                {
                    Update(elements[i]);
                    field.SetValue(elements[i], true);
                }
                int elementId = (int)typeof(T).GetProperty("Id").GetValue(elements[i]);
                if (elementId == 0)
                {
                    Insert(elements[i]);
                }
            }
        }
        private void SetLinks()
        {
            foreach(var student in Students)
            {
                var group=FindById(Groups, student.GroupId);
                group?.Students.Add(student);
            }
            foreach (var session in Sessions)
            {
                var group = FindById(Groups, session.OwnerId);
                var student = FindById(Students, session.OwnerId);
                group?.Sessions.Add(session);
                student?.Sessions.Add(session);
            }
            foreach (var exam in Exams)
            {
                var session = FindById(Sessions, exam.SessionId);
                session?.Exams.Add(exam);
            }
            foreach (var credit in Credits)
            {
                var session = FindById(Sessions, credit.SessionId);
                session?.Credits.Add(credit);
            }
        }
        private T FindById<T>(List<T> elements,int givenId)
        {
            T foundElement = default;
            bool isFound = false;
            for(var i = 0; i < elements.Count&&isFound!=true; i++)
            {
                int elementId = (int)typeof(T).GetProperty("Id").GetValue(elements[i]);
                if (elementId == givenId)
                {
                    isFound = true;
                    foundElement = elements[i];
                }
            }
            return foundElement;
        }
    }
}

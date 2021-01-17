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
    /// <summary>
    /// Representts a class for a working with database and store elements
    /// </summary>
    
    public class DataRepository:IDAO
    {
        /// <summary>
        /// Access to the database
        /// </summary>
        
        private AccessDB access;

        /// <summary>
        /// Creates an instance of the DataRepository class
        /// </summary>
        /// <param name="stringConnection">Connection string</param>
        
        public DataRepository(string stringConnection)
        {
            access = new AccessDB(stringConnection);
            GetAllElements();
        }

        /// <summary>
        /// All groups in database
        /// </summary>
        
        public List<Group> Groups { get; set; }

        /// <summary>
        /// All students in database
        /// </summary>

        public List<Student> Students { get; set; }

        /// <summary>
        /// All sessions in database
        /// </summary>

        public List<Session> Sessions { get; set; }

        /// <summary>
        /// All exams in database
        /// </summary>

        public List<Exam> Exams { get; set; }

        /// <summary>
        /// All credits in database
        /// </summary>
        
        public List<Credit> Credits { get; set; }

        /// <summary>
        /// Inserts element to the database
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="element">Element</param>

        public void Insert<T>(T element)
        {
            access.Insert(element);
        }


        /// <summary>
        /// Updates data about specified element
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="element">Specified element</param>

        public void Update<T>(T element)
        {
            access.Update(element);
        }

        /// <summary>
        /// Deletes specified element from database table
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="element">Specififed element</param>

        public void Delete<T>(T element)
        {
            access.Delete(element);
        }

        /// <summary>
        /// Gets all elements in database table by type
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <returns>List of objects</returns>

        public List<T> Get<T>()
        {
            return access.Get<T>();
        }

        /// <summary>
        /// Gets all elements stored in database
        /// </summary>
        
        private void GetAllElements()
        {
            Groups = Get<Group>();
            Students = Get<Student>();
            Sessions = Get<Session>();
            Exams = Get<Exam>();
            Credits = Get<Credit>();
            SetLinks();
        }

        /// <summary>
        /// Save all changes and update list of elelements in repository
        /// </summary>
        
        public void SaveAllChanges()
        {
            SaveChanges(Groups);
            SaveChanges(Students);
            SaveChanges(Sessions);
            SaveChanges(Exams);
            SaveChanges(Credits);
            GetAllElements();
        }

        /// <summary>
        /// Saves changes by specified list of elements
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="elements">Elements</param>
        private void SaveChanges<T>(List<T> elements)
        {
            for(var i = 0; i < elements.Count; i++) 
            {
                FieldInfo field = elements[i].GetType().GetField("IsChanged");
                bool isChanged= (bool)field.GetValue(elements[i]);
                if (isChanged == true)
                {
                    Update(elements[i]);
                    field.SetValue(elements[i], false);
                }
            }
        }

        /// <summary>
        /// Adds session to all students of the group and inserts all added elements to the database
        /// </summary>
        /// <param name="group">Selected group</param>
        /// <param name="sessionNumber">Session number</param>
        
        public void SetSession(Group group,int sessionNumber)
        {
                var newSessions = group.SetSession(sessionNumber);
                foreach(var session in newSessions)
                {
                    Insert(session);
                    foreach (var exam in session.Exams)
                        Insert(exam);
                    foreach (var credit in session.Credits)
                        Insert(credit);
                }
        }

        /// <summary>
        /// Sets all links by specified owner id in properties
        /// </summary>
        
        private void SetLinks()
        {
            foreach(var student in Students)
            {
                var group=FindById<Group>(student.GroupId);
                group?.Students.Add(student);
            }
            foreach (var session in Sessions)
            {
                if (session.GroupId != null)
                {
                    var group = FindById<Group>((Guid)session.GroupId);
                    group?.Sessions.Add(session);
                }
                else
                {
                    var student = FindById<Student>((Guid)session.StudentId);
                    student?.Sessions.Add(session);
                }
            }
            foreach (var exam in Exams)
            {
                var session = FindById<Session>(exam.SessionId);
                session?.Exams.Add(exam);
            }
            foreach (var credit in Credits)
            {
                var session = FindById<Session>(credit.SessionId);
                session?.Credits.Add(credit);
            }
        }

        /// <summary>
        /// Find element in lists by id
        /// </summary>
        /// <typeparam name="T">Type in database table</typeparam>
        /// <param name="givenId">Given id</param>
        /// <returns>Found element</returns>
        public T FindById<T>(Guid givenId)
        {

            T foundElement = default;
            bool isFound = false;
            List<T> elements = (List<T>)typeof(DataRepository).GetProperty($"{typeof(T).Name}s").GetValue(this);
            for (var i = 0; i < elements.Count&&isFound!=true; i++)
            {
                Guid elementId = (Guid)typeof(T).GetProperty("Id").GetValue(elements[i]);
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

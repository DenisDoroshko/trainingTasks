using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionData
{
    public enum Sexes
    {
        None,
        Male,
        Female
    }
    public class Student:IData
    {
        public Student(int id,string fullName,Sexes sex,DateTime birthDate,int gropuId)
        {
            Id = id;
            FullName = fullName;
            Sex = sex;
            BirthDate = birthDate;
            GroupId = gropuId;
        }
        private int id;
        public int Id { get => id; set {id=value;isSaved = false; } }
        private string fullName;
        public string FullName { get => fullName; set { fullName = value; isSaved = false; } }
        private Sexes sex;
        public Sexes Sex { get => sex; set { sex = value; isSaved = false; } }
        private DateTime birthDate;
        public DateTime BirthDate { get => birthDate; set { birthDate = value; isSaved = false; } }
        private int groupId;
        public int GroupId { get => groupId; set { groupId = value; isSaved = false; } }
        
        public List<Session> Sessions;

        public bool isSaved = false;
    }
}

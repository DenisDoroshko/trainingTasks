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
        public int Id { get; set; }
        public string FullName { get; set; }
        public Sexes Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public int GroupId { get; set; }
        public List<Session> Sessions;
    }
}

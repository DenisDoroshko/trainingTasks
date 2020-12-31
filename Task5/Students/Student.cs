using System;

namespace Students
{
    /// <summary>
    /// Represents a test results
    /// </summary>
    
    [Serializable]
    public class Student: IComparable
    {
        /// <summary>
        /// Creates an instance of Student class
        /// </summary>
        
        public Student()
        {

        }

        /// <summary>
        /// Creates an instance of Student class
        /// </summary>
        /// <param name="fullName">Full name of student</param>
        /// <param name="testName">Test name</param>
        /// <param name="testingDate">Testing date</param>
        /// <param name="testMark">Test mark</param>
        
        public Student(string fullName,string testName,DateTime testingDate,int testMark)
        {
            FullName = fullName;
            TestName = testName;
            TestingDate = testingDate;
            TestMark = testMark;
        }

        /// <summary>
        /// Full name of  the student
        /// </summary>
        
        public string FullName { get; set; }

        /// <summary>
        /// Test name
        /// </summary>
        
        public string TestName { get; set; }

        /// <summary>
        /// Testing date
        /// </summary>
        
        public DateTime TestingDate { get; set; }

        /// <summary>
        /// Test mark
        /// </summary>
        
        public int TestMark { get; set; }

        /// <summary>
        /// Compares test results by test date
        /// </summary>
        /// <param name="obj">Second student</param>
        /// <returns>Result of a comparison</returns>
        
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Student otherStudent = (Student)obj;
            if (otherStudent != null)
            {
                return TestingDate.CompareTo(otherStudent.TestingDate);
            }
            else
            {
                throw new ArgumentException("Object is not a Student");
            }
        }

        /// <summary>
        /// Converts node to string
        /// </summary>
        /// <returns>String represention of the class</returns>
        
        public override string ToString()
        {
            return $"Full name: {FullName} Test name: {TestName} Date: {TestingDate} Mark: {TestMark}";
        }

        /// <summary>
        /// Redefining the Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false</returns>
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                Student student = (Student)obj;
                return FullName == student.FullName && TestName == student.TestName && TestingDate == student.TestingDate && 
                    TestMark == student.TestMark;
            }
        }

        /// <summary>
        /// Redefining the GetHashCode method that calculates the hash code of the current object
        /// </summary>
        /// <returns>Hash code of the current object</returns>
        
        public override int GetHashCode()
        {
            return TestMark;
        }
    }
}

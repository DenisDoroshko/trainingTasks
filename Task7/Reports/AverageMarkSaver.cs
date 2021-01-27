using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;
using Excel = Microsoft.Office.Interop.Excel;

namespace Reports
{
    /// <summary>
    /// Representts a class for adding sheets with average marks by specialty and examiner
    /// </summary>

    public static class AverageMarkSaver
    {
        /// <summary>
        /// Add a sheet with average marks by specialty
        /// </summary>
        /// <param name="path">Workbook path</param>
        /// <param name="groups">Groups</param>
        /// <param name="sessionNumber">Session number</param>
        
        public static void AddAverageBySpecialty(string path, List<Group> groups, int sessionNumber)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workBook = excel.Workbooks.Open(path);
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets.Add();
            workSheet.Name = "Average marks by specialty";
            workSheet.Cells[1, 1] = "Specialty name";
            workSheet.Cells[1, 2] = "Average mark";
            List<string> specialties = new List<string>();
            int row = 2;
            foreach(var group in groups)
            {
                if(!specialties.Contains(group.Specialty))
                {
                    specialties.Add(group.Specialty);
                    workSheet.Cells[row, 1] = group.Specialty.Trim();
                    workSheet.Cells[row, 2] = Math.Round(GetAverageBySpecialty(groups, group.Specialty,sessionNumber),1);
                    row++;
                }
            }
            workSheet.Columns.EntireColumn.AutoFit();
            workBook.SaveAs(path);
        }

        /// <summary>
        /// Add a sheet with average marks by specialty
        /// </summary>
        /// <param name="path">Workbook path</param>
        /// <param name="groups">Student groups</param>
        /// <param name="sessionNumber">Session number</param>
        
        public static void AddAverageByExaminer(string path, List<Group> groups, int sessionNumber)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workBook = excel.Workbooks.Open(path);
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets.Add();
            workSheet.Name = "Average marks by examiner";
            workSheet.Cells[1, 1] = "Examiner name";
            workSheet.Cells[1, 2] = "Average mark";
            List<string> examiners = new List<string>();
            int row = 2;
            foreach (var group in groups)
            {
                var session = group.Sessions.FirstOrDefault(i => i.Number == sessionNumber);
                foreach (var exam in session.Exams)
                {
                    if (!examiners.Contains(exam.Examiner))
                    {
                        examiners.Add(exam.Examiner);
                        workSheet.Cells[row, 1] = exam.Examiner.Trim();
                        workSheet.Cells[row, 2] = Math.Round(GetAverageByExaminer(groups, exam.Examiner, sessionNumber),1);
                        row++;
                    }
                }
            }
            workSheet.Columns.EntireColumn.AutoFit();
            workBook.SaveAs(path);
        }

        /// <summary>
        /// Gets average mark by given specialty
        /// </summary>
        /// <param name="groups">Student groups</param>
        /// <param name="specialty">Given specialty</param>
        /// <param name="sessionNumber">Session number</param>
        /// <returns>Average mark</returns>
        
        private static double GetAverageBySpecialty(List<Group> groups,string specialty,int sessionNumber)
        {
            double sumAverage = 0;
            int count = 0;
            foreach (var group in groups)
            {
                if (group.Specialty == specialty)
                {
                    foreach(var student in group.Students)
                    {
                        var studentSession = student.Sessions.FirstOrDefault(i => i.Number == sessionNumber);
                        if (studentSession != null)
                        {
                            if (studentSession.Exams.All(t => t.Mark != null) && studentSession.Credits.All(u => u.Creditation != null))
                            {
                                sumAverage += (double)studentSession.Exams.Average(exam => exam.Mark);
                                count++;
                            }
                        }
                    }
                }
            }
            return count != 0 ? sumAverage / count : 0;
        }

        /// <summary>
        /// Gets average mark by given examiner
        /// </summary>
        /// <param name="groups">Student groups</param>
        /// <param name="examiner">Given examiner</param>
        /// <param name="sessionNumber">Session number</param>
        /// <returns>Average mark</returns>

        private static double GetAverageByExaminer(List<Group> groups, string examiner, int sessionNumber)
        {
            double sumAverage = 0;
            int count = 0;
            foreach (var group in groups)
            {
                foreach (var student in group.Students)
                {
                    var studentSession = student.Sessions.FirstOrDefault(i => i.Number == sessionNumber);
                    if (studentSession != null) 
                    {
                        if (studentSession.Exams.All(t => t.Mark != null) && studentSession.Credits.All(u => u.Creditation != null))
                        {
                            var exams = studentSession.Exams.Where(exam => exam.Examiner == examiner);
                            if (exams.Count()!=0)
                            {
                                sumAverage += (double)exams.Average(exam => exam.Mark);
                                count++;
                            }
                        }
                    }
                }
            }
            return count !=0 ? sumAverage / count : 0;
        }
    }
}

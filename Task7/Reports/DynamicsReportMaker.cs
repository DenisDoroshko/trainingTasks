using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using SessionData;

namespace Reports
{
    /// <summary>
    /// Shows whether to sort exams or not
    /// </summary>
    public enum SortingMode
    {
        /// <summary>
        /// Sorting off
        /// </summary>
        
        Off,

        /// <summary>
        /// Sorting on
        /// </summary>
        
        On
    }

    /// <summary>
    /// Representts a class for making a table with the dinamics of changes in the average mark by years
    /// </summary>
    
    public static class DynamicsReportMaker
    {
        /// <summary>
        /// Makes a table with the dinamics of changes in the average mark by years
        /// </summary>
        /// <param name="path">Save path</param>
        /// <param name="groups">Student groups</param>
        /// /// <param name="sortingMode">Sort mode</param>
        
        public static void MakeDynamicsReport(string path,List<Group> groups, SortingMode sortingMode)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.Add();
            FillSheet(workSheet, groups, sortingMode);
            excelApp.DisplayAlerts = false;
            workBook.SaveAs(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }

        /// <summary>
        /// Fills given sheet with data
        /// </summary>
        /// <param name="workSheet">Given sheet</param>
        /// <param name="groups">Student groups</param>
        /// <param name="sortingMode">Sorting mode</param>
        
        private static void FillSheet(Excel.Worksheet workSheet, List<Group> groups, SortingMode sortingMode)
        {
            workSheet.Name = $"Average mark dynamics";
            var examNames = GetExams(groups,sortingMode);
            var years = GetYears(groups);
            int row = 2;
            foreach (var examName in examNames)
            {
                workSheet.Cells[row, 1] = examName.Trim();
                int column = 2;
                foreach (var year in years)
                {
                    workSheet.Cells[1, column] = year;
                    workSheet.Cells[row, column] = Math.Round(GetAverage(groups, examName, year),1);
                    column++;
                }
                row++;
            }
            workSheet.Columns.EntireColumn.AutoFit();
        }

        /// <summary>
        /// Gets all years
        /// </summary>
        /// <param name="groups">Student groups</param>
        /// <returns>Years list</returns>

        private static List<int> GetYears(List<Group> groups)
        {
            var years = new List<int>();
            foreach(var group in groups)
            {
                foreach(var session in group.Sessions)
                {
                    foreach(var exam in session.Exams)
                    {
                        if (!years.Contains(exam.Date.Year))
                            years.Add(exam.Date.Year);
                    }
                }
            }
            years.Sort();
            return years;
        }

        /// <summary>
        /// Gets all exam names
        /// </summary>
        /// <param name="groups">Student group</param>
        /// <param name="sortingMode">Soring mode</param>
        /// <returns>List of exam names</returns>
        
        private static List<string> GetExams(List<Group> groups, SortingMode sortingMode)
        {
            var examNames = new List<string>();
            foreach (var group in groups)
            {
                foreach (var session in group.Sessions)
                {
                    foreach (var exam in session.Exams)
                    {
                        if (!examNames.Contains(exam.Name))
                            examNames.Add(exam.Name);
                    }
                }
            }
            if (sortingMode == SortingMode.On)
                examNames.Sort();
            return examNames;
        }
    
        /// <summary>
        /// Gets average mark by selected exam and year
        /// </summary>
        /// <param name="groups">Student groups</param>
        /// <param name="examName">Exam name</param>
        /// <param name="year">Year</param>
        /// <returns>Average mark</returns>
        
        private static double GetAverage(List<Group> groups,string examName,int year)
        {
            var marksSum = 0.0;
            int marksNumber = 0;
            foreach (var group in groups)
            {
                foreach (var student in group.Students)
                {
                    foreach (var session in student.Sessions)
                    {
                        if (session.Exams.All(t => t.Mark != null) && session.Credits.All(u => u.Creditation != null))
                        {
                            foreach (var exam in session.Exams)
                            {
                                if (exam.Name == examName && exam.Date.Year == year)
                                {
                                    marksSum += (int)exam.Mark;
                                    marksNumber++;
                                }
                            }
                        }
                    }
                }
            }
            return marksNumber != 0 ? marksSum / marksNumber : 0;
        }
    }
}

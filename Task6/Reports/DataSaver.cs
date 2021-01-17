﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using SessionData;
using Sorters;

namespace Reports
{
    /// <summary>
    /// Representts a class for a saving data
    /// </summary>
    
    public class DataSaver
    {
        /// <summary>
        /// Saves data as a xlsx file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="groups">Groups</param>
        /// <param name="sessionNumber">Number of saved data</param>
        /// <param name="sortType">Sort type</param>
        
        public static void SaveAsXlsx(string path,List<Group> groups,int sessionNumber,SortTypes sortType)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            foreach (var group in groups)
            {
                SortSelector.SortBy(sortType, group);
                workSheet = (Excel.Worksheet)workBook.Worksheets.Add();
                workSheet.Name = $"{group.GroupName}";
                var session = group.Sessions.FirstOrDefault(i => i.Number == sessionNumber);
                if (session != null)
                {
                    FillColumns(workSheet, session);
                    FillSheet(workSheet, group.Students, sessionNumber);
                }
                workSheet.Columns.EntireColumn.AutoFit();
            }
            excelApp.DisplayAlerts = false;
            workBook.SaveAs(path, Type.Missing,Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
            Excel.XlSaveAsAccessMode.xlShared,Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }

        /// <summary>
        /// Fills table columns
        /// </summary>
        /// <param name="workSheet">Worksheet</param>
        /// <param name="session">Session</param>
        
        private static void FillColumns(Excel.Worksheet workSheet, Session session)
        {
            workSheet.Cells[1, 1] = "Student name";
            var i = 2;
            foreach (var exam in session.Exams)
            {
                workSheet.Cells[1, i] = exam.Name;
                i++;
            }
            foreach (var credit in session.Credits)
            {
                workSheet.Cells[1, i] = credit.Name;
                i++;
            }
        }

        /// <summary>
        /// Fills sheet cells
        /// </summary>
        /// <param name="workSheet">Worksheet</param>
        /// <param name="students">Students</param>
        /// <param name="sessionNumber">Number of saved session</param>
        
        private static void FillSheet(Excel.Worksheet workSheet,List<Student> students,int sessionNumber)
        {   
            int row = 2;
            foreach (var student in students)
            {
                var studentSession = student.Sessions.FirstOrDefault(k => k.Number == sessionNumber);
                if (studentSession != null)
                {
                    if (studentSession.Exams.All(t => t.Mark != null) && studentSession.Credits.All(u => u.Creditation != null))
                    {
                        workSheet.Cells[row, 1] = student.FullName;
                        var markIndex = 2;
                        foreach (var exam in studentSession.Exams)
                        {
                            workSheet.Cells[row, markIndex] = exam.Mark;
                            markIndex++;
                        }
                        foreach (var credit in studentSession.Credits)
                        {
                            workSheet.Cells[row, markIndex] = credit.Creditation.ToString();
                            markIndex++;
                        }
                    }
                    row++;
                }
            }
        }
    }
}

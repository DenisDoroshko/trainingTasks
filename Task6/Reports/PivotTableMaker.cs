using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Reports
{
    /// <summary>
    /// Representts a class for a making pivot table in the workbook
    /// </summary>
    public static class PivotTableMaker
    {
        /// <summary>
        /// Makes a pivot table in the workbook
        /// </summary>
        /// <param name="path">Workbook path</param>
        
        public static void MakePivotTable(string path)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workBook = excel.Workbooks.Open(path);
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets.Add();
            workSheet.Name = "Pivot Table";
            workSheet.Cells[1, 1] = "Group name";
            workSheet.Cells[1, 2] = "Average mark";
            workSheet.Cells[1, 3] = "Max mark";
            workSheet.Cells[1, 4] = "Min mark";
            var currentRow = 2;
            for(var i=2;i<workBook.Worksheets.Count;i++)
            {
                Excel.Worksheet sheet = (Excel.Worksheet)workBook.Worksheets.get_Item(i);
                workSheet.Cells[currentRow, 1] = sheet.Name;
                var examsNumber = GetExamsNumber(sheet);
                var studentsNumber = GetStudentsNumber(sheet);
                var address = GetAddress(sheet,examsNumber,studentsNumber);
                Excel.Range averageCell = workSheet.Cells[currentRow, 2] as Excel.Range;
                Excel.Range maxCell = workSheet.Cells[currentRow, 3] as Excel.Range;
                Excel.Range minCell = workSheet.Cells[currentRow, 4] as Excel.Range;
                averageCell.FormulaLocal = $"=СУММ('{sheet.Name}'!{address})/{studentsNumber*examsNumber}";
                maxCell.FormulaLocal = $"=МАКС('{sheet.Name}'!{address})";
                minCell.FormulaLocal = $"=МИН('{sheet.Name}'!{address})";
                currentRow++;
            }
            workSheet.Columns.EntireColumn.AutoFit();
            workBook.SaveAs(path);
        }

        /// <summary>
        /// Gets exams number
        /// </summary>
        /// <param name="sheet">Current sheet</param>
        /// <returns>Number of exams</returns>
        
        private static int GetExamsNumber(Excel.Worksheet sheet)
        {
            var i = 2;
            var examsNumber = 0;
            while (sheet.Cells[2, i].Value is double)
            {
                examsNumber++;
                i++;
            }
            return examsNumber;
        }

        /// <summary>
        /// Gets students number
        /// </summary>
        /// <param name="sheet">Current sheet</param>
        /// <returns>Students number</returns>
        
        private static int GetStudentsNumber(Excel.Worksheet sheet)
        {
            var i = 2;
            var studentsNumber = 0;
            while (sheet.Cells[i, 1].Value != null)
            {
                studentsNumber++;
                i++;
            }
            return studentsNumber;
        }

        /// <summary>
        /// Gets address of cells
        /// </summary>
        /// <param name="sheet">Current sheet</param>
        /// <param name="examsNumber">Exams number</param>
        /// <param name="studentsNumber">Students number</param>
        /// <returns>Address</returns>
        
        private static string GetAddress(Excel.Worksheet sheet,int examsNumber,int studentsNumber)
        {
            Excel.Range c1 = sheet.Cells[2, 2];
            Excel.Range c2 = sheet.Cells[studentsNumber+1, examsNumber+1];
            Excel.Range range = sheet.get_Range(c1, c2);
            return range.get_Address();
        }
    }
}

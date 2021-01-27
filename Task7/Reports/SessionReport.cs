using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;
using Sorters;


namespace Reports
{
    /// <summary>
    /// Representts a class for making reports
    /// </summary>
    
    public static class SessionReport
    {
        /// <summary>
        /// Makes report about selected session
        /// </summary>
        /// <param name="path">Save path</param>
        /// <param name="groups">Student groups</param>
        /// <param name="sessionNumber">Number of session</param>
        /// <param name="sortType">Type of sort</param>
        
        public static void MakeReportByNumber(string path, List<Group> groups, int sessionNumber, SortTypes sortType)
        {
            DataSaver.SaveAsXlsx(path, groups, sessionNumber, sortType);
            PivotTableMaker.MakePivotTable(path);
            AverageMarkSaver.AddAverageBySpecialty(path, groups, sessionNumber);
            AverageMarkSaver.AddAverageByExaminer(path, groups, sessionNumber);
        }

        /// <summary>
        /// Makes a table with the dinamics of changes in the average mark by years
        /// </summary>
        /// <param name="path">Save path</param>
        /// <param name="groups">Student groups</param>
        /// <param name="sortingMode">Sorting mode</param>

        public static void MakeReportByAll(string path, List<Group> groups, SortingMode sortingMode)
        {
            DynamicsReportMaker.MakeDynamicsReport(path,groups, sortingMode);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;
namespace Sorters
{
    /// <summary>
    /// Sort types
    /// </summary>
    public enum SortTypes
    {
        /// <summary>
        /// No sorting needed
        /// </summary>
        
        None,

        /// <summary>
        /// Sort by name
        /// </summary>
        
        SortByName,

        /// <summary>
        /// Sort by birthdate
        /// </summary>
        
        SortByBirthDate,

        /// <summary>
        /// Sort by sex
        /// </summary>
        
        SortBySex
    }

    /// <summary>
    /// Representts a class for a sorting data by specified sort type
    /// </summary>

    public static class SortSelector
    {
        /// <summary>
        /// Sorts data by specified sort type
        /// </summary>
        /// <param name="sortType">Specified sort type</param>
        /// <param name="group">Selected group</param>
        
        public static void SortBy(SortTypes sortType, Group group)
        {
            ISorter sorter = null;
            switch (sortType)
            {
                case SortTypes.SortByName:
                    sorter = new SorterByName();
                    break;
                case SortTypes.SortByBirthDate:
                    sorter = new SorterByBirthDate();
                    break;
                case SortTypes.SortBySex:
                    sorter = new SorterBySex();
                    break;
            }
            sorter?.Sort(group);
        }
    }
}

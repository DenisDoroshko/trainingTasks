using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;
namespace Sorters
{
    public enum SortTypes
    {
        None,
        SortByName,
        SortByBirthDate,
        SortBySex
    }
    public static class SortSelector
    {
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

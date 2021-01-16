using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace Sorters
{
    public class SorterByName:ISorter
    {
        public SorterByName()
        {
        }
        public void Sort(Group group)
        {
            group.Students =group.Students.OrderBy(i => i.FullName).ToList();
        }
    }
}

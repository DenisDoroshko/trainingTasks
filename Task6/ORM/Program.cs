using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessionData;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepository myData = new DataRepository("data source =.\\SQLEXPRESS; Initial Catalog =task6db; Integrated Security = True");
            Console.ReadLine();

        }
    }
}

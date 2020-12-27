using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(15);
            tree.Add(12);
            tree.Add(18);
            tree.Add(17);
            tree.Add(20);
            tree.Add(13);
            tree.Add(10);
            Console.WriteLine(tree.RootNode.RightNode.RightNode);
            var s = tree.ShowSortedData();
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

        }
    }
}

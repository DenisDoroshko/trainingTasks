using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class BinaryTree<T> where T: IComparable
    {
        public BinaryTreeNode<T> RootNode { get; set; }
        public void Add(T data)
        {
            if (RootNode != null)
            {
                AddNode(new BinaryTreeNode<T>(data),RootNode);
            }
            else
            {
                RootNode = new BinaryTreeNode<T>(data);
            }
        }
        private void AddNode(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode)
        {
            int comparisonResult = node.Data.CompareTo(currentNode.Data);
            if (comparisonResult != 0)
            {
                if(comparisonResult < 0)
                {
                    if(currentNode.LeftNode == null)
                    {
                        currentNode.LeftNode = node;
                    }
                    else
                    {
                        AddNode(node, currentNode.LeftNode);
                    }
                }
                else
                {
                    if (currentNode.RightNode == null)
                    {
                        currentNode.RightNode = node;
                    }
                    else
                    {
                        AddNode(node, currentNode.RightNode);
                    }
                }
            }
        }
        public List<T> ShowSortedData()
        {
            var nodes = new List<T>();
            if (RootNode != null) 
            {
                var currentNode = RootNode;
                CollectNodes(currentNode, nodes);
            }
            nodes.Sort();
            return nodes;
        }
        public void BalanceTree()
        {

        }
        private void CollectNodes(BinaryTreeNode<T> currentNode,List<T> nodes)
        {
            if (currentNode != null)
            {
                nodes.Add(currentNode.Data);
                CollectNodes(currentNode.LeftNode, nodes);
                CollectNodes(currentNode.RightNode, nodes);
            }
        }
    }
}

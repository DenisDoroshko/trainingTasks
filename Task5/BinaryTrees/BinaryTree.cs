using System;
using System.Collections.Generic;

namespace BinaryTrees
{
    /// <summary>
    /// The class representing a binary tree for storing data
    /// </summary>
    /// <typeparam name="T">Any type supports comparisons</typeparam>
    
    [Serializable]
    public class BinaryTree<T> where T: IComparable
    {
        /// <summary>
        /// Creates an instance of BinaryTree class
        /// </summary>
        
        public BinaryTree()
        {

        }

        /// <summary>
        /// Root node of the tree
        /// </summary>
        
        public BinaryTreeNode<T> RootNode { get; set; }

        /// <summary>
        /// Adds node to the tree
        /// </summary>
        /// <param name="data">Any type supports comparisons</param>
        
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

        /// <summary>
        /// Recursive method for adding nodes
        /// </summary>
        /// <param name="node">The node to add</param>
        /// <param name="currentNode">Current node</param>
        
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

        /// <summary>
        /// Collects and sorts tree data
        /// </summary>
        /// <returns>Collection of sorted data</returns>
        
        public List<T> ShowSortedData()
        {
            List<T> allData = null;
            if (RootNode != null) 
            {
                var allNodes = new List<BinaryTreeNode<T>>();
                CollectNodes(RootNode, allNodes);
                allData = new List<T>();
                foreach (var node in allNodes)
                {
                    allData.Add(node.Data);
                }
                allData.Sort();
            }
            return allData;
        }

        /// <summary>
        /// Balances the tree
        /// </summary>
        
        public void BalanceTree()
        {
            var allNodes = new List<BinaryTreeNode<T>>();
            CollectNodes(RootNode, allNodes);
            foreach(var node in allNodes)
            {
                NodeBalancer<T>.BalanceNode(this,node);
            }
        }

        /// <summary>
        /// Collects all nodes of the tree
        /// </summary>
        /// <param name="currentNode">Current node</param>
        /// <param name="nodes">Collection of nodes</param>
        
        private void CollectNodes(BinaryTreeNode<T> currentNode,List<BinaryTreeNode<T>> nodes)
        {
            if (currentNode != null)
            {
                nodes.Add(currentNode);
                CollectNodes(currentNode.LeftNode, nodes);
                CollectNodes(currentNode.RightNode, nodes);
            }
        }
    }
}

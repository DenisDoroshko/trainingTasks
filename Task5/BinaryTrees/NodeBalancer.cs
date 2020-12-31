using System;

namespace BinaryTrees
{
    /// <summary>
    /// Implements a balancing algorithm
    /// </summary>
    /// <typeparam name="T">Any type supports comparisons</typeparam>
    
    public static class NodeBalancer<T> where T : IComparable
    {
        /// <summary>
        /// Current state of the node
        /// </summary>
        
        private enum BalanceState
        {
            /// <summary>
            /// Normal
            /// </summary>
            
            Normal,

            /// <summary>
            /// Left node too big
            /// </summary>
            
            LeftTooBig,

            /// <summary>
            /// Right node too big
            /// </summary>
            
            RightTooBig,
        }

        /// <summary>
        /// Balances the node
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="node">Node</param>
        
        public static void BalanceNode(BinaryTree<T> tree,BinaryTreeNode<T> node)
        {
            BalanceState currentState = GetCurrentState(node);
            switch (currentState) 
            {
                case BalanceState.LeftTooBig:
                    if (node.LeftNode != null && CompareHeights(node) < 0)
                    {
                        RightLeftRotation(tree,node);
                    }
                    else
                    {
                        RightRotation(tree,node);
                    }
                    break;
                case BalanceState.RightTooBig:
                    if (node.RightNode != null && CompareHeights(node) > 0)
                    {
                        LeftRightRotation(tree,node);
                    }
                    else
                    {
                        LeftRotation(tree,node);
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets current state of the node
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Current state of the node</returns>
        
        private static BalanceState GetCurrentState(BinaryTreeNode<T> node)
        {
            if (CompareHeights(node) > 1)
            {
                return BalanceState.LeftTooBig;
            }

            if (CompareHeights(node) < -1)
            {
                return BalanceState.RightTooBig;
            }

            return BalanceState.Normal;
        }

        /// <summary>
        /// Compares heights of node childs
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Comparison result</returns>
        
        private static int CompareHeights(BinaryTreeNode<T> node)
        {
            return MaxChildHeight(node.LeftNode) - MaxChildHeight(node.RightNode);
        }
        
        /// <summary>
        /// Gets max height of child node
        /// </summary>
        /// <param name="node">Child node</param>
        /// <returns>Max height</returns>
        
        private static int MaxChildHeight(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.LeftNode), MaxChildHeight(node.RightNode));
            }

            return 0;
        }

        /// <summary>
        /// Rotates the node to the left
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="node">Node</param>
        
        private static void LeftRotation(BinaryTree<T> tree,BinaryTreeNode<T> node)
        {
            var newRoot = node.RightNode;
            ChangeRoot(tree,node,newRoot);
            node.RightNode = newRoot.LeftNode;
            newRoot.LeftNode = node;
        }

        /// <summary>
        /// Rotates the node to the right
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="node">Node</param>
        
        private static  void RightRotation(BinaryTree<T> tree,BinaryTreeNode<T> node)
        {
            var newRoot = node.LeftNode;
            ChangeRoot(tree,node,newRoot);
            node.LeftNode = newRoot.RightNode;
            newRoot.RightNode = node;
        }

        /// <summary>
        /// Rotates the node to the right and then to the left
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="node">Node</param>
        
        private static void LeftRightRotation(BinaryTree<T> tree,BinaryTreeNode<T> node)
        {
            RightRotation(tree,node.RightNode);
            LeftRotation(tree,node);
        }

        /// <summary>
        /// Rotates the node to the left and then to the right
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="node">Node</param>
        
        private static void RightLeftRotation(BinaryTree<T> tree,BinaryTreeNode<T> node)
        {
            LeftRotation(tree,node.LeftNode);
            RightRotation(tree,node);
        }

        /// <summary>
        /// Changes the root of the tree
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="node">Node</param>
        /// <param name="newRoot">New root</param>
        
        private static void ChangeRoot(BinaryTree<T> tree,BinaryTreeNode<T> node,BinaryTreeNode<T> newRoot)
        {
            if (node.ParentNode != null)
            {
                if (node.ParentNode.LeftNode == node)
                {
                    node.ParentNode.LeftNode = newRoot;
                }
                else if (node.ParentNode.RightNode == node)
                {
                    node.ParentNode.RightNode = newRoot;
                }
            }
            else
            {
                tree.RootNode = newRoot;
            }
            newRoot.ParentNode = node.ParentNode;
            node.ParentNode = newRoot;
        }

    }
}

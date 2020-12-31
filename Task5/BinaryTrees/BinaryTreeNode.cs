using System;
using System.Xml.Serialization;

namespace BinaryTrees
{
    /// <summary>
    /// The class representing a node of the tree for storing data
    /// </summary>
    /// <typeparam name="T">Any type supports comparisons</typeparam>
    
    [Serializable]
    public class BinaryTreeNode<T> where T : IComparable
    {
        /// <summary>
        /// Creates an instance of BinaryTreeNode class
        /// </summary>
        
        public BinaryTreeNode()
        {

        }

        /// <summary>
        /// Creates an instance of BinaryTreeNode class
        /// </summary>
        
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Storing data
        /// </summary>
        
        public T Data { get; set; }

        /// <summary>
        /// Parent of the node
        /// </summary>
        
        [XmlIgnore]
        public BinaryTreeNode<T> ParentNode { get; set; }

        /// <summary>
        /// Private field of right the node
        /// </summary>
        
        private BinaryTreeNode<T> rightNode;

        /// <summary>
        /// Right child of the node
        /// </summary>
        
        public BinaryTreeNode<T> RightNode
        {
            get { return rightNode; }
            set
            {
                rightNode = value;
                if (rightNode != null)
                {
                    rightNode.ParentNode = this;
                }
            }
        }

        /// <summary>
        /// Private field of left the node
        /// </summary>
        
        private BinaryTreeNode<T> leftNode;

        /// <summary>
        /// Left child of the node
        /// </summary>
        
        public BinaryTreeNode<T> LeftNode 
        { 
            get {return leftNode; }
            set
            {
                leftNode = value;
                if (leftNode != null)
                {
                    leftNode.ParentNode = this;
                }
            }
        }

        /// <summary>
        /// Converts node to string
        /// </summary>
        /// <returns>String represention of the class</returns>
        
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}

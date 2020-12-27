using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public enum NodeLocations 
    {
        Left,
        Right
    }

    public class BinaryTreeNode<T> where T : IComparable
    {
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public BinaryTreeNode<T> ParentNode { get; set; }
        private BinaryTreeNode<T> rightNode;
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
        private BinaryTreeNode<T> leftNode;
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
        public NodeLocations? NodeLocation { get { return GetLocation(); } }
        private NodeLocations? GetLocation()
        {
            NodeLocations? location = null;
            if (ParentNode != null)
            {
                location = ParentNode.RightNode == this ? NodeLocations.Right : NodeLocations.Left;
            }
            return location;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}

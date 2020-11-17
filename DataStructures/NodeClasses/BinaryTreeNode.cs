using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.NodeClasses
{
    /// <summary>
    /// Class to represent a binary tree
    /// </summary>
    /// <typeparam name="T">The Generic type for the tree</typeparam>
    internal class BinaryTreeNode<T>
    {
        #region Properties 

        /// <summary>
        /// Property to store the data for the binary tree node
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Property to point to the left subtree for a binary tree node
        /// </summary>
        public BinaryTreeNode<T> LeftTreeNode { get; set; }

        /// <summary>
        /// Property to point to the right subtree for a binary tree node
        /// </summary>
        public BinaryTreeNode<T> RigthTreeNode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BinaryTreeNode() {  }

        /// <summary>
        /// Constructor to create a binary tree with data
        /// </summary>
        /// <param name="data"></param>
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        #endregion 
    }
}

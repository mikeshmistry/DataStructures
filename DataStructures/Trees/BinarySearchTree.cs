using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.NodeClasses;


namespace DataStructures.Trees
{
    /// <summary>
    /// Class to represent a binary search tree
    /// </summary>
    public class BinarySearchTree<T>
    {
        #region Fields

        /// <summary>
        /// Field to represent the root of the binary search tree
        /// </summary>
        private BinaryTreeNode<T> root;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BinarySearchTree() { }


        /// <summary>
        /// Constructor that creates a root with a value
        /// </summary>
        /// <param name="data"></param>
        public BinarySearchTree(T data)
        {
            root = new BinaryTreeNode<T>(data);
        }

        #endregion 
    }
}

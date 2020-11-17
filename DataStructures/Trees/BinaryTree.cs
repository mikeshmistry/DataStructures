using DataStructures.NodeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    /// <summary>
    /// Class to represent a binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
  public class BinaryTree<T>
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
        public BinaryTree() { }


        /// <summary>
        /// Constructor that creates a root with a value
        /// </summary>
        /// <param name="data"></param>
        public BinaryTree(T data)
        {
            root = new BinaryTreeNode<T>(data);
        }

        #endregion
    }
}

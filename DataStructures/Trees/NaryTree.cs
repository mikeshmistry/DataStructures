using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.NodeClasses;

namespace DataStructures.Trees
{
    /// <summary>
    /// Class to represent a tree with many children
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NaryTree<T>
    {
        #region Fields
        /// <summary>
        /// field to represent the root of the tree
        /// </summary>
        private NaryTreeNode<T> root;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public NaryTree() { }

        /// <summary>
        /// Constructor that takes in the data for the root of the tree
        /// </summary>
        /// <param name="data"></param>
        public NaryTree(T data)
        {
            root = new NaryTreeNode<T>(data);
        }

        #endregion 
    }
}

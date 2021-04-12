using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.NodeClasses;
using DataStructures.Interfaces;

namespace DataStructures.Trees
{
    /// <summary>
    /// Class to represent a tree with many children
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NaryTree<T> : INaryTreeOperations<T>
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

        #region INaryTreeOperations Implementations

        /// <summary>
        /// Method to insert a a node at the root without any children
        /// </summary>
        /// <param name="item">The item to add the root</param>
        /// <returns>True if the node was added successfully</returns>
        public bool InsertTopLevel(T item)
        {
            var added = false;

            //Item is not null add it
            if (item != null)
            {
               var newNode = new  NaryTreeNode<T>(item);
                root.ChildrenList.Add(newNode);
                added = true;
            }


            return added;

        }

        public bool InsertTopLevelWithChildren(T item, List<NaryTreeNode<T>> children)
        {
            var added = false;


            // item is not null add it to root
            if (item != null)
            {
                var newNode = new NaryTreeNode<T>(item, children);
                added = true;
            }

            return added;
        }

        public bool Insert(T item, T value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            root = null;
        }
        
          
        #endregion

       
    }
}

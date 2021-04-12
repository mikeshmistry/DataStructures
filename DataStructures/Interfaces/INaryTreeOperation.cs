using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.NodeClasses;

namespace DataStructures.Interfaces
{
   /// <summary>
   /// Generic interface for operations on Nary-Trees
   /// </summary>
   /// <typeparam name="T">The type of the tree</typeparam>
   internal interface INaryTreeOperations<T>
   {
        /// <summary>
        /// Insert a node at the root of the tree with no children
        /// </summary>
        /// <param name="item">The item to add to the root of the tree</param>
        /// <returns>True if the item was successfully added</returns>
        bool InsertTopLevel(T item);

        /// <summary>
        /// Insert a node at the root of the tree with Children 
        /// </summary>
        /// <param name="item">The item to add to the rood of the tree</param>
        /// <param name="children">The List of children to add</param>
        /// <returns>True if the item was successfully added</returns>
        bool InsertTopLevelWithChildren(T item, List<NaryTreeNode<T>> children);

        /// <summary>
        /// Insert a node at a given item in the tree if found
        /// </summary>
        /// <param name="item"> The item to add a new value to</param>
        /// <param name="value">The value to be added to</param>
        /// <returns>True if the item was successfully added</returns>
        bool Insert(T item, T value);

        /// <summary>
        /// Clears the tree and removes all nodes
        /// </summary>
        void Clear();

   }
}

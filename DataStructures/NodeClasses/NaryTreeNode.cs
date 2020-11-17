using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.NodeClasses
{
    /// <summary>
    /// Class to represent a nary tree with n children 
    /// </summary>
    internal class NaryTreeNode<T>
    {

        #region Properties

        /// <summary>
        /// Stores the value of the nary node
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// List to hold children of the Nary node
        /// </summary>
        public IList<NaryTreeNode<T>> ChildrenList { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public NaryTreeNode() { }


        /// <summary>
        /// Constructor that takes in a data and creates a Nary Node with no children
        /// </summary>
        /// <param name="data"></param>
        public NaryTreeNode(T data)
        {
            Data = data;
            ChildrenList = new List<NaryTreeNode<T>>();
        }

        #endregion 

    }
}

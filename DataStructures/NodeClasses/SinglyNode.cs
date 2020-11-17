using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.NodeClasses
{

    /// <summary>
    /// Class to represent generic a single node in a singly linked list 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class SinglyNode<T>
    {

        #region Properties
        
        /// <summary>
        /// The data stored for the generic type
        /// </summary>
        public  T Data { get; set; }

        /// <summary>
        /// A pointer to the next node in the list
        /// </summary>
        public SinglyNode<T> Next { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SinglyNode() 
        {
            Data = default;
            Next = null;
         
        }

        /// <summary>
        /// Constructor that takes in the data to be added to the node
        /// </summary>
        /// <param name="data">the data to the node</param>
        public SinglyNode(T data)
        {
            Data = data;
            Next = null;
        }

        #endregion

    }
}

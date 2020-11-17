using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataStructures.NodeClasses
{
    /// <summary>
    /// Class to represent a doubly linked node in a doubly linked list
    /// </summary>
   
   internal class DoublyNode<T>
    {
        #region Properties

        /// <summary>
        /// The data stored in the linked list
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// A pointer to the next node in the list
        /// </summary>
        public DoublyNode<T> Next { get; set; }

        /// <summary>
        /// A pointer to the previous node in the list
        /// </summary>
        public DoublyNode<T> Previous { get; set; }

        #endregion

        #region Constructors 

        /// <summary>
        /// Default constructor
        /// </summary>
        public DoublyNode()
        {
            Data = default;
            Next = null;
            Previous = null;
        }


        /// <summary>
        ///  Constructor to that takes in the data to be stored
        /// </summary>
        /// <param name="data"></param>
        public DoublyNode(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }

        #endregion 

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DataStructures.AbstactClasses;
using DataStructures.NodeClasses;

namespace DataStructures.Stacks
{
    /// <summary>
    /// Generic class to represent a dynamic stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class DynamicStack<T> : StackOperations<T>
    {
        #region Fields

        /// <summary>
        /// Pointer to the top of the stack
        /// </summary>
        private DoublyNode<T> top;

        #endregion



        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DynamicStack()
        {
            top = null;
            CurrentSize = 0;

        }

        #endregion


        #region Stack Operations

        public override void Clear()
        {
            top = null;
            CurrentSize = 0;
        }


        public override bool IsEmpty()
        {
            return top == null;
        }


        public override bool Push(T element)
        {
            var result = false;

            //create the new stack node
            var newNode = CreateNewNode(element);

            // stack is empty 
            if (IsEmpty())
            {
                top = newNode;
                CurrentSize++;
                result = true;
            }
            else
            {
                // var temp = top;
                newNode.Next = top;
                top.Previous = newNode;
                top = newNode;
                CurrentSize++;
                result = true;
            }


            return result;
        }


        public override T Pop()
        {
            var poppedItem = default(T);
            
            if(!IsEmpty())
            {
                poppedItem = top.Data;
                top = top.Next;
                CurrentSize--;
            }

            return poppedItem;
        }

       

        #endregion


        #region Other Methods

        /// <summary>
        /// Method to create a new stack node 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private DoublyNode<T> CreateNewNode(T data)
        {
            return new DoublyNode<T>(data);
        }
        #endregion 

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.AbstactClasses
{
    /// <summary>
    /// abstract for basic stack operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StackOperations<T>
    {
        /// <summary>
        /// Property to keep track of the current items in the stack 
        /// </summary>
        public int CurrentSize { get; protected set; }
        
        /// <summary>
        /// Pushes a element onto the stack
        /// </summary>
        /// <param name="element">The element to be pushed onto the stack</param>
        /// <returns>true is the element was successfully added </returns>
        public abstract bool Push(T element);
        
        /// <summary>
        /// Removes and returns the value of the element to be removed from the stack
        /// </summary>
        /// <returns>The element that was removed</returns>
        public abstract T Pop();

        /// <summary>
        /// Checks to see if the stack is empty
        /// </summary>
        /// <returns>True if the stack is empty</returns>
        public abstract bool IsEmpty();

        /// <summary>
        /// Method to clear the stack
        /// </summary>
        public abstract void Clear();


    }
}

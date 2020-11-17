using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.AbstractClasses
{
    /// <summary>
    /// Abstract class for basic queue operation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class QueueOperations<T>
    {
       
        /// <summary>
        /// Property to keep track of the current items in the stack 
        /// </summary>
        public int CurrentSize { get; protected set; }

        /// <summary>
        /// Method to add to the back of the queue
        /// </summary>
        /// <param name="item">The item to be added to the queue</param>
        /// <returns>True if the item was added to the queue</returns>
        public abstract bool Enqueue(T item);

        /// <summary>
        /// Method to remove and return an item from the queue
        /// </summary>
        /// <returns>The item removed from the front of the queue</returns>
        public abstract T Dequeue();

        /// <summary>
        /// Method to check to see if the queue is empty 
        /// </summary>
        /// <returns></returns>
        public abstract bool IsEmpty();

        /// <summary>
        /// Method to clear the stack
        /// </summary>
        public abstract void Clear();
    }
}

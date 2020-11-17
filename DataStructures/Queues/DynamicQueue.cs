using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.AbstractClasses;
using DataStructures.NodeClasses;

namespace DataStructures.Queues
{
   public class DynamicQueue<T> : QueueOperations<T>
    {
        #region Fields

        /// <summary>
        /// Field to represent the front of the queue
        /// </summary>
        private DoublyNode<T> front;

        /// <summary>
        /// Field to represent the back of the queue
        /// </summary>
        private DoublyNode<T> back;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DynamicQueue()
        {
        }

        #endregion 

        #region QueueOperations Implementation 

        public override void Clear()
        {
            front = null;
            back = null;
            CurrentSize = 0;
        }

        public override bool Enqueue(T item)
        {
            var isEmpty = IsEmpty();
            var newNode = CreateNewNode(item);
            var result = false;

            /*
               list is empty both front and back are pointing to the newly Created Node
             */
            if (isEmpty)
            {
                front = newNode;
                back = newNode;
                CurrentSize++;
                result = true;
            }
            else
            {
                // append to the back of the queue
                back.Next = newNode;
                newNode.Previous = back;
                back = newNode;
                CurrentSize++;
                result = true;
            }

            return result;
        }

        public override T Dequeue()
        {
            var item = default(T);
            var isEmpty = IsEmpty();
           
            //Dequeue only when list is not empty 
            if (!isEmpty)
            {
                //one item left in the queue call clear to clear the queue
                if (front == back)
                {
                    item = front.Data;
                    Clear();
                }

                //front next 
                else if (front.Next != null)
                {
                    item = front.Data;
                    front = front.Next;
                    CurrentSize--;
                }
            }
            return item;
        }

   
        public override bool IsEmpty()
        {
            return front == null && CurrentSize ==0;
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Create a new queue node with data 
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

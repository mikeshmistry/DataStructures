using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures.AbstractClasses;

namespace DataStructures.Queues
{
  public  class FixedBasedQueue<T> : QueueOperations<T>
    {
        #region Fields

        /// <summary>
        /// Field to hold the queue
        /// </summary>
        private T[] queue;

        /// <summary>
        /// Field to keep track of the front of the queue
        /// </summary>
        private int frontIndex;
        #endregion 

        #region Properties

        /// <summary>
        /// Property that sets the max size of the queue
        /// </summary>
        public int MaxSize { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor Max Size is 100
        /// </summary>
        public FixedBasedQueue()
        {
            CurrentSize = 0;
            MaxSize = 100;
            queue = new T[MaxSize]; 

        }

        /// <summary>
        /// Constructor to set the max size of the queue
        /// </summary>
        /// <param name="size">The max size of the queue</param>
        public FixedBasedQueue(int size)
        {
            //not a correct size default to 100
            if (size < 0)
                MaxSize = 100;
            else
                MaxSize = size;

            CurrentSize = 0;
            queue = new T[MaxSize];
        }

        #endregion

        #region QueueOperations Implementation 


        public override bool Enqueue(T item)
        {
            var isFull = IsFull();
            var result = false;

            //add to the queue 
            if(!isFull)
            {
                queue[CurrentSize] = item;
                CurrentSize++;
                result = true;
            }

              return result;
        }

        public override T Dequeue()
        {
            var isEmpty = IsEmpty();
            var item = default(T);
            var arrayLength = MaxSize - 1;

            //if the queue is not empty return the front item which is MaxSize - 1;
            if (!isEmpty)
            {
                //one element in the queue and frontIndex == arrayLength - 2
                if (frontIndex == arrayLength)
                {
                    item = queue[frontIndex];
                    CurrentSize = 0;
                    frontIndex = 0;
                }

                else
                {
                    item = queue[frontIndex];
                    CurrentSize--;
                    frontIndex++;
                }
            }
           
            return item;
        }


        public override bool IsEmpty()
        {
            return CurrentSize == 0;
        }

        public override void Clear()
        {
            queue = new T[MaxSize];
            CurrentSize = 0;
            frontIndex = 0;
        }

        #endregion

        #region Other Methods
        /// <summary>
        /// Method to check to see the queue is full
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return CurrentSize == MaxSize;
        }
        #endregion 

    }
}

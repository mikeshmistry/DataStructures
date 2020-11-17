using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.AbstactClasses;

namespace DataStructures.Stacks
{
    /// <summary>
    /// Generic class to represent a Fixed based Stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class FixedBasedStack<T> : StackOperations<T>
    {
        #region Fields / Properties 

        /// <summary>
        /// Array to hold the fixed based  stack
        /// </summary>
        private T [] stackArray;

           /// <summary>
          /// The Size of the stack
          /// </summary>
        public int MaxSize { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor sets max size to 100
        /// </summary>
        public FixedBasedStack()
        {
            //default size of 100 elements
            MaxSize = 100;
            stackArray = new T [MaxSize];
            CurrentSize = 0;
            

        }

        /// <summary>
        /// Constructor that takes in the size of the stack
        /// </summary>
        /// <param name="size">The size of the stack</param>
        public FixedBasedStack(int size)
        {
            //valid size
            if (size > 0)
                MaxSize = size;
            else
                MaxSize = 100;
            

            stackArray = new T[MaxSize];
            CurrentSize = 0;
          
        }

        #endregion

        #region StackOperations Implementation 

        public override void Clear()
        {
            stackArray =  new T [MaxSize];
            CurrentSize = 0;
           
        }

        public override bool IsEmpty()
        {
            return CurrentSize == 0;
        }


        public override bool Push(T element)
        {
            // if the stack is not full 
            var isNotFull = IsFull();

            var result = false;

            if (!isNotFull)
            {

                stackArray[CurrentSize] = element;
                CurrentSize++;
                result = true;
            }

            return result;
        }


        public override T Pop()
        {
            //check to see if stack is not empty
            var isNotEmpty = IsEmpty();
            var isNotFull = IsFull();
            var result = default(T);

            if(!isNotEmpty)
            {
                result = stackArray[CurrentSize - 1];
                CurrentSize--;
             
            }

            return result;
        }

      
        #endregion

        #region Other Methods

        /// <summary>
        /// Method to check if the stack is full
        /// </summary>
        /// <returns>True if the stack is full</returns>
        public bool IsFull()
        {
            return CurrentSize  == MaxSize;
        }

        #endregion
    }
}

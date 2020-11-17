using DataStructures.Interfaces;
using System;


namespace DataStructures.Lists
{

    /// <summary>
    /// Generic class to represent a fix size list 
    /// </summary>
    /// <typeparam name="T"> The type of the fixed array </typeparam>

    public class FixedList<T> : IOperations<T>
    {

        #region Fields 

        /// <summary>
        /// Index of the next available index in the array
        /// </summary>
        private int currentIndex;

        /// <summary>
        /// Holds the internal array a keeps track of it
        /// </summary>
        private T[] array;
        #endregion

        #region Properties

        /// <summary>
        /// Returns the current size of the array
        /// </summary>
        public int CurrentSize { get; private set; }

        /// <summary>
        /// Returns the Max size of the array 
        /// </summary>
        public int MaxSize { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor sets max size to 100
        /// </summary>
        public FixedList()
        {
            MaxSize = 100;
            array = new T[MaxSize];
            currentIndex = 0;
            CurrentSize = 0;
        }

        /// <summary>
        /// Constructor that excepts a type for the array and the initial size of the array
        /// </summary>
        /// <param name="arrayType"></param>
        /// <param name="size"></param>
        public FixedList(int size)
        {
            currentIndex = 0;
            CurrentSize = 0;


            //if the array size is negative or 0 default size is 100
            if (size <= 0)
            {
                MaxSize = 100;
                array = new T[MaxSize];
            }

            else
            {
                MaxSize = size;
                array = new T[MaxSize];
            }


        }

        #endregion 

        #region IOperations Methods

        public bool Append(T element)
        {
            var result = false;

            // if the current index is less than Max Size append it
            if (currentIndex <= MaxSize - 1)
            {
                array[currentIndex] = element;
                currentIndex++;
                CurrentSize++;
                result = true;
            }

            return result;

        }

        public void Clear()
        {
            // clear the array relocate to Max size and reset currentIndex and CurrentSize to 1
            array = null;
            array = new T[MaxSize];
            currentIndex = 0;
            CurrentSize = 0;
        }

       

        public bool Insert(T element)
        {
            var result = false;

            // if the array is not full then insert
            if (!IsFull())
            {
                for (var i = CurrentSize; i >= 1; i--)
                    array[i] = array[i - 1];

                array[0] = element;
                CurrentSize++;
                result = true;
            }

            return result;
        }

        public bool InsertAfter(T value, T element)
        {
            var foundIndex = FindIndex(value);
            var result = false;


            //check to see if the array is empty if so add item to head of list by calling Insert 
            if (IsEmpty())
            {
                //insert to the beginning of the list and return true;
                Insert(element);
                //increase the current count
               

                return true;
            }

            //if the array is not full and value is found then insert it
            if (foundIndex != -1 && !IsFull())
            {
                //the insert position for the element to go to  
                var insertPosition = foundIndex + 1;

                for (var i = CurrentSize; i > insertPosition; i--)
                    array[i] = array[i - 1];

                array[insertPosition] = element;

                //increase the current count
                CurrentSize++;
                result = true;
            }

            return result;
        }

        public bool InsertBefore(T value, T element)
        {
            var foundIndex = FindIndex(value);
            var result = false;

            //check to see if the array is empty if so add item to head of list by calling Insert 
            if (IsEmpty())
            {
                //if the array is not full and value is found then insert it
                Insert(element);

                return true;
            }


            //if the array is not full and value is found then insert it
            if (foundIndex != -1 && !IsFull())
            {

                for (var i = CurrentSize; i > foundIndex; i--)
                    array[i] = array[i - 1];

                array[foundIndex] = element;

                //increase the current count
                CurrentSize++;
                result = true;
            }

            return result;
        }

        public bool IsEmpty()
        {
            return CurrentSize == 0;
        }

        public bool Remove(T element)
        {
            var result = false;

            // find the index of the element that you would like to remove
            var findIndex = FindIndex(element);

            //if the index of the element that you want is found and current elements size is not zero
            if (findIndex != -1 && CurrentSize != 0)
            {
                // this is the endIndex for the shifting
                var endIndex = CurrentSize - 1;

                for (var i = findIndex; i < endIndex; i++)
                    array[i] = array[i + 1];

                //decrease the CurrentSize by one
                CurrentSize--;
                result = true;
            }

            return result; 
        }

        public void Print()
        {
            for (var i = 0; i < MaxSize; i++)
                Console.WriteLine($"index : {i} - {array[i]} ");
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Finds the index of the element to be found a returns it
        /// </summary>
        /// <param name="element"></param>
        /// <returns>-1 if the index was not found. If found returns the index</returns>
        public int FindIndex(T element)
        {
            var index = -1;

            for (var i = 0; i < CurrentSize; i++)
            {
                if (array[i].Equals(element))
                    index = i;
            }

            return index;
        }

        /// <summary>
        /// Checks to see if the array is at max complicity
        /// </summary>
        /// <returns>returns true if the array is at max size</returns>
        public bool IsFull()
        {
            return CurrentSize == MaxSize;
        }

        #endregion
    }
}

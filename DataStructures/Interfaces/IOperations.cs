/**************************************************************************************
 Generic Interface for common function for data structures s empty(no elements)
***************************************************************************************/

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Interface for basic operations on data structures
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IOperations<T>
    {
        /// <summary>
        /// Adds an element to the end of the data structure
        /// </summary>
        /// <param name="element"> The element to be added to the end of the data structure</param>
        bool Append(T element);
       
        /// <summary>
        ///  Adds an element to the start of the data structure
        /// </summary>
        /// <param name="element">The element to be added to the start of the data structure </param>
        bool Insert(T element);
        
        /// <summary>
        /// Adds an element before a given value in the data structure, if the value exists
        /// </summary>
        /// <param name="value">The value to add the new element before</param>
        /// <param name="element">The element to be added</param>
        /// <returns>True if the element was added before a given value</returns>
        bool InsertBefore(T value,T element);

        /// <summary>
        /// Adds an element after a given value in the data structure, if the values exists
        /// </summary>
        /// <param name="value">The value to add the new element after</param>
        /// <param name="element">The element to be added</param>
        /// <returns>True if the element was added after a given value</returns>
        bool InsertAfter(T value, T element);
        
        
        /// <summary>
        /// Removes a element from the data structure 
        /// </summary>
        /// <param name="element">The element in the data structure to be deleted</param>
        bool Remove(T element);
        
        /// <summary>
        /// Clears the contents of the data structure 
        /// </summary>
        void Clear();
        
        /// <summary>
        /// Checks to see if the data structure is empty
        /// </summary>
        /// <returns>True if the data structure is empty</returns>
        bool IsEmpty();

        /// <summary>
        /// Method that prints to the console
        /// </summary>
        void Print();
    }
}

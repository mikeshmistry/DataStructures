using DataStructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.NodeClasses;
using System.Xml.Schema;

namespace DataStructures.Lists
{
    
   public class SinglyLinkedList<T> : IOperations<T>
    {
        #region Fields

        /// <summary>
        ///  Pointer to the head of the list
        /// </summary>
        private SinglyNode<T> Head;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Current Size of the singly linked list 
        /// </summary>
        public int CurrentSize { get; private set; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public SinglyLinkedList()
        {
            Head = null;
            CurrentSize = 0;
        }

        #endregion 

        #region IOperations Implementations 

        public bool Append(T element)
        {
            var result = false;
            //create the new node with the element as the data
            var newNode = new SinglyNode<T>(element);

            //checks to see if the list empty
            var isEmpty = IsEmpty();

            //if the list is empty the 
            // point head to the newly created node and increase the current size
            if (isEmpty)
            {
                Head = newNode;
                CurrentSize++;
                result = true;
            }

            else
            {
                var temp = Head;

                while (temp.Next != null)
                    temp = temp.Next;
                
                temp.Next = newNode;
                CurrentSize++;
                result = true;
            }

            return result;
        }

        public void Clear()
        {

            Head = null;
            CurrentSize = 0;
        }

      

        public bool Insert(T element)
        {
            var result = false;

            //create the new node with the element as the data
            var newNode = new SinglyNode<T>(element);

            //checks to see if the list empty
            var isEmpty = IsEmpty();

            //if the list is empty the 
            // point head to the newly created node and increase the current size
            if (isEmpty)
            {
                Head = newNode;
                CurrentSize++;
                result = true;
            }
            
            else
            {
                //assign newNode.Next to head
                newNode.Next = Head;
                
                //assign head to the newNode and increase the CurrentSize
                Head = newNode;
                CurrentSize++;
                result = true;
            }

            return result;
        }

        public bool InsertAfter(T value, T element)
        {
            // the result to see if the insert happened
            var result = false;
            var isEmpty = IsEmpty();

            if (isEmpty)
                result = Insert(element);

            else
            {

                //find the given node based on the value that you would like to insert after
                var found = FindNode(value);

                //found the value and is not null
                if (found != null)
                {
                    //create the new node with the element as the data
                    var newNode = new SinglyNode<T>(element);
                    var temp = found.Next;
                    found.Next = newNode;
                    newNode.Next = temp;
                    CurrentSize++;
                    result = true;

                }
            }


            return result;
        }

        public bool InsertBefore(T value, T element)
        {
            // the result to see if the insert happened
            var result = false;
            var isEmpty = IsEmpty();

            // empty list add to head or value is the found first  
            if (isEmpty || value.Equals(Head.Data))
                result = Insert(element);
                
            else
            {
                //find the previous value before the inserted node
                var previousNode = FindPreviousNode(value);

                //create the new node
                var newNode = CreateNewNode(element);

                //found it
                if (previousNode != null)
                {
                    var temp = previousNode.Next;
                    previousNode.Next = newNode;
                    newNode.Next = temp;
                    CurrentSize++;
                    result = true;
                }

            }

            return result;

        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Print()
        {
            //create a temp variable to point to the head of the list 
            var temp = Head;

            // loop till the end of the list and print the data at each node in the list
            while(temp !=null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }

        public bool Remove(T element)
        {
            var result = false;

            //check to see if list is empty
            var isEmpty = IsEmpty();

            //only delete if list is not empty 
            if (!isEmpty)
            {
                //one element in the list clear the contents of the list
                if (Head.Next == null)
                {
                    Clear();
                    result = true;
                }
                //second element becomes head decrease the size
                else if (Head.Data.Equals(element))
                {
                    Head = Head.Next;
                    CurrentSize--;
                    result  = true;
                }

                // find the previous node before the element to be remove
                else
                {

                    var previousNode = FindPreviousNode(element);

                    //previous node is found
                    if (previousNode != null)
                    {
                        if (previousNode.Next != null)
                            previousNode.Next = previousNode.Next.Next;

                        else
                            previousNode.Next = null;

                        CurrentSize--;
                        result = true;
                    }

                }
            }

            return result;
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Internal method to return a new node in the linked list
        /// </summary>
        /// <param name="data">The data to be stored in the new linked list node</param>
        /// <returns>The newly created node</returns>
        private SinglyNode<T> CreateNewNode(T data)
        {
            return new SinglyNode<T>(data);
        }


       
        /// <summary>
        /// Internal method to find and return a reference to a node in the list 
        /// </summary>
        /// <param name="element">The element to be found</param>
        /// <returns>the reference to the node if found null otherwise</returns>
        private SinglyNode<T> FindNode(T element)
        {
            //create a node to store the found node
            SinglyNode<T> foundNode = null;

            //pointer to the head
            var temp = Head;
            
            while(temp !=null)
            {
                if (temp.Data.Equals(element))
                {
                    foundNode = temp;
                    break;
                }

                temp = temp.Next;
            }

            return foundNode;

        }

        private SinglyNode<T> FindPreviousNode(T element)
        {
            SinglyNode<T> previousNode = null;

            //pointer to the head
            var temp = Head;

            while(temp.Next != null && !(temp.Data.Equals(element)))
            {
                    previousNode = temp;
                    temp = temp.Next;

            }

            return previousNode; 
        }

        #endregion
    }
}

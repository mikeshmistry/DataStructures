using DataStructures.Interfaces;
using DataStructures.NodeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace DataStructures.Lists
{
    /// <summary>
    /// Class to represent a doubly linked list
    /// </summary>
    
   public class DoublyLinkedList<T> : IOperations<T>
    {

        #region Fields

        //Pointer to the head of the list
        private DoublyNode<T> Head;

        #endregion

        #region Properties

        /// <summary>
        /// Keeps track of the current size of the linked list
        /// </summary>
        public int CurrentSize { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DoublyLinkedList()
        {
            Head = null;
            CurrentSize = 0;
        }

        #endregion 

        #region IOperations Implementation  

        public bool Append(T element)
        {
            var result = false;

            //check to see if the list is empty
            var isEmptyList = IsEmpty();

            //create the new node to be appended to 
            var newNode = CreateNewNode(element);

            //empty list point head to the newly node
            if (isEmptyList)
            {
                Insert(element);
                return true;
            }
            
            

                var temp = Head;

                // loop to the end of the list
                while (temp.Next != null)
                    temp = temp.Next;


                //now assign temp.next to the new node
                temp.Next = newNode;
                newNode.Previous = temp;
                CurrentSize++;
                result = true;


            return result;  
        }

        public bool Insert(T element)
        {
            var result = false;
            //check to see if the list is empty
            var isEmptyList = IsEmpty();

            //create the new node to be added to the beginning of the list 
            var newNode = CreateNewNode(element);

            //empty list point head to the newly node
            if (isEmptyList)
            {
                Head = newNode;
                CurrentSize++;
                return true;
            }

         
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
                CurrentSize++;
               result = true;
            
            return result;
        }

        public bool InsertBefore(T value, T element)
        {
            //check to see if the list is empty
            var isEmptyList = IsEmpty();
            
           
            var result = false;

            

            //empty list
            if(isEmptyList || value.Equals(Head.Data))
            {
                Insert(element);
                result = true;
            }

            else 
            {
                //find the previous value before the inserted node
                var foundNode = FindNode(value);

                //create the new node
                var newNode = CreateNewNode(element);

                //found it
                if (foundNode != null)
                {
                    newNode.Next = foundNode;
                    foundNode.Previous.Next = newNode;
                    newNode.Previous = foundNode.Previous;
                    foundNode.Previous = newNode;
                   
                   
                    CurrentSize++;
                    result = true;
                }

            }



            return result;

        }

        public bool InsertAfter(T value, T element)
        {
            //check to see if the list is empty
            var isEmptyList = IsEmpty();


            var result = false;



            //empty list
            if (isEmptyList || value.Equals(Head.Data))
            {
                Append(element);
                result = true;
            }


            else
            {
                //find the previous value before the inserted node
                var foundNode = FindNode(value);

                //create the new node
                var newNode = CreateNewNode(element);

                //found it
                if (foundNode != null)
                {
                   
                    newNode.Previous = foundNode;
                    foundNode.Previous = newNode;
                    CurrentSize++;
                    result = true;
                }

            }

                return result;
        }

        public bool Remove(T element)
        {
            var result = false;

            //check to see if list is empty
            var isEmptyList = IsEmpty();

            //only delete on not empty list
            if(!isEmptyList)
            {
                //one element in the list
                if (Head.Next == null)
                {
                    Clear();
                    result = true;
                }

                //second element becomes head decrease the size
                else if (Head.Data.Equals(element))
                {
                    Head = Head.Next;
                    Head.Previous = null;
                    CurrentSize--;
                    result = true;
                }

                // find the previous node before the element to be remove
                else
                {

                    var foundNode = FindNode(element);

                    //previous node is found
                    if (foundNode != null)
                    {
                        if (foundNode.Next != null)
                            foundNode.Next = foundNode.Next.Next;

                        else
                            foundNode.Previous.Next = null;


                        CurrentSize--;
                        result = true;
                    }

                }
            }
            return result;
        }

        public void Clear()
        {
            Head = null;
            CurrentSize = 0;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Print()
        {
            //temp node pointing to the start of the list
            var temp = Head;

            //loop to the end of the list and print the data
            while (temp !=null)
            {
                
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }

        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Method to create a new doubly linked list node
        /// </summary>
        /// <param name="data">The data to be stored</param>
        /// <returns>A new doubly linked list node with a the given data</returns>
        private DoublyNode<T> CreateNewNode(T data)
        {
            return new DoublyNode<T>(data);
        }

        /// <summary>
        /// Method to print all the values in the linked list includes previous pointer
        /// </summary>
        public void PrintAll()
        {

            //temp node pointing to the start of the list
            var temp = Head;

            //loop to the end of the list and print the data
            while (temp != null)
            {
                Console.WriteLine($"Data:{temp.Data}");
                 
                if(temp.Next !=null)
                    Console.WriteLine($"Next Data:{temp.Next.Data}");
                else
                    Console.WriteLine($"Next Data: Null");


                if (temp.Previous != null)
                    Console.WriteLine($"Previous Data:{temp.Previous.Data}");
                else
                    Console.WriteLine($"Previous Data: Null");

                Console.WriteLine("********************************************************");


                temp = temp.Next;
            }

        }


        /// <summary>
        /// Method to return a node in the doubly linked list 
        /// </summary>
        /// <param name="value">the value to be searched for</param>
        /// <returns>A reference to the node</returns>
        private DoublyNode<T> FindNode(T value)
        {
            DoublyNode<T> foundNode = null;
            var temp = Head;

            while(temp != null)
            {
                if(temp.Data.Equals(value))
                {
                    foundNode = temp;
                    break;
                }

                temp = temp.Next;
            }


            return foundNode;
        }

        #endregion 
    }
}

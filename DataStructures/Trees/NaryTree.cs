using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.NodeClasses;
using DataStructures.Interfaces;

namespace DataStructures.Trees
{
    /// <summary>
    /// Class to represent a tree with many children
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NaryTree<T> : INaryTreeOperations<T>
    {
        #region Fields
        /// <summary>
        /// field to represent the root of the tree
        /// </summary>
        private NaryTreeNode<T> root;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public NaryTree() 
        {
            root = null;
        }

        /// <summary>
        /// Constructor that takes in the data for the root of the tree
        /// </summary>
        /// <param name="data"></param>
        public NaryTree(T data)
        {
            root = new NaryTreeNode<T>(data);
        }

        #endregion

        #region INaryTreeOperations Implementations

        /// <summary>
        /// Method to insert a a node at the root without any children
        /// </summary>
        /// <param name="item">The item to add the root</param>
        /// <returns>True if the node was added successfully</returns>
        public bool InsertTopLevel(T item)
        {
            var added = false;
            var newNode = new NaryTreeNode<T>(item);

            if (root != null)
            {
                root.ChildrenList.Add(newNode);
                added = true;
            }

            //item becomes the new root
            else
            {
                root.Data = item;
                added = true;
            }

           

            return added;

        }

        public bool InsertTopLevelWithChildren(T item, List<NaryTreeNode<T>> children)
        {
            var added = false;
            var newNode = new NaryTreeNode<T>(item, children);


            if (root != null)
            {
                root.ChildrenList.Add(newNode);
                added = true;
            }

            //node becomes the new root
            else
            {
                root = newNode;
                added = true;
            }
             
            return added;
        }

        public bool Insert(T item, T value)
        {
            var added = false;
            var newNode = new NaryTreeNode<T>(value);

            var found = Find(item);

            //found the node
            if (found != null)
            {
                if (found.ChildrenList != null)
                {
                    found.ChildrenList.Add(newNode);
                    added = true;
                }
            }

            return added;
        }

        public void Clear()
        {
            root = null;
        }

        public NaryTreeNode<T> Find(T item)
        {
            //case of empty tree 
            if (root == null)
                return null;

            var queue = new Queue<NaryTreeNode<T>>();
            var found = false;

            //current node when traversing the tree
            NaryTreeNode<T> current = null;

            //holds the value of the found item
            NaryTreeNode<T> foundItem = null;

            //add root to the queue
            queue.Enqueue(root);

            //while the queue is not empty and item is found
            while (queue.Count() != 0 && !found)
            {
                //remove the first node in the queue
                current = queue.Dequeue();

                //current node is not null
                if (current != null)
                {
                    //if found 
                    if (current.Data.Equals(item))
                        found = true;

                    //not found at the current level so add its children
                    else
                    {
                        //add its children if they have any to the queue
                        if (current.ChildrenList != null)
                        {
                            foreach (var child in current.ChildrenList)
                                queue.Enqueue(child);
                        }
                    }
                }

            }

            return foundItem;
        }

        public void PrintTree()
        {
            if (root == null)
                Console.WriteLine("Empty Tree");

            var queue = new Queue<NaryTreeNode<T>>();

            NaryTreeNode<T> current = null;

            queue.Enqueue(root);

            //while the queue is not empty 
            while(queue.Count() !=0)
            {
                //remove the first node in the queue
                current = queue.Dequeue();

                //current node is not null
                if(current !=null)
                {
                    //print it
                    Console.Write(current.Data);

                    //add its children if they have any to the queue
                    if(current.ChildrenList !=null)
                    {
                        foreach (var child in current.ChildrenList)
                            queue.Enqueue(child);
                    }
                }

                Console.WriteLine();
            }

        }


        #endregion


    }
}

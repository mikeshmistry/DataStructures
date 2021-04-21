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
                root = newNode;
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

            //found at root
            if (root.Data.Equals(item))
                return root;

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
                    {
                        found = true;
                        foundItem = current;
                    }
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


        public bool Remove(T item)
        {
            var removed = false;
            var found = false;
            NaryTreeNode<T> current = null;
            NaryTreeNode<T> removedNode = null;
            var queue = new Queue<NaryTreeNode<T>>();

            //base case empty tree
            if (IsEmpty())
                return true;

            //case delete at root removes all children
            if (root != null && root.Data.Equals(item))
            {
                Clear();
                return true;
            }

            queue.Enqueue(root);

            while (queue.Count != 0 && !found)
            {
                current = queue.Dequeue();

                if (current != null)
                {
                    //found it so exit
                    if (current.Data.Equals(item))
                    {
                        found = true;
                        removedNode = current;
                    }
                    //not found so check the children of the node
                    else
                    {
                        if (current.ChildrenList != null)
                        {
                            foreach (var child in current.ChildrenList)
                            {
                                if (child.Data.Equals(item))
                                {
                                    found = true;
                                    removedNode = child;
                                    break;
                                }

                                //children list is not null queue it
                                else if (child.ChildrenList.Count !=0)
                                {
                                    queue.Enqueue(child);
                                }
                            }
                        }

                    }
                }
            }

            //remove the node
            if (removedNode !=null && current != null && current.ChildrenList != null)
            {
                current.ChildrenList.Remove(removedNode);
                removed = true;
            }

                return removed;


            }

            public bool IsEmpty()
            {
                return root == null;
            }

            public void PrintTree()
            {
                if (root == null)
                    Console.WriteLine("Empty Tree");

                var queue = new Queue<NaryTreeNode<T>>();

                NaryTreeNode<T> current = null;

                queue.Enqueue(root);

                //while the queue is not empty 
                while (queue.Count() != 0)
                {
                    //remove the first node in the queue
                    current = queue.Dequeue();

                    //current node is not null
                    if (current != null)
                    {
                        //print it
                        Console.Write(current.Data);

                        //add its children if they have any to the queue
                        if (current.ChildrenList != null)
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

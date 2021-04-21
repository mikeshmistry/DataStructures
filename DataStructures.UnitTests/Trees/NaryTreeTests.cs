using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Trees;
using DataStructures.NodeClasses;
using System.Collections.Generic;

namespace DataStructures.UnitTests.Trees
{
    /// <summary>
    /// Class to test nary tree class
    /// </summary>
    [TestClass]
    public class NaryTreeTests
    {

        #region Constructor Tests

        /// <summary>
        /// Test method to test the default constructor Root should be null
        /// </summary>
        [TestMethod]
        public void NaryTree_DefaultConstructorTest()
        {
            var myNumberTree = new NaryTree<int>();

            //is empty should return true as root is null
            Assert.IsTrue(myNumberTree.IsEmpty());
        }

        /// <summary>
        /// Test method to test a constructor with data
        /// </summary>
        [TestMethod]
        public void NaryTree_ConstuctorWithData()
        {
            var employeeTree = new NaryTree<string>("Mikesh Mistry");
            var found = employeeTree.Find("Mikesh Mistry");

            Assert.IsNotNull(found);
        }

        #endregion

        #region Insert Methods Tests

        #region InsertTopLevel Tests

        /// <summary>
        /// Test to insert at the root level when the root is null
        /// </summary>
        [TestMethod]
        public void InsertTopLevel_EmptyTree_ReturnsTrue()
        {
            var myIntegerTree = new NaryTree<int>();

            //test to see if the tree is empty 
            var isEmpty = myIntegerTree.IsEmpty();

            Assert.IsTrue(isEmpty);

            var added = myIntegerTree.InsertTopLevel(9);

            //should return true that it was added
            Assert.IsTrue(added);

            var foundNode = myIntegerTree.Find(9);

            //should find 9 at root and should not be null
            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                //data should be 9 as the root
                Assert.IsTrue(foundNode.Data == 9);

                //children list should have no children
                Assert.IsTrue(foundNode.ChildrenList.Count == 0);
            }
        }

        /// <summary>
        /// Test to insert at the root level when the root is not null
        /// </summary>
        [TestMethod]
        public void InsertTopLevel_NonEmptyTree_ReturnsTrue()
        {

            var myOrganizationTree = new NaryTree<string>("Jimmy");
            var added = false;
            NaryTreeNode<string> foundNode = null;

            //root of the tree should not be null
            Assert.IsFalse(myOrganizationTree.IsEmpty());

            //add Kim to Jimmy(Root)
            added = myOrganizationTree.InsertTopLevel("Kim");
            Assert.IsTrue(added);

            //find the root
            foundNode = myOrganizationTree.Find("Jimmy");

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Jimmy");

                //Added Kim to Jimmy's Children list
                Assert.IsTrue(foundNode.ChildrenList.Count == 1);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Kim");
            }

            added = myOrganizationTree.InsertTopLevel("Kate");
            Assert.IsTrue(added);

            //find the root
            foundNode = myOrganizationTree.Find("Jimmy");

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Jimmy");

                //Added Kim to Jimmy's Children list
                Assert.IsTrue(foundNode.ChildrenList.Count == 2);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Kim");
                Assert.IsTrue(foundNode.ChildrenList[1].Data == "Kate");
            }


            added = myOrganizationTree.InsertTopLevel("Mikesh");
            //find the root
            foundNode = myOrganizationTree.Find("Jimmy");

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Jimmy");

                //Added Kim to Jimmy's Children list
                Assert.IsTrue(foundNode.ChildrenList.Count == 3);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Kim");
                Assert.IsTrue(foundNode.ChildrenList[1].Data == "Kate");
                Assert.IsTrue(foundNode.ChildrenList[2].Data == "Mikesh");
            }
        }

        #endregion

        #region InsertTopLevelWithChildren Tests

        /// <summary>
        /// Test to insert into a tree where root is null with a new root with children should return true
        /// </summary>
        [TestMethod]
        public void InsertTopLevelWithChildren_EmptyTree_ReturnsTrue()
        {
            var myOrganizationTree = new NaryTree<string>();
            var added = false;
            NaryTreeNode<string> foundNode = null;

            //root of the tree should be null
            Assert.IsTrue(myOrganizationTree.IsEmpty());

            //create a children list
            var Children = new List<NaryTreeNode<string>>()
            {
                new NaryTreeNode<string>("Kim"),
                new NaryTreeNode<string>("Kate"),
                new NaryTreeNode<string>("Mikesh")
            };

            //add root node Jimmy with children 
            added = myOrganizationTree.InsertTopLevelWithChildren("Jimmy", Children);

            //should return true as it was added
            Assert.IsTrue(added);

            foundNode = myOrganizationTree.Find("Jimmy");

            //should find it
            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Jimmy");
                Assert.IsTrue(foundNode.ChildrenList.Count == 3);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Kim");
                Assert.IsTrue(foundNode.ChildrenList[1].Data == "Kate");
                Assert.IsTrue(foundNode.ChildrenList[2].Data == "Mikesh");

            }

        }


        /// <summary>
        /// Test to insert into a tree where root is not null and adding a new node with children should return true 
        /// </summary>
        [TestMethod]
        public void InsertTopLevelWithChildren_NonEmptyTree_ReturnsTrue()
        {

            var myOrganizationTree = new NaryTree<string>("Jimmy");
            var added = false;
            NaryTreeNode<string> foundNode = null;

            //root of the tree should be not null
            Assert.IsFalse(myOrganizationTree.IsEmpty());

            //find the root which is Jimmy and should have no children
            foundNode = myOrganizationTree.Find("Jimmy");

            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Jimmy");
                Assert.IsTrue(foundNode.ChildrenList.Count == 0);
            }


            //create a children list
            var Children = new List<NaryTreeNode<string>>()
            {
                new NaryTreeNode<string>("Kim"),
                new NaryTreeNode<string>("Kate"),
                new NaryTreeNode<string>("Mikesh")
            };



            //add root node Jimmy with children 
            added = myOrganizationTree.InsertTopLevelWithChildren("Timmy", Children);

            //should return true as it was added
            Assert.IsTrue(added);

            foundNode = myOrganizationTree.Find("Timmy");

            //should find it
            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Timmy");
                Assert.IsTrue(foundNode.ChildrenList.Count == 3);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Kim");
                Assert.IsTrue(foundNode.ChildrenList[1].Data == "Kate");
                Assert.IsTrue(foundNode.ChildrenList[2].Data == "Mikesh");

            }

        }
        #endregion

        #region Insert Tests


        /// <summary>
        /// Test to insert into a tree where the item does not exist should return false 
        /// </summary>
        [TestMethod]
        public void Insert_NodeNotFound_ReturnsFalse()
        {
            var myEmployees = new NaryTree<string>("Kim");
            var added = myEmployees.Insert("Mikesh", "Jimmy");

            //should be false 
            Assert.IsFalse(added);
        }

        /// <summary>
        /// Test to insert into a tree where the item does exist
        /// </summary>
        [TestMethod]
        public void Insert_NodeFound_ReturnsTrue()
        {
            var myOrganizationTree = new NaryTree<string>();
            var added = false;
            NaryTreeNode<string> foundNode = null;

            //root of the tree should be null
            Assert.IsTrue(myOrganizationTree.IsEmpty());

            //create a children list
            var Children = new List<NaryTreeNode<string>>()
            {
                new NaryTreeNode<string>("Kim"),
                new NaryTreeNode<string>("Kate"),
                new NaryTreeNode<string>("Mikesh")
            };

            //add root node Jimmy with children 
            added = myOrganizationTree.InsertTopLevelWithChildren("Jimmy", Children);

            //should return true as it was added
            Assert.IsTrue(added);

            //Find Mikesh node it's children list should be 0 before inserting Timmy
            foundNode = myOrganizationTree.Find("Mikesh");

            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Mikesh");
                Assert.IsTrue(foundNode.ChildrenList.Count == 0);
            }

            //add Timmy to Mikesh's children list
            added = myOrganizationTree.Insert("Mikesh", "Timmy");

            Assert.IsTrue(added);

            //Find Mikesh node it's children list should be 1 after inserting Timmy
            foundNode = myOrganizationTree.Find("Mikesh");

            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Mikesh");
                Assert.IsTrue(foundNode.ChildrenList.Count == 1);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Timmy");
            }

        }

        #endregion



        #endregion

        #region Clear Tests

        /// <summary>
        /// Test to clear an non empty tree
        /// </summary>
        [TestMethod]
        public void Clear_NonEmptyTree_Tree_ShouldBe_Empty()
        {

            var myIntegerTree = new NaryTree<int>();

            //test to see if the tree is empty 
            var isEmpty = myIntegerTree.IsEmpty();

            Assert.IsTrue(isEmpty);

            var added = myIntegerTree.InsertTopLevel(9);

            //should return true that it was added
            Assert.IsTrue(added);

            myIntegerTree.Clear();

            Assert.IsTrue(myIntegerTree.IsEmpty());



        }



        #endregion

        #region Find Tests

        /// <summary>
        /// Test to find an item when the tree is empty should return null
        /// </summary>
        [TestMethod]
        public void Find_EmptyTree_ReturnsNull()
        {
            var myStringTree = new NaryTree<String>();

            //The tree should be empty
            Assert.IsTrue(myStringTree.IsEmpty());

            var found = myStringTree.Find("Test");

            //Should return null 
            Assert.IsNull(found);
        }

        /// <summary>
        /// Test to find an item when the item is not found
        /// </summary>
        [TestMethod]
        public void Find_ItemNotFound_ReturnsNull()
        {
            var myStringTree = new NaryTree<String>("Test");
            var found = myStringTree.Find("Testers");

            //Should return null 
            Assert.IsNull(found);
        }

        /// <summary>
        /// Test to find an item when the item exists should return the item
        /// </summary>
        [TestMethod]
        public void Find_ItemFound_ReturnsFoundItem()
        {

            var myOrganizationTree = new NaryTree<string>();
            var added = false;
            NaryTreeNode<string> foundNode = null;

            //root of the tree should be null
            Assert.IsTrue(myOrganizationTree.IsEmpty());

            //create a children list
            var Children = new List<NaryTreeNode<string>>()
            {
                new NaryTreeNode<string>("Kim"),
                new NaryTreeNode<string>("Kate"),
                new NaryTreeNode<string>("Mikesh")
            };

            //add root node Jimmy with children 
            added = myOrganizationTree.InsertTopLevelWithChildren("Jimmy", Children);

            //should return true as it was added
            Assert.IsTrue(added);

            //Find Mikesh node it's children list should be 0 before inserting Timmy
            foundNode = myOrganizationTree.Find("Mikesh");

            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Mikesh");
                Assert.IsTrue(foundNode.ChildrenList.Count == 0);
            }







        }

        #endregion

        #region Remove Tests

        /// <summary>
        /// Test to remove an item that does not exist should return false
        /// </summary>
        [TestMethod]
        public void Remove_ItemNotFound_ReturnsFalse()
        {
            var myLetters = new NaryTree<char>('b');
            var found = myLetters.Remove('x');
            Assert.IsFalse(found);

            //find the existing item to ensure that it was not delete
            var foundItem = myLetters.Find('b');
            Assert.IsNotNull(foundItem);
            
            if(foundItem !=null)
            {
                Assert.IsTrue(foundItem.Data == 'b');
                Assert.IsTrue(foundItem.ChildrenList.Count == 0);
            }

        }

        /// <summary>
        /// Test to remove an item when the tree is empty should return true
        /// </summary>
        [TestMethod]
        public void Remove_EmptyTree_ReturnsTrue()
        {
            var myTree = new NaryTree<int>();

            //tree should be empty 
            Assert.IsTrue(myTree.IsEmpty());

            var removed = myTree.Remove(10);
            
            Assert.IsTrue(removed);
            
            // tree should still be empty
            Assert.IsTrue(myTree.IsEmpty());

        }

        /// <summary>
        /// Test to remove the root when the tree is not empty should return true and clear the tree
        /// </summary>
        [TestMethod]
        public void Remove_Root_ReturnsTrue()
        {
            var myOrganizationTree = new NaryTree<string>();
            var added = false;
            NaryTreeNode<string> foundNode = null;

            //root of the tree should be null
            Assert.IsTrue(myOrganizationTree.IsEmpty());

            //create a children list
            var Children = new List<NaryTreeNode<string>>()
            {
                new NaryTreeNode<string>("Kim"),
                new NaryTreeNode<string>("Kate"),
                new NaryTreeNode<string>("Mikesh")
            };

            //add root node Jimmy with children 
            added = myOrganizationTree.InsertTopLevelWithChildren("Jimmy", Children);

            //should return true as it was added
            Assert.IsTrue(added);

            //Find Root Jimmy
            foundNode = myOrganizationTree.Find("Jimmy");

            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Jimmy");
                Assert.IsTrue(foundNode.ChildrenList.Count == 3);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Kim");
                Assert.IsTrue(foundNode.ChildrenList[1].Data == "Kate");
                Assert.IsTrue(foundNode.ChildrenList[2].Data == "Mikesh");

            }

            //Remove the root
            myOrganizationTree.Remove("Jimmy");

            //root of the tree should be null after removing root
            Assert.IsTrue(myOrganizationTree.IsEmpty());
        }

        /// <summary>
        /// Test to remove a node from the tree with children should return true 
        /// </summary>
        [TestMethod]
        public void Remove_ItemNotRoot_ReturnsTrue()
        {
            var myOrganizationTree = new NaryTree<string>();
            var added = false;
            NaryTreeNode<string> foundNode = null;

            //root of the tree should be null
            Assert.IsTrue(myOrganizationTree.IsEmpty());

            //create a children list
            var Children = new List<NaryTreeNode<string>>()
            {
                new NaryTreeNode<string>("Kim"),
                new NaryTreeNode<string>("Kate"),
                new NaryTreeNode<string>("Mikesh")
            };

            //add some children to Kate
            Children[1].ChildrenList.Add(new NaryTreeNode<string>("Jack"));
            Children[1].ChildrenList.Add(new NaryTreeNode<string>("Peter"));
            Children[1].ChildrenList[1].ChildrenList.Add(new NaryTreeNode<string>("Mike"));


            //add root node Jimmy with children 
            added = myOrganizationTree.InsertTopLevelWithChildren("Jimmy", Children);

            //should return true as it was added
            Assert.IsTrue(added);

            //Find Kate
            foundNode = myOrganizationTree.Find("Kate");

            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Kate");
                Assert.IsTrue(foundNode.ChildrenList.Count == 2);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Jack");
                Assert.IsTrue(foundNode.ChildrenList[1].Data == "Peter");
            }

            //Remove Kate
         var removed =  myOrganizationTree.Remove("Kate");

            Assert.IsTrue(removed);

            foundNode = myOrganizationTree.Find("Kate");

            //Kate should not be found
            Assert.IsNull(foundNode);

        }



        /// <summary>
        /// Test to remove a node from the tree with nested node should return true 
        /// </summary>
        [TestMethod]
        public void Remove_NestedItem_ReturnsTrue()
        {
            var myOrganizationTree = new NaryTree<string>();
            var added = false;
            NaryTreeNode<string> foundNode = null;

            //root of the tree should be null
            Assert.IsTrue(myOrganizationTree.IsEmpty());

            //create a children list
            var Children = new List<NaryTreeNode<string>>()
            {
                new NaryTreeNode<string>("Kim"),
                new NaryTreeNode<string>("Kate"),
                new NaryTreeNode<string>("Mikesh")
            };

            //add some children to Kate
            Children[1].ChildrenList.Add(new NaryTreeNode<string>("Jack"));
            Children[1].ChildrenList.Add(new NaryTreeNode<string>("Peter"));
            Children[1].ChildrenList[1].ChildrenList.Add(new NaryTreeNode<string>("Mike"));


            //add root node Jimmy with children 
            added = myOrganizationTree.InsertTopLevelWithChildren("Jimmy", Children);

            //should return true as it was added
            Assert.IsTrue(added);

            //Find Kate
            foundNode = myOrganizationTree.Find("Kate");

            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Kate");
                Assert.IsTrue(foundNode.ChildrenList.Count == 2);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Jack");
                Assert.IsTrue(foundNode.ChildrenList[1].Data == "Peter");
            }

            //Remove Peter
            var removed = myOrganizationTree.Remove("Peter");

            Assert.IsTrue(removed);

            foundNode = myOrganizationTree.Find("Peter");

            //Peter should not be found
            Assert.IsNull(foundNode);

            //find Kate Peter's parent
            foundNode = myOrganizationTree.Find("Kate");

            Assert.IsNotNull(foundNode);

            if (foundNode != null)
            {
                Assert.IsTrue(foundNode.Data == "Kate");
                Assert.IsTrue(foundNode.ChildrenList.Count == 1);
                Assert.IsTrue(foundNode.ChildrenList[0].Data == "Jack");
            }


        }

        #endregion

        #region IsEmpty Tests
        /// <summary>
        /// Test case to check if tree is empty should return true
        /// </summary>
        [TestMethod]
        public void IsEmpty_ReturnsTrue()
        {
            var myEmployeeList = new NaryTree<string>();
            var isEmpty = myEmployeeList.IsEmpty();

            //should be true
            Assert.IsTrue(isEmpty);
        }

        /// <summary>
        /// Test case to check if tree is empty should return false
        /// </summary>
        [TestMethod]
        public void IsEmpty_ReturnsFalse()
        {
            var myEmployeeList = new NaryTree<string>("Jimmy");
            var isEmpty = myEmployeeList.IsEmpty();

            //should be false
            Assert.IsFalse(isEmpty);
        }

        #endregion



    }
}

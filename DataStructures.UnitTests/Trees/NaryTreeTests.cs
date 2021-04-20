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

            if(foundNode !=null)
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
           added =  myOrganizationTree.InsertTopLevel("Kim");
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

            if(foundNode != null)
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

            if(foundNode != null)
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

        #endregion



        #endregion

        #region Clear Tests

        #endregion

        #region Find Tests

        #endregion

        #region Remove Tests

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

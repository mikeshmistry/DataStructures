using DataStructures.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Lists
{
    /// <summary>
    /// Class to unit test singly linked list class
    /// </summary>
    [TestClass]
    public class SinglyLinkedListTests
    {
        #region Constructor Tests

        /// <summary>
        /// Test for Default Constructor
        /// </summary>
        [TestMethod]
        public void SinglyLinkedList_DefaultConstructor()
        {
            var list = new SinglyLinkedList<int>();
            Assert.IsTrue(list.CurrentSize == 0);
        }

        #endregion

        #region Append Tests

        /// <summary>
        /// Test to Append to the list. CurrentSize should be one and returns true
        /// </summary>
        [TestMethod]
        public void Append_ReturnsTrue()
        {
            var list = new SinglyLinkedList<int>();
            var result = list.Append(10);

            //Check to see if the size is 1
            Assert.IsTrue(list.CurrentSize == 1);

            //Result should be true
            Assert.IsTrue(result == true);
        }

        #endregion

        #region Clear Test

        /// <summary>
        /// Test to clear an non empty list number of elements should be 0
        /// </summary>
        [TestMethod]
        public void Clear_NonEmptyList_CurrentSizeIsZero()
        {

            var list = new SinglyLinkedList<int>();

            list.Append(10);
            list.Append(100);
            list.Clear();

            Assert.IsTrue(list.CurrentSize == 0);

        }

        #endregion

        #region Insert Tests

        /// <summary>
        /// Test to insert to the front list. CurrentSize should be one and returns true
        /// </summary>
        [TestMethod]
        public void Insert_ReturnsTrue()
        {
            var list = new SinglyLinkedList<int>();
            var result = list.Insert(10);

            //Check to see if the size is 1
            Assert.IsTrue(list.CurrentSize == 1);

            //Result should be true
            Assert.IsTrue(result == true);


        }

        #endregion

        #region InsertAfter Tests

        /// <summary>
        /// Test to insert after an item. In this case test for single item should return true
        /// </summary>
        [TestMethod]
        public void InsertAfter_SingleItem_Returns_True()
        {
            var list = new SinglyLinkedList<int>();
            var result = false;

            result = list.InsertAfter(10, 20);


            //check the currentSize should be one
            Assert.IsTrue(list.CurrentSize == 1);
            Assert.IsTrue(result == true);

        }

        /// <summary>
        /// Test to insert after an given value that is in the list and should return true
        /// </summary>
        [TestMethod]
        public void InsertAfter_ReturnsTrue()
        {
            var list = new SinglyLinkedList<int>();
            var result = false;

            result = list.InsertAfter(10, 20);
            result = list.InsertAfter(20, 10);


            //check the currentSize should be two
            Assert.IsTrue(list.CurrentSize == 2);

            //check for result to be true
            Assert.IsTrue(result == true);

        }

        /// <summary>
        /// Test to insert after a given value that is not in the list should return false
        /// </summary>
        [TestMethod]
        public void InsertAfter_ValueToBeInsertedAfterNotFound_ReturnsFalse()
        {
            var list = new SinglyLinkedList<int>();
            var result = false;

            result = list.InsertAfter(10, 20);
            result = list.InsertAfter(120, 10);



            //check the currentSize should be one
            Assert.IsTrue(list.CurrentSize == 1);

            //check for result to be true
            Assert.IsTrue(result == false);

        }

        #endregion

        #region InsertBefore Tests

        /// <summary>
        /// Test to insert before an item. In this case test for single item should return true
        /// </summary>
        [TestMethod]
        public void InsertBefore_SingleItem_Returns_True()
        {
            var list = new SinglyLinkedList<int>();
            var result = false;

            result = list.InsertBefore(10, 20);


            //check the currentSize should be one
            Assert.IsTrue(list.CurrentSize == 1);
            Assert.IsTrue(result == true);
        }

        /// <summary>
        /// Test to insert before a given value that is in the list and should return true
        /// </summary>
        [TestMethod]
        public void InsertBefore_ReturnsTrue()
        {
            var list = new SinglyLinkedList<int>();
            var result = false;

            result = list.InsertBefore(10, 20);
            result = list.InsertBefore(20, 10);

            

            //check the currentSize should be two
            Assert.IsTrue(list.CurrentSize == 2);

            //check for result to be true
            Assert.IsTrue(result == true);

   
        }

        /// <summary>
        /// Test to insert before a given value that is not in the list should return false
        /// </summary>
        [TestMethod]
        public void InsertBefore_ValueToBeInsertedBeforeNotFound_ReturnsFalse()
        {
            var list = new SinglyLinkedList<int>();
            var result = false;

            result = list.InsertBefore(10, 20);
            result = list.InsertBefore(120, 10);

            //check the currentSize should be one
            Assert.IsTrue(list.CurrentSize == 1);

            //check for result to be true
            Assert.IsTrue(result == false);

        }

        #endregion

        #region IsEmpty Tests

        /// <summary>
        /// Test to see if a list is empty should return true
        /// </summary>
        [TestMethod]
        public void IsEmpty_ReturnsTrue()
        {
            var list = new SinglyLinkedList<int>();
            var isEmpty = list.IsEmpty();

            Assert.IsTrue(isEmpty == true);
            Assert.IsTrue(list.CurrentSize == 0);
        }


        /// <summary>
        /// Test to see if a list is not empty should return false
        /// </summary>
        [TestMethod]
        public void IsEmpty_ReturnsFalse()
        {
            var list = new SinglyLinkedList<int>();
            list.Insert(10);
            var isEmpty = list.IsEmpty();

            Assert.IsTrue(isEmpty == false);
            Assert.IsTrue(list.CurrentSize == 1);
        }

        #endregion

        #region Remove Test

        /// <summary>
        /// Test to remove on a empty list should return false
        /// </summary>
        [TestMethod]
        public void Remove_EmptyList_ReturnsFalse()
        {
            var list = new SinglyLinkedList<int>();
            var removedItem = list.Remove(2);

            Assert.IsTrue(removedItem == false);
            Assert.IsTrue(list.CurrentSize == 0);
        }


        /// <summary>
        /// Test to see if one element is in the list should return true
        /// </summary>
        [TestMethod]
        public void Remove_OneElementInList_ReturnsTrue()
        {
            var list = new SinglyLinkedList<int>(); 
            list.Append(2);
            var removedItem = list.Remove(2);

            Assert.IsTrue(removedItem == true);
            Assert.IsTrue(list.CurrentSize == 0);
        }

        /// <summary>
        /// Test to see if any items it the list can be deleted should return true
        /// </summary>
        [TestMethod]
        public void Remove_AnyElement_ReturnsTrue()
        {
            var list = new SinglyLinkedList<int>();
            list.Append(2);
            list.Append(42);
            list.Append(25);

            var removedItem = list.Remove(2);
            removedItem = list.Remove(25);
            Assert.IsTrue(removedItem == true);
            Assert.IsTrue(list.CurrentSize == 1);
        }


        #endregion
    }
}

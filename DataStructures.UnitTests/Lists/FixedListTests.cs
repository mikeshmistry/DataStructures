using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lists;
using System.Collections.Generic;

namespace DataStructures.UnitTests.Lists
{
    /// <summary>
    /// Class to unit test fixed list class 
    /// </summary>
    [TestClass]
    public class FixedListTests
    {

        #region Constructor Tests
        
        /// <summary>
        /// Test for Default Constructor
        /// </summary>
        [TestMethod]
        public void FixedList_DefaultConstructor()
        {
            var list = new FixedList<int>();
            Assert.IsTrue(list.CurrentSize == 0);
            Assert.IsTrue(list.MaxSize == 100);
        }

        /// <summary>
        /// Test for Size Constructor
        /// </summary>
        [TestMethod]
        public void FixedList_SizeConstructor()
        {
            var list = new FixedList<int>(2);
            Assert.IsTrue(list.CurrentSize == 0);
            Assert.IsTrue(list.MaxSize == 2);
        }
        #endregion

        #region Append Tests

        /// <summary>
        /// Test to Append to the list. CurrentSize should be one and returns true
        /// </summary>
        [TestMethod]
        public void Append_ReturnsTrue()
        {
            var list = new FixedList<int>();
            var result = list.Append(10);
            var found = list.FindIndex(10);

            //Check to see if the size is 1
            Assert.IsTrue(list.CurrentSize == 1);

            //Result should be true
            Assert.IsTrue(result == true);
            
            // 10 should be the only item in the list
            Assert.IsTrue(found == 0);
        }

        /// <summary>
        /// Test to Append to the full list. CurrentSize should remain as the given size and should return false
        /// </summary>
        [TestMethod]
        public void Append_OnFullList_ReturnsFalse()
        {
            var list = new FixedList<int>(2);
            var result = false;

           
            result = list.Append(10);
            result = list.Append(100);
            result = list.Append(20);

            var lastIndex = list.FindIndex(100);

            //Last append should return false as
            Assert.IsTrue(result == false);
            Assert.IsTrue(list.CurrentSize == 2);

            //100 should be the last index at 1 for two items
            Assert.IsTrue(lastIndex == 1);

        }


        #endregion

        #region Clear Test

        /// <summary>
        /// Test to clear an non empty list number of elements should be 0
        /// </summary>
        [TestMethod]
        public void Clear_NonEmptyList_CurrentSizeIsZero()
        {

            var list = new FixedList<int>(2);
                
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
            var list = new FixedList<int>();
            var result = list.Insert(10);

            var firstItem = list.FindIndex(10);


            //Check to see if the size is 1
            Assert.IsTrue(list.CurrentSize == 1);

            //Result should be true
            Assert.IsTrue(result == true);

            //first Item should be at index 0
            Assert.IsTrue(firstItem == 0);
        }

        /// <summary>
        /// Test to insert into a full list. CurrentSize should remain as the given size and should return false
        /// </summary>
        [TestMethod]
        public void Insert_OnFullList_ReturnsFalse()
        {
            var list = new FixedList<int>(2);
            var result = false;

            result = list.Insert(10);
            result = list.Insert(100);
            result = list.Insert(20);

            var firstIndex = list.FindIndex(100);

            //Last append should return false as
            Assert.IsTrue(result == false);
            Assert.IsTrue(list.CurrentSize == list.MaxSize);

            //first item in list should be at index 0
            Assert.IsTrue(firstIndex == 0);

        }

        #endregion

        #region InsertAfter Tests

        /// <summary>
        /// Test to insert after an item. In this case test for single item should return true
        /// </summary>
        [TestMethod]
        public void InsertAfter_SingleItem_Returns_True()
        {
            var list = new FixedList<int>();
            var result = false;
            
            result = list.InsertAfter(10, 20);
            var found = list.FindIndex(20); 

            //check the currentSize should be one
            Assert.IsTrue(list.CurrentSize == 1);
            Assert.IsTrue(result == true);

            //index of 10 should be 0(first item in the list)
            Assert.IsTrue(found == 0);
        }

        /// <summary>
        /// Test to insert after an given value that is in the list and should return true
        /// </summary>
        [TestMethod]
        public void InsertAfter_ReturnsTrue()
        {
            var list = new FixedList<int>();
            var result = false;

            result = list.InsertAfter(10, 20);
            result = list.InsertAfter(20, 10);

            var found = list.FindIndex(10);

            //check the currentSize should be two
            Assert.IsTrue(list.CurrentSize == 2);
            
            //check for result to be true
            Assert.IsTrue(result == true);

            //index of 10 should be 1(last item in the list)
            Assert.IsTrue(found == 1);
        }

        /// <summary>
        /// Test to insert after a given value that is not in the list should return false
        /// </summary>
        [TestMethod]
        public void InsertAfter_ValueToBeInsertedAfterNotFound_ReturnsFalse()
        {
            var list = new FixedList<int>();
            var result = false;

            result = list.InsertAfter(10, 20);
            result = list.InsertAfter(120, 10);

            var found = list.FindIndex(120);

            //check the currentSize should be one
            Assert.IsTrue(list.CurrentSize == 1);

            //check for result to be true
            Assert.IsTrue(result == false);

            //index of 120 should be -1 not found
            Assert.IsTrue(found == -1);
        }

        /// <summary>
        /// Test to insert after a given value when the list is full should return false
        /// </summary>
        [TestMethod]
        public void InsertAfter_ListIsFull_ReturnsFalse()
        {
            var list = new FixedList<int>(2);
            var result = false;

            result = list.InsertAfter(10, 20);
            result = list.InsertAfter(20, 120);
            result = list.InsertAfter(120,40);

            var found = list.FindIndex(40);

            //check the currentSize should be MaxSize
            Assert.IsTrue(list.CurrentSize == list.MaxSize);

            //check for result to be true
            Assert.IsTrue(result == false);

            //index of 120 should be -1 not found
            Assert.IsTrue(found == -1);
        }

        #endregion

        #region InsertBefore Tests

        /// <summary>
        /// Test to insert before an item. In this case test for single item should return true
        /// </summary>
        [TestMethod]
        public void InsertBefore_SingleItem_Returns_True()
        {
            var list = new FixedList<int>();
            var result = false;

            result = list.InsertBefore(10, 20);
            var found = list.FindIndex(20);

            //check the currentSize should be one
            Assert.IsTrue(list.CurrentSize == 1);
            Assert.IsTrue(result == true);

            //index of 10 should be 0(first item in the list)
            Assert.IsTrue(found == 0);
        }

        /// <summary>
        /// Test to insert before a given value that is in the list and should return true
        /// </summary>
        [TestMethod]
        public void InsertBefore_ReturnsTrue()
        {
            var list = new FixedList<int>();
            var result = false;

            result = list.InsertBefore(10, 20);
            result = list.InsertBefore(20, 10);

            var found = list.FindIndex(10);

            //check the currentSize should be two
            Assert.IsTrue(list.CurrentSize == 2);

            //check for result to be true
            Assert.IsTrue(result == true);

            //index of 10 should be 0(first item in the list)
            Assert.IsTrue(found == 0);
        }

        /// <summary>
        /// Test to insert before a given value that is not in the list should return false
        /// </summary>
        [TestMethod]
        public void InsertBefore_ValueToBeInsertedBeforeNotFound_ReturnsFalse()
        {
            var list = new FixedList<int>();
            var result = false;

            result = list.InsertBefore(10, 20);
            result = list.InsertBefore(120, 10);

            var found = list.FindIndex(120);

            //check the currentSize should be one
            Assert.IsTrue(list.CurrentSize == 1);

            //check for result to be true
            Assert.IsTrue(result == false);

            //index of 120 should be -1 not found
            Assert.IsTrue(found == -1);
        }

        /// <summary>
        /// Test to insert before a given value when the list is full should return false
        /// </summary>
        [TestMethod]
        public void InsertBefore_ListIsFull_ReturnsFalse()
        {
            var list = new FixedList<int>(2);
            var result = false;

            result = list.InsertBefore(10, 20);
            result = list.InsertBefore(20, 120);
            result = list.InsertBefore(120, 40);

            var found = list.FindIndex(40);

            //check the currentSize should be MaxSize
            Assert.IsTrue(list.CurrentSize == list.MaxSize);

            //check for result to be true
            Assert.IsTrue(result == false);

            //index of 120 should be -1 not found
            Assert.IsTrue(found == -1);
        }




        #endregion
        
        #region IsEmpty Tests

        /// <summary>
        /// Test to see if a list is empty should return true
        /// </summary>
        [TestMethod]
        public void IsEmpty_ReturnsTrue()
        {
            var list = new FixedList<int>();
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
            var list = new FixedList<int>();
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
            var list = new FixedList<int>();
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
            var list = new FixedList<int>();
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
            var list = new FixedList<int>();
            list.Append(2);
            list.Append(42);
            list.Append(25);

            var removedItem = list.Remove(2);
            removedItem = list.Remove(25);
            Assert.IsTrue(removedItem == true);
            Assert.IsTrue(list.CurrentSize == 1);
        }
    
        
        #endregion


        #region Test for Other Methods

        #region FindIndex Tests

        /// <summary>
        /// Test to find an item in an empty list should return -1 
        /// </summary>
        [TestMethod]
        public void FindIndex_EmptyList_ReturnsNegativeOne()
        {
            var list = new FixedList<int>();
            var notFoundItem = list.FindIndex(-100);
            Assert.IsTrue(notFoundItem == -1);
        }

        /// <summary>
        /// Test to find an item in an non empty list should return -1 
        /// </summary>
        [TestMethod]
        public void FindIndex_ItemNotFound_ReturnsNegativeOne()
        {
            var list = new FixedList<int>();
            list.Append(10);
            var notFoundItem = list.FindIndex(-100);

            Assert.IsTrue(notFoundItem == -1);
        }

        /// <summary>
        /// Test to find an item in an non empty list should return index of item 
        /// </summary>
        [TestMethod]
        public void FindIndex_ItemFound_ReturnsIndexOfFoundItem()
        {
            var list = new FixedList<int>();
            list.Append(10);
            list.Append(100);
            list.Insert(45);
            list.InsertAfter(45, 60);
            list.InsertBefore(60, 85);

            //85 should be the second item
            var foundItem = list.FindIndex(85);

            Assert.IsTrue(foundItem == 1);
        }

        #endregion

        #region IsFull Tests

        /// <summary>
        /// Test to see if the list is full should return true
        /// </summary>
        [TestMethod]
        public void IsFull_ReturnsTrue()
        {
            var list = new FixedList<int>(2);
            list.Append(20);
            list.Append(11);

            var isListFull = list.IsFull();

            Assert.IsTrue(isListFull == true);
        }


        /// <summary>
        /// Test to see if the list is not full should return false
        /// </summary>
        [TestMethod]
        public void IsFull_ReturnsFalse()
        {
            var list = new FixedList<int>(2);
            list.Append(20);
       

            var isListFull = list.IsFull();

            Assert.IsTrue(isListFull == false);
        }
        #endregion

        #endregion
    }
}

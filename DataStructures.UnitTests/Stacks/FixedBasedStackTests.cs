using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Stacks;

namespace DataStructures.UnitTests.Stacks
{
    /// <summary>
    /// Class to unit test a fixed based stack
    /// </summary>
    [TestClass]
    public class FixedBasedStackTests
    {
        #region Constructor Tests

        /// <summary>
        /// Test for the default constructor
        /// </summary>
        [TestMethod]
        public void FixedBasedStack_DefaultConstructor()
        {
            var stack = new FixedBasedStack<int>();
            
            Assert.IsTrue(stack.MaxSize == 100);
            Assert.IsTrue(stack.CurrentSize == 0);

        }

        /// <summary>
        /// Test for the size constructor
        /// </summary>
        [TestMethod]
        public void FixedBasedStack_SizeConstructor()
        {
            var stack = new FixedBasedStack<int>(2);

            Assert.IsTrue(stack.MaxSize == 2);
            Assert.IsTrue(stack.CurrentSize == 0);

        }


        #endregion

        #region Clear Tests

        /// <summary>
        /// Test to clear an empty stack
        /// </summary>
        [TestMethod]
        public void Clear_EmptyStack_CurrentSizeIsZero()
        {
            var stack = new FixedBasedStack<int>();
            stack.Clear();

            Assert.IsTrue(stack.CurrentSize == 0);
        }



        /// <summary>
        /// Test to clear a non empty stack
        /// </summary>
        [TestMethod]
        public void Clear_NonEmptyStack_CurrentSizeIsZero()
        {
            var stack = new FixedBasedStack<int>();
            stack.Push(10);
            stack.Clear();

            Assert.IsTrue(stack.CurrentSize == 0);
        }

        #endregion

        #region IsEmpty Tests

        /// <summary>
        /// Test to check if the stack is empty should return true
        /// </summary>
        [TestMethod]
        public void IsEmpty_StackIsEmpty_ReturnsTrue()
        {
            var stack = new FixedBasedStack<int>();
            var result = stack.IsEmpty();

            Assert.IsTrue(result == true);
        }

        /// <summary>
        /// Test to check if the stack is not empty should return true
        /// </summary>
        [TestMethod]
        public void IsEmpty_StackIsNotEmpty_ReturnsFalse()
        {
            var stack = new FixedBasedStack<int>();
            stack.Push(29);
            var result = stack.IsEmpty();

            Assert.IsTrue(result == false);
        }

        #endregion

        #region Push Tests

        /// <summary>
        /// Test to push many items on the stack that is equal to max size 
        /// </summary>
        [TestMethod]
        public void Push_ReturnsTrue()
        {
            var stack = new FixedBasedStack<int>(2);
            var result = stack.Push(10);
            result = stack.Push(100);

            Assert.IsTrue(result == true);
            Assert.IsTrue(stack.CurrentSize == 2);
        }


        /// <summary>
        /// Test to push items on the stack that is more than max size 
        /// </summary>
        [TestMethod]
        public void Push_ReturnsFalse()
        {
            var stack = new FixedBasedStack<int>(2);
            var result = stack.Push(10);
            result = stack.Push(100);
            result = stack.Push(1000);

            Assert.IsTrue(result == false);
            Assert.IsTrue(stack.CurrentSize == 2);
        }

        #endregion

        #region Pop Tests

        /// <summary>
        /// Test to pop on an empty stack should return default value of the type of stack
        /// </summary>
        [TestMethod]
        public void Pop_EmptyStack_DefaultValueOfTheType()
        {
            //Test for default of string should be null
            var stringStack = new FixedBasedStack<string>();
            var stringResult = stringStack.Pop();

            //Test for default of string should be null
            var intStack = new FixedBasedStack<int>();
            var intResult = intStack.Pop();

            Assert.IsTrue(stringResult == null);
            Assert.IsTrue(stringStack.CurrentSize == 0);

            Assert.IsTrue(intResult == 0);
            Assert.IsTrue(intStack.CurrentSize == 0);


        }


        /// <summary>
        /// Test to pop on an non empty stack should return the value and remove it from the stack
        /// </summary>
        [TestMethod]
        public void Pop_NonEmptyStack_ItemRemovedFromStack()
        {
            var stack = new FixedBasedStack<int>(2);
            stack.Push(10);
            stack.Push(100);

            var popedItem = stack.Pop();

            //first pop should return 100 one item should remain
            Assert.IsTrue(popedItem == 100);
            Assert.IsTrue(stack.CurrentSize == 1);

            popedItem = stack.Pop();

            //second pop should be 10 no item should remain
            Assert.IsTrue(popedItem == 10);
            Assert.IsTrue(stack.CurrentSize == 0);

            popedItem = stack.Pop();

            // pop on empty list
            Assert.IsTrue(popedItem == 0);
            Assert.IsTrue(stack.CurrentSize == 0);


        }

        #endregion

        #region Other Method Tests

        #region IsFull Tests

        /// <summary>
        /// Test to see if stack is full
        /// </summary>
        [TestMethod]
        public void IsFull_ReturnsTrue()
        {
            var stack = new FixedBasedStack<int>(2);
            stack.Push(100);
            stack.Push(10);

            var isFull = stack.IsFull();

            Assert.IsTrue(isFull == true);
        }

        /// <summary>
        /// Test to see if stack is not full
        /// </summary>
        [TestMethod]
        public void IsFull_ReturnsFalse()
        {
            var stack = new FixedBasedStack<int>(2);
            stack.Push(100);
         
            var isFull = stack.IsFull();

            Assert.IsTrue(isFull == false);
        }

        #endregion
     
     #endregion
    }
}

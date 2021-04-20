using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Stacks;

namespace DataStructures.UnitTests.Stacks
{
    /// <summary>
    /// Class to unit test dynamic stack class 
    /// </summary>
    [TestClass]
    public class DynamicStackTests
    {
        #region Constructor Tests

        /// <summary>
        /// Test for the default constructor
        /// </summary>
        [TestMethod]
        public void DynamicBasedStack_DefaultConstructor()
        {
            var stack = new DynamicStack<int>();
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
            var stack = new DynamicStack<int>();
            stack.Clear();

            Assert.IsTrue(stack.CurrentSize == 0);
        }



        /// <summary>
        /// Test to clear a non empty stack
        /// </summary>
        [TestMethod]
        public void Clear_NonEmptyStack_CurrentSizeIsZero()
        {
            var stack = new DynamicStack<int>();
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
            var stack = new DynamicStack<int>();
            var result = stack.IsEmpty();

            Assert.IsTrue(result == true);
        }

        /// <summary>
        /// Test to check if the stack is not empty should return false
        /// </summary>
        [TestMethod]
        public void IsEmpty_StackIsNotEmpty_ReturnsFalse()
        {
            var stack = new DynamicStack<int>();
            stack.Push(29);
            var result = stack.IsEmpty();

            Assert.IsTrue(result == false);
        }

        #endregion

        #region Push Tests

        /// <summary>
        /// Test to push many items on the stack
        /// </summary>
        [TestMethod]
        public void Push_ReturnsTrue()
        {
            var stack = new DynamicStack<int>();
            var result = stack.Push(10);
            result = stack.Push(100);
            result = stack.Push(1000);
            result = stack.Push(-100);

            Assert.IsTrue(result == true);
            Assert.IsTrue(stack.CurrentSize == 4);
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
            var stringStack = new DynamicStack<string>();
            var stringResult = stringStack.Pop();

            //Test for default of string should be null
            var intStack = new DynamicStack<int>();
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
            var stack = new DynamicStack<int>();
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


    }
}

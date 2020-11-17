using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Queues;

namespace DataStructures.UnitTests.Queues
{
    /// <summary>
    /// Class to unit test a dynamic queue class
    /// </summary>
    [TestClass]
    public class DynamicQueueTests
    {
        #region Constructor Tests
        
        /// <summary>
        /// Test for the default constructor
        /// </summary>
        [TestMethod]
        public void DynamicQueue_DefaultConstructor()
        {
            var queue = new DynamicQueue<int>();
            Assert.IsTrue(queue.CurrentSize == 0);
        }

        #endregion

        #region Enqueue Tests

        /// <summary>
        /// Test to enqueue items onto a queue
        /// </summary>
        [TestMethod]
        public void Enqueue_ReturnsTrue()
        {
            var queue = new DynamicQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(100);
            queue.Enqueue(200);

            //should be three items in the queue
            Assert.IsTrue(queue.CurrentSize == 3);
        }

        #endregion

        #region Dequeue Tests

        /// <summary>
        /// Test to dequeue multiply items from queue
        /// </summary>
        [TestMethod]
        public void Dequeue_ReturnsItems()
        {
            var queue = new DynamicQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(100);
            queue.Enqueue(200);

            //should be three items in the queue
            Assert.IsTrue(queue.CurrentSize == 3);

            var item = queue.Dequeue();

            //dequeued item should be 10
            Assert.IsTrue(item ==  10);

            //items in the queue should be 2
            Assert.IsTrue(queue.CurrentSize == 2);

            item = queue.Dequeue();

            //dequeued item should be 100
            Assert.IsTrue(item == 100);

            //items in the queue should be 1
            Assert.IsTrue(queue.CurrentSize == 1);

            item = queue.Dequeue();

            //dequeued item should be 200
            Assert.IsTrue(item == 200);

            //items in the queue should be 0 and queue is empty
            Assert.IsTrue(queue.CurrentSize ==0);
            Assert.IsTrue(queue.IsEmpty() == true);


        }

        /// <summary>
        /// Test to check default values on empty queue
        /// </summary>
        [TestMethod]
        public void Dequeue_EmptyQueue_ReturnsDefaultForItems()
        {
            var intQueue = new DynamicQueue<int>();
            var intItem = intQueue.Dequeue();

            Assert.IsTrue(intQueue.CurrentSize == 0);
            Assert.IsTrue(intItem  == default(int));

            var stringQueue = new DynamicQueue<string>();
            var stringItem = stringQueue.Dequeue();

            Assert.IsTrue(stringQueue.CurrentSize == 0);
            Assert.IsTrue(stringItem == default(string));
        }

        #endregion

        #region Clear Tests
        /// <summary>
        /// Test to clear an empty queue
        [TestMethod]
        public void Clear_EmptyQueue_CurrentSizeIsZero()
        {
            var queue = new DynamicQueue<int>();
            queue.Clear();

            Assert.IsTrue(queue.CurrentSize == 0);
        }



        /// <summary>
        /// Test to clear a non empty queue
        /// </summary>
        [TestMethod]
        public void Clear_NonEmptyQueue_CurrentSizeIsZero()
        {
            var queue = new DynamicQueue<int>();
            queue.Enqueue(10);
            queue.Clear();

            Assert.IsTrue(queue.CurrentSize == 0);
        }

        #endregion

        #region IsEmpty Tests

        /// <summary>
        /// Test to check if the queue is empty should return true
        /// </summary>
        [TestMethod]
        public void IsEmpty_ReturnsTrue()
        {
            var queue = new DynamicQueue<int>();
            var result = queue.IsEmpty();

            Assert.IsTrue(result == true);
        }

        /// <summary>
        /// Test to check if the queue is not empty should return false
        /// </summary>
        [TestMethod]
        public void IsEmpty_ReturnsFalse()
        {
            var queue = new DynamicQueue<int>();
            queue.Enqueue(29);
            var result = queue.IsEmpty();

            Assert.IsTrue(result == false);
        }

        #endregion

    }
}

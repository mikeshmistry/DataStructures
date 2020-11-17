using System;
using System.Runtime.InteropServices;
using DataStructures.Queues;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Queues
{
    /// <summary>
    /// Class to unit test a fixed based queue
    /// </summary>
    [TestClass]
    public class FixedBasedQueueTests
    {
        #region Constructor Tests

        /// <summary>
        /// Test for the default constructor
        /// </summary>
        [TestMethod]
        public void FixedBasedQueue_DefaultConstructor()
        {
            var queue = new FixedBasedQueue<int>();

            Assert.IsTrue(queue.MaxSize == 100);
            Assert.IsTrue(queue.CurrentSize == 0);
        }

        /// <summary>
        /// Test for size Constructor 
        /// </summary>
        [TestMethod]
        public void FixedBasedQueue_SizeConstructor()
        {
            var queue = new FixedBasedQueue<int>(2);
            Assert.IsTrue(queue.MaxSize == 2);
            Assert.IsTrue(queue.CurrentSize == 0);

        }
        #endregion

        #region Enqueue Tests

        /// <summary>
        /// Test to enqueue max size on a queue returns true
        /// </summary>
        [TestMethod]
        public void Enqueue_MaxSize_ReturnsTrue()
        {
            var queue = new FixedBasedQueue<int>(2);
            var result = queue.Enqueue(19);
            result = queue.Enqueue(20);

            Assert.IsTrue(result == true);
            Assert.IsTrue(queue.CurrentSize == queue.MaxSize);
        }

        /// <summary>
        /// Test to enqueue more than max size on a queue returns false
        /// </summary>
        [TestMethod]
        public void Enqueue_MoreThanMaxSize_ReturnsFalse()
        {
            var queue = new FixedBasedQueue<int>(2);
            var result = queue.Enqueue(19);
            result = queue.Enqueue(20);
            result = queue.Enqueue(202);

           

            Assert.IsTrue(result == false);
            Assert.IsTrue(queue.CurrentSize == queue.MaxSize);
        }

        #endregion

        #region Dequeue Tests

        /// <summary>
        /// Test to Dequeue a single element
        /// </summary>
        [TestMethod]
        public void Deqeue_SingleElement_ReturnsItemInQueue()
        {
            var queue = new FixedBasedQueue<int>();
            var result = queue.Enqueue(10);
            var item = queue.Dequeue();

            //current size should be 0;
            Assert.IsTrue(queue.CurrentSize == 0);

            //result should be true of the En-queuing 
            Assert.IsTrue(result == true);

            //dequeued item should be 10
            Assert.IsTrue(item == 10);


        }

        /// <summary>
        /// Test to create a queue with 2 item and dequeue until queue is empty
        /// </summary>
        [TestMethod]
        public void Dequeue_UntilEmptyQueue_ReturnsItemsInQueue()
        {
            var queue = new FixedBasedQueue<int>(2);
            var result = queue.Enqueue(10);
             result = queue.Enqueue(100);
          
           
            var item = queue.Dequeue();

            //dequeued item should be 10
            Assert.IsTrue(item == 10);

            //current size should be 1;
            Assert.IsTrue(queue.CurrentSize == 1);

            item = queue.Dequeue();
            //dequeued item should be 100
            Assert.IsTrue(item == 100);

            //current size should be 0 after dequeuing 100
            Assert.IsTrue(queue.CurrentSize == 0);

            //queue should be empty
            Assert.IsTrue(queue.IsEmpty() == true);
        }

        /// <summary>
        /// Test to De-queue on a empty queue
        /// </summary>
        [TestMethod]
        public void Dequeue_EmptyQueue_ReturnsDefaultValue()
        {
            var intQueue = new FixedBasedQueue<int>();
            var intQueueItem = intQueue.Dequeue();

            //check to see if the int item returned is the default value of int which is 0
            Assert.IsTrue(intQueueItem == default(int));

            var stringQueue = new FixedBasedQueue<string>();
            var stringQueueItem = stringQueue.Dequeue();

            //check to see if the string item returned is the default value of string which is null
            Assert.IsTrue(stringQueueItem == default(string));

        }




        #endregion

        #region IsEmpty Tests
        /// <summary>
        /// Test to see if the queue is empty
        /// </summary>
        [TestMethod]
        public void IsEmpty_ReturnsTrue()
        {
            var queue = new FixedBasedQueue<int>();
            var result = queue.IsEmpty();

            Assert.IsTrue(result == true);
            Assert.IsTrue(queue.CurrentSize == 0);
        }


        /// <summary>
        /// Test to see if the queue is not empty
        /// </summary>
        [TestMethod]
        public void IsEmpty_ReturnsFalse()
        {
            var queue = new FixedBasedQueue<int>();
            queue.Enqueue(10);
            var result = queue.IsEmpty();

            Assert.IsTrue(result == false);
            Assert.IsTrue(queue.CurrentSize == 1);
        }

        #endregion

        #region Clear Tests

        /// <summary>
        /// Test to clear an empty queue
        /// </summary>
        [TestMethod]
        public void Clear_EmptyQueue_CurrentSizeIsZero()
        {
            var queue = new FixedBasedQueue<int>();
            queue.Clear();

            Assert.IsTrue(queue.CurrentSize == 0);
        }



        /// <summary>
        /// Test to clear a non empty queue
        /// </summary>
        [TestMethod]
        public void Clear_NonEmptyQueue_CurrentSizeIsZero()
        {
            var queue = new FixedBasedQueue<int>();
            queue.Enqueue(10);
            queue.Clear();

            Assert.IsTrue(queue.CurrentSize == 0);
        }
        #endregion

        #region Other Method Tests

        /// <summary>
        /// Test to check if queue is full
        /// </summary>
        [TestMethod]
        public void Isfull_ReturnTrue()
        {
            var queue = new FixedBasedQueue<int>(1);
            queue.Enqueue(10);
            var isFull = queue.IsFull();

            Assert.IsTrue(queue.CurrentSize == 1);
            Assert.IsTrue(isFull == true);

        }


        /// <summary>
        /// Test to check if queue is not full
        /// </summary>
        [TestMethod]
        public void Isfull_ReturnFalse()
        {
            var queue = new FixedBasedQueue<int>(2);
            queue.Enqueue(10);
            var isFull = queue.IsFull();

            Assert.IsTrue(queue.CurrentSize == 1);
            Assert.IsTrue(isFull == false);

        }

        #endregion
    }
}

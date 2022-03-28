﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTests
{
    [TestClass]
    public class TestLimitedQueue
    {
        [TestMethod]
        public void EnqueueAddUpToNElementsToQueueWhereIsNProvidedInConstructor()
        {
            var queue = new LimitedQueue<int>(3);
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Count);
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Count);
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Count);
            queue.Enqueue(4);
            Assert.AreEqual(3, queue.Count);
            Assert.IsTrue(queue.Contains(2));
            Assert.IsTrue(queue.Contains(3));
            Assert.IsTrue(queue.Contains(4));
            queue.Enqueue(5);
            Assert.AreEqual(3, queue.Count);
            Assert.IsTrue(queue.Contains(5));
            Assert.IsTrue(queue.Contains(3));
            Assert.IsTrue(queue.Contains(4));
        }
    }
}

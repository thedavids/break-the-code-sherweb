using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakTheCode.Tests
{
    [TestClass]
    public class BreakTheCodeTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseInPlaceArgumentNullException()
        {
            ListUtils.ReverseInPlace(null);
        }

        [TestMethod]
        public void TestReverseInPlaceEmpty()
        {
            var list = new List<int>();
            var expected = new List<int>();

            ListUtils.ReverseInPlace(list);

            Assert.AreEqual(true, list.SequenceEqual(expected));
        }

        [TestMethod]
        public void TestReverseInPlaceEven()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var expected = new List<int>() { 6, 5, 4, 3, 2, 1 };

            ListUtils.ReverseInPlace(list);

            Assert.AreEqual(true, list.SequenceEqual(expected));
        }

        [TestMethod]
        public void TestReverseInPlaceOdd()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var expected = new List<int>() { 7, 6, 5, 4, 3, 2, 1 };

            ListUtils.ReverseInPlace(list);

            Assert.AreEqual(true, list.SequenceEqual(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyAndDisposeArgumentNullException()
        {
            ListUtils.EmptyAndDispose(null);
        }

        [TestMethod]
        public void TestEmptyAndDisposeNoDisposable()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            ListUtils.EmptyAndDispose(list);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestEmptyAndDisposeWithDisposables()
        {
            var btcd = new BreakTheCodeDisposable();
            var list = new List<BreakTheCodeDisposable>() { btcd, new BreakTheCodeDisposable(), null };

            Assert.AreEqual(false, btcd.DisposedValue);

            ListUtils.EmptyAndDispose(list);

            Assert.AreEqual(true, btcd.DisposedValue);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DisposeAllArgumentNullException()
        {
            ListUtils.DisposeAll(null);
        }

        [TestMethod]
        public void TestDisposeAllNoDisposable()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var count = list.Count;

            ListUtils.DisposeAll(list);

            Assert.AreEqual(count, list.Count);
        }

        [TestMethod]
        public void TestDisposeAllWithDisposables()
        {
            var btcd = new BreakTheCodeDisposable();
            var list = new List<BreakTheCodeDisposable>() { btcd, new BreakTheCodeDisposable(), null };

            Assert.AreEqual(false, btcd.DisposedValue);
            Assert.AreEqual(false, list[1].DisposedValue);

            ListUtils.DisposeAll(list);

            Assert.AreEqual(true, btcd.DisposedValue);
            Assert.AreEqual(true, list[1].DisposedValue);
        }
    }
}

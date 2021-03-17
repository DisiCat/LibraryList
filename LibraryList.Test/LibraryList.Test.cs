using NUnit.Framework;
using System;

namespace LibraryList.Test
{
    public class LibraryListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 4 })]
        public void AddLast_WhenValuePassed_ThenAddLast(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddLast(4);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Constructor_WhenNullPassed_ThenReturnArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = new ArrayList(null);

            });
           
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] {4, 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 4 })]
        public void AddFirst_WhenValuePassed_ThenAddFirst(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddFirst(4);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, -2, new int[] { -2, 1, 2, 3 })]
        [TestCase(new int[] { }, 0, 10, new int[] {10 })]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 5, 4, new int[] { 3, 3, 3, 3, 3, 4, 3 })]
        public void AddByIndex_WhenValueAndIndexPassed_ThenAddByIndex(int[] actualArr, int index, int value, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddByIndex(index, value);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, -2, new int[] { -2, 1, 2, 3 })]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 6, 4, new int[] { 3, 3, 3, 3, 3, 4, 3 })]
        public void AddByIndex_WhenValueAndIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArr, int index, int value, int[] expectedArr)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {

                ArrayList actual = new ArrayList(actualArr);
                ArrayList expected = new ArrayList(expectedArr);

                actual.AddByIndex(index, value);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2})]
        [TestCase(new int[] { }, new int[] {})]
        public void RemoveLast_WhenMethodCalled_ThenRemoveLast(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveLast();

            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirst_WhenMethodCalled_ThenRemoveFirst(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveFirst();

            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 },0, new int[] { 2, 3 })]
        [TestCase(new int[] { }, 0,  new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] {1, 2})]
        public void RemoveByIndex_WhenIndexPassed_ThenRemoveByIndex(int[] actualArr, int index, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveByIndex(index);

            Assert.AreEqual(actual, expected);
        }

        


    }
}
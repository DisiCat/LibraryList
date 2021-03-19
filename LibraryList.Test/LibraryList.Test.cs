using NUnit.Framework;
using System;

namespace LibraryList.Test
{
    public class LibraryListTests
    {

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 4 })]
        public void AddLast_WhenValuePassed_ThenAddLast(int[] arrayForActualList, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);

            actual.AddLast(4);

            Assert.AreEqual( expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        public void AddLast_WhenListPassed_ThenAddListInLast(int[] arrayForActualList, int[] arrayForList, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);
            ArrayList list = new ArrayList(arrayForList);

            actual.AddLast(list);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { }, 0, new int[] { 0 })]
        public void AddFirst_WhenValuePassed_ThenAddFirst(int[] arrayForActualList, int value, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddFirst_WhenListPassed_ThenAddListInFirst(int[] arrayForActualList, int[] arrayForList, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);
            ArrayList list = new ArrayList(arrayForList);

            actual.AddFirst(list);

            Assert.AreEqual(expected, actual);
        }


        //[Test]
        //public void Constructor_WhenNullPassed_ThenReturnArgumentException()
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        ArrayList actual = new ArrayList(null);

        //    });

        //}

        [TestCase(new int[] { 1, 2, 3 }, 0, -2, new int[] { -2, 1, 2, 3 })]
        //[TestCase(new int[] { }, 0, 10, new int[] {10 })]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 5, 10, new int[] { 3, 3, 3, 3, 3, 10, 3 })]
        public void AddByIndex_WhenValueAndIndexPassed_ThenAddByIndex(int[] arrayForActualList, int index, int value, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, -2, new int[] { -2, 1, 2, 3 })]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 6, 4, new int[] { 3, 3, 3, 3, 3, 4, 3 })]
        public void AddByIndex_WhenValueAndIndexPassed_ThenReturnIndexOutOfRangeException(int[] arrayForActualList, int index, int value, int[] arrayForExpectedList)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {

                ArrayList actual = new ArrayList(arrayForActualList);
                ArrayList expected = new ArrayList(arrayForExpectedList);

                actual.AddByIndex(index, value);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        public void AddByIndex_WhenListAndIndexPassed_ThenAddListByIndex(int[] arrayForActualList, int index, int[] arrayForList, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);
            ArrayList list = new ArrayList(arrayForList);

            actual.AddByIndex(index, list);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        public void AddByIndex_WhenListAndIndexPassed_ThenReturnIndexOutOfRangeException(int[] arrayForActualList, int index, int[] arrayForList, int[] arrayForExpectedList)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(arrayForActualList);
                ArrayList expected = new ArrayList(arrayForExpectedList);
                ArrayList list = new ArrayList(arrayForList);

                actual.AddByIndex(index, list);

                Assert.AreEqual(expected, actual);
            });
        }



        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveLast_WhenMethodCalled_ThenRemoveLast(int[] arrayForActualList, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);

            actual.RemoveLast();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirst_WhenMethodCalled_ThenRemoveFirst(int[] arrayForActualList, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        public void RemoveByIndex_WhenIndexPassed_ThenRemoveByIndex(int[] arrayForActualList, int index, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 6)]
        public void RemoveByIndex_WhenIndexPassed_ThenReturnIndexOutOfRangeException(int[] arrayForActualList, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {

                ArrayList actual = new ArrayList(arrayForActualList);

                actual.RemoveByIndex(index);
            });
        }
        [TestCase(new int[] { 1, 2, 3 }, 0, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 8, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 1, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 2, new int[] { 1, 2, 3, 4, 5, 6, 7})]

        public void RemoveByIndex_WhenIndexAndNElements_ThenRemoveByIndexNElements(int[] arrayForActualList, int index, int nElements, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);

            actual.RemoveByIndex(index, nElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 9, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
         public void RemoveLast_WhenNElementsPassed_ThenRemoveLast(int[] arrayForActualList, int nElements, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);

            actual.RemoveLast(nElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, -1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void RemoveLast_WhenNegativeNElementsPassed_ThenReturnArgumentException(int[] arrayForActualList, int nElements, int[] arrayForExpectedList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = new ArrayList(arrayForActualList);
                ArrayList expected = new ArrayList(arrayForExpectedList);

                actual.RemoveLast(nElements);

                Assert.AreEqual(expected, actual);
            });
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4}, 3, new int[] {4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5, new int[] { 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 9, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void RemoveFirst_WhenNElementsPassed_ThenRemoveFirst(int[] arrayForActualList, int nElements, int[] arrayForExpectedList)
        {
            ArrayList actual = new ArrayList(arrayForActualList);
            ArrayList expected = new ArrayList(arrayForExpectedList);

            actual.RemoveFirst(nElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, -1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void RemoveFirst_WhenNegativeNElementsPassed_ThenReturnArgumentException(int[] arrayForActualList, int nElements, int[] arrayForExpectedList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = new ArrayList(arrayForActualList);
                ArrayList expected = new ArrayList(arrayForExpectedList);

                actual.RemoveLast(nElements);

                Assert.AreEqual(expected, actual);
            });
        }

        //    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 2,1)]
        //    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 10, -1)]
        //    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1, 0)]
        //    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 },8, 7)]

        //    public void GetIndexByValue_WhenValuePassed_ThenReturnIndex(int[] arrayForActualList , int value, int expected)
        //    { 
        //        ArrayList list = new ArrayList(arrayForActualList);
        //        int actual   = list.GetIndexByValue(value);
        //        Assert.AreEqual( expected, actual);

        //    }


        //}
    }
}
namespace UnitTests;

using PracticeExercise1;

[TestClass]
public class UnitTests
{

    [TestMethod]
    public void TestLength()
    {
        IList list = new ArrayList();

        Assert.AreEqual(0, list.Length);

        for (int i = 0; i < 10; i++)
        {
            list.Append(i);
        }

        Assert.AreEqual(10, list.Length);

        for (int i = 0; i < 32; i++)
        {
            list.Append(i);
        }

        Assert.AreEqual(42, list.Length);

    }

    [TestMethod]
    public void TestIsEmpty()
    {
        IList list = new ArrayList();

        Assert.IsTrue(list.IsEmpty);

        for (int i = 0; i < 10; i++)
        {
            list.Append(i);
        }

        Assert.IsFalse(list.IsEmpty);

    }

    [TestMethod]
    public void TestFirst()
    {
        IList list = new ArrayList();

        //Assert.ThrowsException<NullReferenceException>(() =>
        //{
        //    int i = list.First;
        //});

        int? nullFirst = list.First;

        Assert.IsNull(nullFirst);

        for (int i = 0; i < 10; i++)
        {
            list.Append(i);
            Assert.AreEqual(0, list.First);
        }

        Assert.AreEqual(10, list.Length);

        for (int i = 0; i < 32; i++)
        {
            list.Append(i);
            Assert.AreEqual(0, list.First);
        }

    }

    [TestMethod]
    public void TestLast()
    {
        IList list = new ArrayList();

        //Assert.ThrowsException<NullReferenceException>(() =>
        //{
        //    int i = list.Last;
        //});

        int? nullLast = list.Last;

        Assert.IsNull(nullLast);

        list.Append(0);

        Assert.AreEqual(0, list.Last);

        for (int i = 0; i < 10; i++)
        {
            list.Append(i);
            Assert.AreEqual(i, list.Last);
        }

        for (int i = 0; i < 32; i++)
        {
            list.Append(i);
            Assert.AreEqual(i, list.Last);
        }

    }

    [TestMethod]
    public void TestAppend()
    {
        IList list = new ArrayList();

        for (int i = 0; i < 10; i++)
        {
            list.Append(i);
            Assert.AreEqual(i, list.Last);
        }

        Assert.AreEqual("[0,1,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(10, list.Length);

        for (int i = 0; i < 32; i++)
        {
            list.Append(i);
            Assert.AreEqual(i, list.Last);
        }

        Assert.AreEqual("[0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31]", list.ToString().Replace(" ", ""));

    }

    [TestMethod]
    public void TestPrepend()
    {
        IList list = new ArrayList();
        list.Prepend(0);
        Assert.AreEqual(0, list.First);

        list = new ArrayList();

        for (int i = 9; i >= 0; i--)
        {
            list.Prepend(i);
            Assert.AreEqual(i, list.First);
        }

        Assert.AreEqual("[0,1,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(10, list.Length);

        for (int i = 31; i >= 0; i--)
        {
            list.Prepend(i);
            Assert.AreEqual(i, list.First);
        }

        Assert.AreEqual("[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,0,1,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));

    }

    [TestMethod]
    public void TestInsertAfter()
    {
        IList list = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            list.Append(i);
        }

        list.InsertAfter(42, 0);
        Assert.AreEqual("[0,42,1,2,3,4]", list.ToString().Replace(" ", ""));

        list.InsertAfter(42, 3);
        Assert.AreEqual("[0,42,1,2,3,42,4]", list.ToString().Replace(" ", ""));

        list.InsertAfter(42, 4);
        Assert.AreEqual("[0,42,1,2,3,42,4,42]", list.ToString().Replace(" ", ""));

        list.InsertAfter(42, 42);
        Assert.AreEqual("[0,42,42,1,2,3,42,4,42]", list.ToString().Replace(" ", ""));

        list.InsertAfter(400, 8);
        Assert.AreEqual("[0,42,42,1,2,3,42,4,42,400]", list.ToString().Replace(" ", ""));

        list = new ArrayList();
        list.InsertAfter(42, 3);
        Assert.AreEqual("[42]", list.ToString().Replace(" ", ""));

        // grow well past the initial capacity, inserting in the middle
        list = new ArrayList();
        list.Append(0);
        for (int i = 1; i < 50; i++)
        {
            list.InsertAfter(i, 0);
        }

        Assert.AreEqual(50, list.Length);
        Assert.AreEqual(0, list.First);
        Assert.AreEqual(1, list.Last);
        Assert.AreEqual("[0," + string.Join(",", Enumerable.Range(1, 49).Reverse()) + "]", list.ToString().Replace(" ", ""));

        // grow well past the initial capacity, inserting at the end
        list = new ArrayList();
        for (int i = 0; i < 50; i++)
        {
            list.InsertAfter(i, i - 1);
            Assert.AreEqual(i, list.Last);
        }

        Assert.AreEqual(50, list.Length);
        Assert.AreEqual("[" + string.Join(",", Enumerable.Range(0, 50)) + "]", list.ToString().Replace(" ", ""));
    }

    [TestMethod]
    public void TestInsertAt()
    {
        IList list = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            list.Append(i);
            Assert.AreEqual(i, list.Last);
        }

        list.InsertAt(42, 0);
        Assert.AreEqual("[42,0,1,2,3,4]", list.ToString().Replace(" ", ""));

        list.InsertAt(52, 3);
        Assert.AreEqual("[42,0,1,52,2,3,4]", list.ToString().Replace(" ", ""));

        list.InsertAt(62, list.Length - 1);
        Assert.AreEqual("[42,0,1,52,2,3,62,4]", list.ToString().Replace(" ", ""));

        list.InsertAt(72, list.Length);
        Assert.AreEqual("[42,0,1,52,2,3,62,4,72]", list.ToString().Replace(" ", ""));



        list = new ArrayList();
        list.InsertAt(42, 0);
        Assert.AreEqual("[42]", list.ToString().Replace(" ", ""));

        // index just out of bounds
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => list.InsertAt(42, list.Length + 1));
        Assert.AreEqual("[42]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(1, list.Length);

        // index past the end of the list, but small enough to fit in the underlying array
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => list.InsertAt(42, 5));
        Assert.AreEqual("[42]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(1, list.Length);

        // index too large
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => list.InsertAt(42, 42));
        Assert.AreEqual("[42]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(1, list.Length);

        // negative index
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => list.InsertAt(42, -1));
        Assert.AreEqual("[42]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(1, list.Length);

        Assert.ThrowsExactly<IndexOutOfRangeException>(() => list.InsertAt(42, -5));
        Assert.AreEqual("[42]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(1, list.Length);

        // grow well past the initial capacity, inserting at the front
        list = new ArrayList();
        for (int i = 0; i < 50; i++)
        {
            list.InsertAt(i, 0);
            Assert.AreEqual(i, list.First);
        }

        Assert.AreEqual(50, list.Length);
        Assert.AreEqual("[" + string.Join(",", Enumerable.Range(0, 50).Reverse()) + "]", list.ToString().Replace(" ", ""));

        // grow well past the initial capacity, inserting in the middle
        list = new ArrayList();
        list.Append(0);
        for (int i = 1; i < 50; i++)
        {
            list.InsertAt(i, 1);
        }

        Assert.AreEqual(50, list.Length);
        Assert.AreEqual("[0," + string.Join(",", Enumerable.Range(1, 49).Reverse()) + "]", list.ToString().Replace(" ", ""));

        // grow well past the initial capacity, inserting at the end
        list = new ArrayList();
        for (int i = 0; i < 50; i++)
        {
            list.InsertAt(i, list.Length);
            Assert.AreEqual(i, list.Last);
        }

        Assert.AreEqual(50, list.Length);
        Assert.AreEqual("[" + string.Join(",", Enumerable.Range(0, 50)) + "]", list.ToString().Replace(" ", ""));

    }

    [TestMethod]
    public void TestFirstIndexOf()
    {
        IList list = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            list.Append(i);
        }

        Assert.AreEqual(0, list.FirstIndexOf(0));
        Assert.AreEqual(4, list.FirstIndexOf(4));
        Assert.AreEqual(-1, list.FirstIndexOf(10));

        for (int i = 0; i < 50; i++)
        {
            list.Append(i);
        }

        Assert.AreEqual(0, list.FirstIndexOf(0));
        Assert.AreEqual(4, list.FirstIndexOf(4));
        Assert.AreEqual(15, list.FirstIndexOf(10));

        // 0 is not in the list, so it must not be found in the unused part of the array
        list = new ArrayList();
        for (int i = 1; i <= 5; i++)
        {
            list.Append(i);
        }

        Assert.AreEqual(-1, list.FirstIndexOf(0));

        // removed values must not be found
        list.Remove(5);
        Assert.AreEqual(-1, list.FirstIndexOf(5));

        list.RemoveAt(0);
        Assert.AreEqual(-1, list.FirstIndexOf(1));
        Assert.AreEqual(0, list.FirstIndexOf(2));

        list.Clear();
        Assert.AreEqual(-1, list.FirstIndexOf(3));
    }

    [TestMethod]
    public void TestContains()
    {
        IList list = new ArrayList();

        Assert.IsFalse(list.Contains(0));
        Assert.IsFalse(list.Contains(3));

        for (int i = 1; i <= 5; i++)
        {
            list.Append(i);
        }

        Assert.IsTrue(list.Contains(1));
        Assert.IsTrue(list.Contains(3));
        Assert.IsTrue(list.Contains(5));
        Assert.IsFalse(list.Contains(10));
        Assert.IsFalse(list.Contains(-1));

        // 0 is not in the list, so it must not be found in the unused part of the array
        Assert.IsFalse(list.Contains(0));

        // removed values must not be found
        list.Remove(5);
        Assert.IsFalse(list.Contains(5));

        list.RemoveAt(0);
        Assert.IsFalse(list.Contains(1));
        Assert.IsTrue(list.Contains(2));

        // values beyond the initial capacity
        for (int i = 100; i < 150; i++)
        {
            list.Append(i);
        }

        Assert.IsTrue(list.Contains(2));
        Assert.IsTrue(list.Contains(100));
        Assert.IsTrue(list.Contains(149));
        Assert.IsFalse(list.Contains(150));

        list.Clear();
        Assert.IsFalse(list.Contains(2));
        Assert.IsFalse(list.Contains(149));
    }

    [TestMethod]
    public void TestRemove()
    {
        IList list = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            list.Append(i);
        }

        list.Remove(0);
        Assert.AreEqual("[1,2,3,4]", list.ToString().Replace(" ", ""));

        list.Remove(4);
        Assert.AreEqual("[1,2,3]", list.ToString().Replace(" ", ""));

        list.Remove(5);
        Assert.AreEqual("[1,2,3]", list.ToString().Replace(" ", ""));

        for (int i = 0; i < 10; i++)
        {
            list.Append(i);
        }
        Assert.AreEqual("[1,2,3,0,1,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));

        list.Remove(1);
        list.Remove(1);
        Assert.AreEqual("[2,3,0,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));


        // Empty list
        list = new ArrayList();
        list.Remove(3);
        Assert.AreEqual("[]", list.ToString().Replace(" ", ""));

    }

    [TestMethod]
    public void TestRemoveAt()
    {
        IList list = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            list.Append(i);
            Assert.AreEqual(i, list.Last);
        }

        list.RemoveAt(0);
        Assert.AreEqual("[1,2,3,4]", list.ToString().Replace(" ", ""));

        list.RemoveAt(list.Length - 1);
        Assert.AreEqual("[1,2,3]", list.ToString().Replace(" ", ""));

        // index just out of bounds
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => list.RemoveAt(list.Length));
        Assert.AreEqual("[1,2,3]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(3, list.Length);

        // Index too large
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => list.RemoveAt(42));
        Assert.AreEqual("[1,2,3]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(3, list.Length);

        // Negative index
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => list.RemoveAt(-5));
        Assert.AreEqual("[1,2,3]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(3, list.Length);

        // Empty list
        list = new ArrayList();
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => list.RemoveAt(0));
        Assert.AreEqual("[]", list.ToString().Replace(" ", ""));
        Assert.AreEqual(0, list.Length);

    }

    [TestMethod]
    public void TestClear()
    {
        IList list = new ArrayList();
        list.Clear();
        Assert.AreEqual(0, list.Length);

        for (int i = 0; i < 10; i++)
        {
            list.Append(i);
        }

        list.Clear();
        Assert.AreEqual(0, list.Length);



        for (int i = 0; i < 64; i++)
        {
            list.Append(i);
            Assert.AreEqual(i, list.Last);
        }
        list.Clear();
        Assert.AreEqual(0, list.Length);

    }

    [TestMethod]
    public void TestReverse()
    {
        IList list = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            list.Append(i);
        }

        var reversed = list.Reverse();
        Assert.AreEqual("[4,3,2,1,0]", reversed.ToString().Replace(" ", ""));
        Assert.AreEqual("[0,1,2,3,4]", list.ToString().Replace(" ", ""));

        Assert.AreEqual("[0,1,2,3,4]", reversed.Reverse().ToString().Replace(" ", ""));
    }

    [TestMethod]
    public void TestGet()
    {
        IList list = new ArrayList();
        for (int i = 0; i < 5; i++)
        {
            list.Append(i);
        }

        Assert.AreEqual(0, list.Get(0));
        Assert.AreEqual(1, list.Get(1));
        Assert.AreEqual(2, list.Get(2));

        for (int i = 5; i < 50; i++)
        {
            list.Append(i);
        }

        Assert.AreEqual(45, list.Get(45));
        Assert.AreEqual(10, list.Get(10));
        Assert.AreEqual(49, list.Get(list.Length - 1));

        // index out of range
        Assert.IsNull(list.Get(list.Length));
        Assert.IsNull(list.Get(1000));
        Assert.IsNull(list.Get(-1));
        Assert.IsNull(list.Get(-5));

        // index past the end of the list, but small enough to fit in the underlying array
        list = new ArrayList();
        for (int i = 1; i <= 3; i++)
        {
            list.Append(i);
        }

        Assert.AreEqual(3, list.Get(2));
        Assert.IsNull(list.Get(3));
        Assert.IsNull(list.Get(5));

        // removed values must not be returned
        list.Clear();
        Assert.IsNull(list.Get(0));

        // empty list
        list = new ArrayList();
        Assert.IsNull(list.Get(0));
    }
}



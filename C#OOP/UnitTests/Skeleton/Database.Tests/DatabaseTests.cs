namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Test_Ctor_Assigning_Values()
        {
            Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Assert.That(database.Count == 10);
        }
        [Test]
        public void Test_Ctor_Exception_Thrown_If_Count_Exceeds_16()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(new int[17]);
            });
        }
        [Test]

        public void Test_Add_Throws_Exception_At_Count_16()
        {
            Database database = new Database(new int[16]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16});
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            });
        }
        [Test]
        public void Test_Add_Adds_Element_At_The_End()
        {
            Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            database.Add(17);
            Assert.That(database.Fetch()[database.Count-1] == 17);
        } 
        [Test]
        public void Test_Remove_Removes_Elements_At_The_End()
        {
            Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            database.Remove();
            Assert.That(database.Fetch()[database.Count-1] == 9);
        }
        [Test]
        public void Test_Remove_Throws_Exception_At_Count_Zero()
        {
            Database database = new Database(new int[] {});
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void Test_Fetch_Returns_Array()
        {
            Database database = new Database(new int[] {});
            Type type = typeof(int[]);
            Assert.That(database.Fetch().GetType() == type);
        }
    }
}

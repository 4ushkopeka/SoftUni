namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void Add_Exception_When_Capacity_Above_16()
        {
            Person[] peeps = new Person[16];
            for (int i = 0; i < 16; i++) peeps[i] = new Person(i, i.ToString());
            Database database = new Database(peeps);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(15, "Dimii")));
        }
        [Test]
        public void Add_Adds()
        {
            Person[] peeps = new Person[] { new Person(15, "Dimi") };
            Database database = new Database(peeps);
            database.Add(new Person(5, "Dimiiii"));
            Assert.AreEqual(2, database.Count);
        }
        [Test]
        public void Add_Exception_When_Person_Exists()
        {
            Person[] peeps = new Person[] { new Person(15, "Dimi") };
            Database database = new Database(peeps);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(15, "Dimii")));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(40, "Dimi")));
        }
        [Test]
        public void FindByName_Exception_When_Person_NotExist()
        {
            Person[] peeps = new Person[] { new Person(15, "Dimi") };
            Database database = new Database(peeps);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Dimii"));
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }
        [Test]
        public void FindByName_Finding()
        {
            Person p = new Person(15, "Dimi");
            Person[] peeps = new Person[] { p };
            Database database = new Database(peeps);
            Person pers = database.FindByUsername("Dimi");
            Assert.That(pers == p);
        }
        [Test]
        public void FindById_Exception_When_Person_NotExist()
        {
            Person[] peeps = new Person[] { new Person(15, "Dimi") };
            Database database = new Database(peeps);
            Assert.Throws<InvalidOperationException>(() => database.FindById(23));
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-34));
        }
        [Test]
        public void FindById_Finding()
        {
            Person p = new Person(15, "Dimi");
            Person[] peeps = new Person[] { p };
            Database database = new Database(peeps);
            Person pers = database.FindById(15);
            Assert.That(pers == p);
        }
        
        [Test]
        public void Test_Ctor_Assigning_Values()
        {
            Database database = new Database(new Person[1] { new Person(15, "Dimi") });
            Assert.That(database.Count == 1);
        }
        [Test]
        public void Test_PersonCtor_Assigning_Values()
        {
            Person database = new Person(15, "Dimi");
            Assert.That(database.UserName == "Dimi" && database.Id == 15);
        }
       [Test]
       public void Test_Ctor_Exception_Thrown_If_Count_Exceeds_16()
       {
           Assert.Throws<ArgumentException>(() =>
           {
               Database database = new Database(new Person[17]);
           });
       }
        [Test]
        public void Test_Remove_Removes_Elements_At_The_End()
        {
            Person[] peeps = new Person[] { new Person(15, "Dimi") };
            Database database = new Database(peeps);
            database.Remove();
            Assert.That(database.Count == 0);   
            
        }
        [Test]
        public void Test_Remove_Throws_Exception_At_Count_Zero()
        {
            Database database = new Database(new Person[] { });
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
    }
}
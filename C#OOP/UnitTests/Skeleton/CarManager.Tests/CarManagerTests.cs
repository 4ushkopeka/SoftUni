namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Private_Ctor_Initialization_Working()
        {
            var carManager = new Car("making", "audi", 34.7d, 20.8d);
            Assert.That(carManager.FuelAmount == 0);
        }
        [Test]
        public void Ctor_Initialization_Working()
        {
            var carManager = new Car("making", "audi", 34.7d, 20.8d);
            Assert.That(carManager.Make == "making" && carManager.Model == "audi" && carManager.FuelConsumption ==  34.7d && carManager.FuelCapacity == 20.8d);
        }
        [Test]
        public void Make_Exception_When_Null()
        {
            Car carManager;
            Assert.Throws<ArgumentException>(() => carManager = new Car(null, "audi", 34.7d, 20.8d));
        }
        [Test]
        public void Model_Exception_When_Null()
        {
            Car carManager;
            Assert.Throws<ArgumentException>(() => carManager = new Car("m", null, 34.7d, 20.8d));
        }
        [Test]
        public void FuelCons_Exception_When_Null()
        {
            Car carManager;
            Assert.Throws<ArgumentException>(() => carManager = new Car("m", "audi", 0, 20.8d));
            Assert.Throws<ArgumentException>(() => carManager = new Car("m", "audi", -98, 20.8d));
        }
        [Test]
        public void FuelCap_Exception_When_Null()
        {
            Car carManager;
            Assert.Throws<ArgumentException>(() => carManager = new Car("m", "audi", 34, 0));
            Assert.Throws<ArgumentException>(() => carManager = new Car("m", "audi", 78, -45));
        }
        [Test]
        public void Refuel_Exception_When_Value_BelowOrZero ()
        {
            Car carManager = new Car("m", "audi", 34, 45);
            Assert.Throws<ArgumentException>(() => carManager.Refuel(0));
            Assert.Throws<ArgumentException>(() => carManager.Refuel(-76));
        }
        [Test]
        public void Refuel_Refueling ()
        {
            Car carManager = new Car("m", "audi", 34, 45);
            carManager.Refuel(10);
            Assert.AreEqual(10, carManager.FuelAmount);

        }
        [Test]
        public void Refuel_Refueling_OverCap ()
        {
            Car carManager = new Car("m", "audi", 34, 45);
            carManager.Refuel(1000);
            Assert.AreEqual(45, carManager.FuelAmount);
        }
        [Test]
        public void Drive_Exception_When_NeededFuel_Exceeds_FuelAm ()
        {
            Car carManager = new Car("m", "audi", 34, 45);
            Assert.Throws<InvalidOperationException>(() => carManager.Drive(1000));
        }
        [Test]
        public void Drive_Decreasing_FuealAm_When_Driving()
        {
            Car carManager = new Car("m", "audi", 34, 10000);
            carManager.Refuel(1000);
            carManager.Drive(1000);
            Assert.That(carManager.FuelAmount, Is.EqualTo(660));
        }
    }
}
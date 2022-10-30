using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
       [Test]
       public void Ctor_Working_Properly()
       {
           Shop smartphoneShop = new Shop(10);   
           Assert.That(smartphoneShop.Capacity == 10);
           Assert.That(smartphoneShop.Count == 0);
       }
        [Test]
       public void Capacity_Exception_When_Below_Zero()
       {
            Shop smartphoneShop;   
           Assert.Throws<ArgumentException>(() => smartphoneShop = new Shop(-5));
       }
        [Test]
       public void Add_Exception_When_Adding_An_Existing_Phone()
       {
            Shop smartphoneShop = new Shop(10);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            smartphoneShop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => smartphoneShop.Add(phone));
       }
        [Test]
       public void Add_Exception_When_Count_Reaches_Capacity()
       {
            Shop smartphoneShop = new Shop(2);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            Smartphone phone1 = new Smartphone("dimitrichk", 10);
            Smartphone phone2 = new Smartphone("dimitrich", 1001);
            smartphoneShop.Add(phone);
            smartphoneShop.Add(phone1);
            Assert.Throws<InvalidOperationException>(() => smartphoneShop.Add(phone2));
       }
        [Test]
       public void Add_Adding_Then_Count_Increases_With_One()
       {
            Shop smartphoneShop = new Shop(2);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            smartphoneShop.Add(phone);
            Assert.That(smartphoneShop.Count == 1);
       }
        [Test]
       public void Remove_Exception_When_Phone_With_Such_Name_Does_Not_Exist()
       {
            Shop smartphoneShop = new Shop(2);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            smartphoneShop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => smartphoneShop.Remove("dimi"));
       }
        [Test]
       public void Remove_Removing_And_Count_Diminishing()
       {
            Shop smartphoneShop = new Shop(2);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            smartphoneShop.Add(phone);
            smartphoneShop.Remove("dimitrichko");
            Assert.That(smartphoneShop.Count == 0);
       }
        [Test]
       public void TestPhone_Exception_When_Phone_With_Such_Name_Does_Not_Exist()
        {
            Shop smartphoneShop = new Shop(2);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            smartphoneShop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => smartphoneShop.TestPhone("dimi", 90));
       }
        [Test]
       public void TestPhone_Exception_When_Phone_With_Such_Baterry_Usage_Bigger_Than_Set_Battery_Usage()
        {
            Shop smartphoneShop = new Shop(2);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            smartphoneShop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => smartphoneShop.TestPhone("dimitrichko", 101));
       }
        [Test]
       public void TestPhone_Subtracting_BatteryUsage_From_Current_Charge()
        {
            Shop smartphoneShop = new Shop(2);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            smartphoneShop.Add(phone);
            smartphoneShop.TestPhone("dimitrichko", 45);
            Assert.That(phone.CurrentBateryCharge == 55);
       }
        [Test]
        public void Charge_Exception_When_Phone_With_Such_Name_Does_Not_Exist()
        {
            Shop smartphoneShop = new Shop(2);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            smartphoneShop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => smartphoneShop.ChargePhone("dimi"));
        }
        [Test]
        public void Charge_Charging_CurrentBatteryUsage_To_Max()
        {
            Shop smartphoneShop = new Shop(2);
            Smartphone phone = new Smartphone("dimitrichko", 100);
            smartphoneShop.Add(phone);
            smartphoneShop.TestPhone("dimitrichko", 45);
            smartphoneShop.ChargePhone("dimitrichko");
            Assert.That(phone.CurrentBateryCharge == 100);
        }
    }
}
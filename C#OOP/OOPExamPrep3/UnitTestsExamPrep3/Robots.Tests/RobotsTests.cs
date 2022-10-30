namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void Ctor_Setting_Values_Properly()
        {
            var robots = new RobotManager(5);
            Assert.AreEqual(5, robots.Capacity);
        }
        [Test]
        public void Robot_Capacity_Exception_When_Below_Zero()
        {
            RobotManager robots;
            Assert.Throws<ArgumentException>(() => robots = new RobotManager(-9) );
        }
        [Test]
        public void Robot_Count_Zero_When_Not_Added_A_Robot()
        {
            RobotManager robots = new RobotManager(56);
            Assert.That(robots.Count ==0);
        }
        [Test]
        public void Add_Exception_When_Adding_An_Existing_Robot()
        {
            RobotManager robots = new RobotManager(56);
            Robot rob = new Robot("dimitrichko", 100);
            robots.Add(rob);
            Assert.Throws<InvalidOperationException>(()=> robots.Add(rob));
        }
        [Test]
        public void Add_Exception_When_Capacity_Is_At_Max()
        {
            RobotManager robots = new RobotManager(1);
            Robot rob = new Robot("dimitrichko", 100);
            Robot rob1 = new Robot("dimi", 101);
            robots.Add(rob);
            Assert.Throws<InvalidOperationException>(()=> robots.Add(rob1));
        }
        [Test]
        public void Add_Adding_Robots_To_List()
        {
            RobotManager robots = new RobotManager(1);
            Robot rob = new Robot("dimitrichko", 100);
            robots.Add(rob);
            Assert.That(robots.Count == 1);
        }
        [Test]
        public void Remove_Removing_Robots_From_List()
        {
            RobotManager robots = new RobotManager(1);
            Robot rob = new Robot("dimitrichko", 100);
            robots.Add(rob);
            robots.Remove(rob.Name);
            Assert.That(robots.Count == 0);
        }
        [Test]
        public void Remove_Exception_When_Robot_Is_Null()
        {
            RobotManager robots = new RobotManager(1);
            Robot rob = new Robot("dimitrichko", 100);
            robots.Add(rob);
            Assert.Throws<InvalidOperationException>(()=> robots.Remove("d"));
        }
        [Test]
        public void Work_Exception_When_Robot_Not_Found()
        {
            RobotManager robots = new RobotManager(1);
            Robot rob = new Robot("dimitrichko", 100);
            robots.Add(rob);
            Assert.Throws<InvalidOperationException>(()=> robots.Work("dimi", "g", 123));
        }
        [Test]
        public void Work_Exception_When_Robot_Battery_ISLessThan_Battery_Usage()
        {
            RobotManager robots = new RobotManager(1);
            Robot rob = new Robot("dimitrichko", 100);
            robots.Add(rob);
            Assert.Throws<InvalidOperationException>(()=> robots.Work("dimitrichko", "g", 123));
        }
        [Test]
        public void Work_Reducing_Battery_When_Successful()
        {
            RobotManager robots = new RobotManager(1);
            Robot rob = new Robot("dimitrichko", 100);
            robots.Add(rob);
            robots.Work("dimitrichko", "g", 99);
            Assert.That(rob.Battery == 1);
        }
        [Test]
        public void Chraging_Battery_When_Successful_Charges_To_Max()
        {
            RobotManager robots = new RobotManager(1);
            Robot rob = new Robot("dimitrichko", 100);
            robots.Add(rob);
            robots.Work(rob.Name,"h", 99);
            robots.Charge("dimitrichko");
            Assert.That(rob.Battery == 100);
        }
        [Test]
        public void Chraging_Exception_When_Robot_Not_Found()
        {
            RobotManager robots = new RobotManager(1);
            Robot rob = new Robot("dimitrichko", 100);
            robots.Add(rob);
            Assert.Throws<InvalidOperationException>(()=> robots.Charge("dimitric"));
        }
    }
}

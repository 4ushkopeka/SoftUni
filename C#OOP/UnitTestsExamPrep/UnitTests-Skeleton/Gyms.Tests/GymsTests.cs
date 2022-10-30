using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Ctor_Initializing_Values()
        {
            var gyms = new Gym("Dimi", 90);  
            Assert.IsNotNull(gyms);
            Assert.That(gyms.Name == "Dimi" && gyms.Capacity == 90);
        }
        [Test]
        public void Name_Exception_When_Null()
        {
            Gym gyms;  
            Assert.Throws<ArgumentNullException>(() => gyms = new Gym(null, 90));
        }
        [Test]
        public void Size_Exception_When_Null()
        {
            Gym gyms;  
            Assert.Throws<ArgumentException>(() => gyms = new Gym("Dimi", -9));
        }
        [Test]
        public void Add_Exception_When_At_Full_Capacity()
        {
            Gym gyms = new Gym("Dimi", 0);
            Athlete atlet = new Athlete("Chichka");
            Assert.Throws<InvalidOperationException>(() => gyms.AddAthlete(atlet));
        }
        [Test]
        public void Add_Execution_Adding_Athlete()
        {
            Gym gyms = new Gym("Dimi",2);
            Athlete atlet = new Athlete("Chichka");
            gyms.AddAthlete(atlet);
            Assert.That(gyms.Count, Is.EqualTo(1));
        }
        [Test]
        public void Remove_Execution_Removing_Athlete()
        {
            Gym gyms = new Gym("Dimi", 2);
            Athlete atlet = new Athlete("Chichka");
            gyms.AddAthlete(atlet);
            gyms.RemoveAthlete("Chichka");
            Assert.That(gyms.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void Remove_Exception_When_Name_Is_Null()
        {
            Gym gyms = new Gym("Dimi",2);
            Athlete atlet = new Athlete("Chichka");
            gyms.AddAthlete(atlet);
            Assert.Throws<InvalidOperationException>(() => gyms.RemoveAthlete("Dimi"));
        }
        [Test]
        public void Injure_Exception_When_Name_Is_Null()
        {
            Gym gyms = new Gym("Dimi",2);
            Athlete atlet = new Athlete("Chichka");
            gyms.AddAthlete(atlet);
            Assert.Throws<InvalidOperationException>(() => gyms.InjureAthlete("Dimi"));
        }
        [Test]
        public void Injure_Execution_Injuring_Athlete()
        {
            Gym gyms = new Gym("Dimi", 2);
            Athlete atlet = new Athlete("Chichka");
            gyms.AddAthlete(atlet);
            atlet = gyms.InjureAthlete("Chichka");
            Assert.That(atlet.IsInjured);
        }
        [Test]
        public void Report_Execution_Giving_All_Non_Injured_Athletes()
        {
            Gym gyms = new Gym("Dimi", 5);
            Athlete atlet = new Athlete("Chichka");
            Athlete atlet1 = new Athlete("Chichka1");
            Athlete atlet2 = new Athlete("Chichka2");
            gyms.AddAthlete(atlet);
            gyms.AddAthlete(atlet1);
            gyms.AddAthlete(atlet2);
            gyms.InjureAthlete("Chichka");
            Assert.That(gyms.Report() == $"Active athletes at {gyms.Name}: Chichka1, Chichka2");
        }
    }
}

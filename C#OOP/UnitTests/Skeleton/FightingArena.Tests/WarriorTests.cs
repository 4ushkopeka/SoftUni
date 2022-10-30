namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Ctor_Initializing_Values()
        {
            Warrior war = new Warrior("Dimitrichko", 10, 34);
            Assert.That(war.Name == "Dimitrichko" && war.Damage == 10 && war.HP == 34);
        }
        [Test]
        public void Name_Exception_When_Null()
        {
            Warrior war;
            Assert.Throws<ArgumentException>(() => war = new Warrior(null, 10, 34));
        }
        [Test]
        public void Hp_Exception_When_Null()
        {
            Warrior war;
            Assert.Throws<ArgumentException>(() => war = new Warrior("Dimitrichko", 10, -9));
        }
        [Test]
        public void Damage_Exception_When_Null()
        {
            Warrior war;
            Assert.Throws<ArgumentException>(() => war = new Warrior("Dimitrichko", -6, 20));
        }
        [Test]
        public void Attack_Exception_When_Invalid_HealthOrAttacks()
        {
            Warrior war = new Warrior("Dimitrichko", 10, 20);
            Warrior war1 = new Warrior("Dimitrichkaaaa", 10, 1000);
            Assert.Throws<InvalidOperationException>(() => war.Attack(war1));
        }
        [Test]
        public void Attack_Exception_When_Invalid_HealthOrAttacks1()
        {
            Warrior war = new Warrior("Dimitrichko", 10, 200);
            Warrior war1 = new Warrior("Dimitrichkaaaa", 10, 10);
            Assert.Throws<InvalidOperationException>(() => war.Attack(war1));
        }
        [Test]
        public void Attack_Exception_When_Invalid_HealthOrAttacks2()
        {
            Warrior war = new Warrior("Dimitrichko", 10, 200);
            Warrior war1 = new Warrior("Dimitrichkaaaa", 2000, 10);
            Assert.Throws<InvalidOperationException>(() => war.Attack(war1));
        }
        [Test]
        public void Attack_Execution1()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("pesho", 100, 1000);
            Warrior defender = new Warrior("Dimitrichko", 34, 56);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);
            Assert.That(attacker.HP == 966 && defender.HP == 0);
        }[Test]
        public void Attack_Execution2()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("pesho", 100, 1000);
            Warrior defender = new Warrior("Dimitrichko", 34, 200);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);
            Assert.That(attacker.HP == 966 && defender.HP == 100);
        }

    }
}
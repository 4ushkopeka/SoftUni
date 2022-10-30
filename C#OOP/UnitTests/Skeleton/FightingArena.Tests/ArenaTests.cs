namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Ctor_Initializing()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena);
        }
        [Test]
        public void Enrolling_Adding()
        {
            Arena arena = new Arena();
            Warrior war = new Warrior("pesho", 34, 56);
            arena.Enroll(war);
            Assert.That(arena.Warriors.Count == 1);
        }
        [Test]
        public void Enrolling_Exception_Duplicates()
        {
            Arena arena = new Arena();
            Warrior war = new Warrior("pesho", 34, 56);
            arena.Enroll(war);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(war));
        }
        [Test]
        public void Fight_Execution_Attacker_Attacks_Defender()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("pesho", 100, 1000);
            Warrior defender = new Warrior("Dimitrichko", 34, 56);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);
            Assert.That(attacker.HP == 966 && defender.HP == 0);
        }
        [Test]
        public void Fight_Execution_Exception_Attacker_Name_Null()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Dimi", 100, 200);
            Warrior defender = new Warrior("Dimitrichko", 34, 56);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Suuu", defender.Name));
        }
        [Test]
        public void Fight_Execution_Exception_Defender_Name_Null()
        {
            Arena arena = new Arena();
            Warrior defender = new Warrior("Dimi", 100, 200);
            Warrior attacker = new Warrior("Dimitrichko", 34, 56);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Shuuu", defender.Name));
        }
    }
}

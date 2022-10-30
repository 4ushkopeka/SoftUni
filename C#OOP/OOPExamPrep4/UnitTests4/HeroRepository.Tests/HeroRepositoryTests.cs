using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void Ctor_Setting_Values_Properly()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.That(heroRepository.Heroes, Is.Not.Null);
    }
    [Test]
    public void Create_Exception_When_Argument_Is_Null()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }
    [Test]
    public void Create_Exception_When_Argument_Already_Exists()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero her = new Hero("dimitrichko", 13);
        heroRepository.Create(her);
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(her));
    }
    [Test]
    public void Create_Returning_String_When_Successful()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero her = new Hero("dimitrichko", 13);
        Assert.That(heroRepository.Create(her) == $"Successfully added hero {her.Name} with level {her.Level}");
    }
    [Test]
    public void Remove_Exception_When_Argument_Is_Null_Or_Whitespace()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero her = new Hero("dimitrichko", 13);
        heroRepository.Create(her);
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(" "));
    }
    [Test]
    public void Remove_True_When_Name_Is_Existent_Else_False()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero her = new Hero("dimitrichko", 13);
        heroRepository.Create(her);
        Assert.That(heroRepository.Remove("dimitrichko"));
        Assert.That(!heroRepository.Remove("dimichko"));
    }
    [Test]
    public void GetHEroWithHighestLevel_Returning_Proper_Hero()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero her = new Hero("dimitrichko", 123);
        Hero her1 = new Hero("dimi", 13);
        heroRepository.Create(her);
        heroRepository.Create(her1);
        Assert.That(heroRepository.GetHeroWithHighestLevel() == her);
    }
    [Test]
    public void GetHEro_Returning_Proper_Hero()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero her = new Hero("dimitrichko", 123);
        Hero her1 = new Hero("dimi", 13);
        heroRepository.Create(her);
        heroRepository.Create(her1);
        Assert.That(heroRepository.GetHero("dimitrichko") == her);
    }
}
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero testHero;
    private HeroRepository testRepo;

    [SetUp]
    public void SetUp()
    {
        testHero = new Hero("Ivan", 2);
        testRepo = new HeroRepository();
    }
    [Test]
    public void HeroConstWorking()
    {
        string expName = "Ivan";
        int expLevel = 2;

        Assert.AreEqual(expName, testHero.Name);
        Assert.AreEqual(expLevel, testHero.Level);
    }

    [Test]
    public void HeroRepoConstWorking()
    {
        int expCount = 0;
        Assert.AreEqual(expCount, testRepo.Heroes.Count);
    }

    [Test]
    public void TestCreateHeroExcept()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            testRepo.Create(null);
        });
    }

    [Test]
    public void TestCreateExceptionTwo()
    {
        testRepo.Create(testHero);
        Assert.Throws<InvalidOperationException>(() =>
        {
            testRepo.Create(testHero);
        });
    }

    [Test]
    public void AddedHero()
    {
        int expCount = 1;
        testRepo.Create(testHero);
        Assert.AreEqual(expCount, testRepo.Heroes.Count);
    }

    [Test]
    public void TestCreateReturn()
    {
        string expString = $"Successfully added hero Ivan with level 2";
        
        string actualString = testRepo.Create(testHero);

        Assert.AreEqual(expString, actualString);
    }

    [TestCase(null)]
    [TestCase("  ")]
    [TestCase("")]
    public void TestRemoveExce(string value)
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            testRepo.Remove(value);
        });
    }

    [Test]
    public void RemoveSuccesfully()
    {
        testRepo.Create(testHero);
        bool isRemoved = testRepo.Remove("Ivan");
        bool expValue = true;

        Assert.AreEqual(expValue, isRemoved);
    }

    [Test]
    public void StrongestHeroReturnWorks()
    {
        Hero expHero = testHero;
        testRepo.Create(testHero);
        Hero actualHero = testRepo.GetHeroWithHighestLevel();

        Assert.AreEqual(expHero, actualHero);
    }

    [Test]
    public void GetHeroWorks()
    {
        Hero expHero = testHero;
        testRepo.Create(testHero);
        Hero actualHero = testRepo.GetHero("Ivan");

        Assert.AreEqual(expHero, actualHero);
    }

    [Test]
    public void ReturnsMoreHeros()
    {
        testRepo.Create(testHero);
        Hero hero = new Hero("Kalouan", 1);
        testRepo.Create(hero);
        Hero expHero = testHero;

        Assert.AreEqual(expHero, testRepo.GetHeroWithHighestLevel());   
    }

    [Test]
    public void ExpList()
    {
        testRepo.Create(testHero);
        Hero hero = new Hero("Kalouan", 1);
        testRepo.Create(hero);
        IReadOnlyCollection<Hero> expHeroes = testRepo.Heroes;

        CollectionAssert.AreEqual(expHeroes, testRepo.Heroes);
    }

}   
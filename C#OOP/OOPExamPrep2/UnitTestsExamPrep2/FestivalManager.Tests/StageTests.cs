// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void Test_Ctor_Assigning_Values()
	    {
			Stage stag =  new Stage();
            List<Performer> per = stag.Performers.ToList();
            Assert.That(per, Is.Not.Null);
		}
        [Test]
	    public void AddPerformer_Exception_When_Age_Below_Zero()
	    {
			Stage stag =  new Stage();
			Performer perv = new Performer("dimitrichko", "dimov", 14);
			Assert.Throws<ArgumentException>(() => stag.AddPerformer(perv));
		}
		[Test]
	    public void AddPerformer_Exception_When_Performer_IsNull()
	    {
			Stage stag =  new Stage();
			Performer perv = null;
			Assert.Throws<ArgumentNullException>(() => stag.AddPerformer(perv));
		}
		[Test]
	    public void AddPerformer_Adds_Performer_To_List()
	    {
			Stage stag =  new Stage();
			Performer perv = new Performer("dimitrichko", "dimov", 19);
			stag.AddPerformer(perv);
			Assert.That(stag.Performers.Count == 1);
		}
		[Test]
	    public void AddSong_Exception_When_Song_Duration_Is_Less_Than_AMinute()
	    {
			Stage stag =  new Stage();
			Song perv = new Song("dimitrichko", new TimeSpan(1));
			Assert.Throws<ArgumentException>(() => stag.AddSong(perv));
		}
		[Test]
	    public void AddSongToPerformer_Exception_When_Performer_Not_Found()
	    {
			Stage stag =  new Stage();
			Performer perv = new Performer("dimitrichko", "dimi", 67);
			stag.AddPerformer(perv);
			Assert.Throws<ArgumentException>(() => stag.AddSongToPerformer("shush", "g"));
		}
		[Test]
	    public void AddSongToPerformer_Exception_When_Song_Not_Found()
	    {
			Stage stag =  new Stage();
			Performer perv = new Performer("dimitrichko", "dimi", 67);
			Song perv1 = new Song("dimi", new TimeSpan(1000000000));
			stag.AddPerformer(perv);
			stag.AddSong(perv1);
			Assert.Throws<ArgumentException>(() => stag.AddSongToPerformer("g", "dimitrichko dimi"));
		}
		[Test]
	    public void AddSongToPerformer_Returning_Message_Of_Performance()
	    {
			Stage stag =  new Stage();
			Performer perv = new Performer("dimitrichko", "dimit", 67);
			Song perv1 = new Song("dimi", new TimeSpan(1000000000));
			stag.AddPerformer(perv);
			stag.AddSong(perv1);
			string res = stag.AddSongToPerformer("dimi", perv.FullName);
			Assert.AreEqual(res, $"{perv1.ToString()} will be performed by {perv.FullName}");
		}
		[Test]
	    public void Play_Returning_Message_Of_Performance_Who_Performed_And_Their_Count()
	    {
			Stage stag =  new Stage();
			Performer perv = new Performer("dimitrichko", "dimit", 67);
			Song perv1 = new Song("dimi", new TimeSpan(1000000000));
			stag.AddPerformer(perv);
			string res = stag.Play();
			Assert.AreEqual(res, $"1 performers played 0 songs");
		}
	}
}
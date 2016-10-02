using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTests : IDisposable
  { //this method name & class name need to match!
    public VenueTests()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void T1_GetAll_IsDatabaseEmpty()
    {
      //Arrange, Act
      int result = Venue.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void T2_OverrideEquals()
    {
      //Arrange, Act
      // DateTime showTime = new DateTime(2016, 12, 12, 23, 30,00);
      Venue venue1 = new Venue("Seattle");
      Venue venue2 = new Venue("Seattle");

      //Assert
      Assert.Equal(venue1, venue2);
    }

    [Fact]
    public void T3_SaveVenueToDb()
    {
      //Arrange
      // DateTime showTime = new DateTime(2016, 12, 12, 23, 30,00);
      Venue venue1 = new Venue("Seattle");

      //Act
      venue1.Save();
      List<Venue> result = Venue.GetAll();
      List<Venue> savedVenue = new List<Venue> {venue1};

      //Assert
      Assert.Equal(savedVenue, result);
    }

    [Fact]
    public void T4_SaveGetId()
    {
      //Arrange
      // DateTime showTime = new DateTime(2016, 12, 12, 23, 30,00);
      Venue venue1 = new Venue("Seattle");
      //, showTime

      //Act
      venue1.Save();
      Venue savedVenue = Venue.GetAll()[0];

      int result = savedVenue.GetId();
      int savedId = venue1.GetId();

      //Assert
      Assert.Equal(savedId, result);
    }

    [Fact]
    public void T5_Find()
    {
      //Arrange
      Venue venueOne = new Venue("Seattle");
      venueOne.Save();

      //Act
      Venue result = Venue.Find(venueOne.GetId());

      //Assert
      Assert.Equal(venueOne, result);
    }

    [Fact]
    public void T6_Update()
    {
      //Arrange
      string name1 = "Seattle";
      Venue VenueOne = new Venue(name1);
      VenueOne.Save();

      string name2 = "Krungthep";

      //Act
      VenueOne.Update(name2);

      string result = VenueOne.GetName();

      //Assert
      Assert.Equal(name2, result);
    }

    [Fact]
    public void T7_AddBand_ToVenue()
    {
      //Arrange
      Venue testVenue = new Venue("Seattle");
      testVenue.Save();

      Band bandOne = new Band("Oasis");
      bandOne.Save();
      Band bandTwo = new Band("Talay");
      bandTwo.Save();

      //Act
      testVenue.AddBand(bandOne);
      testVenue.AddBand(bandTwo);

      List<Band> result = testVenue.GetBands();
      List<Band> testList = new List<Band> {bandOne, bandTwo};
      //Assert
      Assert.Equal( testList, result);
    }

    [Fact]
    public void T8_GetBands_ReturnAllBands()
    {
      // Arrange
       Venue venue1 = new Venue("Seattle");
       venue1.Save();
       //  DateTime showTime = new DateTime(2016, 12, 12, 21, 30, 00);

       Band testBand = new Band("Oasis");
       testBand.Save();

       Band testBand2 = new Band("Krungthep");
       testBand2.Save();

       //Act
       venue1.AddBand(testBand);

       List<Band> savedBand = venue1.GetBands();
       List<Band> testList = new List<Band> {testBand};

       //Assert
       Assert.Equal(testList, savedBand);
    }

    [Fact]
    public void T9_DeleteOne()
    {
      //Arrange
      Venue venue1 = new Venue("Seattle");
      Venue venue2 = new Venue("Krungthep");
      venue1.Save();
      venue2.Save();

      Band bandOne = new Band("Oasis");
      bandOne.Save();

      //Act
      venue1.AddBand(bandOne);
      venue2.DeleteOne();

      List<Venue> result  = venue1.GetVenues();
      List<Venue> listBandVenues = new List<Venue>{};

      //Assert
      Assert.Equal(listBandVenues, result);

    }

    public void Dispose()
    {
      Venue.DeleteAll();
      // Band.DeleteAll();
    }
  }
}

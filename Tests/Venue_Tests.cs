using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTests : IDisposable
  {
    public VenueTests()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Intergrated Security=SSpi;";
    }

    // [Fact]
    // public void T1_DbEmpty()
    // {
    //   //Arrange, Act
    //   int result = Venue.GetAll().Count;
    //
    //   //Assert
    //   Assert.Equal(0, result);
    // }
    //
    // [Fact]
    // public void T2_OverrideEqual()
    // {
    //   //Arrange, Act
    //   DateTime showTime = new DateTime(2016, 11, 11, 21, 30, 0);
    //   Venue venue1 = new Venue("Seattle", showTime);
    //   Venue venue2 = new Venue("Seattle", showTime);
    //
    //   //Assert
    //   Assert.Equal(venue1, venue2);
    // }
    //
    // [Fact]
    // public void T3_SaveToDB()
    // {
    //   //Arrange
    //   DateTime showTime = new DateTime(2016, 11, 11, 21, 30, 0);
    //   Venue venue1 = new Venue("Seattle", showTime);
    //   venue1.Save();
    //
    //   //Act
    //   List<Venue> result = Venue.GetAll();
    //   List<Venue> savedList= new List<Venue> {venue1};
    //
    //   //Assert
    //   Assert.Equal(savedList, result);
    // }
    //
    // [Fact]
    // public void SaveToId()
    // {
    //   //Arrange
    //   DateTime showTime = new DateTime(2016, 11, 11, 21, 30, 0);
    //   Venue venue1 = new Venue("Krungthep", showTime);
    //   venue1.Save();
    //
    //   //Act
    //   Venue saveVenue = Venue.GetAll()[0];
    //
    //   int result = saveVenue.GetId();
    //   int testId = venue1.GetId();
    //   //Assert
    //   Assert.Equal(testId, result);
    // }
    //
    [Fact]
    public void Dispose()
    {
      // Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}

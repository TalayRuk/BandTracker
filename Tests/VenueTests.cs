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


// [Fact]
// public void T6_AddVenue_ToBand()
// {
//   //Arrange
//   Band bandOne = new Band("Oasis");
//   bandOne.Save();
//
//   Venue testVenue = new Venue("Seattle", (2016, 12, 12, 21, 30, 00));
//   testVenue.Save();
//
//   //Act
//   bandOne.AddBand(testVenue);
//
//   List<Venue> result = bandOne.GetVenue();
//   List<Venue> testList = new List<Band> {bandOne};
//   //Assert
//   Assert.Equal(bandOne, result);
//
// }

    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }
  }
}    

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

    [Fact]
    public void T1_DbEmpty()
    {
      //Arrange, Act
      int result = Venue.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void T2_OverrideEqual()
    {
      //Arrange, Act
      DateTime showTime = new DateTime(2016, 11, 11, 11, 00);
      Venue venue1 = Venue("Seattle", showTime);
      Venue venue2 = Venue("Seattle", showTime);

      //Assert
      Assert.Equal(venue1, venue2);
    }

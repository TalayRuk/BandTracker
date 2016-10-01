using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTests : IDisposable
  {
    public BandTests()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void T1_DbEmpty()
    {
      //Arrange, Act
      int result = Band.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void T2_OverrideEqual()
    {
      //Arrange, Act
      Band band1 = new Band("Oasis");
      Band band2 = new Band("Oasis");

      //Assert
      Assert.Equal(band1, band2);
    }

    [Fact]
    public void T3_SaveBandToDb()
    {
      //Arrange
      Band testBand = new Band("Oasis");
      testBand.Save();

      //Act
      List<Band> result = Band.GetAll();
      List<Band> savedList = new List<Band> {testBand};

      //Assert
      Assert.Equal(savedList, result);
    }

    [Fact]
    public void T4_SaveToId()
    {
      //Arrange
      Band testBand = new Band("Oasis");
      testBand.Save();

      //Act
      Band savedBand = Band.GetAll()[0];

      int result = savedBand.GetId();
      int testId = testBand.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Dispose()
    {
      Band.DeleteAll();
    }
  }
}

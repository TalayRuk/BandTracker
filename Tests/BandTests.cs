using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTests : IDisposable
  { //this method name & class name need to match!
    public BandTests()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void T1_GetAll_IsDatabaseEmpty()
    {
      //Arrange, Act
      int result = Band.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void T2_OverrideEquals()
    {
      //Arrange, Act
      Band bandOne = new Band("Oasis");
      Band bandTwo = new Band("Oasis");

      //Assert
      Assert.Equal(bandOne, bandTwo);
    }

    [Fact]
    public void T3_SaveBandToDb()
    {
      //Arrange
      Band bandOne = new Band("Oasis");

      //Act
      bandOne.Save();
      List<Band> result = Band.GetAll();
      List<Band> savedList = new List<Band> {bandOne};

      //Assert
      Assert.Equal(savedList, result);
    }

    [Fact]
    public void T4_SaveId()
    {
      //Arrange
      Band bandOne = new Band("Oasis");

      //Act
      bandOne.Save();
      Band savedBand = Band.GetAll()[0];

      int result = savedBand.GetId();
      int savedId = bandOne.GetId();

      //Assert
      Assert.Equal(savedId, result);
    }

    [Fact]
    public void T5_Find()
    {
      //Arrange
      Band bandOne = new Band("Oasis");
      bandOne.Save();

      //Act
      Band result = Band.Find(bandOne.GetId());

      //Assert
      Assert.Equal(bandOne, result);
    }

    public void Dispose()
    {
      Band.DeleteAll();
    }
  }
}

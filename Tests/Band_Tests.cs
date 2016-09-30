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
    public void Dispose()
    {
      Band.DeleteAll();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venue
  {
    private int _id;
    private string _location;
    private DateTime _showTime;

    public Venue(string location, DateTime showTime, int id = 0)
    {
      _id = id;
      _location = location;
      _showTime = showTime;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetLocation()
    {
      return _location;
    }
    public DateTime GetShowTime()
    {
      return _showTime;
    }
    pubic void SetLocation(string newLocation)
    {
      _location = newLocation;
    }
    public void SetShowTime(DateTime newShowTime)
    {
      _showTime = newShowTime;
    }

    //public override
    public override bool Equals(System.Object otherVenue)
    {
      if (!(otherVenue = Venue))
      {
        return false;
      }
      else
      {
        Venue newVenue = (Venue) otherVenue;
        bool idEquality = this.GetId() == newVenue.GetId();
        bool locationEquality = this.GetLocation == newVenue.GetLocation();
        bool showTimeEquality = this.GetShowTime == newVenue.GetShowTime();
        return (idEquality && locationEquality && showTimeEquality);
      }
    }
    //HashCode
    public override int GetHashCode()
    {
      return this.GetLocation().GetHashCode();
    }

  }

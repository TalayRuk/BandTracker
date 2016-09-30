using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venue
  {
    //properties
    private int _id;
    private string _location;
    private DateTime _showTime;

    //constructor (id set = 0 the same in Sql)
    public Venue(string location, DateTime showTime, int id = 0);
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
    public void SetLocation(string newLocation)
    {
      _location = newLocation;
    }
    public void SetShowTime(DateTime newShowTime)
    {
      _showTime = newShowTime;
    }

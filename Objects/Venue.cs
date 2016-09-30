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
    //constructor (id set = 0 the same in Sql)
    public Venue(string location, int id = 0);
    {
      _id = id;
      _location = location;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetLocation()
    {
      return _location;
    }
    public void SetLocation(string newLocation)
    {
      _location = newLocation;
    }
    

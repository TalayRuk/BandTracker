using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Band
  {
    //properties
    private int _id;
    private string _name;

    //constructor (id set = 0 the same in Sql)
    public Venue(string name, int id = 0);
    {
      _id = id;
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }

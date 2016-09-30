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
    private DateTime _showTime;
    //constructor (id set = 0 the same in Sql)
    public Venue(string name, DateTime showTime, int id = 0);
    {
      _id = id;
      _name = name;
      _showTime = showTime;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public DateTime GetShowTime()
    {
      return _showTime;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public void SetShowTime(DateTime newShowTime)
    {
      _showTime = newShowTime;
    }

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
    public void SetLocation(string newLocation)
    {
      _location = newLocation;
    }
    public void SetShowTime(DateTime newShowTime)
    {
      _showTime = newShowTime;
    }

    //Override
    public override bool Equals(System.Object otherVenue)
    {
      if (!(otherVenue is Venue))
      {
        return false;
      }
      else
      {
        Venue newVenue = (Venue) otherVenue;
        bool idEquality = this.GetId() == newVenue.GetId();
        bool locationEquality = this.GetLocation()
        == newVenue.GetLocation();
        bool showTimeEquality = this.GetShowTime() == newVenue.GetShowTime();

        return (idEquality && locationEquality && showTimeEquality);
      }
    }
    //GetHashCode
    public override int GetHashCode()
    {
      return this.GetLocation().GetHashCode();
    }

    //GetAll()
    public static List<Venue> GetAll()
    {
      List<Venue> listVenues = new List<Venue> {};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);

      SqlDataReader rdr = cmd.ExecuteReader();


      // int id = 0;
      // string location = null;
      // DateTime showTime = DbNull.Value;
      //dateTime is a value type, I can't put null in a value type.
      //to send a null value?

      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string location = rdr.GetString(1);
        DateTime showTime = rdr.GetDateTime(2);

        Venue newVenue = new Venue(location, showTime, id);
        listVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return listVenues;
    }

    //Save()
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO venues (location, show_time) OUTPUT INSERTED.id VALUES (@location, @showTime);", conn);
      cmd.Parameters.Add(new SqlParameter("@location", this.GetLocation()));
      cmd.Parameters.Add(new SqlParameter("@showTime", this.GetShowTime()));

      SqlDataReader rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        _id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    //DeleteAll
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

  }
}

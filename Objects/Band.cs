using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Band
  {
    private int _id;
    private string _name;
    //add constructor
    public Band(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }
    //Getter
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    //Setter
    public void SetName(string newName)
    {
      _name = newName;
    }

    //Override
    public override bool Equals(System.Object otherBand)
    {
      if (!(otherBand is Band))
      {
        return false;
      }
      else
      {
        Band newBand = (Band) otherBand;
        bool idEquality = (this.GetId() == newBand.GetId());
        bool nameEquality = (this.GetName() == newBand.GetName());
        return (idEquality && nameEquality);
      }
    }
    //GetHashCode
    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }

    //GetAll
    public static List<Band> GetAll()
    {
      List<Band> allBands = new List<Band>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);
        Band newBand = new Band(bandName, bandId);
        allBands.Add(newBand);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allBands;
    }

    //Save()
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO bands (name) OUTPUT INSERTED.id VALUES (@BandName);", conn);//(@needParenthesis)

      cmd.Parameters.Add(new SqlParameter("@BandName", this.GetName()));
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
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

    //Find
    public static Band Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands WHERE id = @BandId;", conn);//(@needParenthesis)

      cmd.Parameters.Add(new SqlParameter("@BandId", id.ToString()));
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundBandId = 0;
      string foundBandName = null;

      while (rdr.Read())
      {
        foundBandId = rdr.GetInt32(0);
        foundBandName = rdr.GetString(1);
      }

      Band foundBand = new Band(foundBandName, foundBandId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundBand;
    }

    //Update()
    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE bands SET name = @NewName OUTPUT INSERTED.name WHERE id = @BandId;", conn);

      cmd.Parameters.Add(new SqlParameter("@NewName", newName));
      cmd.Parameters.Add(new SqlParameter("@BandId", this.GetId().ToString()));

      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        this._name = rdr.GetString(0);
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

    // //AddVenue to Band
    public void AddVenue(Venue newVenue)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO bands_Venues (band_id, venue_id) VALUES (@BandId, @VenueId);", conn);

      cmd.SqlParameters.Add(new SqlParameter("@BandId", this._id.ToString()));
      cmd.SqlParameters.Add(new SqlParameter("@VenueId", newVenue.GetId().ToString()));
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    //GetVenues
    public List<Venue> GetVenues()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT venues.* FROM bands JOIN bands_venues ON (bands.id = bands_venues.band_id) JOIN venues ON (bands_venues.venue_id = venue.id) WHERE bands.id = @BandId;", conn);

      cmd.SqlParameters.Add(new SqlParameter("@BandId", this.GetId().ToString()));

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Venue> listVenues = new List<Venue>{};

      while (rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetName(1);
        // DateTime venueShowTime = rdr.GetShowTime(2);

        Venue newVenue = new Venue(venueName, venueId);

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

    //DeleteOne
    public void DeleteOne()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM bands WHERE id = @BandId; DELETE FROM bands_venues WHERE band_id = @BandId;", conn);

      cmd.Parameters.Add(new SqlParameter("@BandId", this.GetId()));
      cmd.ExecuteNonQuery();

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

      SqlCommand cmd = new SqlCommand("DELETE FROM bands;", conn);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
  }
}

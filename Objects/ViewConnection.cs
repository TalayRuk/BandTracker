using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class ViewConnection
  {
    public static Dictionary<string, object> BandVenues(string name)
    {
      List<Band> BandList = Band.GetAll();
      List<Venue> VenueList = Venue.GetAll();
      Dictionary<string, object> model= new Dictionary<string, object>{};
      model.Add("band", allBands);
      model.Add("venue", allVenues);
      model.Add("name", name);
      return model;
    }
  }
}

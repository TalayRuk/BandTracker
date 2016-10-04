using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Band> allBands = Band.GetAll();
        List<Venue> allVenues = Venue.GetAll();
        return View["index.cshtml"];
      };

      Get["/bands"] = _ => {
        List<Band> allBands = Band.GetAll();
        return View["bands.cshtml", allBands];
      };
      // add band & view all bands at bands.cshtml
      Post["/bands/new"] = _ => {
        Band newBand = new Band(Request.Form["band-name"]);
        newBand.Save();
        return View["success.cshtml"];
      };

      Get["bands/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Band findBand = Band.Find(parameters.id);
        List<Venue> bandsAtVenue = findBand.GetVenues();
        List<Venue> allVenues = Venue.GetAll();
        model.Add("band", findBand);
        model.Add("venues", bandsAtVenue);
        model.Add("allVenues", allVenues);
        return View["band.cshtml"];
      };
      //get info to post from band.cshtml
      Post["/bands/add_venue"] = _ => {
        Venue venue = Venue.Find(Request.Form["venue-id"]);
        Band band = Band.Find(Request.Form["band-id"]);
        band.AddVenue(venue);
        return View["success.cshtml"];
      };

      Get["/bands/{id}/delete"] = parameters => {
        Band band = Band.Find(parameters.id);
        return View["delete.cshtml", band];
      };

      Delete["/bands/{id}/delete"] = parameters => {
        Band band = Band.Find(parameters.id);
        band.Delete();
        return View["success.cshtml"];
      };

      Post["/bands/delete"] = _ => {
        Band.DeleteAll();
        return View["sucess.cshtml"];
      };

      Get["/bands/{id}/update"] = parameters => {
        Band band = Band.Find(parameters.id);
        return View["update.cshtml", band];
      };
      //from update.cshtml
      Patch["/bands/{id}/update"] = parameters => {
        Band band = Band.Find(parameters.id);
        band.Update(Request.Form["new-name"]);
        return View["success.cshtml"];
      };
       //Venue
      Get["/venues"] = _ => {
        List<Venue> allVenues = Venue.GetAll();
        return View["venues.cshtml", allVenues];
      };

      Post["/venues/new"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"]);
        newVenue.Save();
        return View["success.cshtml"];
      };

      Get["/venues/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Venue venue = Venue.Find(parameters.id);
        List<Band> venueBands = venue.GetBands();
        List<Band> allBands = Band.GetAll();
        model.Add("venue", venue);
        model.Add("bands", venueBands);
        model.Add("allBands", allBands);
        return View["venue.cshtml", model];
      };

      Post["/venues/add_band"] = _ => {
        Venue venue = Venue.Find(Request.Form["venue-id"]);
        Band band = Band.Find(Request.Form["band-id"]);
        venue.AddBand(band);
        return View["success.cshtml"];
      };

      Get["/venues/{id}/delete"] = parameters => {
        Venue venue = Venue.Find(parameters.id);
        return View["delete.cshtml", venue];
      };

      Delete["/venues/{id}/delete"] = parameters => {
        Venue venue = Venue.Find(parameters.id);
        venue.Delete();
        return View["success.cshtml"];
      };

      Get["/venues/{id}/update"] = parameters => {
        Venue venue = Venue.Find(parameters.id);
        return View["update.cshtml", venue];
      };

      Patch["/venues/{id}/update"] = parameters => {
        Venue venue = Venue.Find(parameters.id);
        venue.Update(Request.Form["new-name"]);
        return View["success.cshtml"];
      };

      //delete band from venue
      Get["/venues/{venueId}/venue_delete/{bandId}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Band band = Band.Find(parameters.bandId);
        Venue venue = Venue.Find(parameters.venueId);
        model.Add("venue", venue);
        model.Add("band", band);
        return View["venue_delete.cshtml", model];
      };

      Delete["/venues/{venueId}/venue_delete/{bandId}"] = parameters => {
        Venue.DeleteBand(parameters.bandId, parameters.venueId );
        return View["success.cshtml"];
      };
    }
  }
}

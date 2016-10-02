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
        // Dictionary<string, object> model = ViewConnection.BandVenues("music")
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<Venue> allVenues = Venue.GetAll();
        List<Band> allBands = Band.GetAll();
        List<Music> allMusic = Music.GetAll();
        model.Add("venues", allVenues);
        model.Add("bands", allBands);
        model.Add("muisic", allMusic);
        return View["index.cshtml", model];
      };

      Post["/add_band"] = _ => {
        Band newBand = new Band(Request.Form["band-name"]);
        newBand.Save();
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<Venue> allVenues = Venue.GetAll();
        List<Band> allBands = Band.GetAll();
        List<Music> allMusics = Music.GetAll();
        model.Add("venues", allVenues);
        model.Add("bands", allBands);
        model.Add("music", allMusic);
        return View["index.cshtml", model];
      };

      Post["/add_venue"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"]);
        newVenue.Save();
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<Venue> allVenues = Venue.GetAll();
        List<Band> allBands = Band.GetAll();
        List<Music> allMusic = Music.GetAll();
        model.Add("venues", allVenues);
        model.Add("bands", allBands);
        model.Add("music", allMusic);
        return View["index.cshtml", model];
      };

      Get["/band/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Band selectedBand = Band.Find(parameters.id);
        List<Venue> bandVenues = selectedBand.GetVenues();
        model.Add("band", selectedBand);
        model.Add("venues", bandVenues);
        return View["band.cshtml", model];
      };
      Patch["/venue/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Venue selectedVenue = Venue.Find(parameters.id);
        selectedVenue.Update(Request.Form["rename"]);
        List<Band> venueBands = selectedVenue.GetBands();
        model.Add("venue", selectedVenue);
        model.Add("bands", venueBands);
        return View["venue.cshtml", model];
      };
}

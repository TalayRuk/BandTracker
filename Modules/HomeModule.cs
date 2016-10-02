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
        // Dictionary<string, object> model = ViewConnection.BandVenues("")
        return View["index.cshtml"];
      };

      Get["/bands"] = _ =
    }
  }
}s

using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
  public class CityController : Controller
  {
    [HttpGet("/city")]
    public ActionResult CityIndex()
    {
      List<City> allCities = City.GetAllCities();
      return View("Index", allCities);
    }

    [HttpPost("/city/sort")]
    public ActionResult Sort()
    {
      string sortSelection = Request.Form["sort-selection"];
      List<City> sortCities = new List<City> {};
      if(Request.Form["selection"].Equals("ascending"))
      {
        sortCities = City.Sort("ASC", sortSelection);
      }
      else if(Request.Form["selection"].Equals("descending"))
      {
        sortCities = City.Sort("DESC", sortSelection);
      }
      return View("Index", sortCities);
    }
  }
}

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

    [HttpPost("/city/sort-asc")]
    public ActionResult SortAsc()
    {
      List<City> sortCitiesAsc = City.SortCitiesAsc();
      return View("Index", sortCitiesAsc);
    }

    [HttpPost("/city/sort-desc")]
    public ActionResult SortDesc()
    {
      List<City> sortCitiesDesc = City.SortCitiesDesc();
      return View("Index", sortCitiesDesc);
    }
  }
}

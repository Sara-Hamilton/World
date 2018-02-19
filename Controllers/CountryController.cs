using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
  public class CountryController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Country> allCountries = Country.GetAll();
      return View(allCountries);
    }

    [HttpPost("/filter-countries")]
    public ActionResult Filter()
    {
      string inputCode = Request.Form["code"];
      string inputName = Request.Form["name"];
      string inputContinent = Request.Form["continent"];
      string inputRegion = Request.Form["region"];
      string minPopulation =  Request.Form["min-pop"];
      string maxPopulation = Request.Form["max-pop"];

      List<Country> filterCountries = Country.Filter(inputCode, inputName, inputContinent, inputRegion, minPopulation, maxPopulation);

      return View("Index", filterCountries);
    }
  }
}

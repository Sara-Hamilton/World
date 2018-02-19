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

    [HttpPost("/filter-name")]
    public ActionResult Name()
    {
      string inputName = Request.Form["name"];
      List<Country> nameCountries = Country.FilterName(inputName);
      return View("Index", nameCountries);
    }

    [HttpPost("/filter-countries")]
    public ActionResult Filter()
    {
      string inputCode = Request.Form["code"];
      string inputName = Request.Form["name1"];
      string inputContinent = Request.Form["continent"];
      string inputRegion = Request.Form["region"];

      List<Country> nameCountries = Country.Filter(inputCode, inputName, inputContinent, inputRegion);

      return View("Index", nameCountries);
    }

    [HttpPost("/filter-population")]
    public ActionResult FilterPopulation()
    {
      string minPopulation =  Request.Form["min-pop"];
      string maxPopulation = Request.Form["max-pop"];

      List<Country> populationCountries = Country.FilterPopulation(minPopulation, maxPopulation);

      return View("Index", populationCountries);
    }
  }
}

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
  }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using World;
using System;

namespace World.Models
{
  public class City
  {
    private int _id;
    private string _name;
    private string _countryCode;
    private string _district;
    private string _population;

    public City(int id, string name, string countryCode, string district, string population)
    {
      _id = id;
      _name = name;
      _countryCode = countryCode;
      _district = district;
      _population = population;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetCountryCode()
    {
      return _countryCode;
    }

    public string GetDistrict()
    {
      return _district;
    }

    public string GetPopulation()
    {
      return _population;
    }

    //public static List<City>
  }
}

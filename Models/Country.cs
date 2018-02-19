using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using World;
using System;

namespace World.Models
{
  public class Country
  {
    private string _code;
    private string _name;
    private string _continent;
    private string _region;
    private int _population;
    //private int _capital;

    public Country(string code, string name, string continent, string region, int population)
    {
      _code = code;
      _name = name;
      _continent = continent;
      _region = region;
      _population = population;
      //_capital = capital;
    }

    public string GetCode()
    {
      return _code;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetContinent()
    {
      return _continent;
    }

    public string GetRegion()
    {
      return _region;
    }

    public int GetPopulation()
    {
      return _population;
    }

    // public int GetCapital()
    // {
    //   return _capital;
    // }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT Code, Name, Continent, Region, Population, Capital FROM Country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string countryCode = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        string countryContinent = rdr.GetString(2);
        string countryRegion = rdr.GetString(3);
        int countryPopulation = rdr.GetInt32(4);
        //int countryCapital = rdr.GetInt32(5);
        Country newCountry = new Country(countryCode, countryName, countryContinent, countryRegion, countryPopulation);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public static List<Country> FilterName(string userInput)
    {
      List<Country> filterNameCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT Code, Name, Continent, Region, Population, Capital FROM Country WHERE Name LIKE '%" + userInput + "%'";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string countryCode = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        string countryContinent = rdr.GetString(2);
        string countryRegion = rdr.GetString(3);
        int countryPopulation = rdr.GetInt32(4);
        //int countryCapital = rdr.GetInt32(5);
        Country newCountry = new Country(countryCode, countryName, countryContinent, countryRegion, countryPopulation);
        filterNameCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return filterNameCountries;
    }

  }
}

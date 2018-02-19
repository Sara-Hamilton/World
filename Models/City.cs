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
    private int _population;

    public City(int id, string name, string countryCode, string district, int population)
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

    public int GetPopulation()
    {
      return _population;
    }

    public static List<City> GetAllCities()
    {
      List<City> allCities = new List<City>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM City;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCountryCode = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);

        City newCity = new City(cityId, cityName, cityCountryCode, cityDistrict, cityPopulation);

        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    public static List<City> SortCitiesAsc()
    {
      List<City> sortedCities = new List<City>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM City ORDER BY Population ASC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCountryCode = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);

        City newCity = new City(cityId, cityName, cityCountryCode, cityDistrict, cityPopulation);

        sortedCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return sortedCities;
    }

    public static List<City> SortCitiesDesc()
    {
      List<City> sortedCities = new List<City>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM City ORDER BY Population DESC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCountryCode = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);

        City newCity = new City(cityId, cityName, cityCountryCode, cityDistrict, cityPopulation);

        sortedCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return sortedCities;
    }
  }
}

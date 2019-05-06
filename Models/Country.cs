using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace World.Models
{
  public class Country
  {
    private string _code;
    private string _name;
    private string _continent;
    private int _population;
    private int _id;
    private List<City> _cities;

    public Country (string code, string name, string continent, int population, int id = 0)
    {
      _code = code;
      _name = name;
      _continent = continent;
      _population = population;
      _id = id;
      _cities = new List<City>{};
    }

    public int GetId()
    {
    return _id;
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

    public int GetPopulation()
    {
      return _population;
    }

    public List<City> GetCities()
    {
      return _cities;
    }

    public void AddCity(City city)
    {
      _cities.Add(city);
    }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM countries;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int countryId = rdr.GetInt32(0);
        string countryCode = rdr.GetString(1);
        string countryName = rdr.GetString(2);
        string countryContinent = rdr.GetString(3);
        int countryPopulation = rdr.GetInt32(4);
        Country newCountry = new Country(countryCode, countryName, countryContinent, countryPopulation, countryId);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public static Country Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM 'countries' WHERE id = @thisId;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int countryId = 0;
      string countryName = "";
      string countryCode = "";
      string countryContinent = "";
      int countryPopulation = 0;
      while (rdr.Read())
      {
        countryId = rdr.GetInt32(0);
        countryCode = rdr.GetString(1);
        countryName = rdr.GetString(2);
        countryContinent = rdr.GetString(3);
        countryPopulation = rdr.GetInt32(4);
      }
      Country foundCountry = new Country(countryCode, countryName, countryContinent, countryPopulation, countryId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundCountry;
    }





  }
}

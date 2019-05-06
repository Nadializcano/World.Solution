using System.Collections.Generic;

namespace World.Models
{
  public class City
  {
    private string _code;
    private string _name;
    private string _district;
    private int _population;

    public City (string code, string name, string district, int population)
    {
      _code = code;
      _name = name;
      _district = district;
      _population = population;
    }

    public string GetCode()
    {
      return _code;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetDistrict()
    {
      return _district;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public static List<City> GetAll()
    {
      List<City>allCities = new List<City>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreatCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cities;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string countryCode = rdr.GetString(1);
        string cityName = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetString(4);
        City newCity = new City(countryId, countryCode, cityName, cityDistrict, cityPopulation);
        allCities.Add(newCity);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }


  }
}

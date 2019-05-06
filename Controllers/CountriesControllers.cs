using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
  public class CountriesController : Controller
  {
    List<Country> allCountries = Country.GetAll();
    return View(allCategories);

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;


namespace HairSalon.Controllers
{
 public class HomeController : Controller
    {
        //home page
        [HttpGet("/")]
          public ActionResult Index()
          {
          return View();
          }
    }

}
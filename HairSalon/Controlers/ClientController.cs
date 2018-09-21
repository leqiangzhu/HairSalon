using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpPost("/client/new")]
        public ActionResult CreateForm(string clientName, int stylistId)
        {
            
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;

using System;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {

         [HttpGet("Specialty")]
          public ActionResult Index()
          {
             List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
          }

         [HttpPost("Specialty")]
        public ActionResult Create(string SpecialtyName)
        {

        Specialty newSpecialty = new Specialty(SpecialtyName);
        newSpecialty.Save();
        List<Specialty> allSpecialtys = Specialty.GetAll();
        return RedirectToAction("Index");
        }


        [HttpPost("/Specialty/{SpecialtyId}/delete")]
        public ActionResult SpecialtyDelete(int SpecialtyId)
        {
              Specialty.Delete(SpecialtyId);
            List<Specialty> allSpecialty = Specialty.GetAll();
          
            return View("Index",allSpecialty);
        }



    }
}
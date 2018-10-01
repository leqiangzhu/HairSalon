using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
         [HttpGet("stylist")]
          public ActionResult Index()
          {
                List<Stylist> allStylist = Stylist.GetAll();
                return View(allStylist);
          }

        [HttpGet("/stylist/new")]
        public ActionResult CreateForm()
        {
          //  List<Stylist> allStylists = Stylist.GetAll();
            return View("CreateForm");
        }

        //  [HttpPost("/stylist")]
        // public ActionResult Create(string stylistName,string stylistPhone,
        //                   string stylistEmail,string stylistHD,int stylistId)
        // {
        // Stylist newStylist = new Stylist (stylistName,stylistPhone,stylistEmail,
        //                 stylistHD,stylistId);
        // newStylist.Save();
        // List<Stylist> allStylists = Stylist.GetAll();
        // return RedirectToAction("Index");
        // //return View("Index", allStylists);
        // }

        [HttpPost("/stylist")]
        public ActionResult Create()
        {
        Stylist newStylist = new Stylist (Request.Form["stylistName"],Request.Form["stylistPhone"],Request.Form["stylistEmail"],
                       Request.Form["stylistHD"]);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return RedirectToAction("Index");
        //return View("Index", allStylists);
        }




         [HttpGet("/stylist/{stylistId}")]
        public ActionResult Details(int stylistId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectStylist = Stylist.Find(stylistId);
            List<Client> stylistClient = selectStylist.GetClients();
            model.Add("stylist", selectStylist);
            model.Add("client", stylistClient);
            return View(model);
        }


        [HttpPost("/stylist/{stylistId}")]
        public ActionResult CreateClient(int stylistId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectStylist = Stylist.Find(stylistId);
            Client newClient= new Client( Request.Form["clientName"],stylistId
            ,Request.Form["clientPhone"],Request.Form["clientNote"]);
            newClient.Save();
            List<Client> stylistClient = selectStylist.GetClients();
            // model.Add("stylist", selectStylist);
            // model.Add("client", Request.Form["clientName"]);
             model.Add("stylist", selectStylist);
                model.Add("client", stylistClient);
            return View("Details", model);
        }

        // [HttpPost("/stylist/{stylistId}/newClient")]
        // public ActionResult CreateClient(string clientName, int stylistId)
        // {
        //     new Client(clientName, stylistId).Save();
        //     return View("Details", Stylist.Find(stylistId));
        // }

         [HttpPost("/stylist/deleteAll")]
        public ActionResult DeleteAll()
        {
                     Stylist.DeleteAll();

                return View("Index");


        }

        [HttpPost("/stylist/{stylistId}/delete")]
        public ActionResult StylistDelete(int stylistId)
        {

            Stylist.Delete(stylistId);
            List<Stylist> allStylist = Stylist.GetAll();
            return View("Index",allStylist);
        }

    }

}

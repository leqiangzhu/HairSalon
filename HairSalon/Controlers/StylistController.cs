using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {

    

         [HttpGet("Stylist")]
          public ActionResult Index()
          {
                List<Stylist> allStylist = Stylist.GetAll();;
                // Stylist n=new Stylist(stylistName:"JIM");
                // allStylist.Add(n);
                
                return View(allStylist);
    
          }


        [HttpGet("/Stylist/new")]
        public ActionResult CreateForm()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);  
        
        }

         [HttpPost("/stylist")]
        public ActionResult Create()
        {
        
        Stylist newStylist = new Stylist (Request.Form["StylistName"],6);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        //return RedirectToAction("Index");
        return View("Index", allStylists);
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
            Client newClient= new Client( Request.Form["clientName"],stylistId);
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

    }

}
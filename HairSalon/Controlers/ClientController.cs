using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;

using System;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {

         [HttpGet("Client")]
          public ActionResult Index()
          {
            List<Client> allClients = Client.GetAllClients();
            return View(allClients);
          }

          [HttpGet("/Client/new")]
        public ActionResult CreateForm()
        {
            List<Client> allClients = Client.GetAllClients();
            return View(allClients);
        }

        [HttpPost("/Client")]
        public ActionResult Create(string clientName, int stylistId)
        {
         List<Stylist> aStylist = Stylist.GetAll();
        Client newClient = new Client (clientName, stylistId);
        newClient.Save();
        List<Client> allClients = Client.GetAllClients();
        return RedirectToAction("Index");
        //return View("Index", allStylists);
        }



        [HttpPost("/stylist/{stylistId}/newClient")]
        public ActionResult CreateClient(string clientName, int stylistId)
        {
            new Client(clientName, stylistId).Save();
            return View("Details", Stylist.Find(stylistId));
        }


        
         [HttpPost("/client/deleteAll")]
        public ActionResult DeleteAll()
        {
                Client.DeleteAll();
                return View("Index");
        }


         [HttpGet("/client/{clientId}")]
        public ActionResult Details(int clientId)
        {
          //  Dictionary<string, object> model = new Dictionary<string, object>();
            Client selectClient = Client.Find(clientId);
          //  List<Client> stylistClient = selectStylist.GetClients();
           // model.Add("stylist", selectStylist);
          //  model.Add("client", stylistClient);
           // return View("Details");
             return View(selectClient);
              
        }

    }

}

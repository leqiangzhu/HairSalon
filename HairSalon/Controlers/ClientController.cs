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
        public ActionResult Create(string clientName, int stylistId,string clientPhone,
                                    string clientNote,int clientId)
        {

        Client newClient = new Client(clientName, stylistId,
                                        clientPhone ,clientNote, clientId);
        newClient.Save();
        List<Client> allClients = Client.GetAllClients();
        return RedirectToAction("Index");
        }



        [HttpPost("/stylist/{stylistId}/newClient")]
        public ActionResult Details(string clientName, int stylistId, string clientPhone,
        string clientNote,int clientId)
        {
            new Client(clientName, stylistId, clientPhone,clientNote , clientId).Save();
            return View("Details", Stylist.Find(stylistId));
        }



         [HttpPost("/client/deleteAll")]
        public ActionResult DeleteAll()
        {
                Client.DeleteAll();
                return View("Index");
        }

        //detais
         [HttpGet("/client/{clientId}")]
        public ActionResult Details(int clientId)
        {

            Client selectClient = Client.Find(clientId);
             return View(selectClient);

        }


        [HttpGet("/client/{clientId}/edit")]
        public ActionResult Edit(int clientId)
        {
            Client selectClient = Client.Find(clientId);
            return View(selectClient);

        }

         [HttpGet("/Test")]
        public ActionResult Test()
        {
            Client selectClient = Client.Find(3);
            return View(selectClient);

        }




           [HttpPost("/client/{clientId}/edit")]
        public ActionResult EditClient(int Stylist_Id, string clientName,string clientPhoneNumber,string clientNote,int clientId)
        {
           Client selectClient = Client.Find(clientId);
           selectClient.Edit(clientId);

             return RedirectToAction("Details");
        }

        // [HttpGet("/client/{clientId}/edit")]
        // public ActionResult Edit(int Stylist_Id, string clientName,string clientPhoneNumber,string clientNote,int id)
        // {
        //   // Client selectClient = Client.Find(id);

        //   Client.Edit( Stylist_Id,  clientName, clientPhoneNumber, clientNote, id);
        //      return View("Details");


        // }


         [HttpPost("/client/{clientId}/delete")]
        public ActionResult ClientDelete(int clientId)
        {

            Client.Delete(clientId);
            List<Client> allClient = Client.GetAllClients();
            return View("Index",allClient);
        }

    }

}

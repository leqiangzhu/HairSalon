using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;
using Microsoft.AspNetCore.Mvc;


namespace HairSalon.Models
{
    public class Stylist
    {
        private string _stylistName;
        private int _stylistId;
        public Stylist(string stylistName, int stylistId)
        {
            _stylistName = stylistName;
            _stylistId = stylistId;
        }

        public string GetStylistName()
        {
            return _stylistName;
        }
        public void SetStylistName(string stylistName)
        {
            _stylistName = stylistName;
        }

         public int GetStylistId()
        {
            return _stylistId;
        }
        public void SetStylistId(int stylistId)
        {
            _stylistId = stylistId;
        }
      }
}

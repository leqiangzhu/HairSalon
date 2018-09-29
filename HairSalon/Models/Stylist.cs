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
        public Stylist(string stylistName, int stylistId=0)
        {
            _stylistName = stylistName;
            _stylistId = stylistId;
        }

        public string GetStylistName()
        {
            return _stylistName;
        }
        // public void SetStylistName(string stylistName)
        // {
        //     _stylistName = stylistName;
        // }

         public int GetStylistId()
        {
            return _stylistId;
        }
         public void SetStylistId(int stylistId)
        {
            _stylistId=stylistId;
        }


          public override bool Equals(System.Object otherStylist)
        {
            if(!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool areNamesEqual = this.GetStylistName().Equals(newStylist.GetStylistName());
                bool areIdsEqual = this.GetStylistId().Equals(newStylist.GetStylistId());
                return (areNamesEqual && areIdsEqual);
            }
        }

        public override int GetHashCode()
        {
            return this.GetStylistName().GetHashCode();
        }

        //database table: stylists,stylist_name,

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (stylist_name) VALUES (@stylistName);";

            MySqlParameter stylistName1 = new MySqlParameter();
            stylistName1.ParameterName = "@stylistName";
            stylistName1.Value = this.GetStylistName();
            cmd.Parameters.Add(stylistName1);

           // cmd.Parameters.Add(new MySqlParameter("@stylistName", _stylistName));
            cmd.ExecuteNonQuery();
            _stylistId = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                Stylist newStylist = new Stylist(stylistName, stylistId);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }



    //     public static Item Find(int id)
    //    {
    //        MySqlConnection conn = DB.Connection();
    //        conn.Open();

    //        var cmd = conn.CreateCommand() as MySqlCommand;
    //        cmd.CommandText = @"SELECT * FROM `items` WHERE id = @thisId;";

    //        MySqlParameter thisId = new MySqlParameter();
    //        thisId.ParameterName = "@thisId";
    //        thisId.Value = id;
    //        cmd.Parameters.Add(thisId);

    //        var rdr = cmd.ExecuteReader() as MySqlDataReader;

    //        int itemId = 0;
    //        string itemDescription = "";

    //        while (rdr.Read())
    //        {
    //            itemId = rdr.GetInt32(0);
    //            itemDescription = rdr.GetString(1);
    //        }

    //        Item foundItem= new Item(itemDescription, itemId);  // This line is new!

    //         conn.Close();
    //         if (conn != null)
    //         {
    //             conn.Dispose();
    //         }

    //        return foundItem;  // This line is new!

    //    }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE stylist_id = @stylistId;";

            //cmd.Parameters.Add(new MySqlParameter("@stylistId", id));
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@stylistId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int stylistId = 0;
            string stylistName = "";
            while (rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
            }
            Stylist foundStylist = new Stylist(stylistName, stylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundStylist;
        }

        public List<Client> GetClients()
        {
            List<Client> newClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylistId;";

            cmd.Parameters.Add(new MySqlParameter("@stylistId", _stylistId));

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
              string clientName = rdr.GetString(1);
              int stylistId=rdr.GetInt32(2);
              string clientGender=rdr.GetString(3);
              string clientPhoneNumber=rdr.GetString(4);
            string clientEmail=rdr.GetString(5);
            string clientAddress=rdr.GetString(6);
            string clientCard=rdr.GetString(7);
            string clientNote =rdr.GetString(8);
       
              Client newClient = new Client(clientName, stylistId, clientGender, clientPhoneNumber,
         clientEmail, clientAddress, clientCard, clientNote , clientId);
         newClients.Add(newClient);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return newClients;
        }

        public static void DeleteAll()
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"TRUNCATE TABLE stylists;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        }

          public static void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand()as MySqlCommand;

            cmd.CommandText = @"DELETE  FROM stylists  WHERE stylist_id = @id;";
            cmd.Parameters.Add(new MySqlParameter("@id", id));
    
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }





      }
}

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
        private string _stylistDate;
        private string _stylistPhone;
        private string _stylistEmail;
        public Stylist(string stylistName,string stylistPhone,
        string stylistEmail,string stylistDate,int stylistId=0)
        {
            _stylistName = stylistName;
            _stylistPhone=stylistPhone;
            _stylistEmail=stylistEmail;
            _stylistDate=stylistDate;
             _stylistId = stylistId;
        }

        public string GetStylistName()
        {
            return _stylistName;
        }
        public string GetStylistEmail()
        {
            return _stylistEmail;
        }
        public string GetStylistPhone()
        {
            return _stylistPhone;
        }
         public int GetStylistId()
        {
            return _stylistId;
        }
         public void SetStylistId(int stylistId)
        {
            _stylistId=stylistId;
        }

          public string GetStylistDate()
        {
            return _stylistDate;
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
                bool arePhoneEqual = this.GetStylistPhone().Equals(newStylist.GetStylistPhone());
                bool areEmailEqual = this.GetStylistEmail().Equals(newStylist.GetStylistEmail());
                bool areDateEqual = this.GetStylistDate().Equals(newStylist.GetStylistDate());
                return (areNamesEqual && areIdsEqual &&
                        arePhoneEqual && areEmailEqual && areDateEqual);
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
            cmd.CommandText = @"INSERT INTO stylists (stylist_name,stylist_phone,
                                stylist_email,stylist_date)
                 VALUES (@stylistName,@stylistPhone,@stylisEmail,@stylistDate);";



            cmd.Parameters.Add(new MySqlParameter("@stylistName", this._stylistName));
            cmd.Parameters.Add(new MySqlParameter("@stylistPhone", this._stylistPhone));
            cmd.Parameters.Add(new MySqlParameter("@stylisEmail", this._stylistEmail));
            cmd.Parameters.Add(new MySqlParameter("@stylistDate", this._stylistDate));

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
                string stylistPhone = rdr.GetString(2);
                string stylistEmail = rdr.GetString(3);
                string stylistDate=rdr.GetString(4);

                Stylist newStylist = new Stylist(stylistName,stylistPhone,
                                        stylistEmail ,stylistDate,stylistId);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
          //  MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE stylist_id = @stylistId;";

            //cmd.Parameters.Add(new MySqlParameter("@stylistId", id));
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@stylistId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

                int stylistId = 0;
                string stylistName = "";
                string stylistPhone = "";
                string stylistEmail = "";
                string stylistDate="";

                while (rdr.Read())
            {
                 stylistId = rdr.GetInt32(0);
                 stylistName = rdr.GetString(1);
                 stylistPhone = rdr.GetString(2);
                 stylistEmail = rdr.GetString(3);
                 stylistDate=rdr.GetString(4);
            }
            Stylist foundStylist = new Stylist(stylistName,stylistPhone, stylistEmail ,stylistDate,stylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundStylist;
        }


        //add client to the stylist
        public void AddClient(Client newClient )
        {
             MySqlConnection conn = DB.Connection();
             conn.Open();
             MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText= @"INSERT INTO stylist_clients (stylist_id, client_id) 
                                                        VALUES (@stylistId, @clientId);";


              cmd.Parameters.Add(new MySqlParameter("@stylistId", _stylistId));
              cmd.Parameters.Add(new MySqlParameter("@clientId", newClient.GetClientId()));

              cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        
        
        
        
        public List<Client> GetClients()
        {
            List<Client> newClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

            cmd.CommandText =  @"SELECT clients.* FROM stylists
                            JOIN stylist_clients ON (stylists.stylist_id = stylist_clients.stylist_id)
                            JOIN clients ON (stylist_clients.client_id = clients.client_id)
                            WHERE stylists.stylist_id = @stylistId;";

            cmd.Parameters.Add(new MySqlParameter("@stylistId", this._stylistId));

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
                int clientId = 0;
                string clientName="";
                string clientPhoneNumber="";
                string  clientNote=""; 
              
            while (rdr.Read())
            {
                 clientId = rdr.GetInt32(0);
                 clientName=rdr.GetString(1);
                 clientPhoneNumber=rdr.GetString(2);
                 clientNote=rdr.GetString(3); 
              
             
              Client newClient = new Client(clientName, clientPhoneNumber,
          clientNote , clientId);
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


          public void AddSpecialty(Specialty newSpecialty)
        {
             MySqlConnection conn = DB.Connection();
             conn.Open();
             MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText= @"INSERT INTO stylists_specialties (stylist_id, specialty_id) 
                                                        VALUES (@stylistId, @specialtyId);";


              cmd.Parameters.Add(new MySqlParameter("@stylistId", this._stylistId));
              cmd.Parameters.Add(new MySqlParameter("@specialtyId", newSpecialty.GetSpecialtyId()));

              cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }





      }
}

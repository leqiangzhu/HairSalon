using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;
using Microsoft.AspNetCore.Mvc;


namespace HairSalon.Models
{
    public class Client
    {
        private string _clientName;
        private int _clientId;
        private int _stylistId;
        private string _clientPhoneNumber;
         private string _clientGender;
        private string _clientEmail;
        private string _clientAddress;
        private string _clientNote;
        private string _clientCard;

        public Client(string clientName,int stylistId, string clientGender,string clientPhoneNumber,
        string clientEmail,string clientAddress,string clientCard,string clientNote ,int clientId=0)
        {
            _clientName = clientName;
            _clientGender=clientGender;
            _stylistId = stylistId;
            _clientPhoneNumber=clientPhoneNumber;
            _clientEmail=clientEmail;
            _clientId = clientId;
            _clientCard=clientCard;
            _clientNote=clientNote;
            _clientAddress=clientAddress;
        }

        public string GetClientName()
        {
            return _clientName;
        }
       

         public int GetClientId()
        {
            return _clientId;
        }
      
        public int GetStylistId()
        {
            return _stylistId;
        }
         public string GetClientPhone()
        {
            return _clientPhoneNumber;
        }
        
        
         public string GetClientEmail()
        {
            return _clientEmail;
        }

          public string GetClientNote()
        {
            return _clientNote;
        }
           public string GetClientAddress()
        {
            return _clientAddress;
        }

         public string GetClientCard()
        {
            return _clientCard;
        }
        public override bool Equals(System.Object otherClient)
        {
            if(!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool areNamesEqual = this.GetClientName().Equals(newClient.GetClientName());
                bool areIdsEqual = this.GetClientId().Equals(newClient.GetClientId());
                return (areNamesEqual && areIdsEqual);
            }
        }

        public override int GetHashCode()
        {
            return this.GetClientId().GetHashCode();
        }

             public void Save()
            {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (client_name, stylist_id,client_gender,client_phone,
                                client_email,client_address,client_card,client_note) 
                            VALUES (@clientName, @stylistId);";


                    cmd.Parameters.Add(new MySqlParameter("@clientName", this._clientName));
                    cmd.Parameters.Add(new MySqlParameter("@clientGender", this._clientGender));
                    cmd.Parameters.Add(new MySqlParameter("@clientPhone", this._clientPhoneNumber));
                    cmd.Parameters.Add(new MySqlParameter("@clientEmail", this._clientEmail));
                    cmd.Parameters.Add(new MySqlParameter("@clientAddress", this._clientAddress));
                    cmd.Parameters.Add(new MySqlParameter("@clientCard", this._clientCard));
                    cmd.Parameters.Add(new MySqlParameter("@clientNote", this._clientNote));
                    cmd.Parameters.Add(new MySqlParameter("@stylistId", this._stylistId));
                   








            // MySqlParameter clientName = new MySqlParameter();
            // clientName.ParameterName = "@clientName";
            // clientName.Value = this._clientName;
            // cmd.Parameters.Add(clientName);

            // MySqlParameter stylistId = new MySqlParameter();
            // stylistId.ParameterName = "@stylistId";
            // stylistId.Value = this._stylistId;
            // cmd.Parameters.Add(stylistId);


            cmd.ExecuteNonQuery();
            _clientId = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            }
        public static List<Client> GetAllClients()
        {
            List<Client> allClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
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
              allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
            }


            
            public static Client Find(int id)
            {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE client_id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int clientId = 0;
            string clientName = "";
            int Stylist_Id = 0;
              string clientGender="";
              string clientPhoneNumber="";
            string clientEmail="";
            string clientAddress="";
            string clientCard="";
            string clientNote ="";

            while(rdr.Read())
            {
                clientId = rdr.GetInt32(0);
                clientName = rdr.GetString(1);
                Stylist_Id = rdr.GetInt32(2);
               clientGender=rdr.GetString(3);
               clientPhoneNumber=rdr.GetString(4);
             clientEmail=rdr.GetString(5);
             clientAddress=rdr.GetString(6);
             clientCard =rdr.GetString(7);
             clientNote =rdr.GetString(8);
            }
            Client newClient =  new Client(clientName, Stylist_Id, clientGender, clientPhoneNumber,
         clientEmail, clientAddress, clientCard, clientNote , clientId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return newClient;
            }


        public static void DeleteAll()
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"TRUNCATE TABLE clients;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        }


        public void Edit(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
    
        var cmd = conn.CreateCommand()as MySqlCommand;
        cmd.CommandText = @"UPDATE `clients` SET client_name = @Newclient_name,
                                                    client_gender = @Newclient_gender,
                                                    client_phone = @Newclient_phone,
                                                    client_email = @Newclient_email,
                                                    client_card = @Newclient_card,
                                                    client_note = @Newclient_note,
                                                       WHERE client_id = @Id;";
//             UPDATE table_name
// SET column1 = value1, column2 = value2, ...
// WHERE condition;

            cmd.Parameters.Add(new MySqlParameter("@Id", id));
            cmd.Parameters.Add(new MySqlParameter("@Newclient_name", this._clientName));
            cmd.Parameters.Add(new MySqlParameter("@Newclient_gender", this._clientGender));
            cmd.Parameters.Add(new MySqlParameter("@Newclient_phone", _stylistId));
            cmd.Parameters.Add(new MySqlParameter("@Newclient_email", _stylistId));
            cmd.Parameters.Add(new MySqlParameter("@Newclient_note", _stylistId));


       
        cmd.ExecuteNonQuery();
    
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }





    }

}

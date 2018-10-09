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
    //private int _stylistId;
    private string _clientPhoneNumber;
       // private string _clientGender;
   // private string _clientEmail;
   // private string _clientAddress;
    private string _clientNote;
   // private string _clientCard;

    public Client(string clientName,string clientPhoneNumber,string clientNote ,int clientId=0)
    {
        _clientName = clientName;
        //_stylistId = stylistId;
        _clientPhoneNumber=clientPhoneNumber;
        _clientId = clientId;
        _clientNote=clientNote;

    }

    public string GetClientName()
    {
        return _clientName;
    }

        public int GetClientId()
    {
        return _clientId;
    }

    // public int GetStylistId()
    // {
    //     return _stylistId;
    // }
        public string GetClientPhone()
    {
        return _clientPhoneNumber;
    }


    //     public string GetClientEmail()
    // {
    //     return _clientEmail;
    // }

        public string GetClientNote()
    {
        return _clientNote;
    }
    //    public string GetClientAddress()
    // {
    //     return _clientAddress;
    // }

    //  public string GetClientCard()
    // {
    //     return _clientCard;
    // }
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
            bool areNotesEqual = this.GetClientNote().Equals(newClient.GetClientNote());
            bool arePhoneEqual = this.GetClientPhone().Equals(newClient.GetClientPhone());
            // bool areIdsEqual = this.GetClientId().Equals(newClient.GetClientId());
            return (areNamesEqual && areIdsEqual && arePhoneEqual && areNotesEqual);
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
        cmd.CommandText = @"INSERT INTO clients (client_name,client_phone,
                            client_note)
                        VALUES (@clientName,@clientPhone,@clientNote);";

                cmd.Parameters.Add(new MySqlParameter("@clientName", this._clientName));
                cmd.Parameters.Add(new MySqlParameter("@clientPhone", this._clientPhoneNumber));
                cmd.Parameters.Add(new MySqlParameter("@clientNote", this._clientNote));
                // cmd.Parameters.Add(new MySqlParameter("@stylistId", this._stylistId));

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
            //int Stylist_Id = rdr.GetInt32(2);
            string  clientPhoneNumber=rdr.GetString(2);
            string clientNote =rdr.GetString(3);

            Client newClient = new Client(clientName, clientPhoneNumber,
        clientNote , clientId);
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
       
        string clientPhoneNumber="";
        string clientNote ="";

        while(rdr.Read())
        {
            clientId = rdr.GetInt32(0);
            clientName = rdr.GetString(1);
         //   Stylist_Id = rdr.GetInt32(2);
            clientPhoneNumber=rdr.GetString(2);
            clientNote =rdr.GetString(3);
        }
        Client newClient =  new Client(clientName, clientPhoneNumber,
        clientNote , clientId);
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }

        return newClient;
        }


          //get the clinet that dont have stylist

            public static List<Client> GetFreeClients()
        {
            List<Client> newClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;


            cmd.CommandText =  @"SELECT clients.* FROM stylists
                            JOIN stylist_clients ON (stylists.stylist_id = stylist_clients.stylist_id)
                            JOIN clients ON (stylist_clients.client_id = clients.client_id)
                            WHERE stylists.stylist_id >0";

            // cmd.CommandText =  @"SELECT clients.* FROM clients  a  JOIN stylist_clients b ON
            //                         a.client_id=b.client_id  WHERE b.client_id =2;";

           // cmd.Parameters.Add(new MySqlParameter("@stylistId", this._stylistId));

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
    cmd.CommandText = @"TRUNCATE TABLE clients;";
    cmd.ExecuteNonQuery();
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
    }

        public void Edit(string clientName, string clientPhoneNumber,string clientNote, int id)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE clients SET client_name = @clientName,client_phone = @clientPhone,
                     client_note = @clientNote, WHERE client_id = @id;";

                cmd.Parameters.Add(new MySqlParameter("@clientName", clientName));
                cmd.Parameters.Add(new MySqlParameter("@clientPhone", clientPhoneNumber));
                cmd.Parameters.Add(new MySqlParameter("@clientNote", clientNote));
                cmd.Parameters.Add(new MySqlParameter("@id", id));

       // cmd.ExecuteNonQuery();
       // _clientId = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        }



        // public static Client Edit()
        // {
        // MySqlConnection conn = DB.Connection();
        // conn.Open();
        // var cmd = conn.CreateCommand() as MySqlCommand;
        // cmd.CommandText = @"UPDATE  clients SET (client_name, stylist_id,client_phone,client_note)
        //                 VALUES (@clientName, @stylistId,@clientPhone,@clientNote) WHERE client_id = @Id;";

        // var rdr = cmd.ExecuteReader() as MySqlDataReader;

        // int clientId = this.GetClientId();
        // string clientName = "@clientName";
        // int Stylist_Id = @stylistId;
        // string clientPhoneNumber="@clientPhone";
        // string clientNote ="@clientNote";

        // while(rdr.Read())
        // {
        //     clientId = rdr.GetInt32(0);
        //     clientName = rdr.GetString(1);
        //     Stylist_Id = rdr.GetInt32(2);
        //     clientPhoneNumber=rdr.GetString(3);
        //     clientNote =rdr.GetString(4);
        // }
        // Client newClient =  new Client(clientName, Stylist_Id, clientPhoneNumber,
        // clientNote , clientId);
               
        // cmd.ExecuteNonQuery();

        // conn.Close();
        // if (conn != null)
        // {
        //     conn.Dispose();
        // }

        // return newClient;
        // }





            public static void Delete(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand()as MySqlCommand;

        cmd.CommandText = @"DELETE  FROM clients  WHERE client_id = @id;";
        cmd.Parameters.Add(new MySqlParameter("@id", id));

        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

        //add Specialty to the client
       public void AddSpecialty(Specialty newSpecialty)
        {
             MySqlConnection conn = DB.Connection();
             conn.Open();
             MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText= @"INSERT INTO clients_specialties (client_id, specialty_id) 
                                                        VALUES (@clientId, @specialtyId);";


              cmd.Parameters.Add(new MySqlParameter("@clientId", this._clientId));
              cmd.Parameters.Add(new MySqlParameter("@specialtyId", newSpecialty.GetSpecialtyId()));

              cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        //this is a method to Find the STYLIST by clientid , use in client details
         public static Stylist FindStylist(int clientId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"SELECT * FROM stylists WHERE stylist_id =
                (SELECT stylist_id FROM stylist_clients WHERE client_id = (@searchId);)";

            cmd.Parameters.Add(new MySqlParameter("@searchId", clientId));
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


}

}

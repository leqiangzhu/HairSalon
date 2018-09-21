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
        public Client(string clientName,int stylistId, int clientId=0)
        {
            _clientName = clientName;
            _stylistId = stylistId;
            _clientId = clientId;
        }

        public string GetClientName()
        {
            return _clientName;
        }
        public void SetClientName(string clientName)
        {
            _clientName = clientName;
        }

         public int GetClientId()
        {
            return _clientId;
        }
        public void SetClientId(int clientId)
        {
            _clientId = clientId;
        }
        public int GetStylistId()
        {
            return _stylistId;
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
            return this.GetClientName().GetHashCode();
        }

        public static List<Client> GetAll()
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
              Client newClient = new Client(clientName, clientId);
              allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
            }


            public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (client_name, stylist_id) VALUES (@clientName, @stylistId);";

            MySqlParameter clientName = new MySqlParameter();
            clientName.ParameterName = "@clientName";
            clientName.Value = this._clientName;
            cmd.Parameters.Add(clientName);

            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@stylistId";
            stylistId.Value = this._stylistId;
            cmd.Parameters.Add(stylistId);


            cmd.ExecuteNonQuery();
            _clientId = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }




    }

}

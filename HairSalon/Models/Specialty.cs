using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;
using Microsoft.AspNetCore.Mvc;


namespace HairSalon.Models
{
public class Specialty
{
  private  int _specialtyId;
  private  string  _specialtyName;


  public Specialty(string specialtyName,int specialtyId=0)
  {
    _specialtyName=specialtyName;
    _specialtyId=specialtyId;
  }

  public string GetSpecialtyName()
  {
    return _specialtyName;
  }

  public int GetSpecialtyId()
  {
    return _specialtyId;
  }

  public override bool Equals(System.Object otherSpecialty)
{
    if(!(otherSpecialty is Specialty))
    {
        return false;
    }
    else
    {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool areNamesEqual = this.GetSpecialtyName().Equals(newSpecialty.GetSpecialtyName());
        bool areIdsEqual = this.GetSpecialtyId().Equals(newSpecialty.GetSpecialtyId());
        return (areNamesEqual && areIdsEqual);
    }
}

public override int GetHashCode()
{
    return this.GetSpecialtyName().GetHashCode();
}



//table:specialties,specialty_name,specialty_id
public void Save()
{
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"INSERT INTO specialties (specialty_name)
         VALUES (@specialtyName);";
    cmd.Parameters.Add(new MySqlParameter("@specialtyName", this._specialtyName));

    cmd.ExecuteNonQuery();
    _specialtyId = (int)cmd.LastInsertedId;
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
}

public static List<Specialty> GetAll()
{
    List<Specialty> allSpecialties = new List<Specialty> {};
    MySqlConnection conn = DB.Connection();
    conn.Open();

    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM specialties;";

    var rdr = cmd.ExecuteReader() as MySqlDataReader;
    while (rdr.Read())
    {
        int specialtyId = rdr.GetInt32(0);
        string specialtyName = rdr.GetString(1);

        Specialty newSpecialty = new Specialty(specialtyName,specialtyId);
        allSpecialties.Add(newSpecialty);
    }
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
    return allSpecialties;
}

public static Specialty Find(int id)
{
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
  //  MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM specialties WHERE specialty_id = @specialtyId;";
    cmd.Parameters.Add(new MySqlParameter("@specialtyId", id));
    var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int specialtyId = 0;
        string specialtyName = "";
        while (rdr.Read())
    {
         specialtyId = rdr.GetInt32(0);
         specialtyName = rdr.GetString(1);
    }
    Specialty foundSpecialty = new Specialty(specialtyName,specialtyId);

    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
    return foundSpecialty;
}


        public static void DeleteAll()
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"TRUNCATE TABLE specialties;";
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

            cmd.CommandText = @"DELETE  FROM specialties  WHERE specialty_id = @id;";
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

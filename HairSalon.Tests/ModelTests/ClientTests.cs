using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hairsalon_test;";
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
    
   [TestMethod]
    public void Client_GetAllClients_DbStartsEmpty_0()
    {
        //Arrange
        //Act
      int num = Client.GetAllClients().Count;
      //Assert
      Assert.AreEqual(0,num);
    }


    [TestMethod]
    public void ClientsAreTheSame()
    {
    // Arrange
    Client firstClient = new Client("David",1,"phone","note");
    Client secondClient = new Client("David",1,"phone","note");
    //Assert
    Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Clients_GetAll_count() 
    {
    Client firstClient = new Client("David",1,"phone","note");
    Client secondClient = new Client("ZHU",1,"phone","note");
     List<Client> ClientsTest = new List<Client> {};
  
     ClientsTest.Add(firstClient);
     ClientsTest.Add(secondClient);
     
     int num = ClientsTest.Count;

        //Assert
    Assert.AreEqual(2, num);
    }



     [TestMethod]
    public void Clients_Find() 
    {
    Client firstClient = new Client("David",1,"phone","note");
    Client secondClient = new Client("ZHU",1,"phone","note");
    firstClient.Save();
    secondClient.Save();
    int id=secondClient.GetClientId();
     Client ClientFind =Client.Find(id);
        //Assert
    Assert.AreEqual(secondClient, ClientFind);
    }

      [TestMethod]
    public void Clients_Detele() 
    {
    Client firstClient = new Client("David",1,"phone","note");
    firstClient.Save();
    int id=firstClient.GetClientId();
     Client NullClient = new Client("", 0,"","");
    
    Client.Delete(id);
    //int num = Client.GetAll().Count;
    Client notFound = Client.Find(id);
    //Assert
   // Assert.AreEqual(0, num)
    //Assert
      Assert.AreEqual(notFound, NullClient);
    }

    [TestMethod]
    public void Clients_Detele_Seocond_Way() 
    {
    Client firstClient = new Client("David",1,"phone","note");
    firstClient.Save();
    int id=firstClient.GetClientId();
    
    Client.Delete(id);
    int num = Client.GetAllClients().Count;
    
    Assert.AreEqual(0, num);
    }



    [TestMethod]
    public void Clients_DeteleAll() 
    {
    Client firstClient = new Client("David",1,"phone","note");
    Client secondClient = new Client("ZHU",1,"phone","note");
    firstClient.Save();
    secondClient.Save();
    Client.DeleteAll();

    int num = Client.GetAllClients().Count;
    Assert.AreEqual(0, num);
    }



  }
}
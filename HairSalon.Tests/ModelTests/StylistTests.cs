using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=david_zhu_test;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    [TestMethod]
    public void Stylist_GetAll_DbStartsEmpty_0()
    {
        //Arrange
        //Act
      int num = Stylist.GetAll().Count;
      //Assert
      Assert.AreEqual(0,num);
    }


    [TestMethod]
    public void StylistsAreTheSame()
    {
    // Arrange
    Stylist firstStylist = new Stylist("David","phone123","david@gmail.com","date");
    Stylist secondStylist = new Stylist("David","phone123","david@gmail.com","date");
    //Assert
    Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Stylists_GetAll_count() 
    {
    Stylist firstStylist = new Stylist("David","phone123","david@gmail.com","date");
    Stylist secondStylist = new Stylist("ZHU","phone123","david@gmail.com","date");
     List<Stylist> stylistsTest = new List<Stylist> {};
  
     stylistsTest.Add(firstStylist);
     stylistsTest.Add(secondStylist);
     
     int num = stylistsTest.Count;

        //Assert
    Assert.AreEqual(2, num);
    }



     [TestMethod]
    public void Stylists_Find() 
    {
    Stylist firstStylist = new Stylist("David","phone123","david@gmail.com","date");
    Stylist secondStylist = new Stylist("ZHU","phone123","david@gmail.com","date");
    firstStylist.Save();
    secondStylist.Save();
    int id=secondStylist.GetStylistId();
     Stylist stylistFind =Stylist.Find(id);
        //Assert
    Assert.AreEqual(secondStylist, stylistFind);
    }

      [TestMethod]
    public void Stylists_Detele() 
    {
    Stylist firstStylist = new Stylist("David","phone123","david@gmail.com","date");
    firstStylist.Save();
    int id=firstStylist.GetStylistId();
     Stylist NullStylist = new Stylist("", "","","",0);
    
    Stylist.Delete(id);
    //int num = Stylist.GetAll().Count;
    Stylist notFound = Stylist.Find(id);
    //Assert
   // Assert.AreEqual(0, num)
    //Assert
      Assert.AreEqual(notFound, NullStylist);
    }

    [TestMethod]
    public void Stylists_Detele_Seocond_Way() 
    {
    Stylist firstStylist = new Stylist("David","phone123","david@gmail.com","date");
    firstStylist.Save();
    int id=firstStylist.GetStylistId();
    
    Stylist.Delete(id);
    int num = Stylist.GetAll().Count;
    
    Assert.AreEqual(0, num);
    }



    [TestMethod]
    public void Stylists_DeteleAll() 
    {
    Stylist firstStylist = new Stylist("David","phone123","david@gmail.com","date");
    Stylist secondStylist = new Stylist("ZHU","phone123","david@gmail.com","date");
    firstStylist.Save();
    secondStylist.Save();
    Stylist.DeleteAll();

    int num = Stylist.GetAll().Count;
    Assert.AreEqual(0, num);
    }



  }
}
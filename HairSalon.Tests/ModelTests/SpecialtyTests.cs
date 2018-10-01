using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTests : IDisposable
  {
    public SpecialtyTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hairsalon_test;";
    }

    public void Dispose()
    {
      Specialty.DeleteAll();
    }
    
   [TestMethod]
    public void Specialty_GetAll_DbStartsEmpty_0()
    {
        //Arrange
        //Act
      int num = Specialty.GetAll().Count;
      //Assert
      Assert.AreEqual(0,num);
    }


    [TestMethod]
    public void SpecialtysAreTheSame()
    {
    // Arrange
    Specialty firstSpecialty = new Specialty("color");
    Specialty secondSpecialty = new Specialty("color");
    //Assert
    Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void Specialtys_GetAll_count() 
    {
    Specialty firstSpecialty = new Specialty("color");
    Specialty secondSpecialty = new Specialty("cutting");
     List<Specialty> SpecialtysTest = new List<Specialty> {};
  
     SpecialtysTest.Add(firstSpecialty);
     SpecialtysTest.Add(secondSpecialty);
     
     int num = SpecialtysTest.Count;

        //Assert
    Assert.AreEqual(2, num);
    }



     [TestMethod]
    public void Specialtys_Find() 
    {
    Specialty firstSpecialty = new Specialty("color");
    Specialty secondSpecialty = new Specialty("cutting");
    firstSpecialty.Save();
    secondSpecialty.Save();
    int id=secondSpecialty.GetSpecialtyId();
     Specialty SpecialtyFind =Specialty.Find(id);
        //Assert
    Assert.AreEqual(secondSpecialty, SpecialtyFind);
    }

      [TestMethod]
    public void Specialtys_Detele() 
    {
    Specialty firstSpecialty = new Specialty("color");
    firstSpecialty.Save();
    int id=firstSpecialty.GetSpecialtyId();
     Specialty NullSpecialty = new Specialty("", 0);
    
    Specialty.Delete(id);
    //int num = Specialty.GetAll().Count;
    Specialty notFound = Specialty.Find(id);
    //Assert
   // Assert.AreEqual(0, num)
    //Assert
      Assert.AreEqual(notFound, NullSpecialty);
    }

    [TestMethod]
    public void Specialtys_Detele_Seocond_Way() 
    {
    Specialty firstSpecialty = new Specialty("color");
    firstSpecialty.Save();
    int id=firstSpecialty.GetSpecialtyId();
    
    Specialty.Delete(id);
    int num = Specialty.GetAll().Count;
    
    Assert.AreEqual(0, num);
    }



    [TestMethod]
    public void Specialtys_DeteleAll() 
    {
    Specialty firstSpecialty = new Specialty("color");
    Specialty secondSpecialty = new Specialty("cutting");
    firstSpecialty.Save();
    secondSpecialty.Save();
    Specialty.DeleteAll();

    int num = Specialty.GetAll().Count;
    Assert.AreEqual(0, num);
    }

  }
}
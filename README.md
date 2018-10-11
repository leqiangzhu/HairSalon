# Hair Salon  

#### Hair Salon. 9/21/2018

#### By **David Zhu**

## Description

* An application allows user to manage the stylist ,client in the hairsalon system

* As a salon employee, I need to be able to see a list of all our stylists.
* As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As an employee, I need to add new stylists to our system when they are hired.
* As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.



* As an employee, I need to be able to delete stylists (all and single).
* As an employee, I need to be able to delete clients (all and single).
* As an employee, I need to be able to view clients (all and single).
* As an employee, I need to be able to edit JUST the name of a stylist. (You can choose to allow employees to edit additional properties but it is not required.)
* As an employee, I need to be able to edit ALL of the information for a client.
* As an employee, I need to be able to add a specialty and view all specialties that have been added.
* As an employee, I need to be able to add a specialty to a stylist.
* As an employee, I need to be able to click on a specialty and see all of the stylists that have that specialty.
* As an employee, I need to see the stylist's specialties on the stylist's details page.
* As an employee, I need to be able to add a stylist to a specialty.

### Specs


## Setup/Installation Requirements
* clone the HairSalon.Solution
* run the HairSalon/Models/
* In the web browser, type :'http://localhost:5000/'
* Use MAMP ,open the phpMyAdmin,Server: localhost:8889;
* Setup Database
* CREATE DATABASE david_zhu
**you can import the SQL file that in the app foder,or you can do step by step:
* *CREATE DATABASE david_zhu
* USE david_zhu;
* CREATE TABLE `clients` (
  `client_id` int(11) NOT NULL,
  `client_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_estonian_ci NOT NULL,
  `client_phone` varchar(255) NOT NULL,
  `client_note` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
* CREATE TABLE `specialties` (
  `specialty_id` int(11) NOT NULL,
  `specialty_name` varchar(255) NOT NULL
);
* CREATE TABLE `stylists` (
  `stylist_id` int(11) NOT NULL,
  `stylist_name` varchar(255) NOT NULL,
  `stylist_phone` varchar(255) NOT NULL,
  `stylist_email` varchar(255) NOT NULL,
  `stylist_date` varchar(255) NOT NULL
);

* CREATE TABLE `stylists_specialties` (
  `stylist_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL
);

* CREATE TABLE `stylist_clients` (
  `stylist_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
);

* CREATE TABLE `clients_specialties` (
  `stylist_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
);

## Specifications

| Spec | Input | Output |
| :------------- | :------------- | :------------- |
| **Program allow user create new stylist,client,specialty** | input: "DAVID" | OUTPUT: "DAVID" |
| **Program allow user EDIT new stylist,client,specialty** | input: "DAVID" | OUTPUT: "DAVID" |
| **Program allow user DELETE stylist,client,specialty items** | input: delete(int id)| OUTPUT: delete |
| **Program allow user view stylist,client,specialty items and the properties** | input:stylist | output:name,clients, specialties |


## Known Bugs
* can not join left table

## Technologies Used
* C#
* Atom
* MSTesting
* GitHub
* MAMP
* .NET
<img height ="600" src= "https://epicenter.epicodus.com/assets/logo-c7cd8a523c273e7e330a944e559d94dbc6d9fbe84db6467039500d3afb4c0da5.png"/>

## Support and Contact Details

_Email zhuleqiang@gmail.com._

### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **_DZ_**

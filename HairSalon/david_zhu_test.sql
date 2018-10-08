-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Oct 01, 2018 at 10:29 PM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


--
-- Database: `david_zhu_test`
--

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `client_id` int(11) NOT NULL,
  `client_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_estonian_ci NOT NULL,
  `client_phone` varchar(255) NOT NULL,
  `client_note` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`client_id`, `client_name`, `client_phone`, `client_note`) VALUES
(1, 'Abbey', '7654301147', 'note'),
(2, 'Daisy', '345-4873-3457', 'no'),
(3, 'Helen', '42588833455', 'note'),
(4, 'Macy', '347-4564-434', 'note'),
(5, 'Debbie', '208-4985-345', 'note'),
(6, 'Angela', '563-2345-2829', 'yes'),
(7, 'Chris', '783-3454-3243', 'chris@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `clients_specialties`
--

CREATE TABLE `clients_specialties` (
  `client_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `specialty_id` int(11) NOT NULL,
  `specialty_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`specialty_id`, `specialty_name`) VALUES
(18, 'COLOR'),
(19, 'WASHING'),
(20, 'CUTTING'),
(21, 'HAIR DESIGN');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `stylist_id` int(11) NOT NULL,
  `stylist_name` varchar(255) NOT NULL,
  `stylist_phone` varchar(255) NOT NULL,
  `stylist_email` varchar(255) NOT NULL,
  `stylist_date` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`stylist_id`, `stylist_name`, `stylist_phone`, `stylist_email`, `stylist_date`) VALUES
(1, 'Aaron', '3549871234', 'Aaron@gmail.com', '1'),
(2, 'David', '3435234', 'davidzhu@gmail.com', '2'),
(3, 'Larson', '6738888334', 'Larson.sm@yahoo.com', '3'),
(4, 'Randy', '3455', 'randy.seattle@msn.com', 'E'),
(6, 'Angela', '42538389897', 'zhu@email', 'date');

-- --------------------------------------------------------

--
-- Table structure for table `stylists_specialties`
--

CREATE TABLE `stylists_specialties` (
  `stylist_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists_specialties`
--

INSERT INTO `stylists_specialties` (`stylist_id`, `specialty_id`) VALUES
(1, 19),
(1, 21),
(1, 19),
(3, 20),
(6, 20),
(6, 21);

-- --------------------------------------------------------

--
-- Table structure for table `stylist_clients`
--

CREATE TABLE `stylist_clients` (
  `stylist_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylist_clients`
--

INSERT INTO `stylist_clients` (`stylist_id`, `client_id`) VALUES
(1, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`client_id`),
  ADD UNIQUE KEY `client_id` (`client_id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`specialty_id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`stylist_id`);

--
-- Indexes for table `stylist_clients`
--
ALTER TABLE `stylist_clients`
  ADD PRIMARY KEY (`client_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `client_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `specialty_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `stylist_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
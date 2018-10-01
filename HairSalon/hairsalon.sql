-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Oct 01, 2018 at 08:38 AM
-- Server version: 5.7.23
-- PHP Version: 7.2.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `hairsalon`
--

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `client_id` int(11) NOT NULL,
  `client_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_estonian_ci NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `client_phone` varchar(255) NOT NULL,
  `client_note` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`client_id`, `client_name`, `stylist_id`, `client_phone`, `client_note`) VALUES
(1, 'Abbey', 1, '7654301147', 'note'),
(2, 'Daisy', 1, '345-4873-3457', 'no'),
(3, 'Helen', 2, '42588833455', 'note'),
(4, 'Macy', 2, '347-4564-434', 'note'),
(5, 'Debbie', 4, '208-4985-345', 'note'),
(6, 'Angela', 4, '563-2345-2829', 'yes'),
(7, 'Chris', 3, '783-3454-3243', 'chris@gmail.com');

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

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`client_id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`stylist_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `client_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `stylist_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

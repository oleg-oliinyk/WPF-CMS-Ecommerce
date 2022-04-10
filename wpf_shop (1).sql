-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 10, 2022 at 04:25 PM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `wpf_shop`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `id` int(11) NOT NULL,
  `photo` varchar(255) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `active` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `photo`, `title`, `description`, `active`) VALUES
(1, '', 'Category 1', 'Lorem Ipsum is simply dummy text of the printing ', 1),
(3, '', 'Category 2', 'Lorem Ipsum is simply dummy text of the printing', 1),
(4, '', 'Category 3', 'Lorem Ipsum is simply dummy text of the printing', 1),
(6, '', 'Category 5', 'Lorem Ipsum is simply dummy text of the printing', 1),
(7, '', 'Category 6', 'Lorem Ipsum is simply dummy text of the printing', 1),
(8, '', 'Category 7', 'Lorem Ipsum is simply dummy text of the printing', 1),
(9, '', 'Category 8', 'Lorem Ipsum is simply dummy text of the printing', 1),
(10, '', 'Category 9', 'Lorem Ipsum is simply dummy text of the printing', 1),
(11, '', 'Category 10', 'Lorem Ipsum is simply dummy text of the printing', 1),
(12, '', 'Category 11', 'Lorem Ipsum is simply dummy text of the printing', 1),
(13, '', 'Category 12', 'Lorem Ipsum is simply dummy text of the printing', 1),
(14, '', 'Category 13', 'Lorem Ipsum is simply dummy text of the printing', 1),
(15, '', 'Category 14', 'Lorem Ipsum is simply dummy text of the printing', 1),
(16, '', 'Category 15', 'Lorem Ipsum is simply dummy text of the printing', 1);

-- --------------------------------------------------------

--
-- Table structure for table `colors`
--

CREATE TABLE `colors` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `active` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `colors`
--

INSERT INTO `colors` (`id`, `title`, `description`, `active`) VALUES
(2, 'Red', 'test', 1),
(3, 'Green', 'test', 1),
(4, 'Yellow', 'test', 1),
(6, 'Grey', 'test', 1),
(7, 'Red', 'test', 1),
(8, 'test', 'test', 1),
(9, 'admin', 'admin', 1);

-- --------------------------------------------------------

--
-- Table structure for table `product2size`
--

CREATE TABLE `product2size` (
  `product_id` int(11) NOT NULL,
  `size_id` int(11) NOT NULL,
  `amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `photo` varchar(255) DEFAULT NULL,
  `cena_netto` decimal(16,4) NOT NULL,
  `cena_brutto` decimal(16,4) NOT NULL,
  `amount` int(11) NOT NULL,
  `color_id` int(11) NOT NULL,
  `active` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `category_id`, `title`, `description`, `photo`, `cena_netto`, `cena_brutto`, `amount`, `color_id`, `active`) VALUES
(1, 0, 'product 1', 'product 1 description', 'trest', '56.0000', '63.0000', 32, 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `size`
--

CREATE TABLE `size` (
  `id` int(11) NOT NULL,
  `size` varchar(255) NOT NULL,
  `active` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `size`
--

INSERT INTO `size` (`id`, `size`, `active`) VALUES
(1, 'M', 1),
(2, 'L', 1),
(3, 'X', 1),
(4, 'L', 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `login` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `country` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `admin` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login`, `password`, `name`, `surname`, `country`, `city`, `email`, `admin`) VALUES
(1, 'admin', 'admin', 'admin', 'admin', 'admin', 'admin', 'admin', 1),
(2, 'oleh', '', 'Oleh', 'Oliinyk', 'oleh', 'oleh', 'oleh', 1),
(3, 'jozef', 'usa', 'Jozef', 'Biden', 'jozef', 'jozef', 'jozef', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `colors`
--
ALTER TABLE `colors`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `size`
--
ALTER TABLE `size`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `colors`
--
ALTER TABLE `colors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `size`
--
ALTER TABLE `size`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

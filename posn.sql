-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 23, 2020 at 07:02 PM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `posn`
--

-- --------------------------------------------------------

--
-- Table structure for table `brands`
--

CREATE TABLE `brands` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `brands`
--

INSERT INTO `brands` (`id`, `name`, `description`) VALUES
(1, 'Intel', 'Intel brands only'),
(2, 'AMD', 'AMD brands only'),
(3, 'ASUS', 'ASUS brands only'),
(4, 'MSI', 'MSI brands only'),
(5, 'GIGABYTE', 'GIGABYTE brands only'),
(6, 'GALAX ', 'GALAX brands only'),
(7, 'Western Digital', 'Western Digital brands only'),
(8, 'Sandisk', 'Sandisk brands only'),
(9, 'Seagate ', 'Seagate brands only'),
(10, 'HKC', 'HKC brands only'),
(11, 'ViewSonic', 'ViewSonic brands only'),
(12, 'Rakk Anyag', 'Rakk Anyag brands only'),
(13, 'DeepCool', 'DeepCool brands only'),
(14, 'Xigmatek', 'Xigmatek brands only'),
(15, 'CoolerMaster', 'CoolerMaster brands only'),
(16, 'Cougar ', 'Cougar brands only'),
(17, 'AeroCool', 'AeroCool brands only'),
(18, 'Zowie', 'Zowie brands only'),
(19, 'Logitech', 'Logitech brands only'),
(20, 'RAKK', 'RAKK brands only'),
(21, 'Razer', 'Razer brands only'),
(22, 'Corsair', 'Corsair brands only'),
(23, 'Hello', 'World');

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `name`, `description`) VALUES
(1, 'Processor', 'Processor Only'),
(2, 'Motherboard', 'Motherboard Only'),
(3, 'Videocard', 'Videocard Only'),
(4, 'Storage Devices', 'Storage Devices Only'),
(5, 'Monitor', 'Monitor Only'),
(6, 'Casing', 'Casing Only'),
(7, 'Mouse', 'Mouse Only'),
(8, 'Keyboard', 'Keyboard Only');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id`, `name`, `username`, `password`) VALUES
(5, 'bryan', 'bryan', 'abc'),
(6, 'GEMRY', 'gemry', '123'),
(7, 'gemry', 'bgemry', '123123'),
(8, '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `catid` int(11) NOT NULL,
  `brid` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `qty` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `name`, `catid`, `brid`, `price`, `qty`) VALUES
(1, 'AMD RYZEN 3 2200G', 1, 2, 5840, 20),
(2, 'INTEL CORE I5-8400', 1, 1, 10340, 20),
(3, 'GIGABYTE RADEON RX570 GV-RX570GAMING-4GD VIDEOCARD 4GB-256BIT PCIE DDR5', 3, 5, 7350, 20),
(4, 'GALAX GEFORCE GTX1060 OC VIDEOCARD 6GB 192BIT PCIE DDR5 BLACK', 3, 6, 10950, 50),
(5, 'ASUS EXPEDITION RADEON RX 570 OC VIDEOCARD 4GB GDDR5', 3, 3, 7550, 25),
(6, 'MSI GEFORCE GTX1660 GTX1660-VENTUS-XS 6GB GDRR5 192-BIT GRAPHIC CARD', 3, 4, 13650, 15),
(7, 'ASUS 90MB0YS0-M0UAY0 ROG STRIX B450-F GAMING MOTHERBOARD SOCKET AM4 PCIE DDR4', 2, 3, 7320, 20),
(8, 'GIGABYTE GA-B450 PRO MOTHERBOARD SOCKET AM4 DDR4', 2, 5, 5550, 45),
(9, 'MSI B450 TOMAHAWK MOTHERBOARD SOCKET AM4 DDR4', 2, 4, 6795, 60),
(10, 'GIGABYTE GA-X399 GAMING 7 MOTHERBOARD SOCKET TR4 DDR4', 2, 5, 20730, 10),
(11, 'WESTERN DIGITAL HARDDISK DRIVE 500GB 2.5 SATA', 4, 7, 2070, 40),
(12, 'SANDISK SDSQXAF-032G-GN6MA EXTREME MIRCROSD 32GB', 4, 8, 650, 50),
(13, 'SEAGATE SLIM STEA1500400 1.5TB PORTABLE HARD DRIVE', 3, 9, 2950, 60),
(14, 'HKC M24B6 24 INCHES BORDERLESS MONITOR', 5, 10, 6160, 40),
(15, 'MSI OPTIX MAG241C 23.6\" CURVED GAMING MONITOR', 5, 4, 13795, 20),
(16, 'GIGABYTE AORUS AD27QD 27 144HZ 1440P FREESYNC GAMING MONITOR', 5, 5, 31995, 10),
(17, 'VIEWSONIC VA1917A 19 INCH LED MONITOR', 5, 11, 3350, 60),
(18, 'AEROCOOL QUARTZ REVO MID TOWER GAMING CASE', 6, 17, 3620, 50),
(19, 'COUGAR PANZER EVO MID TOWER PC CASE RGB', 6, 16, 9970, 40),
(20, 'COOLERMASTER MASTERCASE H500 MID TOWER CASE IRON GREY', 6, 15, 6695, 50),
(21, 'XIGMATEK AQUILA MICRO ATX BLACK CASE', 6, 14, 1395, 100),
(22, 'DEEPCOOL MATREXX 55 ADD TEMPERED GLASS MID TOWER RGB CASE', 6, 13, 2590, 50),
(23, 'RAKK ANYAG GAMING CASE BLACK', 6, 12, 1000, 150),
(24, 'RAKK QUILDAP ILLUMINATED GAMING MOUSE USB RED', 7, 20, 295, 50),
(25, 'ZOWIE 9HN05BBA2E FK2 ESPORT GAMING MOUSE', 7, 18, 3030, 40),
(26, 'LOGITECH G903 LIGHTSPEED WIRELESS GAMING MOUSE', 7, 19, 7095, 50),
(27, 'ASUS CERBERUS FORTUS GAMING MOUSE', 7, 3, 2150, 60),
(28, 'CORSAIR VENGEANCE K60 GAMING KEYBOARD', 8, 22, 4400, 20),
(29, 'RAZER RZ03-01762000-R3M1 BLACKWIDOW X CHROMA MERCURY', 8, 21, 7840, 10),
(30, 'RAKK MUA ILLUMINATED PLUNGER GAMING KEYBOARD BLUE', 8, 20, 995, 100),
(33, 'Logitech mouse overload', 3, 12, 120, 23),
(34, 'Logitech mouse overload', 7, 12, 120, 23);

-- --------------------------------------------------------

--
-- Table structure for table `salesmain`
--

CREATE TABLE `salesmain` (
  `id` int(11) NOT NULL,
  `date` varchar(255) NOT NULL,
  `time` time NOT NULL,
  `cashier` varchar(255) NOT NULL,
  `qty` int(11) NOT NULL,
  `grosstotal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `salesmain`
--

INSERT INTO `salesmain` (`id`, `date`, `time`, `cashier`, `qty`, `grosstotal`) VALUES
(0, '23/02/2020', '06:13:00', '', 2, 143000),
(1, '23/02/2020', '06:02:00', '', 2, 80900),
(2, '23/02/2020', '06:17:00', '', 2, 244550),
(3, '23/02/2020', '06:17:00', '', 2, 513150),
(4, '23/02/2020', '06:20:00', '', 1, 101925),
(5, '23/02/2020', '08:02:00', '', 3, 994200),
(6, '23/02/2020', '08:04:00', '', 2, 141880),
(7, '23/02/2020', '08:08:00', 'bryan', 3, 885050),
(8, '23/02/2020', '08:09:00', 'gemry', 3, 1718125),
(9, '23/02/2020', '09:08:00', 'bryan', 2, 132600),
(10, '23/02/2020', '09:12:00', 'bryan', 2, 265200),
(11, '23/02/2020', '09:21:00', 'bryan', 1, 37750),
(12, '23/02/2020', '09:40:00', 'bryan', 2, 161800),
(13, '23/02/2020', '09:56:00', 'bryan', 2, 161800),
(14, '23/02/2020', '10:06:00', 'bryan', 2, 116800),
(15, '23/02/2020', '10:14:00', 'bryan', 2, 133900),
(16, '23/02/2020', '10:20:00', 'bryan', 1, 116800),
(17, '23/02/2020', '10:21:00', 'bryan', 2, 42700),
(18, '23/02/2020', '10:24:00', 'bryan', 1, 11680),
(19, '23/02/2020', '10:29:00', 'bryan', 3, 161800),
(20, '23/02/2020', '11:37:00', 'bryan', 3, 128480);

-- --------------------------------------------------------

--
-- Table structure for table `salesproducts`
--

CREATE TABLE `salesproducts` (
  `id` int(11) NOT NULL,
  `saleid` int(11) NOT NULL,
  `productname` varchar(255) NOT NULL,
  `qty` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `grosstotal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `salesproducts`
--

INSERT INTO `salesproducts` (`id`, `saleid`, `productname`, `qty`, `price`, `grosstotal`) VALUES
(1, 1, 'AMD RYZEN 3 2200G', 5, 5840, 29200),
(2, 1, 'INTEL CORE I5-8400', 5, 10340, 51700),
(3, 0, 'MSI GEFORCE GTX1660 GTX1660-VENTUS-XS 6GB GDRR5 192-BIT GRAPHIC CARD', 10, 13650, 136500),
(4, 2, 'ASUS EXPEDITION RADEON RX 570 OC VIDEOCARD 4GB GDDR5', 5, 7550, 37750),
(5, 3, 'GIGABYTE GA-B450 PRO MOTHERBOARD SOCKET AM4 DDR4', 4, 5550, 22200),
(6, 4, 'MSI B450 TOMAHAWK MOTHERBOARD SOCKET AM4 DDR4', 15, 6795, 101925),
(7, 5, 'MSI GEFORCE GTX1660 GTX1660-VENTUS-XS 6GB GDRR5 192-BIT GRAPHIC CARD', 10, 13650, 136500),
(8, 6, 'AEROCOOL QUARTZ REVO MID TOWER GAMING CASE', 24, 3620, 86880),
(9, 7, 'GALAX GEFORCE GTX1060 OC VIDEOCARD 6GB 192BIT PCIE DDR5 BLACK', 15, 10950, 164250),
(10, 8, 'ASUS EXPEDITION RADEON RX 570 OC VIDEOCARD 4GB GDDR5', 65, 7550, 490750),
(11, 9, 'AMD RYZEN 3 2200G', 5, 5840, 29200),
(12, 10, 'AMD RYZEN 3 2200G', 10, 5840, 58400),
(13, 11, 'ASUS EXPEDITION RADEON RX 570 OC VIDEOCARD 4GB GDDR5', 5, 7550, 37750),
(14, 12, 'AMD RYZEN 3 2200G', 10, 5840, 58400),
(15, 13, 'AMD RYZEN 3 2200G', 10, 5840, 58400),
(16, 14, 'AMD RYZEN 3 2200G', 10, 5840, 58400),
(17, 15, 'AMD RYZEN 3 2200G', 10, 5840, 58400),
(18, 16, 'AMD RYZEN 3 2200G', 20, 5840, 116800),
(19, 17, 'AMD RYZEN 3 2200G', 2, 5840, 11680),
(20, 18, 'AMD RYZEN 3 2200G', 2, 5840, 11680),
(21, 19, 'AMD RYZEN 3 2200G', 10, 5840, 58400),
(22, 20, 'AMD RYZEN 3 2200G', 2, 5840, 11680);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `brands`
--
ALTER TABLE `brands`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `salesmain`
--
ALTER TABLE `salesmain`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `salesproducts`
--
ALTER TABLE `salesproducts`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `brands`
--
ALTER TABLE `brands`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `salesproducts`
--
ALTER TABLE `salesproducts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

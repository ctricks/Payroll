-- --------------------------------------------------------
-- Host:                         db24216.public.databaseasp.net
-- Server version:               10.11.11-MariaDB-log - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.11.0.7065
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for db24216
CREATE DATABASE IF NOT EXISTS `db24216` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `db24216`;

-- Dumping structure for table db24216.tblmgb_holidays
CREATE TABLE IF NOT EXISTS `tblmgb_holidays` (
  `tblmgb_holidays_Id` int(11) NOT NULL AUTO_INCREMENT,
  `tblmgb_holidays_key` varchar(45) NOT NULL,
  `tblmgb_holidays_name` varchar(45) NOT NULL,
  `tblmgb_holidays_date` datetime DEFAULT NULL,
  `tblmgb_holidays_type` varchar(45) DEFAULT NULL,
  `tblmgb_holidays_isActive` int(11) DEFAULT 1,
  `tblmgb_holidays_datecreated` datetime DEFAULT current_timestamp(),
  `tblmgb_holidays_createdby` int(11) DEFAULT -1,
  `tblmgb_holidays_lastmodify_user` int(11) DEFAULT -1,
  `tblmgb_holidays_lastmodify_date` datetime DEFAULT NULL,
  `tblmgb_holidays_remarks` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`tblmgb_holidays_Id`),
  UNIQUE KEY `tblmgb_holidays_key_UNIQUE` (`tblmgb_holidays_key`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table db24216.tblmgb_holidays: ~21 rows (approximately)
REPLACE INTO `tblmgb_holidays` (`tblmgb_holidays_Id`, `tblmgb_holidays_key`, `tblmgb_holidays_name`, `tblmgb_holidays_date`, `tblmgb_holidays_type`, `tblmgb_holidays_isActive`, `tblmgb_holidays_datecreated`, `tblmgb_holidays_createdby`, `tblmgb_holidays_lastmodify_user`, `tblmgb_holidays_lastmodify_date`, `tblmgb_holidays_remarks`) VALUES
	(1, '2025-01-01||New Year\'s Day', 'New Year\'s Day', '2025-01-01 00:00:00', 'Regular', 1, '2025-08-07 00:38:52', 1, -1, NULL, 'Insert by Upload'),
	(2, '2025-04-01||Eid\'l Fitr (Feast of Ramadhan)', 'Eid\'l Fitr (Feast of Ramadhan)', '2025-04-01 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(3, '2025-04-09||Araw ng Kagitingan', 'Araw ng Kagitingan', '2025-04-09 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(4, '2025-04-17||Maundy Thursday', 'Maundy Thursday', '2025-04-17 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(5, '2025-04-18||Good Friday', 'Good Friday', '2025-04-18 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(6, '2025-05-01||Labor Day', 'Labor Day', '2025-05-01 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(7, '2025-06-06||Eidul Adha (Feast of Sacrifice)', 'Eidul Adha (Feast of Sacrifice)', '2025-06-06 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(8, '2025-06-12||Independence Day', 'Independence Day', '2025-06-12 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(9, '2025-08-28||National Heroes Day', 'National Heroes Day', '2025-08-28 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(10, '2025-11-30||Bonifacio Day', 'Bonifacio Day', '2025-11-30 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(11, '2025-12-25||Christmas Day', 'Christmas Day', '2025-12-25 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(12, '2025-12-30||Rizal Day', 'Rizal Day', '2025-12-30 00:00:00', 'Regular', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(13, '2025-01-29||Chinese New Year', 'Chinese New Year', '2025-01-29 00:00:00', 'Non-Working', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(14, '2025-04-19||Black Saturday', 'Black Saturday', '2025-04-19 00:00:00', 'Non-Working', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(15, '2025-05-12||National and Local Elections', 'National and Local Elections', '2025-05-12 00:00:00', 'Non-Working', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(16, '2025-07-27||Proclamation No. 729', 'Proclamation No. 729', '2025-07-27 00:00:00', 'Non-Working', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(17, '2025-08-21||Ninoy Aquino Day', 'Ninoy Aquino Day', '2025-08-21 00:00:00', 'Non-Working', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(18, '2025-10-31||All Saints\' Day Eve', 'All Saints\' Day Eve', '2025-10-31 00:00:00', 'Non-Working', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(19, '2025-11-02||All Saints\' Day', 'All Saints\' Day', '2025-11-02 00:00:00', 'Non-Working', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(20, '2025-12-24||Christmas Eve', 'Christmas Eve', '2025-12-24 00:00:00', 'Non-Working', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload'),
	(21, '2025-12-31||Last Day of the Year', 'Last Day of the Year', '2025-12-31 00:00:00', 'Non-Working', 1, '2025-08-07 00:39:13', 1, -1, NULL, 'Insert by Upload');

-- Dumping structure for table db24216.tblmgb_settings
CREATE TABLE IF NOT EXISTS `tblmgb_settings` (
  `tblmgb_settings_Id` int(11) NOT NULL AUTO_INCREMENT,
  `tblmgb_settings_name` varchar(45) NOT NULL,
  `tblmgb_settings_value1` varchar(45) DEFAULT NULL,
  `tblmgb_settings_value2` varchar(45) DEFAULT NULL,
  `tblmgb_settings_value3` varchar(45) DEFAULT NULL,
  `tblmgb_settings_isActive` int(11) NOT NULL DEFAULT 1,
  `tblmgb_settings_createdby` int(11) DEFAULT -1,
  `tblmgb_settings_datecreated` datetime DEFAULT current_timestamp(),
  `tblmgb_settings_lastmodify_user` int(11) DEFAULT -1,
  `tblmgb_settings_lastmodify_date` datetime DEFAULT NULL,
  `tblmgb_settings_Remarks` varchar(45) DEFAULT NULL,
  `tblmgb_settings_ParentID` int(11) DEFAULT -1,
  PRIMARY KEY (`tblmgb_settings_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table db24216.tblmgb_settings: ~7 rows (approximately)
REPLACE INTO `tblmgb_settings` (`tblmgb_settings_Id`, `tblmgb_settings_name`, `tblmgb_settings_value1`, `tblmgb_settings_value2`, `tblmgb_settings_value3`, `tblmgb_settings_isActive`, `tblmgb_settings_createdby`, `tblmgb_settings_datecreated`, `tblmgb_settings_lastmodify_user`, `tblmgb_settings_lastmodify_date`, `tblmgb_settings_Remarks`, `tblmgb_settings_ParentID`) VALUES
	(1, 'Company Information', NULL, NULL, NULL, 1, -1, '2025-08-03 08:49:28', -1, NULL, NULL, -1),
	(2, 'Company Name', 'ABC Company', NULL, NULL, 1, -1, '2025-08-04 05:53:44', -1, NULL, NULL, 1),
	(3, 'Company Address', 'Philippines', NULL, NULL, 1, -1, '2025-08-04 05:54:23', -1, NULL, NULL, 1),
	(4, 'Holiday Set-up', NULL, NULL, NULL, 1, -1, '2025-08-04 05:55:12', -1, NULL, NULL, -1),
	(5, 'Regular Holiday', '', NULL, NULL, 1, -1, '2025-08-04 05:55:38', -1, NULL, NULL, 4),
	(6, 'Special Non-Working', NULL, NULL, NULL, 1, -1, '2025-08-04 06:36:18', -1, NULL, NULL, 4),
	(7, 'Others', NULL, NULL, NULL, 1, -1, '2025-08-04 06:36:18', -1, NULL, NULL, 4);

-- Dumping structure for table db24216.tblmgb_users
CREATE TABLE IF NOT EXISTS `tblmgb_users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `tblmgb_users_username` varchar(45) NOT NULL,
  `tblmgb_users_password` varchar(45) NOT NULL,
  `tblmgb_users_role_id` int(11) NOT NULL,
  `tblmgb_users_isactive` int(11) DEFAULT 1,
  `tblmgb_users_datecreated` datetime DEFAULT current_timestamp(),
  `tblmgb_users_createdby` int(11) DEFAULT -1,
  `tblmgb_users_lastmodify_date` datetime DEFAULT NULL,
  `tblmgb_users_lastmodify_user` int(11) DEFAULT -1,
  `tblmgb_users_Remarks` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`,`tblmgb_users_username`),
  KEY `FK_ROLE_idx` (`tblmgb_users_role_id`),
  CONSTRAINT `FK_ROLE` FOREIGN KEY (`tblmgb_users_role_id`) REFERENCES `tblmgb_user_roles` (`tblmgb_user_roles_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table db24216.tblmgb_users: ~1 rows (approximately)
REPLACE INTO `tblmgb_users` (`Id`, `tblmgb_users_username`, `tblmgb_users_password`, `tblmgb_users_role_id`, `tblmgb_users_isactive`, `tblmgb_users_datecreated`, `tblmgb_users_createdby`, `tblmgb_users_lastmodify_date`, `tblmgb_users_lastmodify_user`, `tblmgb_users_Remarks`) VALUES
	(1, 'admin', 'e759e9c488c8723b68ea06bb653710f1', 1, 1, '2025-08-02 17:38:41', -1, NULL, -1, 'Administrator Account');

-- Dumping structure for table db24216.tblmgb_user_roles
CREATE TABLE IF NOT EXISTS `tblmgb_user_roles` (
  `tblmgb_user_roles_id` int(11) NOT NULL AUTO_INCREMENT,
  `tblmgb_user_roles_name` varchar(45) NOT NULL,
  `tblmgb_user_roles_description` varchar(45) DEFAULT NULL,
  `tblmgb_user_roles_isactive` int(11) DEFAULT 1,
  `tblmgb_user_roles_createdBy` int(11) DEFAULT -1,
  `tblmgb_user_roles_datecreated` datetime DEFAULT current_timestamp(),
  `tblmgb_user_roles_lastmodify_user` int(11) DEFAULT NULL,
  `tblmgb_user_roles_lastmodify_date` varchar(45) DEFAULT NULL,
  `tblmgb_user_roles_remarks` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`tblmgb_user_roles_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table db24216.tblmgb_user_roles: ~1 rows (approximately)
REPLACE INTO `tblmgb_user_roles` (`tblmgb_user_roles_id`, `tblmgb_user_roles_name`, `tblmgb_user_roles_description`, `tblmgb_user_roles_isactive`, `tblmgb_user_roles_createdBy`, `tblmgb_user_roles_datecreated`, `tblmgb_user_roles_lastmodify_user`, `tblmgb_user_roles_lastmodify_date`, `tblmgb_user_roles_remarks`) VALUES
	(1, 'Admin', 'Administrator', 1, -1, '2025-08-02 17:38:41', NULL, NULL, 'For Administrator Account');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

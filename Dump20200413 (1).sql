CREATE DATABASE  IF NOT EXISTS `cresijdatabase` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `cresijdatabase`;
-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: localhost    Database: cresijdatabase
-- ------------------------------------------------------
-- Server version	8.0.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `camera_details`
--

DROP TABLE IF EXISTS `camera_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `camera_details` (
  `cameraip` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `cameraid` int(11) NOT NULL AUTO_INCREMENT,
  `camname` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `port` int(11) NOT NULL,
  `user_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `location` int(11) NOT NULL,
  `camera_provider` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `channelid` int(11) DEFAULT NULL,
  PRIMARY KEY (`cameraid`),
  UNIQUE KEY `camera_ip_UNIQUE` (`cameraip`),
  KEY `ff_camloc_idx` (`location`),
  CONSTRAINT `ff_camloc` FOREIGN KEY (`location`) REFERENCES `class_details` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `camera_details`
--
-- ORDER BY:  `cameraid`

LOCK TABLES `camera_details` WRITE;
/*!40000 ALTER TABLE `camera_details` DISABLE KEYS */;
INSERT INTO `camera_details` (`cameraip`, `cameraid`, `camname`, `port`, `user_id`, `password`, `location`, `camera_provider`, `channelid`) VALUES ('172.168.10.96',11,'Cam1',1200,'admin','admin123',55,'HikVision',2),('172.168.10.97',15,'Cam12',554,'admin','admin123',56,'HikVision',2);
/*!40000 ALTER TABLE `camera_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `card_register`
--

DROP TABLE IF EXISTS `card_register`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `card_register` (
  `cardid` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `sno` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `membername` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `memberid` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `rights` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT 'NA',
  `location` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `comment` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `state` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `pending_loc` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `locationid` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`cardid`),
  UNIQUE KEY `cardid_UNIQUE` (`cardid`),
  UNIQUE KEY `memberid_UNIQUE` (`memberid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `card_register`
--
-- ORDER BY:  `cardid`

LOCK TABLES `card_register` WRITE;
/*!40000 ALTER TABLE `card_register` DISABLE KEYS */;
INSERT INTO `card_register` (`cardid`, `sno`, `membername`, `memberid`, `rights`, `location`, `comment`, `state`, `pending_loc`, `locationid`) VALUES ('DE213DFE','123','suha','a1232','','','nothing much','Pending','class 1, class 21, class 22, class 26, ','Class1,Class15,Class16,Class21'),('ED213D','1234','justaname','123','','','something','Pending','class 19, class 20, class 21, ','Class11,Class12,Class13');
/*!40000 ALTER TABLE `card_register` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `centralcontrol`
--

DROP TABLE IF EXISTS `centralcontrol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `centralcontrol` (
  `CCIP` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `location` int(11) NOT NULL,
  PRIMARY KEY (`CCIP`),
  UNIQUE KEY `cc_ip_UNIQUE` (`CCIP`),
  KEY `ff_ccloc_idx` (`location`),
  CONSTRAINT `fk_ccloc` FOREIGN KEY (`location`) REFERENCES `class_details` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='central control machine ip and location';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `centralcontrol`
--
-- ORDER BY:  `CCIP`

LOCK TABLES `centralcontrol` WRITE;
/*!40000 ALTER TABLE `centralcontrol` DISABLE KEYS */;
INSERT INTO `centralcontrol` (`CCIP`, `location`) VALUES ('172.168.10.38',63),('172.168.11.1',61),('172.168.11.13',56),('172.168.11.14',57),('172.168.11.15',58),('172.168.11.26',60),('172.168.11.29',55),('172.168.11.30',64),('172.168.11.32',65),('172.168.11.4',59),('172.168.11.50',62);
/*!40000 ALTER TABLE `centralcontrol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class_details`
--

DROP TABLE IF EXISTS `class_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ClassID` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `ClassName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `GradeID` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `class_id_UNIQUE` (`ClassID`),
  KEY `fk_gradeid_idx` (`GradeID`),
  CONSTRAINT `fk_gradeid` FOREIGN KEY (`GradeID`) REFERENCES `grade_details` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class_details`
--
-- ORDER BY:  `id`

LOCK TABLES `class_details` WRITE;
/*!40000 ALTER TABLE `class_details` DISABLE KEYS */;
INSERT INTO `class_details` (`id`, `ClassID`, `ClassName`, `GradeID`) VALUES (55,'Class55','Class 1',24),(56,'Class56','Class 2',24),(57,'Class57','Class 3',24),(58,'Class58','Class 4',24),(59,'Class59','Class 21',25),(60,'Class60','Class 22',25),(61,'Class61','Class 5',24),(62,'Class62','Class 23',25),(63,'Class63','Class 24',25),(64,'Class64','Class 25',25),(65,'Class65','class 26',25);
/*!40000 ALTER TABLE `class_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `current_loggeduser`
--

DROP TABLE IF EXISTS `current_loggeduser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `current_loggeduser` (
  `userid` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `index` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`index`),
  KEY `fk_currentuser_idx` (`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Currently logged in user';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `current_loggeduser`
--
-- ORDER BY:  `index`

LOCK TABLES `current_loggeduser` WRITE;
/*!40000 ALTER TABLE `current_loggeduser` DISABLE KEYS */;
INSERT INTO `current_loggeduser` (`userid`, `index`) VALUES ('Guest',40);
/*!40000 ALTER TABLE `current_loggeduser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doc_info`
--

DROP TABLE IF EXISTS `doc_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doc_info` (
  `userid` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `doc_info` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `timeofupload` datetime NOT NULL,
  `type` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='info about uploaded documents';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doc_info`
--

LOCK TABLES `doc_info` WRITE;
/*!40000 ALTER TABLE `doc_info` DISABLE KEYS */;
INSERT INTO `doc_info` (`userid`, `doc_info`, `timeofupload`, `type`) VALUES ('admin','doc2.doc','2019-10-14 10:21:24','Public'),('admin','doc3.doc','2019-10-14 10:21:31','Public'),('kash2','doc1.doc','2019-10-14 10:33:56','Public'),('admin','small (1).webm','2019-11-04 15:50:39','Public'),('admin','small (3)(1).webm','2019-11-04 15:51:03','Personal');
/*!40000 ALTER TABLE `doc_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fault_info`
--

DROP TABLE IF EXISTS `fault_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fault_info` (
  `sno` int(11) NOT NULL AUTO_INCREMENT,
  `classid` int(11) NOT NULL,
  `ip` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `fault_knowledge` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `priority` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `gradeid` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT 'N/A',
  `distname` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `member_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phone` bigint(15) DEFAULT NULL,
  `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT 'N/A',
  `Time` datetime NOT NULL,
  `Lastupdated` datetime NOT NULL,
  `status` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'Pending',
  PRIMARY KEY (`sno`),
  KEY `fk_faultloc_idx` (`classid`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='info about faults';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fault_info`
--
-- ORDER BY:  `sno`

LOCK TABLES `fault_info` WRITE;
/*!40000 ALTER TABLE `fault_info` DISABLE KEYS */;
INSERT INTO `fault_info` (`sno`, `classid`, `ip`, `fault_knowledge`, `priority`, `gradeid`, `distname`, `member_name`, `phone`, `description`, `Time`, `Lastupdated`, `status`) VALUES (12,59,'172.168.11.4','Scan Code','Low','Grade25','mandsaur','Usha',12121212121,'Testing','2019-12-03 15:47:46','2019-12-03 15:47:46','Pending'),(13,59,'172.168.11.4','Scan Code','Medium','Grade25','mandsaur','Usha',12121212121,'Testing','2019-12-03 15:48:28','2019-12-03 15:48:28','Pending');
/*!40000 ALTER TABLE `fault_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fault_task`
--

DROP TABLE IF EXISTS `fault_task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fault_task` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `task` varchar(300) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `timetoreport` datetime NOT NULL,
  `timetoresolve` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fault_task`
--
-- ORDER BY:  `id`

LOCK TABLES `fault_task` WRITE;
/*!40000 ALTER TABLE `fault_task` DISABLE KEYS */;
INSERT INTO `fault_task` (`id`, `task`, `timetoreport`, `timetoresolve`) VALUES (1,'This is first task to test','2019-10-25 14:31:41',NULL),(3,'it worked','2019-10-25 14:37:27',NULL),(4,'21 nov edited','2019-11-21 15:26:40',NULL);
/*!40000 ALTER TABLE `fault_task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grade_details`
--

DROP TABLE IF EXISTS `grade_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grade_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `grade_id` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `grade_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `insid` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `grade_id_UNIQUE` (`grade_id`),
  KEY `fk_insid_idx` (`insid`),
  CONSTRAINT `fk_insid` FOREIGN KEY (`insid`) REFERENCES `institute_details` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='as the name suggests';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grade_details`
--
-- ORDER BY:  `id`

LOCK TABLES `grade_details` WRITE;
/*!40000 ALTER TABLE `grade_details` DISABLE KEYS */;
INSERT INTO `grade_details` (`id`, `grade_id`, `grade_name`, `insid`) VALUES (24,'Grade22','Grade 1',16),(25,'Grade25','Grade 2',16);
/*!40000 ALTER TABLE `grade_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inspection_logs`
--

DROP TABLE IF EXISTS `inspection_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inspection_logs` (
  `sno` int(11) NOT NULL AUTO_INCREMENT,
  `distname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `sname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `bname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `className` varchar(10) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `memname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `projStat` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `screenstat` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `ccstat` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `computer` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `speaker` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `wireless` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `wired` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `platform` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` bigint(15) NOT NULL,
  `description` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `time` datetime NOT NULL,
  PRIMARY KEY (`sno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inspection_logs`
--
-- ORDER BY:  `sno`

LOCK TABLES `inspection_logs` WRITE;
/*!40000 ALTER TABLE `inspection_logs` DISABLE KEYS */;
/*!40000 ALTER TABLE `inspection_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `institute_details`
--

DROP TABLE IF EXISTS `institute_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `institute_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ins_name` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'name can be in chinese/english',
  `ins_id` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `insid_UNIQUE` (`id`),
  UNIQUE KEY `ins_id_UNIQUE` (`ins_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Institution Details';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `institute_details`
--
-- ORDER BY:  `id`

LOCK TABLES `institute_details` WRITE;
/*!40000 ALTER TABLE `institute_details` DISABLE KEYS */;
INSERT INTO `institute_details` (`id`, `ins_name`, `ins_id`) VALUES (16,'IIPS','Ins2');
/*!40000 ALTER TABLE `institute_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `machineworkinghours`
--

DROP TABLE IF EXISTS `machineworkinghours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `machineworkinghours` (
  `IP` varchar(20) NOT NULL,
  `date` datetime NOT NULL,
  `projectorHour` double NOT NULL DEFAULT '0',
  `pcHour` double NOT NULL DEFAULT '0',
  `recorderHour` double NOT NULL DEFAULT '0',
  `ACHour` double NOT NULL DEFAULT '0',
  `systemHour` double NOT NULL DEFAULT '0',
  `screenHour` double DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `machineworkinghours`
--

LOCK TABLES `machineworkinghours` WRITE;
/*!40000 ALTER TABLE `machineworkinghours` DISABLE KEYS */;
INSERT INTO `machineworkinghours` (`IP`, `date`, `projectorHour`, `pcHour`, `recorderHour`, `ACHour`, `systemHour`, `screenHour`) VALUES ('172.168.11.26','2019-11-29 18:17:12',0,0,0,0,0.05,0),('172.168.11.26','2019-11-29 21:07:00',0,0.06,0,0,0,0),('172.168.11.4','2019-11-30 18:16:57',0,0,0,0,0.17,0.17),('172.168.11.4','2019-12-02 19:56:27',0,0,0,0,0.88,0),('172.168.11.4','2019-12-02 21:31:10',0,0,0,0,0.18,0),('172.168.11.4','2019-12-02 23:32:11',0,0,0,0,0.05,0),('172.168.11.50','2019-12-05 12:46:34',0.77,0,0,0,0,0),('172.168.11.50','2019-12-06 09:31:50',0,0,0,0,0.03,0),('172.168.11.50','2019-12-06 11:58:21',0,0,0,0,1.02,0.87),('172.168.10.38','2019-12-06 14:01:25',0,0.05,0,0,0,0),('172.168.10.38','2019-12-06 14:06:25',0,0.07,0,0,0,0),('172.168.10.38','2019-12-06 14:09:25',0,0.03,0,0,0,0),('172.168.10.38','2019-12-06 14:15:25',0,0.05,0,0,0,0),('172.168.10.38','2019-12-06 14:22:25',0,0.1,0,0,0,0),('172.168.10.38','2019-12-06 14:29:26',0,0.08,0,0,0,0),('172.168.10.38','2019-12-06 14:32:26',0,0.03,0,0,0,0),('172.168.11.50','2019-12-10 14:06:38',0,0,0,0,0.07,0),('172.168.11.50','2019-12-11 09:21:07',0,0,0,0,0.05,0),('172.168.11.50','2019-12-11 09:29:07',0,0,0,0,0.1,0),('172.168.11.50','2019-12-11 10:04:07',0,0,0,0,0.55,0),('172.168.11.50','2019-12-11 11:49:48',0,0,0,0,0.25,0.05),('172.168.11.50','2019-12-18 14:34:26',0,0,0,0,0.05,0.05),('172.168.11.29','2019-12-19 10:35:10',1,0,0,0,0,0),('172.168.11.15','2020-01-07 17:19:58',0,0,0,0,0.05,0),('172.168.11.15','2020-01-09 13:54:31',0,0,0,0,0.03,0),('172.168.11.15','2020-01-09 14:00:32',0,0,0,0,0.05,0);
/*!40000 ALTER TABLE `machineworkinghours` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `noofdevices`
--

DROP TABLE IF EXISTS `noofdevices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `noofdevices` (
  `proj` int(11) NOT NULL DEFAULT '0',
  `pc` int(11) NOT NULL DEFAULT '0',
  `recorder` int(11) NOT NULL DEFAULT '0',
  `ac` int(11) NOT NULL DEFAULT '0',
  `cc` int(11) DEFAULT '0',
  `screen` int(11) NOT NULL DEFAULT '0',
  `location` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`location`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `noofdevices`
--
-- ORDER BY:  `location`

LOCK TABLES `noofdevices` WRITE;
/*!40000 ALTER TABLE `noofdevices` DISABLE KEYS */;
INSERT INTO `noofdevices` (`proj`, `pc`, `recorder`, `ac`, `cc`, `screen`, `location`) VALUES (2,4,0,0,10,0,'Ins2');
/*!40000 ALTER TABLE `noofdevices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reader_logs`
--

DROP TABLE IF EXISTS `reader_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reader_logs` (
  `readerid` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `cardid` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='record of cards scanned';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reader_logs`
--

LOCK TABLES `reader_logs` WRITE;
/*!40000 ALTER TABLE `reader_logs` DISABLE KEYS */;
INSERT INTO `reader_logs` (`readerid`, `cardid`, `date`) VALUES ('1','ED213D','2019-09-18 09:33:59'),('2','ED213D','2019-09-18 09:21:08'),('2','ED213D','2019-09-18 09:54:11'),('3','ED213D','2019-09-18 09:54:24'),('1','ED213D','2019-09-18 09:54:33'),('1','ED213D','2019-09-18 09:54:50');
/*!40000 ALTER TABLE `reader_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `readerlocation`
--

DROP TABLE IF EXISTS `readerlocation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `readerlocation` (
  `readerid` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `location` int(11) NOT NULL,
  PRIMARY KEY (`readerid`),
  KEY `fk_readerloc_idx` (`location`),
  CONSTRAINT `fk_readerloc` FOREIGN KEY (`location`) REFERENCES `class_details` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `readerlocation`
--
-- ORDER BY:  `readerid`

LOCK TABLES `readerlocation` WRITE;
/*!40000 ALTER TABLE `readerlocation` DISABLE KEYS */;
/*!40000 ALTER TABLE `readerlocation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registration`
--

DROP TABLE IF EXISTS `registration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registration` (
  `userid` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `currentstatus` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'Pending',
  `roleid` int(11) DEFAULT '0',
  PRIMARY KEY (`userid`),
  UNIQUE KEY `UserId_UNIQUE` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='User details before authentication';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registration`
--
-- ORDER BY:  `userid`

LOCK TABLES `registration` WRITE;
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
/*!40000 ALTER TABLE `registration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedule` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `starttime` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `stoptime` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `TimerOn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `TimerOff` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `monday` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `tuesday` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `wednesday` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `thursday` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `friday` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `saturday` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `sunday` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `location` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1111 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--
-- ORDER BY:  `id`

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` (`id`, `starttime`, `stoptime`, `TimerOn`, `TimerOff`, `monday`, `tuesday`, `wednesday`, `thursday`, `friday`, `saturday`, `sunday`, `location`) VALUES (1075,'07:00','07:55','未启动','未启动','','','','','','','','Grade22'),(1076,'08:00','08:55','未启动','未启动','dfgdfg','','','','','','dfgdfg','Grade22'),(1077,'09:00','09:55','未启动','未启动','','dgsdgdfgd','','','','','dfgdfg','Grade22'),(1078,'10:00','10:55','未启动','未启动','','','dfgdfg','dfgdfg','dfgdfg','','','Grade22'),(1079,'11:00','11:55','未启动','未启动','','','','','','','gdfg','Grade22'),(1080,'12:00','12:55','未启动','未启动','','','','','','','','Grade22'),(1081,'13:00','13:55','未启动','未启动','dfgdfg','dgfdfg','','fdgdfgdf','','gdgdf','','Grade22'),(1082,'14:00','14:55','未启动','未启动','','','','','','','','Grade22'),(1083,'15:00','15:55','未启动','未启动','','','','','','','','Grade22'),(1084,'07:00','07:55','未启动','未启动','','','','','','','','Class61'),(1085,'08:00','08:55','未启动','未启动','dfgdfg','','','dfgdfg','','','dfgdfg','Class61'),(1086,'09:00','09:55','未启动','未启动','','dgsdgdfgd','','','','dgfdgf','dfgdfg','Class61'),(1087,'10:00','10:55','未启动','未启动','','','dfgdfg','dfgdfg','dfgdfg','','','Class61'),(1088,'11:00','11:55','未启动','未启动','','dfgdfg','','','','dfgdfg','gdfg','Class61'),(1089,'12:00','12:55','未启动','未启动','','','','','','','','Class61'),(1090,'13:00','13:55','未启动','未启动','dfgdfg','dgfdfg','dfgdfg','fdgdfgdf','dfgdfg','gdgdf','dgfdfg','Class61'),(1091,'14:00','14:55','未启动','未启动','','','','','','','','Class61'),(1092,'15:00','15:55','未启动','未启动','','','','','','dfgdfg','','Class61'),(1093,'07:00','07:55','未启动','已启动','','','','','','','','Ins2'),(1094,'08:00','08:55','未启动','已启动','dfgdfg','','','','','','','Ins2'),(1095,'09:00','09:55','未启动','已启动','','','','','','','','Ins2'),(1096,'10:00','10:55','未启动','已启动','','','dfgdfg','dfgdfg','dfgdfg','','','Ins2'),(1097,'11:00','11:55','未启动','已启动','','','','','','','','Ins2'),(1098,'12:00','12:55','未启动','已启动','','','','','','','','Ins2'),(1099,'13:00','13:55','未启动','已启动','dfgdfg','dgfdfg','','','','','','Ins2'),(1100,'14:00','14:55','未启动','已启动','','','','','','','','Ins2'),(1101,'15:00','15:55','未启动','已启动','','','','','','','','Ins2'),(1102,'07:00','07:55','未启动','未启动','','','','','','','','Class63'),(1103,'08:00','08:55','未启动','未启动','dfgdfg','','','','','hfgh','hfghfg','Class63'),(1104,'09:00','09:55','未启动','未启动','','','','','','','fghfg','Class63'),(1105,'10:00','10:55','未启动','未启动','','','dfgdfg','dfgdfg','dfgdfg','','','Class63'),(1106,'11:00','11:55','未启动','未启动','','','','','','','hfghfgh','Class63'),(1107,'12:00','12:55','未启动','未启动','','','','','','fghfgh','','Class63'),(1108,'13:00','13:55','未启动','未启动','dfgdfg','dgfdfg','','','','','','Class63'),(1109,'14:00','14:55','未启动','未启动','','','','','fghfgh','','','Class63'),(1110,'15:00','15:55','未启动','未启动','','','','','','','','Class63');
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scheduletable`
--

DROP TABLE IF EXISTS `scheduletable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scheduletable` (
  `teacherId` varchar(45) NOT NULL,
  `teacherName` varchar(45) NOT NULL,
  `CourseId` varchar(50) NOT NULL,
  `className` varchar(45) NOT NULL,
  `Coursename` varchar(45) NOT NULL,
  `weekStart` varchar(45) NOT NULL,
  `weekEnd` varchar(45) NOT NULL,
  `dayno` int(11) NOT NULL,
  `section` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scheduletable`
--

LOCK TABLES `scheduletable` WRITE;
/*!40000 ALTER TABLE `scheduletable` DISABLE KEYS */;
INSERT INTO `scheduletable` (`teacherId`, `teacherName`, `CourseId`, `className`, `Coursename`, `weekStart`, `weekEnd`, `dayno`, `section`) VALUES ('t001','first teacher','c001','class 1','science','2','5',3,7),('t002','second teacher','c002','class 1','math','1','6',2,5),('t003','third teacher','c003','class 1','english','1','6',2,5),('t001','first teacher','c001','class 2','science','1','5',3,7),('t001','first teacher','c001','class 3','science','7','15',4,9),('t001','first teacher','c001','class 4','science','23','30',5,11);
/*!40000 ALTER TABLE `scheduletable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `Class` int(11) NOT NULL,
  `MachineIp` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MachineStatus` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `WorkStatus` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `PCStatus` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`MachineIp`),
  UNIQUE KEY `Class_UNIQUE` (`Class`),
  CONSTRAINT `fk_ipstat` FOREIGN KEY (`MachineIp`) REFERENCES `centralcontrol` (`CCIP`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Status of Central Machines';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--
-- ORDER BY:  `MachineIp`

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temp_cardregister`
--

DROP TABLE IF EXISTS `temp_cardregister`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `temp_cardregister` (
  `sno` int(11) DEFAULT NULL,
  `memberid` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `memname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `cardid` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `comment` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `state` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `accessto` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `selectaccess` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`cardid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temp_cardregister`
--
-- ORDER BY:  `cardid`

LOCK TABLES `temp_cardregister` WRITE;
/*!40000 ALTER TABLE `temp_cardregister` DISABLE KEYS */;
INSERT INTO `temp_cardregister` (`sno`, `memberid`, `memname`, `cardid`, `comment`, `state`, `accessto`, `selectaccess`) VALUES (NULL,NULL,NULL,'RST12W',NULL,'unregistered',NULL,NULL);
/*!40000 ALTER TABLE `temp_cardregister` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temp_centralcontrol`
--

DROP TABLE IF EXISTS `temp_centralcontrol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `temp_centralcontrol` (
  `ip` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `loc` int(11) NOT NULL,
  `status` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '离线',
  `workstatus` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `Timer` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT '未启动',
  `pcstatus` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `projectorstatus` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `ProjHour` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT '--',
  `curtain` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `screen` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `light` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `mediasignal` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `centrallock` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `podiumlock` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `classlock` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `temperature` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `humidity` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '--',
  `pm25` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0.0',
  `pm10` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0.0',
  PRIMARY KEY (`ip`,`loc`),
  UNIQUE KEY `loc_UNIQUE` (`loc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='temporary status of machines';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temp_centralcontrol`
--
-- ORDER BY:  `ip`,`loc`

LOCK TABLES `temp_centralcontrol` WRITE;
/*!40000 ALTER TABLE `temp_centralcontrol` DISABLE KEYS */;
INSERT INTO `temp_centralcontrol` (`ip`, `loc`, `status`, `workstatus`, `Timer`, `pcstatus`, `projectorstatus`, `ProjHour`, `curtain`, `screen`, `light`, `mediasignal`, `centrallock`, `podiumlock`, `classlock`, `temperature`, `humidity`, `pm25`, `pm10`) VALUES ('172.168.10.38',63,'离线','--','未启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.1',61,'离线','--','已启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.13',56,'离线','--','已启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.14',57,'离线','--','已启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.15',58,'离线','--','已启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.26',60,'离线','--','已启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.29',55,'离线','--','已启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.30',64,'离线','--','已启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.32',65,'离线','--','未启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.4',59,'离线','--','已启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0'),('172.168.11.50',62,'离线','--','已启动','--','--','--','--','--','--','--','--','--','--','--','--','0.0','0.0');
/*!40000 ALTER TABLE `temp_centralcontrol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temporary_user`
--

DROP TABLE IF EXISTS `temporary_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `temporary_user` (
  `Userid` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `UserName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `ClassName` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `MachineIP` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Date` date NOT NULL,
  `Starttime` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Stoptime` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Status` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(110) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`Userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temporary_user`
--
-- ORDER BY:  `Userid`

LOCK TABLES `temporary_user` WRITE;
/*!40000 ALTER TABLE `temporary_user` DISABLE KEYS */;
INSERT INTO `temporary_user` (`Userid`, `UserName`, `Password`, `ClassName`, `MachineIP`, `Date`, `Starttime`, `Stoptime`, `Status`, `phone`, `description`) VALUES ('admin123','this','admin123','Class 21','172.168.11.4','2019-12-06','11:00','16:00','Approved','14545784578','test'),('tempuser','usha','admin123','Class 21','172.168.11.4','2019-12-02','11:00','13:00','Approved','13254678954','testing'),('tempuser1','usha','admin123','Class 21','172.168.11.4','2019-12-02','11:30','16:30','Approved','45781245785','testing agian'),('Usha','admin2','admin123','Class 22','172.168.11.26','2019-11-30','16:00','18:00','Approved','',''),('usha1','usha','usha1234','Class 21','172.168.11.4','2019-12-02','16:00','17:40','Approved','',''),('usha12','usha','usha1234','Class 2','172.168.11.13','2019-11-30','20:00','21:00','Approved','14785266987','to test'),('usha2','usha','usha1234','Class 21','172.168.11.4','2019-11-30','17:00','19:00','Approved','','');
/*!40000 ALTER TABLE `temporary_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temprature_details`
--

DROP TABLE IF EXISTS `temprature_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `temprature_details` (
  `location` int(11) NOT NULL,
  `temperature` decimal(10,2) NOT NULL,
  `humidity` decimal(10,2) NOT NULL,
  `pm25` decimal(10,2) NOT NULL,
  `pm10` decimal(10,2) NOT NULL,
  `date` datetime DEFAULT NULL,
  KEY `fk_temperatureloc_idx` (`location`),
  CONSTRAINT `fk_temperatureloc` FOREIGN KEY (`location`) REFERENCES `class_details` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='temperature after every 20-30 minutes';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temprature_details`
--

LOCK TABLES `temprature_details` WRITE;
/*!40000 ALTER TABLE `temprature_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `temprature_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `university_name`
--

DROP TABLE IF EXISTS `university_name`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `university_name` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Univ_name` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `university_name`
--
-- ORDER BY:  `id`

LOCK TABLES `university_name` WRITE;
/*!40000 ALTER TABLE `university_name` DISABLE KEYS */;
/*!40000 ALTER TABLE `university_name` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_details`
--

DROP TABLE IF EXISTS `user_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_details` (
  `user_id` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `user_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `role_id` int(11) NOT NULL,
  `phone` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `userid_UNIQUE` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='contain Userdetails';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_details`
--
-- ORDER BY:  `user_id`

LOCK TABLES `user_details` WRITE;
/*!40000 ALTER TABLE `user_details` DISABLE KEYS */;
INSERT INTO `user_details` (`user_id`, `user_name`, `password`, `role_id`, `phone`) VALUES ('admin','admin','admin123',1,'21312321231'),('admin1','admin1','admin123',34,'12111121121'),('Guest','Guest','Guest123',1,'21121221122'),('kash2','kash','kashish1234',1,'232212121222'),('kashi','kashi','kashi123',345,'12123123121'),('usertest','testuser','admin123',1,'14785236974');
/*!40000 ALTER TABLE `user_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_logs`
--

DROP TABLE IF EXISTS `user_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_logs` (
  `userid` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `task` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `time` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_logs`
--

LOCK TABLES `user_logs` WRITE;
/*!40000 ALTER TABLE `user_logs` DISABLE KEYS */;
INSERT INTO `user_logs` (`userid`, `task`, `time`) VALUES ('jsut','some','2019-09-20 11:02:03'),('admin','Login','2019-10-15 11:45:08'),('admin','Visited Status Page','2019-10-15 11:45:08'),('admin','Updated Institute, Grade or Class Details','2019-10-15 11:48:04'),('admin','Login','2019-10-15 13:36:42'),('admin','Visited Status Page','2019-10-15 13:36:42'),('admin','Login','2019-10-15 14:03:44'),('admin','Visited Status Page','2019-10-15 14:03:44'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:04:44'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:04:50'),('admin','Login','2019-10-15 14:09:58'),('admin','Visited Status Page','2019-10-15 14:09:58'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:10:14'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:10:19'),('admin','Login','2019-10-15 14:11:35'),('admin','Visited Status Page','2019-10-15 14:11:35'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:11:44'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:11:49'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:12:09'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:12:13'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:12:51'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:12:55'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:13:52'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:13:56'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:29:10'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:29:14'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:30:07'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:30:10'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:30:59'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:31:07'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:31:41'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:31:46'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:31:53'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:31:57'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:32:01'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:32:25'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:32:28'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:34:04'),('admin','Login','2019-10-15 14:36:22'),('admin','Visited Status Page','2019-10-15 14:36:23'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:36:40'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:36:43'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:38:33'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:39:21'),('admin','Login','2019-10-15 14:40:22'),('admin','Visited Status Page','2019-10-15 14:40:22'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:40:33'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:40:36'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:40:37'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:40:40'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:40:51'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:42:02'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:42:32'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:43:23'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:43:37'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:46:49'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:48:36'),('admin','Login','2019-10-15 14:50:02'),('admin','Visited Status Page','2019-10-15 14:50:02'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:50:17'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:52:13'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:52:38'),('admin','Login','2019-10-15 14:54:31'),('admin','Visited Status Page','2019-10-15 14:54:31'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:54:48'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:55:23'),('admin','Login','2019-10-15 14:57:49'),('admin','Visited Status Page','2019-10-15 14:57:49'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:58:03'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:58:12'),('admin','Updated Institute, Grade or Class Details','2019-10-15 14:59:59'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:00:13'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:00:25'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:00:35'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:00:40'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:00:51'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:00:57'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:10:44'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:10:46'),('admin','Login','2019-10-15 15:22:38'),('admin','Visited Status Page','2019-10-15 15:22:39'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:22:49'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:22:51'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:23:10'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:23:11'),('admin','Login','2019-10-15 15:42:34'),('admin','Visited Status Page','2019-10-15 15:42:34'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:42:45'),('admin','Updated Institute, Grade or Class Details','2019-10-15 15:42:47'),('admin','Login','2019-10-15 16:01:18'),('admin','Visited Status Page','2019-10-15 16:01:18'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:01:28'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:01:30'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:01:58'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:01:59'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:02:44'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:02:55'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:02:56'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:07:27'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:07:51'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:07:53'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:24:22'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:24:24'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:24:52'),('admin','Updated Institute, Grade or Class Details','2019-10-15 16:24:53'),('admin','Login','2019-10-15 16:49:19'),('admin','Visited Status Page','2019-10-15 16:49:19'),('admin','Visited Status Page','2019-10-15 16:49:54'),('admin','Login','2019-10-15 16:55:41'),('admin','Visited Status Page','2019-10-15 16:55:41'),('admin','Login','2019-10-15 17:05:58'),('admin','Visited Status Page','2019-10-15 17:05:58'),('admin','Login','2019-10-15 17:35:59'),('admin','Visited Status Page','2019-10-15 17:35:59'),('admin','Login','2019-10-15 17:46:41'),('admin','Visited Status Page','2019-10-15 17:46:41'),('admin','Login','2019-10-15 17:47:46'),('admin','Visited Status Page','2019-10-15 17:47:46'),('admin','Login','2019-10-15 17:48:42'),('admin','Visited Status Page','2019-10-15 17:48:42'),('admin','Login','2019-10-15 17:58:06'),('admin','Visited Status Page','2019-10-15 17:58:06'),('admin','Login','2019-10-15 17:59:46'),('admin','Visited Status Page','2019-10-15 17:59:46'),('admin','Login','2019-10-15 18:02:31'),('admin','Visited Status Page','2019-10-15 18:02:31'),('admin','Login','2019-10-15 18:10:49'),('admin','Visited Status Page','2019-10-15 18:10:49'),('admin','Login','2019-10-16 08:38:45'),('admin','Visited Status Page','2019-10-16 08:38:45'),('admin','Login','2019-10-16 08:41:31'),('admin','Visited Status Page','2019-10-16 08:41:31'),('admin','Login','2019-10-16 08:42:22'),('admin','Visited Status Page','2019-10-16 08:42:22'),('admin','Login','2019-10-16 08:44:50'),('admin','Visited Status Page','2019-10-16 08:44:50'),('admin','Login','2019-10-16 08:46:47'),('admin','Visited Status Page','2019-10-16 08:46:47'),('admin','Login','2019-10-16 08:50:16'),('admin','Visited Status Page','2019-10-16 08:50:16'),('admin','Login','2019-10-16 09:09:20'),('admin','Visited Status Page','2019-10-16 09:09:20'),('admin','Login','2019-10-16 09:30:55'),('admin','Visited Status Page','2019-10-16 09:30:55'),('admin','Login','2019-10-16 09:32:10'),('admin','Visited Status Page','2019-10-16 09:32:10'),('admin','Login','2019-10-16 09:38:00'),('admin','Visited Status Page','2019-10-16 09:38:00'),('admin','Login','2019-10-16 09:45:11'),('admin','Visited Status Page','2019-10-16 09:45:11'),('admin','Login','2019-10-16 09:52:01'),('admin','Visited Status Page','2019-10-16 09:52:01'),('admin','Login','2019-10-16 09:52:58'),('admin','Visited Status Page','2019-10-16 09:52:58'),('admin','Login','2019-10-16 09:56:30'),('admin','Visited Status Page','2019-10-16 09:56:30'),('admin','Login','2019-10-16 09:59:04'),('admin','Visited Status Page','2019-10-16 09:59:04'),('admin','Login','2019-10-16 10:00:07'),('admin','Visited Status Page','2019-10-16 10:00:07'),('admin','Login','2019-10-16 10:01:26'),('admin','Visited Status Page','2019-10-16 10:01:26'),('admin','Login','2019-10-16 10:03:52'),('admin','Visited Status Page','2019-10-16 10:03:52'),('admin','Login','2019-10-16 10:05:50'),('admin','Visited Status Page','2019-10-16 10:05:50'),('admin','Login','2019-10-16 10:32:41'),('admin','Visited Status Page','2019-10-16 10:32:41'),('admin','Login','2019-10-16 10:33:27'),('admin','Visited Status Page','2019-10-16 10:33:27'),('admin','Edited Schedule','2019-10-16 10:34:50'),('admin','Login','2019-10-16 10:37:26'),('admin','Visited Status Page','2019-10-16 10:37:26'),('admin','Edited Schedule','2019-10-16 10:38:54'),('admin','Edited Schedule','2019-10-16 10:39:07'),('admin','Edited Schedule','2019-10-16 10:39:59'),('admin','Login','2019-10-16 10:42:07'),('admin','Visited Status Page','2019-10-16 10:42:07'),('admin','Edited Schedule','2019-10-16 10:42:29'),('admin','Login','2019-10-16 10:44:27'),('admin','Visited Status Page','2019-10-16 10:44:27'),('admin','Edited Schedule','2019-10-16 10:45:00'),('admin','Login','2019-10-16 10:47:31'),('admin','Visited Status Page','2019-10-16 10:47:31'),('admin','Edited Schedule','2019-10-16 10:48:04'),('admin','Login','2019-10-16 10:49:13'),('admin','Visited Status Page','2019-10-16 10:49:13'),('admin','Edited Schedule','2019-10-16 10:49:38'),('admin','Edited Schedule','2019-10-16 10:50:33'),('admin','Login','2019-10-16 11:00:48'),('admin','Visited Status Page','2019-10-16 11:00:48'),('admin','Edited Schedule','2019-10-16 11:01:08'),('admin','Login','2019-10-16 11:03:09'),('admin','Visited Status Page','2019-10-16 11:03:09'),('admin','Edited Schedule','2019-10-16 11:03:35'),('admin','Edited Schedule','2019-10-16 11:09:37'),('admin','Edited Schedule','2019-10-16 11:09:59'),('admin','Login','2019-10-16 11:13:41'),('admin','Visited Status Page','2019-10-16 11:13:41'),('admin','Login','2019-10-16 11:16:02'),('admin','Visited Status Page','2019-10-16 11:16:02'),('admin','Visited Configuration Settings Page','2019-10-16 11:19:48'),('admin','Login','2019-10-16 11:21:36'),('admin','Visited Status Page','2019-10-16 11:21:36'),('admin','Visited Configuration Settings Page','2019-10-16 11:21:44'),('admin','Login','2019-10-16 11:26:33'),('admin','Visited Status Page','2019-10-16 11:26:33'),('admin','Login','2019-10-16 13:38:43'),('admin','Visited Status Page','2019-10-16 13:38:43'),('admin','Login','2019-10-16 13:41:12'),('admin','Visited Status Page','2019-10-16 13:41:12'),('admin','Login','2019-10-16 14:30:17'),('admin','Visited Status Page','2019-10-16 14:30:17'),('admin','Updated Institute, Grade or Class Details','2019-10-16 14:30:43'),('admin','Updated Institute, Grade or Class Details','2019-10-16 14:30:56'),('admin','Updated Institute, Grade or Class Details','2019-10-16 14:31:03'),('admin','Updated Institute, Grade or Class Details','2019-10-16 14:31:09'),('admin','Login','2019-10-16 14:50:01'),('admin','Visited Status Page','2019-10-16 14:50:02'),('admin','Visited Status Page','2019-10-16 14:51:59'),('admin','Visited Status Page','2019-10-16 14:52:13'),('admin','Visited Machine Control Page','2019-10-16 14:52:59'),('admin','Visited Machine Control Page','2019-10-16 14:53:11'),('admin','Visited Machine Control Page','2019-10-16 15:02:53'),('admin','Visited Status Page','2019-10-16 15:03:46'),('admin','Login','2019-10-16 15:07:11'),('admin','Visited Status Page','2019-10-16 15:07:11'),('admin','Visited Machine Control Page','2019-10-16 15:07:32'),('admin','Visited Status Page','2019-10-16 15:09:16'),('admin','Visited Machine Control Page','2019-10-16 15:09:31'),('admin','Visited Status Page','2019-10-16 15:09:57'),('admin','Visited Machine Control Page','2019-10-16 15:28:02'),('admin','Visited Status Page','2019-10-16 15:34:39'),('admin','Visited Machine Control Page','2019-10-16 15:34:56'),('admin','Visited Machine Control Page','2019-10-16 15:42:20'),('admin','Visited Machine Control Page','2019-10-16 15:42:51'),('admin','Visited Machine Control Page','2019-10-16 15:43:08'),('admin','Visited Status Page','2019-10-16 15:44:45'),('admin','Visited Status Page','2019-10-16 15:45:06'),('admin','Visited Machine Control Page','2019-10-16 15:45:27'),('admin','Login','2019-10-16 17:43:56'),('admin','Visited Status Page','2019-10-16 17:43:56'),('admin','Login','2019-10-16 17:56:19'),('admin','Visited Status Page','2019-10-16 17:56:19'),('admin','Logout','2019-10-16 17:56:25'),('admin','Login','2019-10-17 13:49:54'),('admin','Visited Status Page','2019-10-17 13:49:54'),('admin','Login','2019-10-17 13:53:50'),('admin','Visited Status Page','2019-10-17 13:53:50'),('admin','Login','2019-10-17 13:55:07'),('admin','Visited Status Page','2019-10-17 13:55:07'),('admin','Login','2019-10-17 13:56:42'),('admin','Visited Status Page','2019-10-17 13:56:42'),('admin','Login','2019-10-17 13:57:34'),('admin','Visited Status Page','2019-10-17 13:57:34'),('admin','Login','2019-10-17 18:03:53'),('admin','Visited Status Page','2019-10-17 18:03:53'),('admin','Login','2019-10-18 08:47:23'),('admin','Visited Status Page','2019-10-18 08:47:23'),('admin','Login','2019-10-18 09:05:39'),('admin','Visited Status Page','2019-10-18 09:05:39'),('admin','Login','2019-10-18 09:18:42'),('admin','Visited Status Page','2019-10-18 09:18:42'),('admin','Login','2019-10-18 10:05:20'),('admin','Visited Status Page','2019-10-18 10:05:20'),('admin','Login','2019-10-18 10:18:40'),('admin','Visited Status Page','2019-10-18 10:18:40'),('admin','Login','2019-10-18 11:33:10'),('admin','Visited Status Page','2019-10-18 11:33:10'),('admin','Login','2019-10-18 11:49:11'),('admin','Visited Status Page','2019-10-18 11:49:11'),('admin','Login','2019-10-18 15:50:04'),('admin','Visited Status Page','2019-10-18 15:50:04'),('admin','Login','2019-10-18 15:58:03'),('admin','Visited Status Page','2019-10-18 15:58:03'),('admin','Visited Status Page','2019-10-18 15:58:34'),('admin','Visited Status Page','2019-10-18 15:59:18'),('admin','Login','2019-10-21 09:37:45'),('admin','Visited Status Page','2019-10-21 09:37:45'),('admin','Visited Status Page','2019-10-21 09:38:47'),('admin','Login','2019-10-21 10:10:36'),('admin','Visited Status Page','2019-10-21 10:10:36'),('admin','Login','2019-10-21 10:11:55'),('admin','Visited Status Page','2019-10-21 10:11:55'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:13:19'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:13:20'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:13:28'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:13:29'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:13:41'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:13:42'),('admin','Visited Status Page','2019-10-21 10:13:54'),('admin','Login','2019-10-21 10:16:11'),('admin','Visited Status Page','2019-10-21 10:16:11'),('admin','Login','2019-10-21 10:30:35'),('admin','Visited Status Page','2019-10-21 10:30:35'),('admin','Visited Status Page','2019-10-21 10:31:26'),('admin','Visited Status Page','2019-10-21 10:31:36'),('admin','Visited Status Page','2019-10-21 10:32:03'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:33:37'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:33:38'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:35:02'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:35:03'),('admin','Login','2019-10-21 10:36:22'),('admin','Visited Status Page','2019-10-21 10:36:22'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:36:41'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:36:49'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:36:50'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:38:42'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:38:44'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:38:49'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:00'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:08'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:10'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:12'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:13'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:16'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:17'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:20'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:21'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:24'),('admin','Updated Institute, Grade or Class Details','2019-10-21 10:39:25'),('admin','Login','2019-10-21 11:50:16'),('admin','Visited Status Page','2019-10-21 11:50:16'),('admin','Login','2019-10-21 13:30:16'),('admin','Visited Status Page','2019-10-21 13:30:17'),('admin','Login','2019-10-22 09:20:47'),('admin','Visited Status Page','2019-10-22 09:20:47'),('admin','Login','2019-10-22 10:25:14'),('admin','Visited Status Page','2019-10-22 10:25:14'),('admin','Login','2019-10-22 11:15:41'),('admin','Visited Status Page','2019-10-22 11:15:41'),('admin','Login','2019-10-22 11:22:10'),('admin','Visited Status Page','2019-10-22 11:22:11'),('admin','Login','2019-10-23 14:56:18'),('admin','Visited Status Page','2019-10-23 14:56:19'),('admin','Login','2019-10-23 15:21:35'),('admin','Visited Status Page','2019-10-23 15:21:35'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:21:48'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:21:53'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:22:19'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:22:25'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:23:00'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:23:03'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:24:22'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:24:25'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:26:06'),('admin','Updated Institute, Grade or Class Details','2019-10-23 15:26:18'),('admin','Login','2019-10-23 15:54:17'),('admin','Visited Status Page','2019-10-23 15:54:17'),('admin','Logout','2019-10-23 15:54:21'),('admin','Login','2019-10-23 15:54:26'),('admin','Visited Status Page','2019-10-23 15:54:26'),('admin','Logout','2019-10-23 16:13:58'),('admin','Login','2019-10-23 16:14:04'),('admin','Visited Status Page','2019-10-23 16:14:05'),('admin','Visited Status Page','2019-10-23 16:15:29'),('admin','Visited Status Page','2019-10-23 16:27:26'),('admin','Visited Status Page','2019-10-23 16:35:15'),('admin','Visited Machine Control Page','2019-10-23 16:37:40'),('admin','Visited Machine Control Page','2019-10-23 16:38:35'),('admin','Visited Machine Control Page','2019-10-23 16:38:39'),('admin','Visited Machine Control Page','2019-10-23 16:38:42'),('admin','Login','2019-10-24 09:13:15'),('admin','Visited Status Page','2019-10-24 09:13:15'),('admin','Visited Status Page','2019-10-24 09:13:25'),('admin','Login','2019-10-24 09:47:51'),('admin','Visited Status Page','2019-10-24 09:47:51'),('admin','Visited Status Page','2019-10-24 09:50:20'),('admin','Visited Machine Control Page','2019-10-24 09:50:30'),('admin','Visited Status Page','2019-10-24 09:50:36'),('admin','Visited Status Page','2019-10-24 09:51:42'),('admin','Visited Status Page','2019-10-24 09:53:54'),('admin','Visited Machine Control Page','2019-10-24 09:55:06'),('admin','Visited Machine Control Page','2019-10-24 10:02:55'),('admin','Visited Machine Control Page','2019-10-24 10:04:21'),('admin','Visited Machine Control Page','2019-10-24 10:04:27'),('admin','Visited Machine Control Page','2019-10-24 10:04:32'),('admin','Visited Machine Control Page','2019-10-24 10:05:44'),('admin','Visited Machine Control Page','2019-10-24 10:05:54'),('admin','Visited Machine Control Page','2019-10-24 10:11:56'),('admin','Visited Status Page','2019-10-24 10:15:01'),('admin','Visited Machine Control Page','2019-10-24 10:15:07'),('admin','Visited Status Page','2019-10-24 10:17:05'),('admin','Visited Machine Control Page','2019-10-24 10:17:07'),('admin','Updated Institute, Grade or Class Details','2019-10-24 10:31:50'),('admin','Visited Machine Control Page','2019-10-24 10:31:50'),('admin','Visited Status Page','2019-10-24 10:31:54'),('admin','Visited Machine Control Page','2019-10-24 10:33:03'),('admin','Visited Machine Control Page','2019-10-24 10:33:13'),('admin','Visited Machine Control Page','2019-10-24 10:33:51'),('admin','Visited Machine Control Page','2019-10-24 10:34:16'),('admin','Visited Machine Control Page','2019-10-24 10:34:50'),('admin','Visited Status Page','2019-10-24 10:35:29'),('admin','Visited Machine Control Page','2019-10-24 10:36:09'),('admin','Visited Status Page','2019-10-24 10:36:12'),('admin','Login','2019-10-24 10:37:04'),('admin','Visited Status Page','2019-10-24 10:37:04'),('admin','Visited Machine Control Page','2019-10-24 10:37:08'),('admin','Visited Status Page','2019-10-24 10:37:13'),('admin','Visited Machine Control Page','2019-10-24 10:37:45'),('admin','Updated Institute, Grade or Class Details','2019-10-24 10:39:38'),('admin','Updated Institute, Grade or Class Details','2019-10-24 10:39:39'),('admin','Updated Institute, Grade or Class Details','2019-10-24 10:39:41'),('admin','Login','2019-10-24 10:41:58'),('admin','Visited Status Page','2019-10-24 10:41:58'),('admin','Login','2019-10-24 14:31:24'),('admin','Visited Status Page','2019-10-24 14:31:24'),('admin','Edited Schedule','2019-10-24 14:32:31'),('admin','Edited Schedule','2019-10-24 14:32:49'),('admin','Edited Schedule','2019-10-24 14:32:53'),('admin','Edited Schedule','2019-10-24 14:32:57'),('admin','Edited Schedule','2019-10-24 14:33:00'),('admin','Edited Schedule','2019-10-24 14:34:12'),('admin','Login','2019-10-24 15:00:00'),('admin','Visited Status Page','2019-10-24 15:00:00'),('admin','Edited Schedule','2019-10-24 15:01:02'),('admin','Edited Schedule','2019-10-24 15:07:52'),('admin','Edited Schedule','2019-10-24 15:09:23'),('admin','Visited Status Page','2019-10-24 15:59:25'),('admin','Login','2019-10-25 11:13:26'),('admin','Visited Status Page','2019-10-25 11:13:26'),('admin','Login','2019-10-25 11:14:20'),('admin','Visited Status Page','2019-10-25 11:14:20'),('admin','Login','2019-10-25 11:15:29'),('admin','Login','2019-10-25 11:50:28'),('admin','Login','2019-10-25 14:33:40'),('admin','Login','2019-10-25 14:37:18'),('admin','Login','2019-10-25 14:40:08'),('admin','Updated Institute, Grade or Class Details','2019-10-25 14:42:54'),('admin','Updated Institute, Grade or Class Details','2019-10-25 14:45:59'),('admin','Updated Institute, Grade or Class Details','2019-10-25 14:46:00'),('admin','Updated Institute, Grade or Class Details','2019-10-25 14:46:20'),('admin','Updated Institute, Grade or Class Details','2019-10-25 14:47:12'),('admin','Updated Institute, Grade or Class Details','2019-10-25 14:47:15'),('admin','Updated Institute, Grade or Class Details','2019-10-25 14:47:17'),('admin','Updated Institute, Grade or Class Details','2019-10-25 14:47:18'),('admin','Updated Institute, Grade or Class Details','2019-10-25 14:47:26'),('admin','Login','2019-10-25 15:58:40'),('admin','Updated Institute, Grade or Class Details','2019-10-25 15:58:52'),('admin','Updated Institute, Grade or Class Details','2019-10-25 15:58:53'),('admin','Login','2019-10-25 15:59:04'),('admin','Updated Institute, Grade or Class Details','2019-10-25 15:59:26'),('admin','Updated Institute, Grade or Class Details','2019-10-25 15:59:43'),('admin','Login','2019-10-25 16:18:23'),('admin','Updated Institute, Grade or Class Details','2019-10-25 16:18:30'),('admin','Updated Institute, Grade or Class Details','2019-10-25 16:18:31'),('admin','Updated Institute, Grade or Class Details','2019-10-25 16:18:32'),('admin','Updated Institute, Grade or Class Details','2019-10-25 16:18:33'),('admin','Updated Institute, Grade or Class Details','2019-10-25 16:18:42'),('admin','Login','2019-10-28 10:13:14'),('admin','Login','2019-10-28 11:03:14'),('admin','Edited Schedule','2019-10-28 11:06:10'),('admin','Edited Schedule','2019-10-28 11:06:27'),('admin','Edited Schedule','2019-10-28 11:10:08'),('admin','Edited Schedule','2019-10-28 11:15:49'),('admin','Edited Schedule','2019-10-28 11:26:46'),('admin','Edited Schedule','2019-10-28 11:26:55'),('admin','Edited Schedule','2019-10-28 11:26:57'),('admin','Edited Schedule','2019-10-28 11:26:57'),('admin','Edited Schedule','2019-10-28 11:26:57'),('admin','Edited Schedule','2019-10-28 11:27:01'),('admin','Edited Schedule','2019-10-28 11:27:13'),('admin','Edited Schedule','2019-10-28 11:30:30'),('admin','Edited Schedule','2019-10-28 11:30:32'),('admin','Edited Schedule','2019-10-28 11:30:49'),('admin','Edited Schedule','2019-10-28 11:30:54'),('admin','Login','2019-10-28 14:05:12'),('admin','Visited Status Page','2019-10-28 14:06:10'),('admin','Visited Machine Control Page','2019-10-28 14:09:08'),('admin','Login','2019-10-28 14:42:31'),('admin','Edited Schedule','2019-10-28 14:42:49'),('admin','Edited Schedule','2019-10-28 14:43:41'),('admin','Edited Schedule','2019-10-28 14:45:55'),('admin','Edited Schedule','2019-10-28 14:46:09'),('admin','Login','2019-10-28 14:50:25'),('admin','Edited Schedule','2019-10-28 14:50:41'),('admin','Login','2019-10-28 14:54:49'),('admin','Edited Schedule','2019-10-28 14:58:52'),('admin','Edited Schedule','2019-10-28 14:59:06'),('admin','Login','2019-10-28 15:02:41'),('admin','Edited Schedule','2019-10-28 15:03:16'),('admin','Login','2019-10-28 15:05:40'),('admin','Login','2019-10-28 15:16:46'),('admin','Edited Schedule','2019-10-28 15:17:04'),('admin','Login','2019-10-28 15:17:56'),('admin','Edited Schedule','2019-10-28 15:18:25'),('admin','Edited Schedule','2019-10-28 15:19:13'),('admin','Edited Schedule','2019-10-28 15:19:23'),('admin','Edited Schedule','2019-10-28 15:19:25'),('admin','Edited Schedule','2019-10-28 15:19:42'),('admin','Edited Schedule','2019-10-28 15:19:46'),('admin','Visited Status Page','2019-10-28 15:19:52'),('admin','Login','2019-10-28 15:25:58'),('admin','Visited Status Page','2019-10-28 15:26:36'),('admin','Edited Schedule','2019-10-28 15:27:11'),('admin','Visited Status Page','2019-10-28 15:27:14'),('admin','Visited Status Page','2019-10-28 15:29:24'),('admin','Visited Status Page','2019-10-28 15:30:36'),('admin','Edited Schedule','2019-10-28 15:30:54'),('admin','Visited Status Page','2019-10-28 15:30:59'),('admin','Login','2019-10-28 15:32:51'),('admin','Login','2019-10-28 15:38:27'),('admin','Edited Schedule','2019-10-28 15:38:51'),('admin','Edited Schedule','2019-10-28 15:38:59'),('admin','Visited Status Page','2019-10-28 15:39:02'),('admin','Edited Schedule','2019-10-28 15:39:26'),('admin','Visited Status Page','2019-10-28 15:39:29'),('admin','Edited Schedule','2019-10-28 15:54:26'),('admin','Edited Schedule','2019-10-28 15:55:10'),('admin','Edited Schedule','2019-10-28 15:55:22'),('admin','Edited Schedule','2019-10-28 15:55:33'),('admin','Login','2019-10-28 15:59:34'),('admin','Edited Schedule','2019-10-28 16:01:38'),('admin','Visited Status Page','2019-10-28 16:01:49'),('admin','Edited Schedule','2019-10-28 16:02:53'),('admin','Login','2019-10-28 16:07:25'),('admin','Edited Schedule','2019-10-28 16:08:01'),('admin','Login','2019-10-28 16:10:56'),('admin','Edited Schedule','2019-10-28 16:11:08'),('admin','Login','2019-10-28 16:16:32'),('admin','Edited Schedule','2019-10-28 16:16:48'),('admin','Edited Schedule','2019-10-28 16:17:07'),('admin','Edited Schedule','2019-10-28 16:17:18'),('admin','Edited Schedule','2019-10-28 16:17:33'),('admin','Visited Status Page','2019-10-28 16:17:48'),('admin','Edited Schedule','2019-10-28 16:18:28'),('admin','Visited Status Page','2019-10-28 16:18:31'),('admin','Visited Status Page','2019-10-28 16:18:41'),('admin','Visited Status Page','2019-10-28 16:18:50'),('admin','Edited Schedule','2019-10-28 16:19:45'),('admin','Visited Status Page','2019-10-28 16:19:47'),('admin','Visited Status Page','2019-10-28 16:19:56'),('admin','Visited Status Page','2019-10-28 16:20:16'),('admin','Visited Status Page','2019-10-28 16:21:35'),('admin','Visited Status Page','2019-10-28 16:22:36'),('admin','Login','2019-10-28 16:24:13'),('admin','Visited Status Page','2019-10-28 16:25:26'),('admin','Visited Status Page','2019-10-28 16:25:32'),('admin','Visited Status Page','2019-10-28 16:28:08'),('admin','Login','2019-10-28 16:37:09'),('admin','Login','2019-10-28 16:48:56'),('admin','Visited Status Page','2019-10-28 16:49:18'),('admin','Login','2019-10-28 17:03:06'),('admin','Visited Status Page','2019-10-28 17:05:54'),('admin','Visited Status Page','2019-10-28 17:08:45'),('admin','Login','2019-10-29 08:41:14'),('admin','Edited Schedule','2019-10-29 08:41:56'),('admin','Edited Schedule','2019-10-29 08:42:00'),('admin','Login','2019-10-29 10:11:29'),('admin','Visited Status Page','2019-10-29 10:12:53'),('admin','Visited Machine Control Page','2019-10-29 10:15:05'),('admin','Visited Machine Control Page','2019-10-29 10:15:43'),('admin','Visited Machine Control Page','2019-10-29 10:15:48'),('admin','Visited Status Page','2019-10-29 10:26:57'),('admin','Visited Status Page','2019-10-29 10:29:04'),('admin','Visited Status Page','2019-10-29 10:29:22'),('admin','Visited Status Page','2019-10-29 10:29:23'),('admin','Visited Status Page','2019-10-29 10:29:24'),('admin','Visited Status Page','2019-10-29 10:29:32'),('admin','Visited Status Page','2019-10-29 10:29:34'),('admin','Visited Status Page','2019-10-29 10:29:34'),('admin','Visited Status Page','2019-10-29 10:29:34'),('admin','Visited Status Page','2019-10-29 10:29:34'),('admin','Visited Status Page','2019-10-29 10:29:35'),('admin','Visited Status Page','2019-10-29 10:29:35'),('admin','Visited Status Page','2019-10-29 10:29:36'),('admin','Visited Status Page','2019-10-29 10:29:36'),('admin','Visited Status Page','2019-10-29 10:30:51'),('admin','Visited Status Page','2019-10-29 10:31:10'),('admin','Visited Status Page','2019-10-29 10:31:15'),('admin','Visited Status Page','2019-10-29 10:31:15'),('admin','Visited Status Page','2019-10-29 10:31:22'),('admin','Visited Status Page','2019-10-29 10:31:46'),('admin','Visited Status Page','2019-10-29 10:31:53'),('admin','Visited Status Page','2019-10-29 10:33:02'),('admin','Edited Schedule','2019-10-29 10:33:18'),('admin','Visited Status Page','2019-10-29 10:33:37'),('admin','Edited Schedule','2019-10-29 10:34:22'),('admin','Visited Status Page','2019-10-29 10:34:26'),('admin','Login','2019-10-29 11:13:12'),('admin','Visited Machine Control Page','2019-10-29 11:13:41'),('admin','Visited Machine Control Page','2019-10-29 11:17:13'),('admin','Visited Machine Control Page','2019-10-29 11:18:18'),('admin','Visited Status Page','2019-10-29 11:21:44'),('admin','Visited Machine Control Page','2019-10-29 11:22:39'),('admin','Visited Machine Control Page','2019-10-29 11:23:13'),('admin','Visited Machine Control Page','2019-10-29 11:23:29'),('admin','Updated Institute, Grade or Class Details','2019-10-29 11:24:21'),('admin','Updated Institute, Grade or Class Details','2019-10-29 11:24:27'),('admin','Updated Institute, Grade or Class Details','2019-10-29 11:24:40'),('admin','Updated Institute, Grade or Class Details','2019-10-29 11:24:45'),('admin','Updated Institute, Grade or Class Details','2019-10-29 11:25:35'),('admin','Updated Institute, Grade or Class Details','2019-10-29 11:25:45'),('admin','Updated Institute, Grade or Class Details','2019-10-29 11:26:03'),('admin','Updated Institute, Grade or Class Details','2019-10-29 11:26:06'),('admin','Updated Institute, Grade or Class Details','2019-10-29 11:26:07'),('admin','Visited Machine Control Page','2019-10-29 11:26:44'),('admin','Visited Machine Control Page','2019-10-29 11:30:08'),('admin','Login','2019-10-29 13:45:04'),('admin','Visited Machine Control Page','2019-10-29 13:45:37'),('admin','Login','2019-10-29 14:03:55'),('admin','Visited Machine Control Page','2019-10-29 14:04:03'),('admin','Login','2019-10-29 14:20:21'),('admin','Visited Machine Control Page','2019-10-29 14:20:27'),('admin','Login','2019-10-29 14:39:16'),('admin','Login','2019-10-29 14:46:48'),('admin','Visited Status Page','2019-10-29 14:47:05'),('admin','Edited Schedule','2019-10-29 14:47:41'),('admin','Visited Status Page','2019-10-29 14:47:44'),('admin','Login','2019-10-29 14:51:01'),('admin','Login','2019-10-29 14:53:02'),('admin','Login','2019-10-29 14:53:59'),('admin','Updated Institute, Grade or Class Details','2019-10-29 14:59:20'),('admin','Updated Institute, Grade or Class Details','2019-10-29 14:59:31'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:00:25'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:00:40'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:01:01'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:01:09'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:01:24'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:02:54'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:02:58'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:03:00'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:03:02'),('admin','Visited Machine Control Page','2019-10-29 15:03:02'),('admin','Login','2019-10-29 15:05:36'),('admin','Visited Machine Control Page','2019-10-29 15:05:43'),('admin','Visited Machine Control Page','2019-10-29 15:06:00'),('admin','Visited Status Page','2019-10-29 15:06:15'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:06:24'),('admin','Updated Institute, Grade or Class Details','2019-10-29 15:06:25'),('admin','Login','2019-10-29 15:12:56'),('admin','Visited Machine Control Page','2019-10-29 15:13:12'),('admin','Login','2019-10-29 15:16:43'),('admin','Visited Machine Control Page','2019-10-29 15:18:20'),('admin','Login','2019-10-29 15:20:19'),('admin','Visited Machine Control Page','2019-10-29 15:20:51'),('admin','Login','2019-10-29 15:21:21'),('admin','Visited Machine Control Page','2019-10-29 15:21:26'),('admin','Visited Status Page','2019-10-29 15:27:21'),('admin','Visited Status Page','2019-10-29 15:29:09'),('admin','Visited Machine Control Page','2019-10-29 15:29:36'),('admin','Visited Status Page','2019-10-29 15:29:45'),('admin','Edited Schedule','2019-10-29 15:30:02'),('admin','Visited Status Page','2019-10-29 15:30:06'),('admin','Login','2019-10-29 15:41:48'),('admin','Login','2019-10-29 15:46:22'),('admin','Login','2019-10-29 15:49:00'),('admin','Login','2019-10-29 15:54:27'),('admin','Login','2019-10-29 16:22:33'),('admin','Login','2019-10-29 16:25:16'),('admin','Login','2019-10-29 17:09:11'),('admin','Login','2019-10-29 17:27:20'),('admin','Login','2019-10-29 17:56:35'),('admin','Login','2019-10-29 18:02:15'),('admin','Login','2019-10-30 08:55:03'),('admin','Visited Status Page','2019-10-30 09:00:43'),('admin','Visited Machine Control Page','2019-10-30 09:02:31'),('admin','Login','2019-10-30 09:32:25'),('admin','Updated Institute, Grade or Class Details','2019-10-30 10:12:38'),('admin','Updated Institute, Grade or Class Details','2019-10-30 10:13:14'),('admin','Updated Institute, Grade or Class Details','2019-10-30 10:13:17'),('admin','Updated Institute, Grade or Class Details','2019-10-30 10:13:24'),('admin','Updated Institute, Grade or Class Details','2019-10-30 10:13:27'),('admin','Updated Institute, Grade or Class Details','2019-10-30 10:13:39'),('admin','Login','2019-10-30 10:25:02'),('admin','Login','2019-10-30 13:32:22'),('admin','Login','2019-10-30 15:18:32'),('admin','Edited Schedule','2019-10-30 15:18:48'),('admin','Edited Schedule','2019-10-30 15:18:51'),('admin','Edited Schedule','2019-10-30 15:18:56'),('admin','Edited Schedule','2019-10-30 15:21:40'),('admin','Visited Status Page','2019-10-30 15:21:47'),('admin','Edited Schedule','2019-10-30 15:22:11'),('admin','Visited Status Page','2019-10-30 15:22:21'),('admin','Edited Schedule','2019-10-30 15:23:53'),('admin','Edited Schedule','2019-10-30 15:24:48'),('admin','Visited Status Page','2019-10-30 15:25:20'),('admin','Edited Schedule','2019-10-30 15:29:53'),('admin','Edited Schedule','2019-10-30 15:36:20'),('admin','Edited Schedule','2019-10-30 15:39:17'),('admin','Edited Schedule','2019-10-30 15:42:54'),('admin','Edited Schedule','2019-10-30 15:48:49'),('admin','Edited Schedule','2019-10-30 16:02:13'),('admin','Edited Schedule','2019-10-30 16:02:14'),('admin','Edited Schedule','2019-10-30 16:05:04'),('admin','Visited Status Page','2019-10-30 16:06:10'),('admin','Edited Schedule','2019-10-30 16:09:10'),('admin','Visited Status Page','2019-10-30 16:09:36'),('admin','Edited Schedule','2019-10-30 16:16:52'),('admin','Edited Schedule','2019-10-30 16:17:04'),('admin','Visited Status Page','2019-10-30 16:20:46'),('admin','Visited Status Page','2019-10-30 16:22:24'),('admin','Edited Schedule','2019-10-30 16:22:59'),('admin','Visited Status Page','2019-10-30 16:24:03'),('admin','Edited Schedule','2019-10-30 16:28:01'),('admin','Visited Status Page','2019-10-30 16:28:33'),('admin','Edited Schedule','2019-10-30 16:29:14'),('admin','Visited Status Page','2019-10-30 16:29:57'),('admin','Login','2019-10-31 09:44:34'),('admin','Visited Status Page','2019-10-31 09:47:52'),('admin','Edited Schedule','2019-10-31 09:48:32'),('admin','Visited Status Page','2019-10-31 09:51:05'),('admin','Visited Machine Control Page','2019-10-31 09:51:23'),('admin','Visited Status Page','2019-10-31 09:51:29'),('admin','Visited Machine Control Page','2019-10-31 09:59:14'),('admin','Visited Status Page','2019-10-31 09:59:43'),('admin','Visited Status Page','2019-10-31 10:01:19'),('admin','Login','2019-11-01 09:02:04'),('admin','Visited Status Page','2019-11-01 09:02:13'),('admin','Visited Machine Control Page','2019-11-01 09:02:55'),('admin','Visited Machine Control Page','2019-11-01 09:42:25'),('admin','Visited Machine Control Page','2019-11-01 09:42:33'),('admin','Visited Machine Control Page','2019-11-01 11:10:40'),('admin','Visited Status Page','2019-11-01 11:21:51'),('admin','Visited Machine Control Page','2019-11-01 11:21:54'),('admin','Visited Machine Control Page','2019-11-01 11:21:59'),('admin','Visited Machine Control Page','2019-11-01 11:24:40'),('admin','Visited Machine Control Page','2019-11-01 11:27:00'),('admin','Visited Machine Control Page','2019-11-01 11:37:54'),('admin','Login','2019-11-01 14:01:16'),('admin','Visited Machine Control Page','2019-11-01 14:01:19'),('admin','Visited Status Page','2019-11-01 15:14:39'),('admin','Visited Machine Control Page','2019-11-01 15:19:41'),('admin','Visited Machine Control Page','2019-11-01 16:41:15'),('admin','Visited Machine Control Page','2019-11-01 16:41:30'),('admin','Visited Status Page','2019-11-01 16:41:44'),('admin','Visited Machine Control Page','2019-11-01 16:41:50'),('admin','Visited Machine Control Page','2019-11-01 16:47:55'),('admin','Visited Machine Control Page','2019-11-01 16:48:30'),('admin','Visited Machine Control Page','2019-11-01 16:49:18'),('admin','Visited Machine Control Page','2019-11-01 16:49:47'),('admin','Visited Machine Control Page','2019-11-01 16:49:51'),('admin','Visited Machine Control Page','2019-11-01 16:50:55'),('admin','Login','2019-11-01 17:55:09'),('admin','Login','2019-11-01 17:57:51'),('admin','Login','2019-11-01 18:00:15'),('admin','Login','2019-11-04 08:43:53'),('admin','Login','2019-11-04 09:44:39'),('admin','Login','2019-11-04 09:57:41'),('admin','Login','2019-11-04 10:38:41'),('admin','Login','2019-11-04 10:59:00'),('admin','Login','2019-11-04 11:01:31'),('admin','Login','2019-11-04 11:29:55'),('admin','Login','2019-11-04 11:31:13'),('admin','Login','2019-11-04 11:39:19'),('admin','Login','2019-11-04 13:33:31'),('admin','Login','2019-11-04 13:40:04'),('admin','Updated Institute, Grade or Class Details','2019-11-04 13:43:53'),('admin','Updated Institute, Grade or Class Details','2019-11-04 13:44:01'),('admin','Updated Institute, Grade or Class Details','2019-11-04 13:44:59'),('admin','Login','2019-11-04 13:45:52'),('admin','Login','2019-11-04 14:07:53'),('admin','Login','2019-11-04 14:29:12'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:31:41'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:32:24'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:33:16'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:33:18'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:33:19'),('admin','Login','2019-11-04 14:37:52'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:38:09'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:38:11'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:39:00'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:40:39'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:42:19'),('admin','Login','2019-11-04 14:47:34'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:48:14'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:49:15'),('admin','Login','2019-11-04 14:51:19'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:54:33'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:55:21'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:57:52'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:58:08'),('admin','Updated Institute, Grade or Class Details','2019-11-04 14:59:29'),('admin','Login','2019-11-04 15:01:55'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:02:11'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:02:59'),('admin','Login','2019-11-04 15:05:07'),('admin','Login','2019-11-04 15:06:00'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:06:17'),('admin','Login','2019-11-04 15:09:32'),('admin','Login','2019-11-04 15:12:36'),('admin','Login','2019-11-04 15:18:04'),('admin','Login','2019-11-04 15:20:24'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:20:53'),('admin','Logout','2019-11-04 15:21:07'),('admin','Login','2019-11-04 15:26:39'),('admin','Deleted Document','2019-11-04 15:32:13'),('admin','Login','2019-11-04 15:33:04'),('admin','Logout','2019-11-04 15:33:52'),('admin','Login','2019-11-04 15:44:04'),('admin','Performed User related actions','2019-11-04 15:48:58'),('admin','Uploaded document','2019-11-04 15:50:39'),('admin','Played audio video file','2019-11-04 15:50:52'),('admin','Uploaded document','2019-11-04 15:51:03'),('admin','Played audio video file','2019-11-04 15:51:11'),('admin','Downloaded Document','2019-11-04 15:51:33'),('admin','Downloaded Document','2019-11-04 15:51:42'),('admin','Downloaded Document','2019-11-04 15:54:41'),('admin','Downloaded Document','2019-11-04 15:55:17'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:55:39'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:55:41'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:57:30'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:57:31'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:58:14'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:58:15'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:58:46'),('admin','Updated Institute, Grade or Class Details','2019-11-04 15:58:47'),('admin','Login','2019-11-04 15:59:59'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:00:13'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:00:15'),('admin','Login','2019-11-04 16:00:52'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:01:11'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:01:12'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:01:52'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:01:54'),('admin','Login','2019-11-04 16:02:57'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:17'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:18'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:34'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:35'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:39'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:40'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:43'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:44'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:48'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:51'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:54'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:03:58'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:04:01'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:04:05'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:04:10'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:04:15'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:04:23'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:04:54'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:07:44'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:08:02'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:08:37'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:08:42'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:08:50'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:08:57'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:09:00'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:09:05'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:09:16'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:09:23'),('admin','Updated Institute, Grade or Class Details','2019-11-04 16:09:29'),('admin','Logout','2019-11-04 16:10:04'),('admin','Login','2019-11-04 16:13:26'),('admin','Login','2019-11-04 16:19:25'),('admin','Visited Machine Control Page','2019-11-04 16:19:31'),('admin','Visited Machine Control Page','2019-11-04 16:20:06'),('admin','Login','2019-11-05 10:10:08'),('admin','Visited Status Page','2019-11-05 10:10:22'),('admin','Login','2019-11-05 10:12:24'),('admin','Visited Machine Control Page','2019-11-05 10:28:29'),('admin','Visited Status Page','2019-11-05 10:29:00'),('admin','Visited Machine Control Page','2019-11-05 10:29:17'),('admin','Visited Machine Control Page','2019-11-05 10:29:23'),('admin','Visited Machine Control Page','2019-11-05 10:47:01'),('admin','Login','2019-11-05 14:31:02'),('admin','Updated Institute, Grade or Class Details','2019-11-05 14:31:09'),('admin','Updated Institute, Grade or Class Details','2019-11-05 14:31:44'),('admin','Login','2019-11-05 14:32:58'),('admin','Visited Machine Control Page','2019-11-05 14:33:07'),('admin','Visited Machine Control Page','2019-11-05 14:35:02'),('admin','Visited Machine Control Page','2019-11-05 14:35:59'),('admin','Login','2019-11-05 14:52:55'),('admin','Visited Machine Control Page','2019-11-05 14:53:01'),('admin','Visited Machine Control Page','2019-11-05 14:56:53'),('admin','Visited Machine Control Page','2019-11-05 15:02:02'),('admin','Visited Status Page','2019-11-05 15:05:47'),('admin','Visited Machine Control Page','2019-11-05 15:12:06'),('admin','Visited Machine Control Page','2019-11-05 15:20:54'),('admin','Login','2019-11-05 17:11:09'),('admin','Updated Institute, Grade or Class Details','2019-11-05 17:11:16'),('admin','Updated Institute, Grade or Class Details','2019-11-05 17:11:24'),('admin','Login','2019-11-05 18:07:10'),('admin','Visited Machine Control Page','2019-11-05 18:09:12'),('admin','Visited Status Page','2019-11-05 19:15:36'),('admin','Visited Machine Control Page','2019-11-05 19:16:47'),('admin','Visited Machine Control Page','2019-11-05 19:19:40'),('admin','Login','2019-11-05 19:25:57'),('admin','Visited Status Page','2019-11-05 19:26:02'),('admin','Visited Machine Control Page','2019-11-05 19:43:24'),('admin','Visited Machine Control Page','2019-11-05 19:43:46'),('admin','Visited Status Page','2019-11-05 19:44:10'),('admin','Login','2019-11-06 10:12:12'),('admin','Visited Status Page','2019-11-06 10:12:19'),('admin','Visited Status Page','2019-11-06 10:12:38'),('admin','Login','2019-11-06 10:18:24'),('admin','Visited Machine Control Page','2019-11-06 10:28:46'),('admin','Login','2019-11-06 13:43:23'),('admin','Visited Machine Control Page','2019-11-06 13:43:43'),('admin','Visited Machine Control Page','2019-11-06 13:45:32'),('admin','Visited Machine Control Page','2019-11-06 13:55:40'),('admin','Login','2019-11-07 09:13:21'),('admin','Visited Machine Control Page','2019-11-07 09:14:31'),('admin','Visited Machine Control Page','2019-11-07 09:14:38'),('admin','Login','2019-11-07 09:32:24'),('admin','Visited Machine Control Page','2019-11-07 09:32:31'),('admin','Login','2019-11-07 10:24:31'),('admin','Login','2019-11-07 10:27:04'),('admin','Login','2019-11-07 10:32:47'),('admin','Login','2019-11-07 11:43:41'),('admin','Login','2019-11-07 13:27:49'),('admin','Updated Institute, Grade or Class Details','2019-11-07 13:50:28'),('admin','Updated Institute, Grade or Class Details','2019-11-07 13:51:04'),('admin','Updated Institute, Grade or Class Details','2019-11-07 13:52:15'),('admin','Updated Institute, Grade or Class Details','2019-11-07 13:52:38'),('admin','Updated Institute, Grade or Class Details','2019-11-07 13:52:41'),('admin','Updated Institute, Grade or Class Details','2019-11-07 13:55:03'),('admin','Updated Institute, Grade or Class Details','2019-11-07 13:57:13'),('admin','Updated Institute, Grade or Class Details','2019-11-07 13:57:41'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:12:54'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:13:38'),('admin','Login','2019-11-07 14:27:34'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:27:40'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:27:45'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:27:48'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:28:40'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:28:50'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:28:55'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:28:59'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:29:11'),('admin','Visited Status Page','2019-11-07 14:29:14'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:58:45'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:58:51'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:58:53'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:59:34'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:59:36'),('admin','Updated Institute, Grade or Class Details','2019-11-07 14:59:57'),('admin','Visited Status Page','2019-11-07 15:00:00'),('admin','Updated Institute, Grade or Class Details','2019-11-07 15:06:50'),('admin','Updated Institute, Grade or Class Details','2019-11-07 15:06:59'),('admin','Updated Institute, Grade or Class Details','2019-11-07 15:07:17'),('admin','Updated Institute, Grade or Class Details','2019-11-07 15:07:19'),('admin','Updated Institute, Grade or Class Details','2019-11-07 15:07:28'),('admin','Updated Institute, Grade or Class Details','2019-11-07 15:07:30'),('admin','Updated Institute, Grade or Class Details','2019-11-07 15:07:39'),('admin','Updated Institute, Grade or Class Details','2019-11-07 15:07:44'),('admin','Updated Institute, Grade or Class Details','2019-11-07 15:07:56'),('admin','Visited Status Page','2019-11-07 15:08:02'),('admin','Visited Machine Control Page','2019-11-07 15:09:32'),('admin','Visited Status Page','2019-11-07 15:10:09'),('admin','Visited Machine Control Page','2019-11-07 15:10:19'),('admin','Login','2019-11-07 15:13:58'),('admin','Visited Machine Control Page','2019-11-07 15:14:07'),('admin','Visited Status Page','2019-11-07 15:14:25'),('admin','Visited Machine Control Page','2019-11-07 15:15:07'),('admin','Visited Machine Control Page','2019-11-07 15:15:25'),('admin','Visited Machine Control Page','2019-11-07 15:15:56'),('admin','Visited Status Page','2019-11-07 15:16:08'),('admin','Visited Machine Control Page','2019-11-07 15:16:39'),('admin','Visited Machine Control Page','2019-11-07 15:16:50'),('admin','Visited Machine Control Page','2019-11-07 15:16:56'),('admin','Visited Machine Control Page','2019-11-07 15:17:18'),('admin','Visited Machine Control Page','2019-11-07 15:17:29'),('admin','Visited Machine Control Page','2019-11-07 16:27:31'),('admin','Visited Machine Control Page','2019-11-07 16:27:51'),('admin','Visited Machine Control Page','2019-11-07 16:28:53'),('admin','Visited Machine Control Page','2019-11-07 16:29:00'),('admin','Visited Machine Control Page','2019-11-07 16:29:01'),('admin','Visited Status Page','2019-11-07 16:29:07'),('admin','Visited Machine Control Page','2019-11-07 16:29:19'),('admin','Visited Machine Control Page','2019-11-07 16:29:24'),('admin','Visited Machine Control Page','2019-11-07 16:29:28'),('admin','Login','2019-11-07 17:23:43'),('admin','Visited Machine Control Page','2019-11-07 17:23:49'),('admin','Visited Machine Control Page','2019-11-07 17:25:17'),('admin','Visited Machine Control Page','2019-11-07 17:25:21'),('admin','Visited Machine Control Page','2019-11-07 17:25:25'),('admin','Visited Machine Control Page','2019-11-07 17:25:30'),('admin','Visited Machine Control Page','2019-11-07 17:25:35'),('admin','Visited Machine Control Page','2019-11-07 17:25:39'),('admin','Visited Machine Control Page','2019-11-07 17:25:43'),('admin','Visited Machine Control Page','2019-11-07 17:25:47'),('admin','Visited Machine Control Page','2019-11-07 17:25:50'),('admin','Visited Machine Control Page','2019-11-07 17:25:54'),('admin','Visited Machine Control Page','2019-11-07 17:25:58'),('admin','Visited Machine Control Page','2019-11-07 17:26:02'),('admin','Visited Machine Control Page','2019-11-07 17:26:05'),('admin','Visited Machine Control Page','2019-11-07 17:26:08'),('admin','Visited Machine Control Page','2019-11-07 17:26:12'),('admin','Visited Machine Control Page','2019-11-07 17:26:16'),('admin','Visited Machine Control Page','2019-11-07 17:26:19'),('admin','Visited Machine Control Page','2019-11-07 17:26:23'),('admin','Visited Machine Control Page','2019-11-07 17:26:27'),('admin','Visited Status Page','2019-11-07 17:26:32'),('admin','Visited Machine Control Page','2019-11-07 17:26:41'),('admin','Visited Machine Control Page','2019-11-07 17:26:48'),('admin','Visited Machine Control Page','2019-11-07 17:26:53'),('admin','Visited Machine Control Page','2019-11-07 17:26:58'),('admin','Visited Machine Control Page','2019-11-07 17:34:17'),('admin','Login','2019-11-08 08:33:32'),('admin','Visited Machine Control Page','2019-11-08 09:15:00'),('admin','Visited Machine Control Page','2019-11-08 09:15:13'),('admin','Visited Machine Control Page','2019-11-08 09:16:57'),('admin','Login','2019-11-08 10:40:16'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:40:30'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:40:31'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:41:13'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:41:17'),('admin','Login','2019-11-08 10:42:52'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:43:21'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:43:23'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:49:31'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:49:32'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:49:39'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:50:45'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:50:46'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:50:52'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:50:53'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:51:00'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:51:01'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:51:34'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:51:50'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:51:51'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:53:15'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:53:20'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:53:21'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:54:29'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:54:31'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:55:20'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:55:22'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:55:32'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:55:34'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:56:30'),('admin','Updated Institute, Grade or Class Details','2019-11-08 10:56:31'),('admin','Login','2019-11-08 11:01:40'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:02:11'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:02:12'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:02:40'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:02:41'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:03:10'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:03:11'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:05:02'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:05:10'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:05:17'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:05:18'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:08:16'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:08:21'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:08:29'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:08:30'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:09:19'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:09:21'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:09:42'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:09:44'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:10:01'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:10:02'),('admin','Login','2019-11-08 11:11:45'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:12:10'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:12:12'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:12:32'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:12:33'),('admin','Login','2019-11-08 11:16:35'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:21:05'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:21:08'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:21:58'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:21:59'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:22:27'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:22:28'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:22:38'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:22:39'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:28:08'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:28:16'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:28:18'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:28:38'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:28:39'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:33:27'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:33:35'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:33:36'),('admin','Visited Status Page','2019-11-08 11:33:58'),('admin','Login','2019-11-08 11:34:07'),('admin','Visited Status Page','2019-11-08 11:34:11'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:35:00'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:35:01'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:35:42'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:35:43'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:36:01'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:36:02'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:36:42'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:36:43'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:40:00'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:40:10'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:40:10'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:53:35'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:53:42'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:53:43'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:53:58'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:53:59'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:54:05'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:54:06'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:54:13'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:54:14'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:54:56'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:54:57'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:55:11'),('admin','Updated Institute, Grade or Class Details','2019-11-08 11:55:12'),('admin','Login','2019-11-11 11:37:36'),('admin','Visited Machine Control Page','2019-11-11 11:37:53'),('admin','Updated Institute, Grade or Class Details','2019-11-11 11:38:13'),('admin','Updated Institute, Grade or Class Details','2019-11-11 11:38:39'),('admin','Visited Machine Control Page','2019-11-11 11:38:46'),('admin','Visited Machine Control Page','2019-11-11 11:39:03'),('admin','Login','2019-11-11 11:40:12'),('admin','Visited Machine Control Page','2019-11-11 11:40:20'),('admin','Visited Machine Control Page','2019-11-11 11:40:45'),('admin','Login','2019-11-11 11:41:22'),('admin','Visited Machine Control Page','2019-11-11 11:41:28'),('admin','Visited Machine Control Page','2019-11-11 11:41:58'),('admin','Visited Machine Control Page','2019-11-11 11:42:18'),('admin','Updated Institute, Grade or Class Details','2019-11-11 11:42:43'),('admin','Updated Institute, Grade or Class Details','2019-11-11 11:42:48'),('admin','Updated Institute, Grade or Class Details','2019-11-11 11:42:50'),('admin','Updated Institute, Grade or Class Details','2019-11-11 11:42:50'),('admin','Updated Institute, Grade or Class Details','2019-11-11 11:42:51'),('admin','Visited Machine Control Page','2019-11-11 11:42:51'),('admin','Visited Machine Control Page','2019-11-11 11:43:07'),('admin','Login','2019-11-11 11:43:53'),('admin','Visited Machine Control Page','2019-11-11 11:43:57'),('admin','Visited Machine Control Page','2019-11-11 11:48:51'),('admin','Login','2019-11-11 11:50:16'),('admin','Visited Machine Control Page','2019-11-11 11:50:28'),('admin','Visited Machine Control Page','2019-11-11 11:52:57'),('admin','Visited Machine Control Page','2019-11-11 11:53:51'),('admin','Login','2019-11-11 11:55:26'),('admin','Visited Machine Control Page','2019-11-11 11:55:31'),('admin','Visited Machine Control Page','2019-11-11 11:55:59'),('admin','Visited Machine Control Page','2019-11-11 11:57:26'),('admin','Updated Institute, Grade or Class Details','2019-11-11 11:57:54'),('admin','Updated Institute, Grade or Class Details','2019-11-11 11:58:00'),('admin','Visited Machine Control Page','2019-11-11 11:58:03'),('admin','Visited Machine Control Page','2019-11-11 11:58:48'),('admin','Login','2019-11-11 13:38:07'),('admin','Visited Machine Control Page','2019-11-11 13:38:23'),('admin','Login','2019-11-11 16:54:20'),('admin','Login','2019-11-11 17:48:19'),('admin','Visited Machine Control Page','2019-11-11 17:48:59'),('admin','Login','2019-11-11 18:16:45'),('admin','Visited Machine Control Page','2019-11-11 18:16:59'),('admin','Visited Machine Control Page','2019-11-11 18:19:06'),('admin','Login','2019-11-11 18:21:27'),('admin','Visited Machine Control Page','2019-11-11 18:21:35'),('admin','Visited Machine Control Page','2019-11-11 18:25:30'),('admin','Login','2019-11-11 18:26:06'),('admin','Visited Machine Control Page','2019-11-11 18:26:14'),('admin','Visited Machine Control Page','2019-11-11 18:28:00'),('admin','Visited Machine Control Page','2019-11-11 18:36:04'),('admin','Visited Machine Control Page','2019-11-11 18:39:22'),('admin','Visited Machine Control Page','2019-11-11 18:50:10'),('admin','Visited Machine Control Page','2019-11-11 18:55:56'),('admin','Login','2019-11-11 18:59:39'),('admin','Visited Machine Control Page','2019-11-11 18:59:43'),('admin','Visited Machine Control Page','2019-11-11 19:01:19'),('admin','Visited Machine Control Page','2019-11-11 19:04:18'),('admin','Login','2019-11-11 19:04:41'),('admin','Visited Machine Control Page','2019-11-11 19:04:45'),('admin','Visited Machine Control Page','2019-11-11 19:06:07'),('admin','Visited Machine Control Page','2019-11-11 19:06:24'),('admin','Visited Machine Control Page','2019-11-11 19:06:53'),('admin','Login','2019-11-11 19:07:44'),('admin','Visited Machine Control Page','2019-11-11 19:07:48'),('admin','Visited Machine Control Page','2019-11-11 19:08:54'),('admin','Login','2019-11-11 19:19:26'),('admin','Visited Machine Control Page','2019-11-11 19:19:36'),('admin','Visited Machine Control Page','2019-11-11 19:20:46'),('admin','Login','2019-11-12 10:02:33'),('admin','Visited Machine Control Page','2019-11-12 10:02:44'),('admin','Visited Machine Control Page','2019-11-12 10:05:03'),('admin','Visited Machine Control Page','2019-11-12 10:05:40'),('admin','Visited Machine Control Page','2019-11-12 10:06:54'),('admin','Visited Machine Control Page','2019-11-12 10:07:29'),('admin','Visited Machine Control Page','2019-11-12 10:10:19'),('admin','Visited Machine Control Page','2019-11-12 10:11:03'),('admin','Visited Machine Control Page','2019-11-12 10:11:27'),('admin','Visited Machine Control Page','2019-11-12 10:11:52'),('admin','Visited Machine Control Page','2019-11-12 10:12:10'),('admin','Login','2019-11-12 10:12:28'),('admin','Visited Machine Control Page','2019-11-12 10:12:31'),('admin','Login','2019-11-12 10:13:39'),('admin','Visited Machine Control Page','2019-11-12 10:13:43'),('admin','Login','2019-11-12 10:13:56'),('admin','Visited Machine Control Page','2019-11-12 10:14:00'),('admin','Visited Machine Control Page','2019-11-12 10:15:48'),('admin','Visited Machine Control Page','2019-11-12 10:16:05'),('admin','Visited Machine Control Page','2019-11-12 10:16:15'),('admin','Visited Machine Control Page','2019-11-12 10:20:03'),('admin','Visited Machine Control Page','2019-11-12 10:20:52'),('admin','Visited Machine Control Page','2019-11-12 10:21:18'),('admin','Visited Machine Control Page','2019-11-12 10:21:37'),('admin','Visited Machine Control Page','2019-11-12 10:22:07'),('admin','Visited Machine Control Page','2019-11-12 10:22:24'),('admin','Login','2019-11-12 10:22:53'),('admin','Visited Machine Control Page','2019-11-12 10:22:56'),('admin','Visited Configuration Settings Page','2019-11-12 10:23:48'),('admin','Updated Institute, Grade or Class Details','2019-11-12 10:24:52'),('admin','Visited Machine Control Page','2019-11-12 10:26:47'),('admin','Login','2019-11-12 11:04:54'),('admin','Login','2019-11-13 10:00:34'),('admin','Visited Machine Control Page','2019-11-13 10:00:49'),('admin','Visited Machine Control Page','2019-11-13 10:01:38'),('admin','Visited Machine Control Page','2019-11-13 10:05:48'),('admin','Login','2019-11-13 10:06:53'),('admin','Visited Machine Control Page','2019-11-13 10:06:56'),('admin','Login','2019-11-13 10:33:00'),('admin','Visited Machine Control Page','2019-11-13 10:33:16'),('admin','Visited Machine Control Page','2019-11-13 10:34:05'),('admin','Login','2019-11-13 10:35:21'),('admin','Visited Machine Control Page','2019-11-13 10:35:31'),('admin','Visited Machine Control Page','2019-11-13 10:36:23'),('admin','Login','2019-11-13 10:43:05'),('admin','Visited Machine Control Page','2019-11-13 10:43:16'),('admin','Visited Machine Control Page','2019-11-13 10:43:24'),('admin','Login','2019-11-13 10:44:27'),('admin','Visited Machine Control Page','2019-11-13 10:44:31'),('admin','Login','2019-11-13 11:05:01'),('admin','Visited Machine Control Page','2019-11-13 11:05:10'),('admin','Login','2019-11-13 11:06:51'),('admin','Visited Machine Control Page','2019-11-13 11:06:58'),('admin','Visited Machine Control Page','2019-11-13 11:09:42'),('admin','Login','2019-11-13 11:11:35'),('admin','Visited Machine Control Page','2019-11-13 11:11:43'),('admin','Visited Machine Control Page','2019-11-13 11:12:19'),('admin','Login','2019-11-13 11:20:52'),('admin','Visited Machine Control Page','2019-11-13 11:21:02'),('admin','Visited Machine Control Page','2019-11-13 11:21:29'),('admin','Visited Machine Control Page','2019-11-13 11:24:39'),('admin','Visited Machine Control Page','2019-11-13 11:24:48'),('admin','Visited Machine Control Page','2019-11-13 11:25:36'),('admin','Login','2019-11-13 11:28:55'),('admin','Visited Machine Control Page','2019-11-13 11:29:04'),('admin','Login','2019-11-13 11:53:23'),('admin','Visited Machine Control Page','2019-11-13 11:53:31'),('admin','Visited Machine Control Page','2019-11-13 11:53:44'),('admin','Visited Machine Control Page','2019-11-13 11:54:01'),('admin','Visited Machine Control Page','2019-11-13 11:54:21'),('admin','Visited Machine Control Page','2019-11-13 11:54:43'),('admin','Visited Machine Control Page','2019-11-13 11:55:51'),('admin','Login','2019-11-13 11:58:53'),('admin','Visited Machine Control Page','2019-11-13 11:59:32'),('admin','Visited Machine Control Page','2019-11-13 12:00:28'),('admin','Visited Machine Control Page','2019-11-13 12:00:38'),('admin','Login','2019-11-13 12:02:05'),('admin','Visited Machine Control Page','2019-11-13 12:02:12'),('admin','Login','2019-11-13 12:03:38'),('admin','Visited Machine Control Page','2019-11-13 12:03:49'),('admin','Login','2019-11-13 13:34:48'),('admin','Visited Machine Control Page','2019-11-13 13:34:56'),('admin','Login','2019-11-13 13:43:33'),('admin','Visited Machine Control Page','2019-11-13 13:43:42'),('admin','Visited Machine Control Page','2019-11-13 13:45:10'),('admin','Visited Machine Control Page','2019-11-13 13:45:16'),('admin','Visited Machine Control Page','2019-11-13 13:45:38'),('admin','Visited Machine Control Page','2019-11-13 13:45:46'),('admin','Login','2019-11-13 13:47:13'),('admin','Visited Machine Control Page','2019-11-13 13:47:21'),('admin','Visited Machine Control Page','2019-11-13 13:56:35'),('admin','Updated Institute, Grade or Class Details','2019-11-13 13:58:17'),('admin','Updated Institute, Grade or Class Details','2019-11-13 13:58:38'),('admin','Updated Institute, Grade or Class Details','2019-11-13 13:58:42'),('admin','Updated Institute, Grade or Class Details','2019-11-13 13:58:43'),('admin','Updated Institute, Grade or Class Details','2019-11-13 13:58:44'),('admin','Visited Machine Control Page','2019-11-13 13:58:44'),('admin','Visited Machine Control Page','2019-11-13 13:59:29'),('admin','Updated Institute, Grade or Class Details','2019-11-13 14:00:10'),('admin','Updated Institute, Grade or Class Details','2019-11-13 14:00:11'),('admin','Updated Institute, Grade or Class Details','2019-11-13 14:00:25'),('admin','Updated Institute, Grade or Class Details','2019-11-13 14:00:31'),('admin','Updated Institute, Grade or Class Details','2019-11-13 14:00:46'),('admin','Updated Institute, Grade or Class Details','2019-11-13 14:00:56'),('admin','Updated Institute, Grade or Class Details','2019-11-13 14:00:58'),('admin','Updated Institute, Grade or Class Details','2019-11-13 14:00:59'),('admin','Visited Machine Control Page','2019-11-13 14:00:59'),('admin','Visited Machine Control Page','2019-11-13 14:02:03'),('admin','Login','2019-11-13 14:11:41'),('admin','Visited Machine Control Page','2019-11-13 14:12:00'),('admin','Visited Machine Control Page','2019-11-13 14:14:03'),('admin','Visited Machine Control Page','2019-11-13 14:16:13'),('admin','Login','2019-11-13 14:33:59'),('admin','Visited Machine Control Page','2019-11-13 14:34:06'),('admin','Visited Machine Control Page','2019-11-13 14:34:52'),('admin','Visited Machine Control Page','2019-11-13 14:35:37'),('admin','Visited Machine Control Page','2019-11-13 14:40:44'),('admin','Visited Machine Control Page','2019-11-13 15:00:52'),('admin','Visited Machine Control Page','2019-11-13 15:02:43'),('admin','Visited Machine Control Page','2019-11-13 15:04:06'),('admin','Visited Machine Control Page','2019-11-13 15:04:44'),('admin','Visited Machine Control Page','2019-11-13 15:05:25'),('admin','Visited Machine Control Page','2019-11-13 15:06:12'),('admin','Visited Machine Control Page','2019-11-13 15:07:43'),('admin','Visited Machine Control Page','2019-11-13 15:09:13'),('admin','Visited Machine Control Page','2019-11-13 15:16:42'),('admin','Visited Machine Control Page','2019-11-13 15:19:20'),('admin','Visited Machine Control Page','2019-11-13 15:23:39'),('admin','Visited Machine Control Page','2019-11-13 15:24:05'),('admin','Visited Machine Control Page','2019-11-13 15:24:47'),('admin','Visited Machine Control Page','2019-11-13 15:26:05'),('admin','Visited Machine Control Page','2019-11-13 15:27:03'),('admin','Visited Machine Control Page','2019-11-13 15:33:49'),('admin','Visited Machine Control Page','2019-11-13 15:36:56'),('admin','Login','2019-11-13 15:45:08'),('admin','Visited Machine Control Page','2019-11-13 15:45:15'),('admin','Visited Machine Control Page','2019-11-13 15:49:44'),('admin','Visited Machine Control Page','2019-11-13 15:50:02'),('admin','Visited Machine Control Page','2019-11-13 15:52:51'),('admin','Login','2019-11-13 16:02:16'),('admin','Visited Machine Control Page','2019-11-13 16:02:24'),('admin','Visited Machine Control Page','2019-11-13 16:02:45'),('admin','Visited Machine Control Page','2019-11-13 16:03:31'),('admin','Visited Machine Control Page','2019-11-13 16:04:18'),('admin','Login','2019-11-13 16:08:22'),('admin','Visited Machine Control Page','2019-11-13 16:08:28'),('admin','Visited Machine Control Page','2019-11-13 16:09:10'),('admin','Login','2019-11-13 16:10:15'),('admin','Visited Machine Control Page','2019-11-13 16:10:18'),('admin','Visited Machine Control Page','2019-11-13 16:11:43'),('admin','Visited Machine Control Page','2019-11-13 16:12:07'),('admin','Visited Machine Control Page','2019-11-13 16:12:39'),('admin','Visited Machine Control Page','2019-11-13 16:13:53'),('admin','Visited Machine Control Page','2019-11-13 16:16:17'),('admin','Visited Machine Control Page','2019-11-13 16:16:55'),('admin','Login','2019-11-13 16:20:37'),('admin','Visited Machine Control Page','2019-11-13 16:20:44'),('admin','Login','2019-11-13 16:21:39'),('admin','Visited Machine Control Page','2019-11-13 16:21:49'),('admin','Visited Machine Control Page','2019-11-13 16:22:09'),('admin','Login','2019-11-13 16:24:54'),('admin','Visited Machine Control Page','2019-11-13 16:25:03'),('admin','Visited Machine Control Page','2019-11-13 16:25:33'),('admin','Visited Machine Control Page','2019-11-13 16:26:59'),('admin','Visited Machine Control Page','2019-11-13 16:28:26'),('admin','Visited Machine Control Page','2019-11-13 16:29:44'),('admin','Visited Machine Control Page','2019-11-13 16:32:22'),('admin','Visited Machine Control Page','2019-11-13 16:33:12'),('admin','Visited Machine Control Page','2019-11-13 16:33:41'),('admin','Visited Machine Control Page','2019-11-13 16:34:24'),('admin','Visited Machine Control Page','2019-11-13 16:34:58'),('admin','Visited Machine Control Page','2019-11-13 16:35:51'),('admin','Visited Machine Control Page','2019-11-13 16:36:24'),('admin','Visited Machine Control Page','2019-11-13 16:37:15'),('admin','Visited Machine Control Page','2019-11-13 16:38:55'),('admin','Visited Machine Control Page','2019-11-13 16:43:02'),('admin','Visited Machine Control Page','2019-11-13 16:46:33'),('admin','Visited Machine Control Page','2019-11-13 16:46:54'),('admin','Login','2019-11-13 17:06:21'),('admin','Visited Machine Control Page','2019-11-13 17:06:27'),('admin','Visited Machine Control Page','2019-11-13 17:07:35'),('admin','Login','2019-11-13 17:11:44'),('admin','Visited Machine Control Page','2019-11-13 17:11:51'),('admin','Login','2019-11-13 17:13:32'),('admin','Visited Machine Control Page','2019-11-13 17:13:36'),('admin','Visited Machine Control Page','2019-11-13 17:15:48'),('admin','Login','2019-11-13 17:20:49'),('admin','Visited Machine Control Page','2019-11-13 17:20:54'),('admin','Visited Machine Control Page','2019-11-13 17:21:04'),('admin','Login','2019-11-13 17:30:44'),('admin','Visited Machine Control Page','2019-11-13 17:30:51'),('admin','Visited Machine Control Page','2019-11-13 17:31:41'),('admin','Login','2019-11-13 18:09:56'),('admin','Login','2019-11-13 18:13:21'),('admin','Login','2019-11-13 18:21:37'),('admin','Login','2019-11-13 18:31:57'),('admin','Login','2019-11-13 18:50:57'),('admin','Login','2019-11-13 19:05:15'),('admin','Login','2019-11-13 19:09:38'),('admin','Login','2019-11-13 19:54:30'),('admin','Login','2019-11-13 19:57:15'),('admin','Login','2019-11-13 19:58:45'),('admin','Login','2019-11-13 19:59:44'),('admin','Login','2019-11-13 20:01:57'),('admin','Login','2019-11-13 20:02:42'),('admin','Login','2019-11-13 20:17:11'),('admin','Login','2019-11-13 20:44:19'),('admin','Login','2019-11-14 09:04:39'),('admin','Login','2019-11-14 09:23:18'),('admin','Login','2019-11-14 10:32:50'),('admin','Login','2019-11-14 10:52:09'),('admin','Login','2019-11-14 10:55:08'),('admin','Login','2019-11-14 10:55:44'),('admin','Login','2019-11-14 10:58:19'),('admin','Login','2019-11-14 11:09:34'),('admin','Login','2019-11-14 11:16:25'),('admin','Login','2019-11-14 11:18:50'),('admin','Login','2019-11-14 11:19:58'),('admin','Login','2019-11-14 11:22:43'),('admin','Login','2019-11-14 11:26:06'),('admin','Login','2019-11-14 11:44:13'),('admin','Login','2019-11-14 11:47:17'),('admin','Login','2019-11-14 11:49:02'),('admin','Login','2019-11-14 11:51:19'),('admin','Login','2019-11-14 12:00:01'),('admin','Login','2019-11-14 12:02:40'),('admin','Login','2019-11-14 12:04:08'),('admin','Uploaded document','2019-11-14 12:05:03'),('admin','Downloaded Document','2019-11-14 12:05:09'),('admin','Login','2019-11-14 13:02:55'),('admin','Login','2019-11-14 14:34:27'),('admin','Deleted Document','2019-11-14 14:34:36'),('admin','Uploaded document','2019-11-14 14:34:44'),('admin','Deleted Document','2019-11-14 14:34:48'),('admin','Login','2019-11-14 14:35:57'),('admin','Login','2019-11-14 14:41:01'),('admin','Login','2019-11-14 14:41:50'),('admin','Login','2019-11-14 14:44:09'),('admin','Login','2019-11-14 17:49:55'),('admin','Login','2019-11-15 09:59:16'),('admin','Updated Institute, Grade or Class Details','2019-11-15 09:59:31'),('admin','Updated Institute, Grade or Class Details','2019-11-15 09:59:34'),('admin','Updated Institute, Grade or Class Details','2019-11-15 09:59:40'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:01:02'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:01:09'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:01:31'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:03:08'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:04:38'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:05:04'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:05:07'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:05:11'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:05:42'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:05:52'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:05:59'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:06:32'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:07:40'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:07:49'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:08:32'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:08:37'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:08:40'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:08:42'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:08:44'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:08:47'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:08:53'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:27:10'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:27:53'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:27:58'),('admin','Login','2019-11-15 10:33:55'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:34:27'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:36:02'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:36:07'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:36:25'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:36:28'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:55:04'),('admin','Updated Institute, Grade or Class Details','2019-11-15 10:55:05'),('admin','Login','2019-11-15 11:07:33'),('admin','Visited Status Page','2019-11-15 11:07:41'),('admin','Visited Status Page','2019-11-15 11:08:08'),('admin','Login','2019-11-15 11:41:06'),('admin','Login','2019-11-15 11:41:17'),('admin','Login','2019-11-15 13:32:20'),('admin','Login','2019-11-15 14:28:32'),('admin','Login','2019-11-18 08:59:46'),('admin','Login','2019-11-18 09:43:56'),('admin','Login','2019-11-18 10:20:38'),('admin','Login','2019-11-18 10:37:04'),('admin','Login','2019-11-18 13:41:23'),('admin','Login','2019-11-18 14:55:29'),('admin','Login','2019-11-18 15:28:05'),('admin','Login','2019-11-18 16:23:15'),('admin','Login','2019-11-18 16:56:39'),('admin','Login','2019-11-18 16:57:11'),('admin','Login','2019-11-18 17:20:12'),('admin','Updated Institute, Grade or Class Details','2019-11-18 17:25:52'),('admin','Updated Institute, Grade or Class Details','2019-11-18 17:26:19'),('admin','Login','2019-11-18 17:27:11'),('admin','Updated Institute, Grade or Class Details','2019-11-18 17:27:29'),('admin','Visited Status Page','2019-11-18 17:45:08'),('admin','Login','2019-11-19 09:09:33'),('admin','Login','2019-11-19 09:30:51'),('admin','Login','2019-11-19 09:43:26'),('admin','Login','2019-11-19 10:42:20'),('admin','Login','2019-11-19 10:42:43'),('admin','Login','2019-11-19 11:06:01'),('admin','Updated Institute, Grade or Class Details','2019-11-19 11:06:12'),('admin','Updated Institute, Grade or Class Details','2019-11-19 11:06:19'),('admin','Updated Institute, Grade or Class Details','2019-11-19 11:06:24'),('admin','Updated Institute, Grade or Class Details','2019-11-19 11:06:43'),('admin','Updated Institute, Grade or Class Details','2019-11-19 11:06:47'),('admin','Login','2019-11-19 11:53:50'),('admin','Login','2019-11-19 11:57:36'),('admin','Login','2019-11-19 11:58:17'),('admin','Login','2019-11-19 12:03:33'),('admin','Login','2019-11-19 12:03:45'),('admin','Played audio video file','2019-11-19 12:04:07'),('admin','Login','2019-11-19 14:01:45'),('admin','Visited Status Page','2019-11-19 14:02:16'),('admin','Visited Status Page','2019-11-19 14:04:12'),('admin','Visited Status Page','2019-11-19 14:12:40'),('admin','Login','2019-11-19 14:16:06'),('admin','Login','2019-11-19 14:25:12'),('admin','Login','2019-11-19 14:25:57'),('admin','Login','2019-11-19 17:43:57'),('admin','Login','2019-11-20 09:22:09'),('admin','Login','2019-11-20 09:34:37'),('admin','Login','2019-11-20 10:06:26'),('admin','Login','2019-11-20 10:07:48'),('admin','Updated Institute, Grade or Class Details','2019-11-20 10:17:26'),('admin','Updated Institute, Grade or Class Details','2019-11-20 10:17:36'),('admin','Updated Institute, Grade or Class Details','2019-11-20 10:18:13'),('admin','Updated Institute, Grade or Class Details','2019-11-20 10:18:31'),('admin','Updated Institute, Grade or Class Details','2019-11-20 10:22:12'),('admin','Updated Institute, Grade or Class Details','2019-11-20 10:22:13'),('admin','Updated Institute, Grade or Class Details','2019-11-20 10:22:14'),('admin','Login','2019-11-20 10:40:32'),('admin','Visited Status Page','2019-11-20 10:40:35'),('admin','Login','2019-11-20 10:46:43'),('admin','Login','2019-11-20 11:09:27'),('admin','Login','2019-11-20 11:56:04'),('admin','Login','2019-11-20 14:43:32'),('admin','Updated Institute, Grade or Class Details','2019-11-20 14:46:50'),('admin','Updated Institute, Grade or Class Details','2019-11-20 14:47:02'),('admin','Login','2019-11-20 15:45:27'),('admin','Login','2019-11-20 16:37:22'),('admin','Login','2019-11-20 16:37:53'),('admin','Login','2019-11-20 16:58:12'),('admin','Login','2019-11-20 17:02:08'),('admin','Login','2019-11-20 19:22:16'),('admin','Updated Institute, Grade or Class Details','2019-11-20 19:22:32'),('admin','Updated Institute, Grade or Class Details','2019-11-20 19:23:07'),('admin','Login','2019-11-20 19:27:11'),('admin','Updated Institute, Grade or Class Details','2019-11-20 19:27:22'),('admin','Login','2019-11-21 09:14:56'),('admin','Updated Institute, Grade or Class Details','2019-11-21 09:15:22'),('admin','Updated Institute, Grade or Class Details','2019-11-21 09:15:31'),('admin','Updated Institute, Grade or Class Details','2019-11-21 09:17:39'),('admin','Login','2019-11-21 09:35:17'),('admin','Login','2019-11-21 09:40:04'),('admin','Login','2019-11-21 09:41:38'),('admin','Login','2019-11-21 10:11:29'),('admin','Visited Status Page','2019-11-21 10:11:33'),('admin','Login','2019-11-21 10:22:43'),('admin','Login','2019-11-21 10:25:50'),('admin','Login','2019-11-21 10:27:42'),('admin','Login','2019-11-21 10:37:39'),('admin','Login','2019-11-21 10:57:29'),('admin','Updated Institute, Grade or Class Details','2019-11-21 10:57:36'),('admin','Updated Institute, Grade or Class Details','2019-11-21 10:57:40'),('admin','Updated Institute, Grade or Class Details','2019-11-21 10:57:41'),('admin','Updated Institute, Grade or Class Details','2019-11-21 10:57:49'),('admin','Login','2019-11-21 10:58:14'),('admin','Visited Status Page','2019-11-21 10:58:32'),('admin','Updated Institute, Grade or Class Details','2019-11-21 11:56:01'),('admin','Updated Institute, Grade or Class Details','2019-11-21 11:56:26'),('admin','Updated Institute, Grade or Class Details','2019-11-21 11:56:44'),('admin','Updated Institute, Grade or Class Details','2019-11-21 11:57:32'),('admin','Updated Institute, Grade or Class Details','2019-11-21 11:57:33'),('admin','Updated Institute, Grade or Class Details','2019-11-21 11:57:35'),('admin','Login','2019-11-21 13:42:04'),('admin','Visited Status Page','2019-11-21 13:43:12'),('admin','Visited Status Page','2019-11-21 13:43:39'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:14:44'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:14:46'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:14:50'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:15:01'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:15:03'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:15:10'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:15:12'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:15:21'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:15:22'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:16:22'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:16:23'),('admin','Updated Institute, Grade or Class Details','2019-11-21 14:16:24'),('admin','Login','2019-11-21 15:10:54'),('admin','Login','2019-11-21 15:12:20'),('admin','Login','2019-11-21 15:18:54'),('admin','Logout','2019-11-21 15:21:14'),('admin','Login','2019-11-21 15:21:40'),('admin','Visited Status Page','2019-11-21 15:21:48'),('admin','Login','2019-11-21 15:48:13'),('admin','Login','2019-11-21 15:57:39'),('admin','Login','2019-11-21 16:01:43'),('admin','Updated Institute, Grade or Class Details','2019-11-21 16:01:51'),('admin','Login','2019-11-21 16:04:17'),('admin','Login','2019-11-21 16:10:01'),('admin','Login','2019-11-21 16:18:07'),('admin','Login','2019-11-21 16:52:56'),('admin','Updated Institute, Grade or Class Details','2019-11-21 16:53:10'),('admin','Updated Institute, Grade or Class Details','2019-11-21 16:53:21'),('admin','Updated Institute, Grade or Class Details','2019-11-21 16:53:25'),('admin','Updated Institute, Grade or Class Details','2019-11-21 16:53:26'),('admin','Updated Institute, Grade or Class Details','2019-11-21 16:53:27'),('admin','Login','2019-11-21 17:02:50'),('admin','Login','2019-11-21 18:13:32'),('admin','Login','2019-11-22 09:19:29'),('admin','Login','2019-11-22 10:12:42'),('admin','Login','2019-11-22 11:01:15'),('admin','Login','2019-11-22 11:04:26'),('admin','Login','2019-11-22 14:07:15'),('admin','Login','2019-11-22 16:33:40'),('admin','Login','2019-11-22 16:35:02'),('admin','Login','2019-11-22 16:47:50'),('admin','Login','2019-11-22 17:09:21'),('admin','Login','2019-11-22 17:23:29'),('admin','Login','2019-11-22 17:45:52'),('admin','Login','2019-11-22 17:47:05'),('admin','Login','2019-11-22 17:49:46'),('admin','Login','2019-11-25 08:53:12'),('admin','Logout','2019-11-25 09:05:07'),('admin','Login','2019-11-25 09:10:24'),('admin','Login','2019-11-25 11:41:38'),('admin','Login','2019-11-25 11:49:04'),('admin','Visited Status Page','2019-11-25 11:49:38'),('admin','Visited Status Page','2019-11-25 11:50:46'),('admin','Visited Status Page','2019-11-25 11:51:10'),('admin','Visited Status Page','2019-11-25 13:56:01'),('admin','Visited Status Page','2019-11-25 13:57:23'),('admin','Visited Status Page','2019-11-25 13:57:51'),('admin','Visited Status Page','2019-11-25 13:58:05'),('admin','Visited Status Page','2019-11-25 13:59:04'),('admin','Login','2019-11-25 14:03:02'),('admin','Visited Status Page','2019-11-25 14:11:26'),('admin','Visited Status Page','2019-11-25 14:39:35'),('admin','Visited Status Page','2019-11-25 14:43:04'),('admin','Visited Status Page','2019-11-25 14:45:26'),('admin','Visited Status Page','2019-11-25 15:19:15'),('admin','Visited Status Page','2019-11-25 15:20:01'),('admin','Visited Status Page','2019-11-25 15:20:44'),('admin','Visited Status Page','2019-11-25 15:20:57'),('admin','Visited Status Page','2019-11-25 15:26:18'),('admin','Visited Status Page','2019-11-25 15:26:50'),('admin','Visited Status Page','2019-11-25 15:27:29'),('admin','Visited Status Page','2019-11-25 15:39:04'),('admin','Visited Status Page','2019-11-25 15:39:36'),('admin','Visited Status Page','2019-11-25 15:40:12'),('admin','Logout','2019-11-25 15:40:17'),('admin','Visited Status Page','2019-11-25 15:48:18'),('admin','Visited Status Page','2019-11-25 15:51:12'),('admin','Visited Status Page','2019-11-25 15:53:45'),('admin','Visited Status Page','2019-11-25 15:54:07'),('admin','Visited Status Page','2019-11-25 15:54:27'),('admin','Visited Status Page','2019-11-25 16:11:31'),('admin','Visited Status Page','2019-11-25 16:13:05'),('admin','Visited Status Page','2019-11-25 16:13:10'),('admin','Logout','2019-11-25 16:15:06'),('admin','Visited Status Page','2019-11-25 16:15:09'),('admin','Visited Status Page','2019-11-25 16:16:20'),('admin','Visited Status Page','2019-11-25 16:16:25'),('admin','Login','2019-11-25 16:27:01'),('admin','Visited Status Page','2019-11-25 16:29:29'),('admin','Visited Status Page','2019-11-25 16:36:01'),('admin','Logout','2019-11-25 16:36:44'),('admin','Visited Status Page','2019-11-25 16:36:45'),('admin','Visited Status Page','2019-11-25 16:38:07'),('admin','Visited Status Page','2019-11-25 16:38:54'),('admin','Visited Status Page','2019-11-25 16:39:39'),('admin','Visited Status Page','2019-11-25 16:40:39'),('admin','Visited Status Page','2019-11-25 16:49:29'),('admin','Logout','2019-11-25 16:49:36'),('admin','Visited Status Page','2019-11-25 17:06:20'),('admin','Login','2019-11-25 17:06:34'),('admin','Logout','2019-11-25 17:06:47'),('admin','Visited Status Page','2019-11-25 17:07:52'),('admin','Visited Status Page','2019-11-25 17:10:28'),('admin','Visited Status Page','2019-11-25 17:22:28'),('admin','Visited Status Page','2019-11-25 17:23:06'),('admin','Visited Status Page','2019-11-25 17:25:12'),('admin','Visited Status Page','2019-11-25 17:27:45'),('admin','Visited Status Page','2019-11-25 17:28:25'),('admin','Visited Status Page','2019-11-25 17:29:40'),('admin','Visited Status Page','2019-11-25 17:30:49'),('admin','Visited Status Page','2019-11-25 17:30:54'),('admin','Visited Status Page','2019-11-25 17:30:55'),('admin','Visited Status Page','2019-11-25 17:30:57'),('admin','Visited Status Page','2019-11-25 17:30:58'),('admin','Visited Status Page','2019-11-25 17:31:26'),('admin','Visited Status Page','2019-11-25 17:32:15'),('admin','Visited Status Page','2019-11-25 17:32:15'),('admin','Visited Status Page','2019-11-25 17:32:28'),('admin','Visited Status Page','2019-11-25 17:34:03'),('admin','Visited Status Page','2019-11-25 17:34:12'),('admin','Visited Status Page','2019-11-25 17:34:24'),('admin','Logout','2019-11-25 17:35:00'),('admin','Visited Status Page','2019-11-25 17:35:02'),('admin','Visited Status Page','2019-11-25 17:39:53'),('admin','Visited Status Page','2019-11-25 17:48:47'),('admin','Visited Status Page','2019-11-25 17:59:29'),('admin','Visited Status Page','2019-11-25 18:00:25'),('admin','Visited Status Page','2019-11-26 08:59:53'),('admin','Login','2019-11-26 09:04:48'),('admin','Visited Status Page','2019-11-26 09:13:39'),('admin','Visited Status Page','2019-11-26 09:13:40'),('admin','Visited Status Page','2019-11-26 09:13:43'),('admin','Visited Status Page','2019-11-26 09:13:46'),('admin','Visited Status Page','2019-11-26 09:13:53'),('admin','Visited Status Page','2019-11-26 09:14:28'),('admin','Visited Status Page','2019-11-26 09:16:44'),('admin','Visited Status Page','2019-11-26 09:17:28'),('admin','Visited Status Page','2019-11-26 09:17:32'),('admin','Visited Status Page','2019-11-26 09:17:57'),('admin','Visited Status Page','2019-11-26 09:20:41'),('admin','Visited Status Page','2019-11-26 09:21:55'),('admin','Visited Status Page','2019-11-26 09:25:47'),('admin','Visited Status Page','2019-11-26 09:27:22'),('admin','Visited Status Page','2019-11-26 09:29:55'),('admin','Visited Status Page','2019-11-26 09:30:27'),('admin','Visited Status Page','2019-11-26 09:31:27'),('admin','Visited Status Page','2019-11-26 09:32:10'),('admin','Login','2019-11-26 10:15:03'),('admin','Logout','2019-11-26 10:15:12'),('admin','Visited Status Page','2019-11-26 10:15:22'),('admin','Visited Status Page','2019-11-26 10:18:44'),('admin','Login','2019-11-26 11:14:49'),('admin','Visited Status Page','2019-11-26 11:18:21'),('admin','Visited Status Page','2019-11-26 14:36:16'),('admin','Visited Status Page','2019-11-26 14:51:47'),('admin','Visited Status Page','2019-11-26 14:54:16'),('admin','Logout','2019-11-26 14:54:48'),('admin','Visited Status Page','2019-11-26 14:54:51'),('admin','Visited Status Page','2019-11-26 14:58:58'),('admin','Visited Status Page','2019-11-26 14:59:17'),('admin','Visited Status Page','2019-11-26 14:59:20'),('admin','Visited Status Page','2019-11-26 14:59:33'),('admin','Visited Status Page','2019-11-26 15:00:16'),('admin','Visited Status Page','2019-11-26 15:01:30'),('admin','Visited Status Page','2019-11-26 15:02:08'),('admin','Visited Status Page','2019-11-26 15:02:39'),('admin','Visited Status Page','2019-11-26 15:04:14'),('admin','Visited Status Page','2019-11-26 15:04:35'),('admin','Visited Status Page','2019-11-26 15:04:56'),('admin','Visited Status Page','2019-11-26 15:07:44'),('admin','Visited Status Page','2019-11-26 15:09:47'),('admin','Visited Status Page','2019-11-26 16:31:26'),('admin','Visited Status Page','2019-11-26 16:40:54'),('admin','Visited Status Page','2019-11-26 16:58:18'),('admin','Visited Status Page','2019-11-26 16:58:24'),('admin','Visited Status Page','2019-11-26 17:03:42'),('admin','Login','2019-11-26 17:06:06'),('admin','Visited Status Page','2019-11-26 17:06:12'),('admin','Visited Status Page','2019-11-26 17:08:56'),('admin','Logout','2019-11-26 17:09:06'),('admin','Login','2019-11-26 17:11:23'),('admin','Login','2019-11-26 17:29:08'),('admin','Login','2019-11-26 17:31:16'),('admin','Login','2019-11-26 17:38:26'),('admin','Visited Status Page','2019-11-26 17:51:07'),('admin','Login','2019-11-26 18:15:52'),('admin','Login','2019-11-27 09:18:08'),('admin','Visited Status Page','2019-11-27 09:35:45'),('admin','Visited Status Page','2019-11-27 09:36:36'),('admin','Login','2019-11-27 09:44:22'),('admin','Login','2019-11-27 09:46:15'),('admin','Login','2019-11-27 09:55:11'),('admin','Login','2019-11-27 10:05:06'),('admin','Logout','2019-11-27 10:05:11'),('admin21','Login','2019-11-27 10:10:07'),('admin21','Login','2019-11-27 10:12:57'),('admin21','Logout','2019-11-27 10:13:14'),('admin','Login','2019-11-27 10:13:21'),('admin','Logout','2019-11-27 10:13:24'),('admin21','Login','2019-11-27 10:13:29'),('admin21','Login','2019-11-27 10:21:20'),('admin21','Logout','2019-11-27 10:21:26'),('admin21','Login','2019-11-27 10:30:20'),('admin21','Logout','2019-11-27 10:30:46'),('admin','Login','2019-11-27 10:30:51'),('admin','Logout','2019-11-27 10:31:09'),('admin','Login','2019-11-27 10:31:25'),('admin','Logout','2019-11-27 10:31:41'),('admin','Login','2019-11-27 10:33:43'),('admin','Login','2019-11-27 10:55:21'),('admin','Logout','2019-11-27 10:55:45'),('admin','Login','2019-11-27 11:06:37'),('admin','Logout','2019-11-27 11:06:43'),('admin','Login','2019-11-27 11:10:15'),('admin','Login','2019-11-27 11:28:39'),('admin','Login','2019-11-27 14:32:43'),('admin','Login','2019-11-27 14:50:42'),('admin','Logout','2019-11-27 14:55:56'),('admin21','Login','2019-11-27 14:56:00'),('admin21','Login','2019-11-27 15:01:04'),('admin21','Login','2019-11-27 15:04:14'),('admin21','Visited Status Page','2019-11-27 15:04:17'),('admin21','Login','2019-11-27 15:09:53'),('admin21','Login','2019-11-27 15:14:11'),('admin21','Login','2019-11-27 15:21:34'),('admin21','Login','2019-11-27 15:21:44'),('admin21','Login','2019-11-27 15:22:52'),('admin21','Logout','2019-11-27 15:23:41'),('admin','Login','2019-11-27 15:23:45'),('admin','Login','2019-11-27 15:30:54'),('admin','Login','2019-11-27 15:50:03'),('admin','Visited Status Page','2019-11-27 15:50:05'),('admin','Login','2019-11-27 15:52:08'),('admin','Visited Status Page','2019-11-27 15:58:04'),('admin','Login','2019-11-27 15:59:35'),('admin','Login','2019-11-27 15:59:43'),('admin','Visited Status Page','2019-11-27 16:16:52'),('admin','Login','2019-11-27 16:34:10'),('admin','Visited Status Page','2019-11-27 16:34:13'),('admin','Login','2019-11-27 16:54:52'),('admin','Visited Status Page','2019-11-27 16:54:56'),('admin','Login','2019-11-27 17:35:40'),('admin','Login','2019-11-27 17:41:40'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:42:05'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:42:32'),('admin','Login','2019-11-27 17:43:55'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:44:07'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:45:02'),('admin','Login','2019-11-27 17:49:51'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:50:06'),('admin','Login','2019-11-27 17:55:05'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:55:21'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:55:22'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:55:23'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:55:23'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:55:24'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:55:24'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:55:25'),('admin','Login','2019-11-27 17:56:25'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:56:32'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:56:33'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:56:35'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:56:37'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:56:43'),('admin','Login','2019-11-27 17:58:12'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:58:21'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:58:23'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:58:24'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:58:26'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:58:29'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:58:30'),('admin','Updated Institute, Grade or Class Details','2019-11-27 17:58:32'),('admin','Login','2019-11-27 18:46:48'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:47:51'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:47:53'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:47:55'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:47:56'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:47:59'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:48:01'),('admin','Login','2019-11-27 18:51:46'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:51:55'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:51:56'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:51:58'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:51:59'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:52:00'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:52:04'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:52:05'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:52:18'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:52:45'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:53:38'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:53:44'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:53:55'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:54:05'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:54:37'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:54:43'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:55:03'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:55:30'),('admin','Login','2019-11-27 18:58:05'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:58:22'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:58:26'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:58:44'),('admin','Updated Institute, Grade or Class Details','2019-11-27 18:59:00'),('admin','Login','2019-11-27 19:07:16'),('admin','Login','2019-11-27 19:10:05'),('admin','Login','2019-11-27 19:12:27'),('admin','Login','2019-11-27 19:13:51'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:14:18'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:14:32'),('admin','Login','2019-11-27 19:15:48'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:16:02'),('admin','Login','2019-11-27 19:23:21'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:23:39'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:24:04'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:24:08'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:24:12'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:25:00'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:25:37'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:25:54'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:26:33'),('admin','Login','2019-11-27 19:28:14'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:28:24'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:28:41'),('admin','Login','2019-11-27 19:29:36'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:29:47'),('admin','Login','2019-11-27 19:30:45'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:30:56'),('admin','Login','2019-11-27 19:32:08'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:32:20'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:33:33'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:38:07'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:38:23'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:38:40'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:39:36'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:40:03'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:44:52'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:45:24'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:46:01'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:46:04'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:46:08'),('admin','Updated Institute, Grade or Class Details','2019-11-27 19:46:13'),('admin','Login','2019-11-27 19:56:46'),('admin','Login','2019-11-27 20:00:23'),('admin','Login','2019-11-27 20:07:33'),('admin','Login','2019-11-27 20:08:22'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:08:40'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:08:43'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:08:44'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:08:45'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:08:45'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:08:46'),('admin','Login','2019-11-27 20:11:54'),('admin','Visited Status Page','2019-11-27 20:17:00'),('admin','Login','2019-11-27 20:17:45'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:17:53'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:17:58'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:18:02'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:18:20'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:18:22'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:18:25'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:18:56'),('admin','Login','2019-11-27 20:20:05'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:20:15'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:20:48'),('admin','Login','2019-11-27 20:37:46'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:37:59'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:38:04'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:38:29'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:38:55'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:43:59'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:44:04'),('admin','Updated Institute, Grade or Class Details','2019-11-27 20:44:07'),('admin','Login','2019-11-27 20:45:50'),('admin','Visited Status Page','2019-11-27 20:46:28'),('admin','Login','2019-11-27 20:56:13'),('admin','Login','2019-11-27 21:02:12'),('admin','Login','2019-11-27 21:06:11'),('admin','Login','2019-11-28 09:02:08'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:02:20'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:02:26'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:02:36'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:02:38'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:02:45'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:02:50'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:02:51'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:03:34'),('admin','Login','2019-11-28 09:06:00'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:06:20'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:06:27'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:06:29'),('admin','Login','2019-11-28 09:15:25'),('admin','Login','2019-11-28 09:16:51'),('admin','Login','2019-11-28 09:18:11'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:18:30'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:18:35'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:18:47'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:19:16'),('admin','Login','2019-11-28 09:24:02'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:24:32'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:24:39'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:24:40'),('admin','Login','2019-11-28 09:30:44'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:31:07'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:31:18'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:31:29'),('admin','Updated Institute, Grade or Class Details','2019-11-28 09:31:31'),('admin','Login','2019-11-28 12:36:47'),('admin','Login','2019-11-28 13:21:16'),('admin','Updated Institute, Grade or Class Details','2019-11-28 13:49:13'),('admin','Login','2019-11-28 14:15:43'),('admin','Login','2019-11-28 14:59:52'),('admin','Login','2019-11-28 15:03:54'),('admin','Login','2019-11-28 15:05:09'),('admin','Login','2019-11-28 15:05:48'),('admin','Login','2019-11-28 15:09:56'),('admin','Login','2019-11-28 15:11:47'),('admin','Login','2019-11-28 15:11:59'),('admin','Login','2019-11-28 15:13:17'),('admin','Login','2019-11-28 15:17:34'),('admin','Login','2019-11-28 16:45:00'),('admin','Logout','2019-11-28 16:48:45'),('admin','Login','2019-11-28 16:48:47'),('admin','Login','2019-11-28 17:01:52'),('admin','Login','2019-11-29 09:36:04'),('admin','Login','2019-11-29 10:11:43'),('admin','Login','2019-11-29 11:55:01'),('admin','Updated Institute, Grade or Class Details','2019-11-29 11:55:19'),('admin','Login','2019-11-29 13:24:46'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:25:00'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:25:21'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:25:28'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:25:34'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:25:36'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:25:39'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:25:43'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:25:49'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:26:01'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:26:10'),('admin','Login','2019-11-29 13:30:11'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:30:27'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:30:34'),('admin','Login','2019-11-29 13:31:54'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:32:06'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:32:13'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:32:18'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:32:22'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:32:39'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:33:09'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:33:15'),('admin','Login','2019-11-29 13:34:37'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:34:50'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:34:53'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:34:59'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:35:07'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:35:15'),('admin','Login','2019-11-29 13:36:45'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:37:02'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:37:09'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:37:17'),('admin','Login','2019-11-29 13:38:57'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:39:11'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:39:17'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:40:13'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:40:22'),('admin','Login','2019-11-29 13:41:59'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:42:09'),('admin','Updated Institute, Grade or Class Details','2019-11-29 13:42:15'),('admin','Login','2019-11-29 14:26:53'),('admin','Logout','2019-11-29 14:27:10'),('admin','Login','2019-11-29 14:56:02'),('admin','Login','2019-11-29 15:14:00'),('admin','Login','2019-11-29 15:18:22'),('admin','Logout','2019-11-29 15:18:31'),('admin','Login','2019-11-29 16:49:09'),('admin','Updated Institute, Grade or Class Details','2019-11-29 16:59:55'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:00:07'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:00:28'),('admin','Login','2019-11-29 17:31:50'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:32:00'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:32:07'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:32:10'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:32:19'),('admin','Login','2019-11-29 17:33:48'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:34:05'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:34:11'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:34:22'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:34:27'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:36:25'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:36:28'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:36:33'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:36:41'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:36:47'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:36:56'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:37:26'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:40:37'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:40:41'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:40:52'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:40:56'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:19'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:23'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:37'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:40'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:46'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:47'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:49'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:50'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:57'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:41:58'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:42:46'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:42:48'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:43:39'),('admin','Login','2019-11-29 17:46:50'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:47:08'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:47:15'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:48:35'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:48:41'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:48:57'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:48:59'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:58:56'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:58:58'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:07'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:09'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:18'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:19'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:24'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:28'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:36'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:40'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:49'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:52'),('admin','Updated Institute, Grade or Class Details','2019-11-29 17:59:53'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:00:21'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:00:23'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:00:31'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:00:33'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:02:03'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:02:12'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:02:15'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:02:42'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:05:02'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:05:08'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:05:09'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:05:10'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:08:41'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:08:53'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:09:18'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:09:20'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:09:21'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:19:06'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:19:07'),('admin','Updated Institute, Grade or Class Details','2019-11-29 18:19:08'),('admin','Login','2019-11-29 19:34:14'),('admin','Login','2019-11-29 20:11:12'),('admin','Login','2019-11-29 20:27:59'),('admin','Visited Status Page','2019-11-29 20:28:07'),('admin','Visited Status Page','2019-11-29 20:29:17'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:38:37'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:39:04'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:39:12'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:39:23'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:39:30'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:39:38'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:39:40'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:39:46'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:39:57'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:40:07'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:40:08'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:40:45'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:40:46'),('admin','Login','2019-11-29 20:42:19'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:42:40'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:42:41'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:42:57'),('admin','Updated Institute, Grade or Class Details','2019-11-29 20:43:04'),('admin','Login','2019-11-29 21:04:00'),('admin','Login','2019-11-30 14:21:41'),('admin','Logout','2019-11-30 14:21:50'),('admin','Login','2019-11-30 15:54:20'),('admin','Login','2019-11-30 16:03:55'),('admin','Login','2019-11-30 17:02:45'),('admin','Login','2019-11-30 17:10:30'),('admin','Login','2019-11-30 17:14:59'),('admin','Login','2019-11-30 17:35:47'),('admin','Logout','2019-11-30 17:39:49'),('admin','Login','2019-11-30 18:12:58'),('admin','Login','2019-11-30 18:14:19'),('admin','Login','2019-11-30 19:37:08'),('admin','Login','2019-12-02 11:05:22'),('admin','Logout','2019-12-02 11:05:33'),('admin','Login','2019-12-02 11:05:35'),('admin','Login','2019-12-02 13:56:38'),('admin123','Login','2019-12-02 13:57:13'),('admin','Login','2019-12-02 14:21:18'),('admin','Login','2019-12-02 14:21:21'),('admin','Login','2019-12-02 14:24:36'),('admin','Login','2019-12-02 14:45:22'),('admin','Login','2019-12-02 14:49:07'),('admin','Login','2019-12-02 14:55:58'),('admin','Login','2019-12-02 15:05:32'),('admin','Login','2019-12-02 15:07:12'),('admin','Login','2019-12-02 15:10:09'),('admin','Logout','2019-12-02 15:10:13'),('admin','Login','2019-12-02 15:14:16'),('admin','Login','2019-12-02 16:26:01'),('admin','登录','2019-12-02 16:41:18'),('admin','登录','2019-12-02 16:54:57'),('admin','登录','2019-12-02 16:58:46'),('usha1','登录','2019-12-02 17:29:19'),('admin','登录','2019-12-02 18:57:23'),('admin','编辑课程表','2019-12-02 19:03:18'),('admin','编辑课程表','2019-12-02 19:32:35'),('admin','编辑课程表','2019-12-02 19:51:08'),('admin','编辑课程表','2019-12-02 19:51:35'),('admin','编辑课程表','2019-12-02 19:54:17'),('admin','登录','2019-12-02 20:35:30'),('admin','查看状态页','2019-12-02 21:19:26'),('admin','登录','2019-12-02 21:25:17'),('admin','登录','2019-12-02 21:27:58'),('admin','登录','2019-12-02 21:28:10'),('admin','编辑课程表','2019-12-02 21:29:53'),('admin','编辑课程表','2019-12-02 21:30:22'),('admin','登录','2019-12-02 21:40:13'),('admin','退出','2019-12-02 21:41:57'),('admin','登录','2019-12-02 21:43:35'),('admin','登录','2019-12-02 23:26:06'),('admin','查看状态页','2019-12-02 23:26:09'),('admin','编辑课程表','2019-12-02 23:27:32'),('admin','查看状态页','2019-12-02 23:27:54'),('admin','查看状态页','2019-12-02 23:54:28'),('admin','查看状态页','2019-12-02 23:54:41'),('admin','编辑课程表','2019-12-02 23:55:32'),('admin','编辑课程表','2019-12-02 23:55:33'),('admin','查看状态页','2019-12-02 23:55:37'),('admin','编辑课程表','2019-12-02 23:57:48'),('admin','编辑课程表','2019-12-02 23:57:50'),('admin','编辑课程表','2019-12-02 23:59:47'),('admin','编辑课程表','2019-12-02 23:59:47'),('admin','编辑课程表','2019-12-02 23:59:48'),('admin','编辑课程表','2019-12-02 23:59:48'),('admin','编辑课程表','2019-12-02 23:59:48'),('admin','编辑课程表','2019-12-02 23:59:48'),('admin','编辑课程表','2019-12-02 23:59:48'),('admin','编辑课程表','2019-12-02 23:59:48'),('admin','编辑课程表','2019-12-02 23:59:49'),('admin','编辑课程表','2019-12-02 23:59:58'),('admin','编辑课程表','2019-12-02 23:59:59'),('admin','编辑课程表','2019-12-02 23:59:59'),('admin','编辑课程表','2019-12-02 23:59:59'),('admin','编辑课程表','2019-12-02 23:59:59'),('admin','编辑课程表','2019-12-02 23:59:59'),('admin','编辑课程表','2019-12-02 23:59:59'),('admin','编辑课程表','2019-12-03 00:00:00'),('admin','编辑课程表','2019-12-03 00:00:00'),('admin','编辑课程表','2019-12-03 00:00:00'),('admin','编辑课程表','2019-12-03 00:00:00'),('admin','编辑课程表','2019-12-03 00:00:01'),('admin','编辑课程表','2019-12-03 00:00:01'),('admin','登录','2019-12-03 00:24:14'),('admin','登录','2019-12-03 00:34:14'),('admin','登录','2019-12-03 00:35:50'),('admin','查看系统配置页','2019-12-03 00:37:21'),('admin','退出','2019-12-03 00:37:23'),('admin','登录','2019-12-03 00:37:25'),('admin','登录','2019-12-03 00:46:00'),('admin','Login','2019-12-03 15:48:02'),('admin','Login','2019-12-03 15:49:26'),('admin','Login','2019-12-03 16:09:21'),('admin','Login','2019-12-03 16:13:35'),('admin','Visited Status Page','2019-12-03 16:15:46'),('admin','Login','2019-12-03 16:18:34'),('admin','Login','2019-12-03 16:31:46'),('admin','Login','2019-12-03 16:33:59'),('admin','Login','2019-12-03 16:35:42'),('admin','Login','2019-12-03 16:36:38'),('admin','Login','2019-12-03 16:56:12'),('admin','Sign Out','2019-12-03 16:56:16'),('admin','Login','2019-12-03 16:56:36'),('admin','Sign Out','2019-12-03 16:56:37'),('admin','Login','2019-12-03 16:57:04'),('admin','Login','2019-12-03 17:59:42'),('admin','Sign Out','2019-12-03 17:59:56'),('admin','Login','2019-12-03 18:00:11'),('admin','Login','2019-12-03 18:02:21'),('admin','Login','2019-12-03 18:04:31'),('admin','Login','2019-12-03 18:09:12'),('admin','Login','2019-12-04 09:04:12'),('admin','Updated Institute, Grade or Class Details','2019-12-04 09:05:09'),('admin','Updated Institute, Grade or Class Details','2019-12-04 09:05:20'),('admin','Updated Institute, Grade or Class Details','2019-12-04 09:05:25'),('admin','Updated Institute, Grade or Class Details','2019-12-04 09:05:39'),('admin','Login','2019-12-04 09:07:10'),('admin','Login','2019-12-04 09:08:51'),('admin','Updated Institute, Grade or Class Details','2019-12-04 09:09:24'),('admin','Updated Institute, Grade or Class Details','2019-12-04 09:09:25'),('admin','Updated Institute, Grade or Class Details','2019-12-04 09:09:26'),('admin','Login','2019-12-04 09:28:28'),('admin','Login','2019-12-04 09:37:07'),('admin','Sign Out','2019-12-04 09:37:13'),('admin','Login','2019-12-04 10:38:07'),('admin','Login','2019-12-04 10:47:34'),('admin','登录','2019-12-04 17:26:31'),('admin','退出','2019-12-04 17:29:12'),('Guest','登录','2019-12-04 17:29:19'),('Guest','登录','2019-12-04 17:32:56'),('Guest','查看状态页','2019-12-04 17:33:07'),('Guest','登录','2019-12-04 17:36:09'),('Guest','查看状态页','2019-12-04 17:36:15'),('Guest','查看状态页','2019-12-04 17:37:22'),('Guest','查看状态页','2019-12-04 17:39:22'),('Guest','查看状态页','2019-12-04 17:39:40'),('Guest','查看状态页','2019-12-04 17:40:07'),('Guest','查看状态页','2019-12-04 17:40:40'),('Guest','登录','2019-12-04 17:44:02'),('Guest','查看状态页','2019-12-04 17:44:08'),('Guest','登录','2019-12-04 17:45:06'),('Guest','查看状态页','2019-12-04 17:45:11'),('Guest','查看状态页','2019-12-04 17:45:54'),('Guest','登录','2019-12-04 17:48:25'),('Guest','查看状态页','2019-12-04 17:48:43'),('Guest','查看状态页','2019-12-04 17:48:57'),('Guest','登录','2019-12-04 17:49:33'),('Guest','查看状态页','2019-12-04 17:49:40'),('Guest','查看状态页','2019-12-04 17:50:42'),('Guest','查看状态页','2019-12-04 17:51:31'),('Guest','查看状态页','2019-12-04 17:55:58'),('Guest','查看状态页','2019-12-04 17:56:14'),('Guest','查看状态页','2019-12-04 17:57:20'),('Guest','查看状态页','2019-12-04 17:57:36'),('Guest','查看状态页','2019-12-04 17:57:43'),('Guest','查看状态页','2019-12-04 17:57:59'),('Guest','查看状态页','2019-12-04 17:58:21'),('Guest','查看状态页','2019-12-04 17:59:00'),('Guest','查看状态页','2019-12-04 17:59:39'),('Guest','登录','2019-12-05 08:50:04'),('Guest','查看状态页','2019-12-05 08:50:12'),('Guest','查看状态页','2019-12-05 08:50:37'),('Guest','查看状态页','2019-12-05 08:52:49'),('Guest','登录','2019-12-05 09:14:17'),('Guest','查看状态页','2019-12-05 09:14:27'),('Guest','查看状态页','2019-12-05 09:14:45'),('Guest','登录','2019-12-05 09:16:38'),('Guest','查看状态页','2019-12-05 09:16:42'),('Guest','查看状态页','2019-12-05 09:17:02'),('admin','登录','2019-12-05 09:52:56'),('admin','登录','2019-12-05 10:04:07'),('admin','登录','2019-12-05 10:09:31'),('admin','登录','2019-12-05 10:10:55'),('admin','登录','2019-12-05 10:13:00'),('admin','登录','2019-12-05 10:16:46'),('admin','查看状态页','2019-12-05 10:16:50'),('admin','查看状态页','2019-12-05 10:19:31'),('admin','查看状态页','2019-12-05 10:25:11'),('admin','登录','2019-12-05 10:26:54'),('admin','查看状态页','2019-12-05 10:27:18'),('admin','登录','2019-12-05 10:27:33'),('admin','登录','2019-12-05 10:45:35'),('admin','登录','2019-12-05 10:53:54'),('admin','编辑课程表','2019-12-05 10:56:05'),('admin','编辑课程表','2019-12-05 10:56:14'),('admin','编辑课程表','2019-12-05 10:57:46'),('admin','编辑课程表','2019-12-05 11:00:23'),('admin','编辑课程表','2019-12-05 11:00:42'),('admin','编辑课程表','2019-12-05 11:00:58'),('admin','登录','2019-12-05 11:56:03'),('admin','修改学校，年级或班级。','2019-12-05 11:56:13'),('admin','修改学校，年级或班级。','2019-12-05 11:56:25'),('admin','修改学校，年级或班级。','2019-12-05 11:57:16'),('admin','修改学校，年级或班级。','2019-12-05 11:57:17'),('admin','修改学校，年级或班级。','2019-12-05 11:57:21'),('admin','修改学校，年级或班级。','2019-12-05 11:57:22'),('admin','修改学校，年级或班级。','2019-12-05 11:57:23'),('admin','登录','2019-12-05 14:07:22'),('admin','登录','2019-12-05 14:25:00'),('admin','登录','2019-12-05 15:15:01'),('admin','登录','2019-12-05 15:26:30'),('admin','登录','2019-12-05 16:15:10'),('admin','退出','2019-12-05 16:15:21'),('admin','登录','2019-12-05 16:15:37'),('admin','登录','2019-12-05 16:16:09'),('admin','登录','2019-12-05 16:24:20'),('admin','登录','2019-12-05 16:29:02'),('admin','登录','2019-12-05 17:40:51'),('admin','查看状态页','2019-12-05 17:40:58'),('admin','查看状态页','2019-12-05 17:41:26'),('admin','查看状态页','2019-12-05 17:42:04'),('admin','查看状态页','2019-12-05 17:42:42'),('admin','登录','2019-12-05 17:49:43'),('admin','编辑课程表','2019-12-05 17:49:51'),('admin','查看状态页','2019-12-05 17:49:53'),('admin','登录','2019-12-06 08:54:56'),('admin','编辑课程表','2019-12-06 08:55:26'),('admin','查看状态页','2019-12-06 09:11:00'),('admin','登录','2019-12-06 09:21:19'),('admin','查看状态页','2019-12-06 09:21:31'),('admin','登录','2019-12-06 09:24:13'),('admin','查看状态页','2019-12-06 09:24:20'),('admin','登录','2019-12-06 09:26:12'),('admin','查看状态页','2019-12-06 09:49:12'),('admin','登录','2019-12-06 09:52:45'),('admin','登录','2019-12-06 09:59:09'),('admin','退出','2019-12-06 10:08:15'),('admin','登录','2019-12-06 10:08:28'),('admin','登录','2019-12-06 10:27:44'),('admin','查看状态页','2019-12-06 10:31:23'),('admin','查看状态页','2019-12-06 10:34:15'),('admin','查看状态页','2019-12-06 10:35:07'),('admin','查看状态页','2019-12-06 10:35:41'),('admin','登录','2019-12-06 10:37:54'),('admin','查看状态页','2019-12-06 10:38:00'),('admin','登录','2019-12-06 10:38:45'),('admin','登录','2019-12-06 11:04:40'),('admin','登录','2019-12-06 11:06:57'),('admin','登录','2019-12-06 11:10:02'),('admin','登录','2019-12-06 11:10:35'),('admin','查看状态页','2019-12-06 11:10:44'),('admin','登录','2019-12-06 11:24:07'),('admin','登录','2019-12-06 11:33:28'),('admin','登录','2019-12-06 11:36:49'),('admin','退出','2019-12-06 11:43:35'),('admin','登录','2019-12-06 11:57:49'),('admin','登录','2019-12-06 13:29:59'),('admin','登录','2019-12-06 13:53:37'),('admin','登录','2019-12-06 13:55:54'),('admin','修改学校，年级或班级。','2019-12-06 13:56:02'),('admin','修改学校，年级或班级。','2019-12-06 13:56:20'),('admin','修改学校，年级或班级。','2019-12-06 13:57:38'),('admin','修改学校，年级或班级。','2019-12-06 13:57:39'),('admin','修改学校，年级或班级。','2019-12-06 13:57:40'),('admin','登录','2019-12-06 14:07:14'),('admin','登录','2019-12-06 14:37:51'),('admin','修改学校，年级或班级。','2019-12-06 14:51:46'),('admin','修改学校，年级或班级。','2019-12-06 14:51:55'),('admin','修改学校，年级或班级。','2019-12-06 14:51:58'),('admin','修改学校，年级或班级。','2019-12-06 14:51:59'),('admin','修改学校，年级或班级。','2019-12-06 14:52:03'),('admin','修改学校，年级或班级。','2019-12-06 14:52:04'),('admin','修改学校，年级或班级。','2019-12-06 14:52:05'),('admin','查看状态页','2019-12-06 15:27:59'),('admin','登录','2019-12-06 15:30:31'),('admin','登录','2019-12-06 15:31:50'),('admin','登录','2019-12-06 16:07:12'),('admin','登录','2019-12-06 16:09:20'),('admin','登录','2019-12-06 16:42:31'),('admin','登录','2019-12-09 08:33:31'),('admin','查看状态页','2019-12-09 08:33:37'),('admin','查看状态页','2019-12-09 08:39:08'),('admin','登录','2019-12-09 09:46:01'),('admin','Login','2019-12-09 10:46:33'),('admin','Login','2019-12-09 15:40:34'),('admin','Visited Status Page','2019-12-09 15:40:39'),('admin','登录','2019-12-09 15:47:09'),('admin','Visited Status Page','2019-12-09 16:11:29'),('admin','登录','2019-12-09 16:12:01'),('admin','查看状态页','2019-12-09 16:12:06'),('admin','查看状态页','2019-12-09 16:12:13'),('admin','Login','2019-12-10 09:56:10'),('admin','Visited Status Page','2019-12-10 09:58:40'),('admin','Visited Configuration Settings Page','2019-12-10 09:58:43'),('admin','Sign Out','2019-12-10 09:59:01'),('admin','Login','2019-12-10 09:59:19'),('admin','Visited Status Page','2019-12-10 09:59:46'),('admin','Login','2019-12-10 10:03:12'),('admin','Login','2019-12-10 10:46:37'),('admin','登录','2019-12-10 10:47:09'),('admin','登录','2019-12-10 10:49:54'),('admin','登录','2019-12-10 10:51:30'),('admin','登录','2019-12-10 10:57:07'),('admin','编辑课程表','2019-12-10 10:57:34'),('admin','登录','2019-12-10 11:03:54'),('admin','编辑课程表','2019-12-10 11:04:36'),('admin','编辑课程表','2019-12-10 11:04:55'),('admin','登录','2019-12-10 11:06:31'),('admin','编辑课程表','2019-12-10 11:06:54'),('admin','编辑课程表','2019-12-10 11:07:06'),('admin','登录','2019-12-10 11:13:27'),('admin','编辑课程表','2019-12-10 11:13:58'),('admin','编辑课程表','2019-12-10 11:14:52'),('admin','编辑课程表','2019-12-10 11:15:19'),('admin','编辑课程表','2019-12-10 11:15:37'),('admin','登录','2019-12-10 11:59:54'),('admin','查看状态页','2019-12-10 12:00:01'),('admin','查看状态页','2019-12-10 12:00:09'),('admin','登录','2019-12-10 13:47:06'),('admin','查看状态页','2019-12-10 13:47:12'),('admin','登录','2019-12-10 13:51:32'),('admin','查看状态页','2019-12-10 13:51:36'),('admin','查看状态页','2019-12-10 13:51:50'),('admin','查看状态页','2019-12-10 13:53:26'),('admin','查看状态页','2019-12-10 13:54:49'),('admin','查看状态页','2019-12-10 13:55:44'),('admin','登录','2019-12-10 13:56:51'),('admin','查看状态页','2019-12-10 13:56:54'),('admin','查看状态页','2019-12-10 13:57:16'),('admin','查看状态页','2019-12-10 13:57:21'),('admin','查看状态页','2019-12-10 13:59:52'),('admin','查看状态页','2019-12-10 14:02:27'),('admin','登录','2019-12-10 14:05:35'),('admin','查看状态页','2019-12-10 14:05:39'),('admin','查看状态页','2019-12-10 14:06:47'),('admin','查看状态页','2019-12-10 14:06:53'),('admin','查看状态页','2019-12-10 14:07:28'),('admin','查看状态页','2019-12-10 14:08:05'),('admin','查看状态页','2019-12-10 14:08:12'),('admin','查看状态页','2019-12-10 14:08:33'),('admin','查看状态页','2019-12-10 14:08:51'),('admin','查看状态页','2019-12-10 14:09:04'),('admin','登录','2019-12-10 15:23:44'),('admin','查看状态页','2019-12-10 15:23:48'),('admin','登录','2019-12-10 15:30:01'),('admin','登录','2019-12-11 11:28:52'),('admin','登录','2019-12-12 09:33:34'),('admin','修改学校，年级或班级。','2019-12-12 09:33:45'),('admin','修改学校，年级或班级。','2019-12-12 09:33:54'),('admin','修改学校，年级或班级。','2019-12-12 09:34:01'),('admin','登录','2019-12-12 10:11:09'),('admin','修改学校，年级或班级。','2019-12-12 10:12:06'),('admin','修改学校，年级或班级。','2019-12-12 10:12:10'),('admin','登录','2019-12-12 11:08:38'),('admin','修改学校，年级或班级。','2019-12-12 11:08:46'),('admin','修改学校，年级或班级。','2019-12-12 11:08:50'),('admin','修改学校，年级或班级。','2019-12-12 11:08:54'),('admin','修改学校，年级或班级。','2019-12-12 11:09:00'),('admin','修改学校，年级或班级。','2019-12-12 11:09:01'),('admin','修改学校，年级或班级。','2019-12-12 11:11:50'),('admin','修改学校，年级或班级。','2019-12-12 11:11:53'),('admin','修改学校，年级或班级。','2019-12-12 11:11:57'),('admin','修改学校，年级或班级。','2019-12-12 11:29:20'),('admin','修改学校，年级或班级。','2019-12-12 11:29:22'),('admin','登录','2019-12-12 17:04:35'),('admin','修改学校，年级或班级。','2019-12-12 17:04:46'),('admin','修改学校，年级或班级。','2019-12-12 17:04:47'),('admin','修改学校，年级或班级。','2019-12-12 17:04:55'),('admin','修改学校，年级或班级。','2019-12-12 17:05:40'),('admin','登录','2019-12-16 13:33:55'),('admin','登录','2019-12-16 13:44:28'),('admin','登录','2019-12-16 15:59:00'),('admin','登录','2019-12-16 16:04:16'),('admin','登录','2019-12-16 16:38:32'),('admin','登录','2019-12-17 08:47:12'),('admin','登录','2019-12-17 09:22:06'),('admin','登录','2019-12-17 09:25:19'),('admin','登录','2019-12-17 09:27:23'),('admin','登录','2019-12-17 09:29:54'),('admin','登录','2019-12-17 09:44:20'),('admin','登录','2019-12-18 09:02:12'),('admin','登录','2019-12-18 09:06:43'),('admin','登录','2019-12-18 09:19:42'),('admin','登录','2019-12-18 09:35:03'),('admin','登录','2019-12-18 09:39:49'),('admin','登录','2019-12-18 09:49:12'),('admin','登录','2019-12-18 09:55:27'),('admin','登录','2019-12-18 10:13:12'),('admin','登录','2019-12-18 10:18:55'),('admin','登录','2019-12-18 10:21:59'),('admin','登录','2019-12-18 10:27:06'),('admin','登录','2019-12-18 10:28:26'),('admin','登录','2019-12-18 10:33:08'),('admin','登录','2019-12-18 10:35:22'),('admin','登录','2019-12-18 10:49:12'),('admin','登录','2019-12-18 10:51:50'),('admin','登录','2019-12-18 11:06:38'),('admin','查看状态页','2019-12-18 11:54:51'),('admin','登录','2019-12-18 11:56:50'),('admin','登录','2019-12-18 11:59:36'),('admin','登录','2019-12-18 12:00:51'),('admin','登录','2019-12-18 12:03:28'),('admin','登录','2019-12-18 13:44:36'),('admin','登录','2019-12-18 14:00:08'),('admin','登录','2019-12-18 14:45:33'),('admin','登录','2019-12-18 14:47:30'),('admin','修改学校，年级或班级。','2019-12-18 16:03:12'),('admin','登录','2019-12-18 16:05:02'),('admin','登录','2019-12-18 17:30:11'),('admin','修改学校，年级或班级。','2019-12-18 17:30:30'),('admin','登录','2019-12-18 17:33:06'),('admin','修改学校，年级或班级。','2019-12-18 17:33:35'),('admin','登录','2019-12-19 08:37:31'),('admin','登录','2019-12-19 10:14:52'),('admin','修改学校，年级或班级。','2019-12-19 10:15:31'),('admin','修改学校，年级或班级。','2019-12-19 10:16:39'),('admin','修改学校，年级或班级。','2019-12-19 10:16:42'),('admin','修改学校，年级或班级。','2019-12-19 10:17:07'),('admin','修改学校，年级或班级。','2019-12-19 10:17:24'),('admin','修改学校，年级或班级。','2019-12-19 10:17:31'),('admin','修改学校，年级或班级。','2019-12-19 10:17:34'),('admin','修改学校，年级或班级。','2019-12-19 10:17:37'),('admin','修改学校，年级或班级。','2019-12-19 10:17:40'),('admin','修改学校，年级或班级。','2019-12-19 10:17:43'),('admin','登录','2019-12-19 10:19:39'),('admin','修改学校，年级或班级。','2019-12-19 10:19:54'),('admin','登录','2019-12-19 10:25:38'),('admin','修改学校，年级或班级。','2019-12-19 10:25:53'),('admin','修改学校，年级或班级。','2019-12-19 10:26:14'),('admin','修改学校，年级或班级。','2019-12-19 10:26:28'),('admin','修改学校，年级或班级。','2019-12-19 10:26:29'),('admin','修改学校，年级或班级。','2019-12-19 10:27:09'),('admin','登录','2019-12-19 10:31:24'),('admin','修改学校，年级或班级。','2019-12-19 10:31:36'),('admin','登录','2019-12-19 10:33:16'),('admin','修改学校，年级或班级。','2019-12-19 10:33:29'),('admin','登录','2019-12-19 10:34:33'),('admin','修改学校，年级或班级。','2019-12-19 10:34:44'),('admin','修改学校，年级或班级。','2019-12-19 10:34:47'),('admin','修改学校，年级或班级。','2019-12-19 10:34:50'),('admin','修改学校，年级或班级。','2019-12-19 10:35:02'),('admin','修改学校，年级或班级。','2019-12-19 10:35:20'),('admin','登录','2019-12-19 10:36:09'),('admin','修改学校，年级或班级。','2019-12-19 10:36:21'),('admin','修改学校，年级或班级。','2019-12-19 10:36:26'),('admin','修改学校，年级或班级。','2019-12-19 10:36:27'),('admin','修改学校，年级或班级。','2019-12-19 10:36:29'),('admin','修改学校，年级或班级。','2019-12-19 11:10:00'),('admin','登录','2019-12-24 09:18:04'),('admin','修改学校，年级或班级。','2019-12-24 09:18:44'),('admin','登录','2019-12-24 10:29:46'),('admin','修改学校，年级或班级。','2019-12-24 10:29:53'),('admin','修改学校，年级或班级。','2019-12-24 10:30:45'),('admin','修改学校，年级或班级。','2019-12-24 10:31:04'),('admin','修改学校，年级或班级。','2019-12-24 10:31:05'),('admin','登录','2019-12-24 10:36:07'),('admin','修改学校，年级或班级。','2019-12-24 10:36:20'),('admin','修改学校，年级或班级。','2019-12-24 10:37:15'),('admin','修改学校，年级或班级。','2019-12-24 10:37:19'),('admin','修改学校，年级或班级。','2019-12-24 10:37:22'),('admin','修改学校，年级或班级。','2019-12-24 10:37:28'),('admin','修改学校，年级或班级。','2019-12-24 10:37:30'),('admin','登录','2019-12-24 10:43:05'),('admin','修改学校，年级或班级。','2019-12-24 10:43:10'),('admin','修改学校，年级或班级。','2019-12-24 10:43:13'),('admin','修改学校，年级或班级。','2019-12-24 10:43:15'),('admin','修改学校，年级或班级。','2019-12-24 10:43:21'),('admin','修改学校，年级或班级。','2019-12-24 10:43:24'),('admin','登录','2019-12-24 13:32:48'),('admin','修改学校，年级或班级。','2019-12-24 13:39:47'),('admin','修改学校，年级或班级。','2019-12-24 13:40:38'),('admin','修改学校，年级或班级。','2019-12-24 13:40:47'),('admin','登录','2019-12-24 14:03:33'),('admin','登录','2019-12-24 15:28:37'),('admin','登录','2019-12-24 15:57:58'),('admin','登录','2019-12-25 11:32:41'),('admin','登录','2019-12-25 11:36:13'),('admin','登录','2019-12-25 13:25:36'),('admin','登录','2019-12-25 13:30:34'),('admin','登录','2019-12-25 13:34:55'),('admin','登录','2019-12-25 13:36:06'),('admin','登录','2019-12-25 13:38:42'),('admin','登录','2019-12-25 13:55:22'),('admin','登录','2019-12-25 13:55:23'),('admin','登录','2019-12-25 14:04:28'),('admin','登录','2019-12-25 14:09:18'),('admin','登录','2019-12-25 14:23:50'),('admin','登录','2019-12-25 14:26:14'),('admin','登录','2019-12-25 14:32:05'),('admin','登录','2019-12-25 14:33:40'),('admin','登录','2019-12-25 14:38:49'),('admin','登录','2019-12-25 16:07:32'),('admin','登录','2019-12-25 16:10:34'),('admin','登录','2019-12-25 16:12:03'),('admin','登录','2019-12-25 16:18:40'),('admin','退出','2019-12-25 16:19:16'),('admin','登录','2019-12-25 16:20:17'),('admin','登录','2019-12-25 16:31:07'),('admin','退出','2019-12-25 16:33:24'),('admin1','登录','2019-12-25 16:33:32'),('admin1','登录','2019-12-25 16:39:27'),('admin1','登录','2019-12-25 16:39:36'),('admin1','登录','2019-12-25 16:41:11'),('admin','登录','2019-12-25 16:44:40'),('admin','退出','2019-12-25 16:46:59'),('admin','登录','2019-12-25 16:49:14'),('admin','退出','2019-12-25 16:49:24'),('admin','登录','2019-12-25 17:07:48'),('admin','登录','2019-12-26 08:48:40'),('admin','登录','2019-12-26 08:49:20'),('admin','登录','2019-12-26 08:50:09'),('admin','退出','2019-12-26 08:50:17'),('admin','登录','2019-12-26 08:50:26'),('admin','登录','2019-12-26 08:53:38'),('admin','查看状态页','2019-12-26 08:53:44'),('admin','登录','2019-12-26 17:05:50'),('admin','Login','2019-12-26 17:23:21'),('admin','登录','2019-12-31 15:56:53'),('admin','查看状态页','2019-12-31 15:56:58'),('admin','查看状态页','2019-12-31 16:08:19'),('admin','Login','2020-01-02 16:37:53'),('admin','Updated Institute, Grade or Class Details','2020-01-02 16:38:41'),('admin','Updated Institute, Grade or Class Details','2020-01-02 16:38:48'),('admin','Login','2020-01-02 16:40:29'),('admin','Login','2020-01-02 16:49:07'),('admin','Login','2020-01-02 16:58:06'),('admin','Login','2020-01-02 17:00:23'),('admin','Login','2020-01-02 17:02:54'),('admin','Login','2020-01-03 09:49:39'),('admin','登录','2020-01-03 09:50:40'),('admin','登录','2020-01-03 09:54:18'),('admin','修改学校，年级或班级。','2020-01-03 09:54:25'),('admin','修改学校，年级或班级。','2020-01-03 10:02:11'),('admin','登录','2020-01-07 09:50:29'),('admin','登录','2020-01-07 10:38:26'),('admin','查看状态页','2020-01-07 10:38:54'),('admin','登录','2020-01-07 10:42:08'),('admin','登录','2020-01-07 10:53:09'),('admin','登录','2020-01-07 11:01:50'),('admin','登录','2020-01-07 11:03:59'),('admin','查看状态页','2020-01-07 11:04:06'),('admin','修改学校，年级或班级。','2020-01-07 11:04:26'),('admin','修改学校，年级或班级。','2020-01-07 11:04:28'),('admin','修改学校，年级或班级。','2020-01-07 11:04:33'),('admin','登录','2020-01-07 12:29:23'),('admin','登录','2020-01-07 17:12:13'),('admin','修改学校，年级或班级。','2020-01-07 17:13:24'),('admin','登录','2020-01-07 17:15:42'),('admin','登录','2020-01-07 17:42:00'),('admin','登录','2020-01-07 17:43:58'),('admin','登录','2020-01-08 11:41:11'),('admin','查看状态页','2020-01-08 11:41:17'),('admin','修改学校，年级或班级。','2020-01-08 11:41:37'),('admin','修改学校，年级或班级。','2020-01-08 11:41:51'),('admin','修改学校，年级或班级。','2020-01-08 11:42:01'),('admin','登录','2020-01-08 17:29:56'),('admin','修改学校，年级或班级。','2020-01-08 17:30:07'),('admin','登录','2020-01-08 17:35:11'),('admin','登录','2020-01-09 10:58:38'),('admin','登录','2020-01-09 11:41:10'),('admin','修改学校，年级或班级。','2020-01-09 11:41:22'),('admin','登录','2020-01-09 14:04:04'),('admin','退出','2020-01-09 14:08:19'),('admin','登录','2020-01-09 14:08:58'),('admin','登录','2020-01-09 15:40:00'),('admin','登录','2020-01-09 15:45:42'),('admin','查看状态页','2020-01-09 15:46:15'),('admin','登录','2020-01-14 17:01:12'),('admin','登录','2020-01-15 16:37:56'),('admin','登录','2020-03-27 13:29:17'),('admin','登录','2020-03-27 13:37:09'),('admin','登录','2020-03-27 13:37:18'),('admin','登录','2020-03-30 09:05:23'),('admin','登录','2020-03-30 11:10:36'),('admin','登录','2020-03-31 10:03:25'),('admin','退出','2020-03-31 10:11:08'),('admin','登录','2020-03-31 10:12:22'),('admin','登录','2020-03-31 10:33:11'),('admin','登录','2020-04-03 10:10:19'),('admin','登录','2020-04-03 10:39:09'),('admin','Login','2020-04-07 10:13:54'),('admin','登录','2020-04-07 10:21:18'),('admin','Login','2020-04-07 10:22:44'),('admin','Login','2020-04-07 10:26:51'),('admin','登录','2020-04-07 10:29:52'),('admin','登录','2020-04-07 10:31:03'),('admin','Login','2020-04-07 10:31:54'),('admin','Login','2020-04-07 10:35:22'),('admin','Login','2020-04-07 10:38:05'),('admin','Login','2020-04-07 11:31:40'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:32:04'),('admin','Login','2020-04-07 11:49:12'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:49:26'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:49:48'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:49:56'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:51:05'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:52:51'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:53:04'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:53:05'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:53:10'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:53:37'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:53:42'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:53:50'),('admin','Updated Institute, Grade or Class Details','2020-04-07 11:53:52'),('admin','Updated Institute, Grade or Class Details','2020-04-07 12:02:32'),('admin','Updated Institute, Grade or Class Details','2020-04-07 12:02:43'),('admin','Updated Institute, Grade or Class Details','2020-04-07 12:05:19'),('admin','Updated Institute, Grade or Class Details','2020-04-07 12:08:14'),('admin','Updated Institute, Grade or Class Details','2020-04-07 12:08:24'),('admin','登录','2020-04-07 12:11:33'),('admin','修改学校，年级或班级。','2020-04-07 12:11:40'),('admin','修改学校，年级或班级。','2020-04-07 12:11:59'),('admin','修改学校，年级或班级。','2020-04-07 12:12:08'),('admin','修改学校，年级或班级。','2020-04-07 12:12:10'),('admin','修改学校，年级或班级。','2020-04-07 12:12:12'),('admin','修改学校，年级或班级。','2020-04-07 12:12:12'),('admin','修改学校，年级或班级。','2020-04-07 12:12:13'),('admin','修改学校，年级或班级。','2020-04-07 12:12:19'),('admin','修改学校，年级或班级。','2020-04-07 12:12:21'),('admin','修改学校，年级或班级。','2020-04-07 12:12:39'),('admin','登录','2020-04-07 12:16:26'),('admin','修改学校，年级或班级。','2020-04-07 12:16:47'),('admin','登录','2020-04-07 12:17:26'),('admin','修改学校，年级或班级。','2020-04-07 12:17:34'),('admin','登录','2020-04-07 14:28:12'),('admin','修改学校，年级或班级。','2020-04-07 14:37:00'),('admin','修改学校，年级或班级。','2020-04-07 14:37:52'),('admin','修改学校，年级或班级。','2020-04-07 14:37:55'),('admin','修改学校，年级或班级。','2020-04-07 14:38:00'),('admin','修改学校，年级或班级。','2020-04-07 14:38:06'),('admin','修改学校，年级或班级。','2020-04-07 14:38:10'),('admin','修改学校，年级或班级。','2020-04-07 14:38:15'),('admin','修改学校，年级或班级。','2020-04-07 14:38:19'),('admin','修改学校，年级或班级。','2020-04-07 14:38:31');
/*!40000 ALTER TABLE `user_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_roles`
--

DROP TABLE IF EXISTS `user_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_roles` (
  `role_id` int(11) NOT NULL AUTO_INCREMENT,
  `role_name` varchar(100) NOT NULL,
  PRIMARY KEY (`role_id`),
  UNIQUE KEY `roleid_UNIQUE` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Contains all role details according to website ';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_roles`
--
-- ORDER BY:  `role_id`

LOCK TABLES `user_roles` WRITE;
/*!40000 ALTER TABLE `user_roles` DISABLE KEYS */;
INSERT INTO `user_roles` (`role_id`, `role_name`) VALUES (1,'admin'),(2,'documentupdate'),(3,'userauthentication'),(4,'scannercard'),(5,'newsettings'),(6,'Schedule'),(7,'configuration');
/*!40000 ALTER TABLE `user_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'cresijdatabase'
--
/*!50106 SET @save_time_zone= @@TIME_ZONE */ ;
/*!50106 DROP EVENT IF EXISTS `status_cleaner_event` */;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8mb4 */ ;;
/*!50003 SET character_set_results = utf8mb4 */ ;;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `status_cleaner_event` ON SCHEDULE EVERY 15 MINUTE STARTS '2019-11-15 13:36:35' ON COMPLETION NOT PRESERVE ENABLE COMMENT 'Delete Status' DO Delete from cresijdatabase.status */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
DELIMITER ;
/*!50106 SET TIME_ZONE= @save_time_zone */ ;

--
-- Dumping routines for database 'cresijdatabase'
--
/*!50003 DROP FUNCTION IF EXISTS `func_CountPendingUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `func_CountPendingUser`() RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN
declare total int;
set total = (select (select count(userid) from temporary_user where Status='Pending') +
(select count(userid) from Registration where currentstatus='Pending') );
RETURN @total;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_addNewUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_addNewUser`(userid varchar(20), username varchar(50), pass varchar(20),
roleid int, ph varchar(15), out result int)
BEGIN
if not exists(select user_id from user_details where user_id = userid COLLATE utf8mb4_unicode_ci)
	then
		if not exists(select user_id from user_details where phone = ph COLLATE utf8mb4_unicode_ci)
		then
			Insert into user_details values(userid, username, pass, roleid, ph);
			set result =1;
		else
			set result=-1;
		end if;
    else
		set result =-1;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_cam` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cam`(camip varchar(20), loc int)
BEGIN
/*fn_cam*/
select * from camera_details where camera_ip =camip and location =loc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_camdetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_camdetails`(cname varchar(20), loc varchar(10))
BEGIN
/*fn_camdetails*/
select id into @loca from class_details where ClassID = loc COLLATE utf8mb4_unicode_ci;
select cameraip, user_id as ID, camname, password, port as portNo, channelid from camera_details 
where camname =cname COLLATE utf8mb4_unicode_ci and location =@loca;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_cardLogs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cardLogs`(classid int, cardid varchar(20), out log varchar(200))
BEGIN
declare currentdate datetime;
set currentdate = sysdate();
if exists(select * from class_details where id =classid)
then
insert into reader_logs values(classid, cardid, currentdate);

 create temporary table temp (memname varchar(50), memid varchar(30), cardid varchar(50),
locname varchar(50), currenttime datetime);

insert into temp
select cr.membername , cr.memberid, rl.cardid, cd.class_name, rl.date
 from reader_logs rl inner join
 card_register cr on rl.cardid = cr.cardid 
inner join class_details cd on cd.id = rl.locationid 
where rl.locationid = classid and rl.date = currentdate;
set @log = (select concat(memname ,',', memid,',', cardid ,',',CAST( currenttime as char)
,',', locname) from temp);
set log = @log;
drop temporary table temp;
else
set log='NA';
end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_cardRegister` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cardRegister`(sno varchar(10), name varchar(50), memid varchar(30),
card_id varchar(50),rights varchar(50), pending varchar(200),comment varchar(100),
state varchar(15), classids varchar(200), out result int)
BEGIN
if not exists(select cardid from card_register where cardid = card_id)
then
insert into card_register values(card_id, sno, name, memid,rights,'', comment, state, pending,
classids);
set result =1;
else
set result = -1;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_changeMachineTime` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_changeMachineTime`(projector double , comp double, record double, actemp double, scr double, sys double, loc varchar(15))
BEGIN
select ccip into @ip from centralcontrol
 where location in( select id from class_details where classid = loc COLLATE utf8mb4_unicode_ci);
if exists(select * from machineworkinghours where IP  = @ip COLLATE utf8mb4_unicode_ci)
then
delete from machineworkinghours where ip = @ip COLLATE utf8mb4_unicode_ci;
Insert into machineworkinghours values(@ip, now(), projector,comp,record,actemp,sys,scr);
else
Insert into machineworkinghours values(@ip, now(), projector,comp,record,actemp,sys,scr);
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CountPendingUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CountPendingUser`(out total int)
BEGIN
 select (select count(userid) from temporary_user where Status='Pending') +
(select count(userid) from Registration where currentstatus='Pending') into total ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_delCConLocation` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_delCConLocation`(ips varchar(20), loc varchar(10), out r int)
BEGIN
delete from status where MachineIp = ips COLLATE utf8mb4_unicode_ci;
delete from machineworkinghours where Ip= ips COLLATE utf8mb4_unicode_ci;
delete from fault_info where ip= ips COLLATE utf8mb4_unicode_ci;
delete from centralcontrol where ccip = ips COLLATE utf8mb4_unicode_ci and location in(select id from Class_details where classid = loc COLLATE utf8mb4_unicode_ci);
delete from temp_centralcontrol where ip = ips COLLATE utf8mb4_unicode_ci and location in(select id from Class_details where classid = loc COLLATE utf8mb4_unicode_ci);

set r=1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deleteCamera` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_deleteCamera`(loc varchar(10), out result int)
BEGIN
/*delAllCam*/
select id into @loca from class_details where ClassID = loc COLLATE utf8mb4_unicode_ci;
delete from camera_details where location =@loca;
set result =1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deleteCameraonLocation` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_deleteCameraonLocation`(camip varchar(20), loc varchar(10), out r int)
BEGIN
select id into @loca from class_details where ClassID = loc COLLATE utf8mb4_unicode_ci;
delete from camera_details where cameraip =camip COLLATE utf8mb4_unicode_ci and location=@loca;
set r=1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deleteCentralControl` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_deleteCentralControl`(loc varchar(10), out result int)
BEGIN
/*delallcc*/

select id into @loca from class_details where ClassID = 'Class44' COLLATE utf8mb4_unicode_ci;
if exists(select ccip from centralcontrol where location = @loca)
then

delete from machineworkinghours where Ip in(select ccip from centralcontrol where location =@loca);
delete from fault_info where ip in(select ccip from centralcontrol where location =@loca);
delete from status where machineIp in(select ccip from centralcontrol where location =@loca);
delete from centralcontrol where location= @loca;
delete from temp_centralcontrol where loc = @loca;
end if;
set result=1;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deleteClass` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_deleteClass`(class varchar(10), out r int)
BEGIN
delete from machineworkinghours where Ip in(select ccip from centralcontrol where location in (select id from class_Details where classid =class COLLATE utf8mb4_unicode_ci));
delete from fault_info where classid in(select id from class_Details where classid ='Class41' COLLATE utf8mb4_unicode_ci);
delete from status where MachineIp in (select ccip from centralcontrol where location in (select id from class_Details where classid =class COLLATE utf8mb4_unicode_ci));
delete from centralcontrol where location in (select id from class_Details where classid =class COLLATE utf8mb4_unicode_ci);
delete from temp_centralcontrol where loc in (select id from class_Details where classid =class COLLATE utf8mb4_unicode_ci);
delete from camera_details where location in (select id from class_Details where classid =class COLLATE utf8mb4_unicode_ci);
delete from readerlocation where location in (select id from class_Details where classid =class COLLATE utf8mb4_unicode_ci);
delete from fault_info where classid in (select id from class_Details where classid =class COLLATE utf8mb4_unicode_ci);
delete from temprature_details where location in (select id from class_Details where classid =class COLLATE utf8mb4_unicode_ci);
delete from schedule where location = class COLLATE utf8mb4_unicode_ci;
delete from class_Details where classid =class COLLATE utf8mb4_unicode_ci;
set r=1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteDocInfo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteDocInfo`(doc varchar(150), userIDs varchar(20), out result int)
BEGIN

if exists (select  doc_info from doc_info where userid = userIDs COLLATE utf8mb4_unicode_ci and doc_info = doc COLLATE utf8mb4_unicode_ci)
then
delete from doc_info where userid= userIDs COLLATE utf8mb4_unicode_ci and doc_info =doc COLLATE utf8mb4_unicode_ci;
set result=1;
else

set result=-1;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deletegrade` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_deletegrade`(gradeids varchar(10), out r int)
BEGIN
delete from machineworkinghours where Ip in (select ccip from centralcontrol where location in (select id from class_details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci)));
delete from status where MachineIp in (select ccip from centralcontrol where location in (select id from class_details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci)));
delete from camera_details where location in (select id from class_details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci));
delete from centralcontrol where location in (select id from class_details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci));
delete from temp_centralcontrol where loc in (select id from class_Details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci));
delete from fault_info where classid  in (select id from class_details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci));
delete from readerlocation where location in (select id from class_details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci));
delete from temprature_details where location in (select id from class_Details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci));
delete from schedule where location in (select classid from class_Details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci));
delete from schedule where location=gradeids  COLLATE utf8mb4_unicode_ci;
delete from class_details where gradeid in (select id from grade_details where grade_id =gradeids COLLATE utf8mb4_unicode_ci);

delete from grade_details where grade_id= gradeids COLLATE utf8mb4_unicode_ci;
set r=1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deleteInstitute` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_deleteInstitute`(ins varchar(10), out r int)
BEGIN
if exists(select * from institute_details where ins_id=ins COLLATE utf8mb4_unicode_ci)
then
delete from machineworkinghours where Ip in (select ccip from centralcontrol where location in (select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci))));

delete from fault_info where classid in(select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci)));

delete from status where MachineIp in (select ccip from centralcontrol where location in (select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci))));

delete from camera_details where location in (select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci)));

delete from centralcontrol where location in (select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci)));

delete from temp_centralcontrol where loc in (select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci)));

delete from readerlocation where location in (select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci)));

delete from fault_info where classid in (select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci)));

delete from temprature_details where location in (select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci)));

delete from schedule where location in (select classid from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci)));

delete from schedule where location in (select grade_id from grade_details where insid in 
(select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci));

delete from schedule where location=ins COLLATE utf8mb4_unicode_ci;

delete from class_details where gradeid in (select id from grade_details where insid in (select id from institute_details 
where ins_id = ins COLLATE utf8mb4_unicode_ci));

delete from grade_details where insid in (select id from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci);

delete from noofdevices where location = ins COLLATE utf8mb4_unicode_ci;

delete from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci;

set r=1;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deleteSchedule` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_deleteSchedule`(classid varchar(50))
BEGIN
delete from schedule where location=classid  COLLATE utf8mb4_unicode_ci;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteTempTables` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteTempTables`(tbname varchar(100), out tbexist int)
BEGIN
    DECLARE CONTINUE HANDLER FOR SQLSTATE '42S02' SET @err = 1;
    SET @err = 0;
    SET @table_name = tbname;
    SET @sql_query = CONCAT('SELECT 1 FROM ',@table_name);
    PREPARE stmt1 FROM @sql_query;
    IF (@err = 1) THEN
        SET @table_exists = 0;
        set tbexist =1;
    ELSE
        SET @table_exists = 1;
        set tbexist =1;
        DEALLOCATE PREPARE stmt1;
    END IF;

	END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deleteuser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_deleteuser`(userid varchar(20))
BEGIN
if not exists(select c.userid from current_loggeduser c where c.userid=userid COLLATE utf8mb4_unicode_ci)
then
delete from doc_info where doc_info.userid = userid COLLATE utf8mb4_unicode_ci;
DELETE FROM registration 
WHERE
    registration.userid = userid COLLATE utf8mb4_unicode_ci;
DELETE FROM user_details 
WHERE
    user_id = userid COLLATE utf8mb4_unicode_ci;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getLogsPageWise` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getLogsPageWise`( pageindex int , pagesize int, out recordcount int)
BEGIN
set pageindex =ifnull(pageindex,1);
set pagesize =ifnull(pagesize,10);
set @rownumber =0;
create temporary table temp_table
select (@rownumber :=@rownumber +1) as RowNumber, cd.membername as Name , 
cd.memberid as memberID, rd.cardid as cardid, cn.class_name as Location, rd.date as time 
from reader_logs rd inner join card_register cd on cd.cardid = rd.cardid
inner join class_details cn on cn.class_id = rd.locationid order by rd.date desc;
select count(*) into recordcount from temp_table;

select * from temp_table where RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 
AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1;

drop temporary table temp_table;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetPendingTempuser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPendingTempuser`()
BEGIN
select userid , username as UserName, phone as phone, date as Date, starttime, stoptime, description, status
from temporary_user where status ='Pending' ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getSchedule` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getSchedule`(loc varchar(10))
BEGIN

if exists(select * from schedule where location =loc COLLATE utf8mb4_unicode_ci )
then
select starttime, stoptime, monday , 
tuesday, wednesday, thursday, friday, saturday, sunday, TimerOn, TimerOff 
from schedule where location=loc COLLATE utf8mb4_unicode_ci order by starttime;
	else if(loc like 'Gra%')
	then
	select ins_id into @ins from institute_details where id in (select insid from grade_details where grade_id = loc COLLATE utf8mb4_unicode_ci); 
	select starttime, stoptime, monday , 
	tuesday, wednesday, thursday, friday, saturday, sunday, TimerOn, TimerOff 
	from schedule where location=@ins COLLATE utf8mb4_unicode_ci order by starttime;
		else if(loc like 'Cla%')
		then
		select grade_id into @grade from grade_details where id in (select gradeid from class_details where classid = loc COLLATE utf8mb4_unicode_ci);
			if exists(select * from schedule where location = @grade COLLATE utf8mb4_unicode_ci)
			then
			select starttime, stoptime, monday , 
			tuesday, wednesday, thursday, friday, saturday, sunday, TimerOn, TimerOff 
			from schedule where location=@grade COLLATE utf8mb4_unicode_ci order by starttime;
				else
				select ins_id into @insid from institute_details where id in (select insid from grade_details where grade_id = @grade COLLATE utf8mb4_unicode_ci);
				select starttime, stoptime, monday , 
				tuesday, wednesday, thursday, friday, saturday, sunday, TimerOn, TimerOff 
				from schedule where location=@insid COLLATE utf8mb4_unicode_ci order by starttime;
			end if;
		end if;
	end if;
end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetStartTimer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetStartTimer`(Time1 varchar(20),Time2 varchar(20))
BEGIN
Declare loc varchar(10) default '';
DECLARE finished INTEGER DEFAULT 0;

DECLARE cur_name CURSOR FOR select classid from `table1`;
    DECLARE CONTINUE HANDLER
        FOR NOT FOUND SET finished = 1;
	create temporary table if not exists `result`(ip varchar(15) default '') ;	
    create temporary table if not exists `table1`(classid varchar(10)  default '');
    truncate TABLE `table1`;
    truncate TABLE `result`;
    select dayname(now()) into @today;
    set @true1 ='已启动';
    SET @sql := CONCAT('Insert into `table1` select distinct(location) from Schedule where TimerOn=''',@true1,
''' and StartTime =''',Time1,''' COLLATE utf8mb4_unicode_ci  and length(`', @today,'`)>0 COLLATE utf8mb4_unicode_ci');

PREPARE stmt FROM @sql;
EXECUTE stmt;

    
    OPEN cur_name;
    getip:LOOP
    fetch cur_name into loc;
     IF finished = 1 THEN
            LEAVE getip;
        END IF;
     if(loc like 'Gra%')
     then 
     Insert into `result` select ccip from centralcontrol where location in (select id from class_details 
     where gradeid in(select id from grade_details where grade_id = loc COLLATE utf8mb4_unicode_ci ));
     else if(loc like 'Ins%')
     then 
      Insert into `result` select ccip from centralcontrol where location in (select id from class_details 
     where gradeid in(select id from grade_details where insid in (select id from institute_Details where ins_id = loc COLLATE utf8mb4_unicode_ci)));
     else
     Insert into `result` select ccip from centralcontrol where location in(select id from class_details where classid= loc COLLATE utf8mb4_unicode_ci);
     end if;
     end if;
    END LOOP getip;
    close cur_name;
    Drop temporary table `table1`;
	select distinct(ip) from `result`;
	Drop temporary table `result`;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetStopTimer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetStopTimer`(Time1 varchar(20),Time2 varchar(20))
BEGIN
Declare loc varchar(10) default '';
DECLARE finished INTEGER DEFAULT 0;
DECLARE cur_name CURSOR FOR select classid from `table1`;
    DECLARE CONTINUE HANDLER
        FOR NOT FOUND SET finished = 1;

	create temporary table if not exists `result`(ip varchar(15) default '') ;	
    create temporary table if not exists `table1`(classid varchar(10)  default '');
    truncate TABLE `table1`;
    truncate TABLE `result`;
    select dayname(now()) into @today;
    set @true1 ='已启动';
    SET @sql := CONCAT('Insert into `table1` select distinct(location) from Schedule where TimerOff=''',@true1,
''' and stopTime =''',Time1,''' COLLATE utf8mb4_unicode_ci and length(`', @today,'`)>0 COLLATE utf8mb4_unicode_ci');

PREPARE stmt FROM @sql;
EXECUTE stmt;

   select * from table1; 
    OPEN cur_name;
    getip:LOOP
    fetch cur_name into loc;
     IF finished = 1 THEN
            LEAVE getip;
        END IF;
     if(loc like 'Gra%')
     then 
     Insert into `result` select ccip from centralcontrol where location in (select id from class_details 
     where gradeid in(select id from grade_details where grade_id = loc COLLATE utf8mb4_unicode_ci ));
     else if(loc like 'Ins%')
     then 
      Insert into `result` select ccip from centralcontrol where location in (select id from class_details 
     where gradeid in(select id from grade_details where insid in (select id from institute_Details where ins_id = loc COLLATE utf8mb4_unicode_ci)));
     else
     Insert into `result` select ccip from centralcontrol where location in(select id from class_details where classid= loc COLLATE utf8mb4_unicode_ci);
     end if;
     end if;
    END LOOP getip;
    close cur_name;
    Drop temporary table `table1`;
	select distinct(ip) from `result`;
	Drop temporary table `result`;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getUserDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getUserDetails`(user varchar(20))
BEGIN
/*fn_GetUserDetails*/
select userid as userid, username as username from registration where userid= user COLLATE utf8mb4_unicode_ci and currentstatus='Pending'
union
select user_id as userid, user_name as username from user_details where user_id != user COLLATE utf8mb4_unicode_ci and user_id !='admin';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getuserDetailsPending` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getuserDetailsPending`()
BEGIN
select userid, username from `cresijdatabase`.registration where currentstatus='pending';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertCamDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertCamDetails`(ip varchar(15),  portno int,
userid varchar(50), pass varchar(20),chid int,loc varchar(10),camprovider varchar(50), ins varchar(10), out result int)
BEGIN
set @res ='false';
if exists(select * from Camera_Details)
	then
	set @i= (select max(Cameraid) from Camera_Details);
	set @i =@i+1;	
	set @camname=concat('Cam', cast(@i as char(10)));
Else
	set @camname='Cam1';
    select @camname;
end if;
select id into @insids from institute_details where ins_id = ins COLLATE utf8mb4_unicode_ci;
if exists(select ccip from CentralControl where location in (select id from Class_Details where 
GradeID in (select id from Grade_details where insid = @insids )) and ccip = ip COLLATE utf8mb4_unicode_ci)
  then
  set @res= 'true';
  else
  if exists(select cameraip from Camera_details where location in (select id from Class_Details where 
GradeID in (select id from Grade_details where insid = @insids )) and cameraip = ip COLLATE utf8mb4_unicode_ci)
  then
  set @res ='true';
  else set @res='false';
  end if;
  end if;
  select @res;
  if(@res='false')
  then
  select count(cameraip) into @camcount from camera_details where location = loc COLLATE utf8mb4_unicode_ci;
  if(@camcount=4)
  then
  set result =-2;
  select result;
  else
  select id into @location from class_details where classid = loc COLLATE utf8mb4_unicode_ci;
   insert into camera_details(cameraip,camname,port,user_id,password,location,camera_provider, channelid)
   values(ip, @camname,portno,userid,pass,@location,camprovider,chid);
   set result =1;
   select result;
   end if;
  end if;
  
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertCentralControl` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertCentralControl`(ip varchar(20),insid varchar(10), location varchar(10), out result int)
BEGIN
select @res ='false';
if exists (select ins.id from centralcontrol cc join class_details cd on cc.location =cd.id
 join grade_details gd on cd.gradeID= gd.id join institute_details ins
 on gd.insid = ins.id where cc.ccip = ip COLLATE utf8mb4_unicode_ci and ins.ins_id = insid COLLATE utf8mb4_unicode_ci)
then
set @res ='true';
else 
if exists(select ins.id from camera_details cc join class_details cd on cc.location =cd.id
 join grade_details gd on cd.gradeID= gd.id join institute_details ins
 on gd.insid = ins.id where cc.cameraip = ip COLLATE utf8mb4_unicode_ci and ins.ins_id = insid COLLATE utf8mb4_unicode_ci)
then
set @res ='true';
else
set @res ='false';
end if;
end if;
if(@res = 'false')
then
select id into @cid from class_details where classID = location COLLATE utf8mb4_unicode_ci ;
insert into centralcontrol values(ip, @cid);
insert into temp_centralcontrol (ip,loc) values (ip, @cid);
set result =1;
else set result =-1;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertClass` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertClass`( Class varchar(50), 
grade varchar(10),ip varchar(20) , out Ids int)
BEGIN
select @classid;
select @num ;
select @gr;
select id into @gr from grade_details where grade_id = grade COLLATE utf8mb4_unicode_ci ;
select max(id) into @num from `class_details`;
if(@num is NULL) then
set @num =1;
else set @num= @num +1;
end if;
set @classid = concat('Class', cast(@num as char(10)));
insert into `class_details` (classID , className, gradeID)
values(@classid, Class, @gr);
if(ip!=1)
then
select id into @cid from class_details where classID = @classid COLLATE utf8mb4_unicode_ci ;
if not exists(select ins.id from centralcontrol cc join class_details cd on cc.location =cd.id
 join grade_details gd on cd.gradeID= gd.id join institute_details ins
 on gd.insid = ins.id where cc.ccip = ip COLLATE utf8mb4_unicode_ci)
 then
insert into centralcontrol values(ip, @cid);
insert into temp_centralcontrol (ip,loc) values (ip, @cid);
set Ids=1;

else
set Ids=-1;
end if;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertCurrentUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertCurrentUser`(userid varchar(20))
BEGIN
if not exists (select userid from current_loggeduser where userid=userid)
then
insert into current_loggeduser(userid) values(userid);
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertFaultInfo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertFaultInfo`(ip nvarchar(20), faultknow nvarchar(50), priority nvarchar(50),
	distName nvarchar(50), memName nvarchar(50), phone nvarchar(50), desce nvarchar(300), stat nvarchar(50), out result int  )
BEGIN
if exists(select CCIP from CentralControl where CCIP= ip )
then	

	 select location into @classid from CentralControl where CCIP=ip ;
     select @classid;
	 select gd.Grade_Id into @gradeid from Class_Details cd join grade_details gd on gd.id = cd.gradeid where cd.ID= @classid;
     select @gradeid;
	 insert into Fault_Info (classid, ip, fault_knowledge, priority,gradeid, distname, member_name,phone,description,time,LastUpdated,status) 
     values( @classid, ip,faultknow, priority, @gradeid, distName, memName, phone, desce, now(),now(), stat );
	set result = 1;
    
else
set result = -1;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertGrade` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertGrade`(insid varchar(10), gradename varchar(50))
BEGIN
select @gradeid ;
select @num ;
select max(id) into @num from `grade_details`;
if(@num is NULL) then
set @num =1;
else set @num= @num +1;
end if;
set @gradeid = concat('Grade', cast(@num as char(10)));
select @gradeid;
insert into `grade_details` (grade_id, grade_name, insid)
values(@gradeid, gradename, insid);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertInstitute` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertInstitute`(insname varchar(50) , out Ids int)
BEGIN
select @insid ;
select @num ;
select max(id) into @num from `institute_details`;
if(@num is NULL) then
select @num :=1;
else set @num= @num +1;
end if;
set @insid = concat('Ins' , cast( @num as char(10)));
insert into `cresijdatabase`.`institute_details` (ins_name, ins_id)
values (insname, @insid);
set Ids = ( select id from `cresijdatabase`.`institute_details` where ins_id = @insid COLLATE utf8mb4_unicode_ci);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertOnlyGrade` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertOnlyGrade`(insid varchar(10), gradename varchar(50))
BEGIN
select @gradeid ;
select @insids;
select id into @insids from institute_details where ins_id = insid COLLATE utf8mb4_unicode_ci;
select @num ;
select max(id) into @num from `grade_details`;
if(@num is NULL) then
set @num =1;
else set @num= @num +1;
end if;
set @gradeid = concat('Grade', cast(@num as char(10)));
insert into `grade_details` (grade_id, grade_name, insid)
values(@gradeid, gradename, @insids);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertorUpdateDevicesCount` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertorUpdateDevicesCount`(projector int, comp int, record int, actemp int, scr int, loc varchar(10))
BEGIN
select count(ccip) into @cc from centralcontrol where location in (select id from class_details where gradeid in (
select id from grade_details where insid in (select id from institute_details where ins_id = loc COLLATE utf8mb4_unicode_ci)));
if exists(select * from noofdevices where location = loc  COLLATE utf8mb4_unicode_ci)
then
update noofdevices set  proj = projector , pc =comp, recorder = record, ac = actemp, screen = scr where location = loc  COLLATE utf8mb4_unicode_ci;
else
Insert into noofdevices (proj, pc, recorder, ac, cc, screen, location) values
(projector, comp, record, actemp, @cc, scr, loc);
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertSchedule` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertSchedule`(start datetime, stop datetime, timer varchar(10),
mon varchar(30), tues varchar(30), wed varchar(30), thurs varchar(30), fri varchar(30),
sat varchar(30), sun varchar(30), loc varchar(10))
BEGIN
/*updateschedule*/
insert into schedule values( start, stop, timer, mon, tues,wed,thurs,fri,sat,sun,loc);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertTemperature` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertTemperature`(ip varchar(20), temp decimal(10,2),
humid decimal(10,2), pm25 decimal(10,2), pm10 decimal(10,2) )
BEGIN
select location into @loc from centralcontrol where ccip =ip  COLLATE utf8mb4_unicode_ci;
insert into temprature_details values(@loc, temp, humid, pm25,pm10, now());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertUserLogs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertUserLogs`(userid varchar(20), task varchar(300))
BEGIN
/*sp_userLogs*/
insert into user_logs values ( userid, task, now());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_login` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_login`(userid varchar(20) , 
	phone_no varchar(15) ,
	user_password varchar(20),
	out rolename int ,
	 out usernametemp varchar(50),
	out userids varchar(20) )
BEGIN

if exists(select user_id from cresijdatabase.user_details where phone=phone_no COLLATE utf8mb4_unicode_ci and password =user_password COLLATE utf8mb4_unicode_ci) then
select role_id into rolename from cresijdatabase.user_details where phone = phone_no COLLATE utf8mb4_unicode_ci;
select user_id into userids from cresijdatabase.user_details where phone = phone_no COLLATE utf8mb4_unicode_ci;
select user_name into usernametemp from cresijdatabase.user_details where phone = phone_no COLLATE utf8mb4_unicode_ci;

elseif exists (select user_id from cresijdatabase.user_details where user_id=userid COLLATE utf8mb4_unicode_ci
 and password =user_password COLLATE utf8mb4_unicode_ci) then
select role_id into rolename from cresijdatabase.user_details where user_id=userid COLLATE utf8mb4_unicode_ci;
select user_id into userids from cresijdatabase.user_details where user_id=userid COLLATE utf8mb4_unicode_ci;
select user_name into usernametemp from cresijdatabase.user_details where user_id=userid COLLATE utf8mb4_unicode_ci;
else
set rolename=0;
 end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_LoginForTempUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_LoginForTempUser`(usertemp varchar(20), pass varchar(20), time1 varchar(6), ip varchar(15), out result int, out uname varchar(50))
BEGIN
if exists(select * from temporary_user where userid = usertemp COLLATE utf8mb4_unicode_ci  and password = pass COLLATE utf8mb4_unicode_ci )
then 
if exists(select username from temporary_user where starttime <= time1 COLLATE utf8mb4_unicode_ci and stoptime > time1 COLLATE utf8mb4_unicode_ci 
and userid = usertemp COLLATE utf8mb4_unicode_ci
 and date = date(now()) COLLATE utf8mb4_unicode_ci and Status ='Approved' )
then
select username into uname from temporary_user where userid = usertemp COLLATE utf8mb4_unicode_ci;
set result=1;
else 
set result=-1;
end if;
else
set result =-2;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_LogoutTempUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_LogoutTempUser`(time1 varchar(6), time2 varchar(6))
BEGIN
if exists(select * from temporary_user where date= date(now()) and stoptime >=time1 COLLATE utf8mb4_unicode_ci)
then
select userid from temporary_user where date= date(now()) and stoptime =time1 COLLATE utf8mb4_unicode_ci;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_newuserbyadmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_newuserbyadmin`(userid varchar(20), username varchar(50),
password varchar(20), phone varchar(15), roleid int)
BEGIN
 insert into user_details (user_id, user_name, password, role_id,phone)
  values(userid, username, password, roleid, phone);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registerNewCard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registerNewCard`(sno int, memid varchar(30), memname varchar(50),
cardid varchar(20), state varchar(20), comment varchar(100), pendingloc varchar(200)
, locids varchar(200), rights varchar(50), out result int)
BEGIN
if not exists(select cardid from card_register where cardid= card_id)
then
insert into card_register values(cardid, sno, memname, memid,rights,
'',comment, state, pendingloc,locids);
set result =1;
else
set result=-1;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RegisterOneTimeUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_RegisterOneTimeUser`(tempUserName varchar(50),tempuserid varchar(20), pass varchar(20), 
ip varchar(15), tempdate date, time1 varchar(6), 
time2 varchar(6),Stat varchar(10), phone varchar(12), desce varchar(110) , out duplicate int)
BEGIN
if exists(select * from user_details where user_id = tempuserid COLLATE utf8mb4_unicode_ci )
then
set duplicate=-1;
else
if exists(select * from temporary_user where Userid = tempuserid COLLATE utf8mb4_unicode_ci )
then
set duplicate=-1;
else
select className into @class from class_details where id in(select location from centralcontrol where ccip = ip COLLATE utf8mb4_unicode_ci);
Insert into temporary_user values( tempuserid,tempUserName, pass,@class,ip,tempdate,time1,time2,stat,phone,desce);
set duplicate=1;
end if;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registration` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registration`(userids varchar(20), username varchar(50),
password varchar(20), phone_number varchar(15), out k int)
BEGIN
set @step =1;
if not exists(select User_Id from User_Details where User_Id=Userids COLLATE utf8mb4_unicode_ci)
 then
 set @step =2;
 select @step;
	if not exists(select Phone from User_Details where Phone =Phone_Number  COLLATE utf8mb4_unicode_ci)
	then
    set @step =3;
 select @step;
	if not exists(select USERID from Registration where USERID=userids COLLATE utf8mb4_unicode_ci)
	then
    set @step =4;
 select @step;
	if not exists(select Phone from Registration where Phone = Phone_Number COLLATE utf8mb4_unicode_ci)
	then
    set @step =5;
 select @step;
		insert into registration (userid, username, password, phone)
		values(userids, username, password, phone_number);    
	set k=1;
    set @step =6;
 select @step;
	end if;
	else	
	set k=-4;
	end if;
	else	
	set k=-4;
	end if;
	else
	set k=-3;
    end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_rejectOneTimeUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_rejectOneTimeUser`(tempuser varchar(20), out r int)
BEGIN
if exists(select * from temporary_user where userid = tempuser COLLATE utf8mb4_unicode_ci)
then
delete from temporary_user where userid = tempuser COLLATE utf8mb4_unicode_ci;
set r=1;
else
set r=-1;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_scancard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_scancard`( currentcardid varchar(50), out currentstate varchar(15))
BEGIN
/* procdure scancard*/
if exists(select cardid from card_register where cardid  = currentcardid)
then
select state into currentstate from card_register where cardid = currentcardid;
else
insert into temp_cardregister (cardid, state) values(currentcardid, 'unregistered');
set currentstate ='unregistered';
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_tempCardRegister` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_tempCardRegister`(sno int, memid varchar(30), memname varchar(50),
card_id varchar(50), comment varchar(100), state varchar(20), 
access varchar(200), selectaccess varchar(20), out result int)
BEGIN
if not exists(select cardid from card_register where cardid= card_id)
then
insert into temp_cardregister values(sno, memid, memname, 
card_id, comment, state, access, selectacess);
set result =1;
else
set result = -5;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_timerMachineUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_timerMachineUpdate`( timer1 varchar(10), loc varchar(10))
BEGIN
Declare ips varchar(15);
DECLARE finished INTEGER DEFAULT 0;
DECLARE cur_name CURSOR FOR select ip from changetimer;
    DECLARE CONTINUE HANDLER
        FOR NOT FOUND SET finished = 1;
        
        create temporary table changetimer(ip varchar(15));
if(loc like 'Gra%')
     then 
	 Insert into changetimer select ccip from centralcontrol where location in (select id from class_details 
     where gradeid in(select id from grade_details where grade_id = loc COLLATE utf8mb4_unicode_ci));
     else if(loc like 'Ins%')
     then 
     Insert into changetimer select ccip from centralcontrol where location in (select id from class_details 
     where gradeid in(select id from grade_details where insid in (select id from institute_Details where ins_id = loc COLLATE utf8mb4_unicode_ci)));
     else
     Insert into changetimer select ccip from centralcontrol where location in(select id from class_details where classid= loc COLLATE utf8mb4_unicode_ci);
     end if;
     end if;
     
      OPEN cur_name;
    getip:LOOP
    fetch cur_name into ips;
     IF finished = 1 THEN
            LEAVE getip;
        END IF;
        update temp_centralcontrol
			set timer= timer1 
            where ip = ips COLLATE utf8mb4_unicode_ci;
        END LOOP getip;
    close cur_name;
    Drop temporary table changetimer;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateCamera` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateCamera`(ip varchar(20), portno int, userid varchar(50), 
pass varchar(20), cameraName varchar(10), chid int)
BEGIN
update camera_details
set cameraip=ip, port = portno, user_id=userid, password= pass, channelid = chid  
where camname = cameraName COLLATE utf8mb4_unicode_ci;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateCard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateCard`(cid varchar(50),memid varchar(30), name varchar(50),
loc varchar(200), pending varchar(200), locid varchar(200), comment varchar(100))
BEGIN
/*UpdateRegCard*/
update card_register
	set memberid = memid,membername=name,
	comment=comment,  location=loc,
	pending_loc=pending,
	locationid = locid
	 where cardid =cid COLLATE utf8mb4_unicode_ci;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateCardLocations` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateCardLocations`(card_id varchar(50), ip varchar(20))
BEGIN
/* procedure regOnloc*/
declare locid int;
select cd.class_name into @locname from
 class_details cd join central_control cc on cd.id =cc.location where cc.cc_ip = ip;
 select cd.id into locid from class_details cd join central_control cc
 on cd.id =cc.location where cc.cc_ip = ip;
if exists (select pending_loc from card_register where pending_loc like concat( '%',locid,'%') and cardid=card_id)
then
if(select ifnull(location,'') from card_register where cardid=card_id)
then
select locid, @locnames;
update card_register set location =concat( @locnames ,','),
pending_loc = replace(pending_loc,concat(locid,','),'') where cardid=card_id;
else
update card_register
set location =concat(location , @locnames,','),
pending_loc = replace(pending_loc,concat(locid,','),'') where cardid=card_id;
end if;
 update card_register
	 set State='Registered' where pending_loc=''and location!='';
	 update card_register
	 set State='Pending' where pending_loc!='' ;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateCentralControl` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateCentralControl`(Ip varchar(20), className varchar(10))
BEGIN
select id into @loca from class_details where ClassID = className COLLATE utf8mb4_unicode_ci;
update centralcontrol 
set ccip = Ip where location = @loca;

select Ip into @tempip;
update temp_centralcontrol set ip= @tempip where loc=@loca;
update status
set MachineIp = Ip where Class = @loca;
update fault_info set ip = Ip where classid = @loca;
update machineworkinghours set IP =Ip where IP in(select ccip from centralcontrol where location =@loca);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateClass` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateClass`(className varchar(50), Id varchar(10))
BEGIN
update class_details
set classname =className where classID=Id COLLATE utf8mb4_unicode_ci;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateGrade` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateGrade`(gradeName varchar(50), Id varchar(10))
BEGIN
update grade_details
set grade_name = gradeName where grade_id = Id COLLATE utf8mb4_unicode_ci;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateInstitute` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateInstitute`( Id varchar(10),InsName varchar(50))
BEGIN
update institute_details
set ins_name = InsName where ins_id=Id COLLATE utf8mb4_unicode_ci;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateMachineStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateMachineStatus`(tip varchar(20),tstatus varchar(10), tworkstatus varchar(10),
tpcstatus varchar(10), tmediasignal varchar(30), tprojstat varchar(10), tscreen varchar(10), tcurtain varchar(10),
tlight varchar(10), tcentrallock varchar(10), tclasslock  varchar(10), tpodiumlock varchar(10) )
BEGIN
if exists(select * from temp_centralcontrol where ip=ip)
then
	if(status = 'Offline')
	then
    update temp_centralcontrol set status='Offline', workstatus= '--', 
    pcstatus='--', mediasignal = '--',
    projectorstatus = '--', screen='--', curtain ='--', light ='--',
    centrallock='--', classlock ='--', podiumlock = '--' where ip= tip;
    else
    update temp_centralcontrol
    set status=tstatus, workstatus= tworkstatus, pcstatus=tpcstatus, mediasignal = tmediasignal,
    projectorstatus = tprojstatus, screen=tscreen, curtain =tcurtain, light =tlight,
    centrallock=tcentrallock, classlock =tclasslock, podiumlock = tpodiumlock where ip= tip;
    end if;
else
select location into @loc from central_control where cc_ip = tip;
insert into temp_centralcontrol values(tip,@loc,'--','--','--','--','--','--','--','--','--','--','--');
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateOneTimeuser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateOneTimeuser`(tempuser varchar(20),stat varchar(20))
BEGIN
update temporary_user set Status= stat where userid = tempuser COLLATE utf8mb4_unicode_ci;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateSchedule` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateSchedule`(loc varchar(10), starttime varchar(10), stoptime varchar(10), timer1 varchar(10), timer2 varchar(10),
 mon varchar(30), tue varchar(30), wed varchar(30), thu varchar(30), fri varchar(30), sat varchar(30),
 sun varchar(30))
BEGIN
	
insert into Schedule (starttime, stoptime, TimerOn,TimerOff, monday, tuesday, wednesday, thursday,
 friday, saturday, sunday,location)
 values(starttime, stoptime, timer1,timer2, mon, tue, wed, thu, fri,sat,sun,loc);
 

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateStatus`(ip varchar(15),mstat varchar(10), wstat varchar(10), cstat varchar(10))
BEGIN
if exists (select ccip from centralcontrol where ccip = ip COLLATE utf8mb4_unicode_ci)
then
select location into @loc from centralcontrol where ccip = ip COLLATE utf8mb4_unicode_ci;
if exists (select * from status where MachineIp = ip COLLATE utf8mb4_unicode_ci)
then
update status set MachineStatus = mstat, WorkStatus = wstat , PCStatus = cstat
where MachineIP = ip COLLATE utf8mb4_unicode_ci;
else
Insert into status values(@loc, ip, mstat, wstat, cstat);
end if;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UserRoleSave` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UserRoleSave`(tuserid varchar(20), trole int)
BEGIN
/*sp_UserRolSave*/
select username into @username from registration where userid =tuserid COLLATE utf8mb4_unicode_ci;
select password into @pass from registration where userid =tuserid COLLATE utf8mb4_unicode_ci;
select phone into @ph from registration where userid =tuserid COLLATE utf8mb4_unicode_ci;
insert into user_details values(tuserid,@username,@pass,trole,@ph);
delete from registration where userid=tuserid COLLATE utf8mb4_unicode_ci;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_WeekTempDatabyIns` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_WeekTempDatabyIns`(loc varchar(10))
BEGIN
Select CASE     
WHEN date_format(Date,'%d') < 8 THEN 'week 1'     
WHEN date_format(Date,'%d') < 15 THEN 'week 2'     
WHEN date_format(Date,'%d') < 22 THEN 'week 3'  
when date_format(Date,'%d') <29 Then 'week 4'    
 ELSE 'week 5' END AS weekOfMonth,
 Round(Avg(temperature),2) as temp, Round(AVG(Humidity),2) as humidity, 
 Round(avg(pm25),2) as pm25, Round(avg(pm10),2) as pm10 
 from temprature_details  td join Class_Details cd 
 on td.Location=cd.ID join Grade_Details gd on      
 gd.ID=cd.GradeID join Institute_Details id on       
 id.ID=gd.InsID where id.ins_id=loc COLLATE utf8mb4_unicode_ci and month(date) =month(now()) 
 group by month(date);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-04-13 16:37:58

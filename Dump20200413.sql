-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: localhost    Database: organisationdatabase
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
-- Table structure for table `buildingdetails`
--

DROP TABLE IF EXISTS `buildingdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `buildingdetails` (
  `id` int(11) NOT NULL,
  `BuildingName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buildingdetails`
--

LOCK TABLES `buildingdetails` WRITE;
/*!40000 ALTER TABLE `buildingdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `buildingdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classdetails`
--

DROP TABLE IF EXISTS `classdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classdetails` (
  `classID` int(11) NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(45) NOT NULL,
  `teachingBuilding` varchar(45) NOT NULL,
  `floor` varchar(20) NOT NULL,
  `Seats` int(11) NOT NULL,
  `CCEquipIP` varchar(20) NOT NULL,
  `camipS` varchar(20) NOT NULL,
  `camipN` varchar(20) NOT NULL,
  `desktopip` varchar(20) NOT NULL,
  `recordingEquip` varchar(20) NOT NULL,
  `ccmac` varchar(20) NOT NULL,
  `ccport` int(11) NOT NULL,
  `ccuserid` varchar(20) NOT NULL,
  `ccpass` varchar(20) NOT NULL,
  `camSmac` varchar(20) NOT NULL,
  `camSport` int(11) NOT NULL,
  `camSuserid` varchar(20) NOT NULL,
  `camSpass` varchar(20) NOT NULL,
  `camNmac` varchar(20) NOT NULL,
  `camNport` int(11) NOT NULL,
  `camNuserid` varchar(20) NOT NULL,
  `camNpass` varchar(20) NOT NULL,
  `deskmac` varchar(20) NOT NULL,
  `deskport` int(11) NOT NULL,
  `deskuserid` varchar(20) NOT NULL,
  `deskpass` varchar(20) NOT NULL,
  `recordermac` varchar(20) NOT NULL,
  `recorderport` int(11) NOT NULL,
  `recorderuserid` varchar(20) NOT NULL,
  `recorderpass` varchar(20) NOT NULL,
  `callforhelp` varchar(20) NOT NULL,
  PRIMARY KEY (`classID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classdetails`
--
-- ORDER BY:  `classID`

LOCK TABLES `classdetails` WRITE;
/*!40000 ALTER TABLE `classdetails` DISABLE KEYS */;
INSERT INTO `classdetails` (`classID`, `ClassName`, `teachingBuilding`, `floor`, `Seats`, `CCEquipIP`, `camipS`, `camipN`, `desktopip`, `recordingEquip`, `ccmac`, `ccport`, `ccuserid`, `ccpass`, `camSmac`, `camSport`, `camSuserid`, `camSpass`, `camNmac`, `camNport`, `camNuserid`, `camNpass`, `deskmac`, `deskport`, `deskuserid`, `deskpass`, `recordermac`, `recorderport`, `recorderuserid`, `recorderpass`, `callforhelp`) VALUES (1,'Class 2','明德楼','1层',80,'172.168.11.16','172.168.11.17','172.168.11.18','172.168.11.19','172.168.11.20','21:21:21:21',1200,'admin','admin123','11:11:21:21',1200,'admin','admin123','11:65:66:55',1100,'admin','admin123','44:33:22:22',1100,'admin','admin123','22:66:77:33',1200,'admin','admin123','12312312'),(6,'Class 4','building 5','3nd',50,'172.168.31.11','172.168.31.12','172.168.31.13','172.168.31.14','172.168.31.15','12:22:22:23',1300,'admin','abc123','12:22:22:12',1200,'admin','admin123','12:22:22:22',1100,'admin','admin1','12:22:54:42',1200,'admin','admin123','12:12:32:11',2200,'admin','admin1','12121221'),(7,'Class 5','building 2','3nd',50,'172.168.31.11','172.168.31.12','172.168.31.13','172.168.31.14','172.168.31.15','12:22:22:23',1300,'admin','abc123','12:22:22:12',1200,'admin','admin123','12:22:22:22',1100,'admin','admin1','12:22:54:42',1200,'admin','admin123','12:12:32:11',2200,'admin','admin1','12121221'),(8,'Class 6','building 3','3nd',50,'172.168.31.11','172.168.31.12','172.168.31.13','172.168.31.14','172.168.31.15','12:22:22:23',1300,'admin','abc123','12:22:22:12',1200,'admin','admin123','12:22:22:22',1100,'admin','admin1','12:22:54:42',1200,'admin','admin123','12:12:32:11',2200,'admin','admin1','12121221');
/*!40000 ALTER TABLE `classdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classroomdetails`
--

DROP TABLE IF EXISTS `classroomdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classroomdetails` (
  `classid` int(11) NOT NULL,
  `Classname` varchar(50) COLLATE utf8mb4_0900_as_ci NOT NULL,
  `BuildingId` int(11) DEFAULT NULL,
  PRIMARY KEY (`classid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_as_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classroomdetails`
--
-- ORDER BY:  `classid`

LOCK TABLES `classroomdetails` WRITE;
/*!40000 ALTER TABLE `classroomdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `classroomdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `course` (
  `CourseID` varchar(50) NOT NULL,
  `CourseName` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`CourseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--
-- ORDER BY:  `CourseID`

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departmentdetail`
--

DROP TABLE IF EXISTS `departmentdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departmentdetail` (
  `SerialNo` int(11) NOT NULL AUTO_INCREMENT,
  `departmentName` varchar(100) NOT NULL,
  `departmentCode` int(3) unsigned zerofill NOT NULL,
  PRIMARY KEY (`SerialNo`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departmentdetail`
--
-- ORDER BY:  `SerialNo`

LOCK TABLES `departmentdetail` WRITE;
/*!40000 ALTER TABLE `departmentdetail` DISABLE KEYS */;
INSERT INTO `departmentdetail` (`SerialNo`, `departmentName`, `departmentCode`) VALUES (1,'test',001),(2,'test1',002),(3,'test2',003),(4,'science',004),(5,'001',005),(6,'math',006),(7,'social',007);
/*!40000 ALTER TABLE `departmentdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devicesdetails`
--

DROP TABLE IF EXISTS `devicesdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `devicesdetails` (
  `Ip` varchar(20) NOT NULL,
  `Mac` varchar(30) NOT NULL,
  `port` int(11) NOT NULL,
  `userid` varchar(50) NOT NULL,
  `password` varchar(20) NOT NULL,
  PRIMARY KEY (`Ip`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devicesdetails`
--
-- ORDER BY:  `Ip`

LOCK TABLES `devicesdetails` WRITE;
/*!40000 ALTER TABLE `devicesdetails` DISABLE KEYS */;
INSERT INTO `devicesdetails` (`Ip`, `Mac`, `port`, `userid`, `password`) VALUES ('172.168.11.11','23:23:23:23',2000,'admin','admin123'),('172.168.11.12','23:23:63:63',1000,'admin','admin123'),('172.168.11.13','23:23:23:23',2000,'admin','admin123'),('172.168.11.14','23:23:23:43',3000,'admin','admin123'),('172.168.11.15','23:23:63:43',4000,'admin','admin123'),('172.168.11.21','23:23:63:63',4000,'admin','admin123'),('172.168.11.22','23:23:63:63',4000,'admin','admin123'),('172.168.11.23','23:23:63:63',4000,'admin','admin123'),('172.168.11.24','23:23:63:63',4000,'admin','admin123'),('172.168.11.25','23:23:63:63',4000,'admin','admin123'),('172.168.21.21','23:23:63:63',4000,'admin','admin123'),('172.168.21.22','23:23:63:63',4000,'admin','admin123'),('172.168.21.23','23:23:63:63',4000,'admin','admin123'),('172.168.21.24','23:23:63:63',4000,'admin','admin123'),('172.168.21.25','23:23:63:63',4000,'admin','admin123');
/*!40000 ALTER TABLE `devicesdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operationmgmt`
--

DROP TABLE IF EXISTS `operationmgmt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `operationmgmt` (
  `devicename` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `assetno` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `model` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `specification` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `devicetype` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `price` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `factory` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `dateofmanufacture` date DEFAULT NULL,
  `dateofpurchase` date DEFAULT NULL,
  `dateofdelivery` date DEFAULT NULL,
  `warrantytime` tinyint(3) DEFAULT NULL,
  `locationType` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `equipmentstatus` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `serialno` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`serialno`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operationmgmt`
--
-- ORDER BY:  `serialno`

LOCK TABLES `operationmgmt` WRITE;
/*!40000 ALTER TABLE `operationmgmt` DISABLE KEYS */;
INSERT INTO `operationmgmt` (`devicename`, `assetno`, `model`, `specification`, `devicetype`, `price`, `factory`, `dateofmanufacture`, `dateofpurchase`, `dateofdelivery`, `warrantytime`, `locationType`, `equipmentstatus`, `serialno`) VALUES ('﻿\'W1700\'',' \'ZC00001\'',' \'model01\'',' \'specs\'',' \'type\'',' 40000',' \'zhuyuan\'','2019-10-02','2020-01-02','2020-01-02',3,' public',' working',24),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',25),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',26),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',27),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',28),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',29),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',30),('﻿\"\'W1700\'',' \'ZC00001\'',' \'model01\'',' \'specs\'',' \'type\'',' 40000',' \'房改房zhuyuan\'','2019-10-02','2020-01-02','2020-01-02',3,' public',' working\"',31),('\"\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working\"',32),('\"\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working\"',33),('\"\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working\"',34),('\"\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working\"',35),('\"\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working\"',36),('\"\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working\"',37),('﻿\'W1700\'',' \'ZC00001\'',' \'model01\'',' \'specs\'',' \'type\'',' 40000',' \'房改房zhuyuan\'','2019-10-02','2020-01-02','2020-01-02',3,' public',' working',38),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',39),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',40),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',41),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',42),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',43),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',44),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',45),('﻿\'W1700\'',' \'ZC00001\'',' \'model01\'',' \'specs\'',' \'type\'',' 40000',' \'???zhuyuan\'','2019-10-02','2020-01-02','2020-01-02',3,' public',' working',46),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',47),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',48),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',49),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',50),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',51),('\'W1700\'',' \'ZC00002\'',' \'model02\'',' \'specs\'',' \'type\'',' 30000',' \'zhuyuan\'','2019-10-02','2020-01-07','2020-01-07',2,' \'public\'',' working',52);
/*!40000 ALTER TABLE `operationmgmt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organisationdetails`
--

DROP TABLE IF EXISTS `organisationdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organisationdetails` (
  `SerialNo` int(11) NOT NULL AUTO_INCREMENT,
  `deptCode` int(3) unsigned zerofill NOT NULL,
  `BusinessCtrlCode` varchar(45) NOT NULL,
  `HigherOffice` varchar(45) NOT NULL,
  `QueueNumber` int(11) NOT NULL,
  `Public` varchar(10) NOT NULL,
  `Notes` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`SerialNo`)
) ENGINE=InnoDB AUTO_INCREMENT=77 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organisationdetails`
--
-- ORDER BY:  `SerialNo`

LOCK TABLES `organisationdetails` WRITE;
/*!40000 ALTER TABLE `organisationdetails` DISABLE KEYS */;
INSERT INTO `organisationdetails` (`SerialNo`, `deptCode`, `BusinessCtrlCode`, `HigherOffice`, `QueueNumber`, `Public`, `Notes`) VALUES (1,001,'bus001','highoff1',12,'public','testing data'),(2,002,'bus002','highoff2',13,'public','testing data 2'),(4,007,'bus007','北京大学',15,'private','testing'),(5,004,'bus005','校办',16,'private','testing from web'),(25,004,'bus002','北京大学',12,'public','testing'),(74,002,'bus006','机关党委',15,'public','test');
/*!40000 ALTER TABLE `organisationdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedule` (
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
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` (`teacherId`, `teacherName`, `CourseId`, `className`, `Coursename`, `weekStart`, `weekEnd`, `dayno`, `section`) VALUES ('t001','first teacher','c001','class 1','science','2','5',3,7),('t002','second teacher','c002','class 1','math','1','6',2,5),('t003','third teacher','c003','class 1','english','1','6',2,5),('t001','first teacher','c001','class 2','science','1','5',3,7),('t001','first teacher','c001','class 3','science','7','15',4,9),('t001','first teacher','c001','class 4','science','23','30',5,11);
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `studentdata`
--

DROP TABLE IF EXISTS `studentdata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `studentdata` (
  `studentid` varchar(20) NOT NULL,
  `studentname` varchar(45) NOT NULL,
  `gender` varchar(10) NOT NULL,
  `age` int(11) NOT NULL,
  `deptcode` varchar(20) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `idcard` varchar(30) NOT NULL,
  `onecard` varchar(30) NOT NULL,
  PRIMARY KEY (`studentid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `studentdata`
--
-- ORDER BY:  `studentid`

LOCK TABLES `studentdata` WRITE;
/*!40000 ALTER TABLE `studentdata` DISABLE KEYS */;
INSERT INTO `studentdata` (`studentid`, `studentname`, `gender`, `age`, `deptcode`, `phone`, `idcard`, `onecard`) VALUES ('S002','sachi','男',33,'国土资源学院','43645423645','fsd341','wre312');
/*!40000 ALTER TABLE `studentdata` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacherdata`
--

DROP TABLE IF EXISTS `teacherdata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacherdata` (
  `TeacherID` varchar(30) NOT NULL,
  `TeacherName` varchar(100) NOT NULL,
  `gender` varchar(10) NOT NULL,
  `age` int(11) NOT NULL,
  `faculty` varchar(45) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `idcard` varchar(30) NOT NULL,
  `onecard` varchar(30) NOT NULL,
  PRIMARY KEY (`TeacherID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacherdata`
--
-- ORDER BY:  `TeacherID`

LOCK TABLES `teacherdata` WRITE;
/*!40000 ALTER TABLE `teacherdata` DISABLE KEYS */;
INSERT INTO `teacherdata` (`TeacherID`, `TeacherName`, `gender`, `age`, `faculty`, `phone`, `idcard`, `onecard`) VALUES ('T-001','usha','女',22,'国土资源学院','45784578','lo097','ko0978'),('t101','some','f',22,'science','87878787878','qwer123','zxcv1234'),('t102','some','f',22,'science','87878787878','qwer123','zxcv1234'),('t103','usha','男',22,'经济与管理学院','32343234321','ert3213','ury32322'),('t104','usha','男',22,'经济与管理学院','32321232232','ew2312','wq1234'),('t106','yfgd','男',34,'经济与管理学院','542345323','gtr4523','erwerwe4'),('t107','ytrehgf','女',22,'国土资源学院','54324532433','453ryt645','hgf546yuti'),('t108','udef','男',22,'经济与管理学院','32321256787','yt54rt','tr43er'),('t109','ytki','男',22,'经济与管理学院','3323232432','tyt65','u6754h');
/*!40000 ALTER TABLE `teacherdata` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userdetails`
--

DROP TABLE IF EXISTS `userdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userdetails` (
  `SerialNo` int(11) NOT NULL AUTO_INCREMENT,
  `LoginID` varchar(20) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `PersonType` varchar(45) NOT NULL,
  `DeptCode` varchar(45) NOT NULL,
  `PersonnelStatus` varchar(45) NOT NULL,
  `telephone` varchar(15) NOT NULL,
  `Notes` varchar(200) DEFAULT NULL,
  `Password` varchar(20) NOT NULL,
  PRIMARY KEY (`SerialNo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userdetails`
--
-- ORDER BY:  `SerialNo`

LOCK TABLES `userdetails` WRITE;
/*!40000 ALTER TABLE `userdetails` DISABLE KEYS */;
INSERT INTO `userdetails` (`SerialNo`, `LoginID`, `UserName`, `PersonType`, `DeptCode`, `PersonnelStatus`, `telephone`, `Notes`, `Password`) VALUES (1,'admin','admin','teacher','4','active','147852145','editing','usha123');
/*!40000 ALTER TABLE `userdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userregistration`
--

DROP TABLE IF EXISTS `userregistration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userregistration` (
  `UserName` varchar(50) NOT NULL,
  `Userid` varchar(30) NOT NULL,
  `userpassword` varchar(20) NOT NULL,
  `Departmentid` int(11) NOT NULL,
  `Remarks` varchar(100) NOT NULL,
  `Status` varchar(15) NOT NULL DEFAULT 'Pending',
  `UserType` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Registration by user';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userregistration`
--
-- ORDER BY:  `Userid`

LOCK TABLES `userregistration` WRITE;
/*!40000 ALTER TABLE `userregistration` DISABLE KEYS */;
/*!40000 ALTER TABLE `userregistration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'organisationdatabase'
--

--
-- Dumping routines for database 'organisationdatabase'
--
/*!50003 DROP PROCEDURE IF EXISTS `sp_SaveClassData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_SaveClassData`(cname varchar(45), tbuild varchar(45), tfloor varchar(20), tseat int , ccip varchar(20), cam1ip varchar(20),
 cam2ip varchar(20), deskip varchar(20), recip varchar(20), cmac varchar(20), cport int, cid varchar(20), cpass varchar(20), 
 cam1mac varchar(20), cam1port int, cam1id varchar(20), cam1pass varchar(20) ,cam2mac varchar(20), cam2port int, cam2id varchar(20),
 cam2pass varchar(20), deskmac varchar(20), deskport int, deskid varchar(20), deskpass varchar(20), recmac varchar(20), recport int,
  recid varchar(20), recpass varchar(20), callhelp varchar(20))
BEGIN
insert into classdetails(`ClassName`,`teachingBuilding`,`floor`,`Seats`,`CCEquipIP`,`camipS`,`camipN`,
`desktopip`,`recordingEquip`,`ccmac`,`ccport`,`ccuserid`,`ccpass`,`camSmac`,`camSport`,`camSuserid`,
`camSpass`,`camNmac`,`camNport`,`camNuserid`,`camNpass`,`deskmac`,`deskport`,`deskuserid`,`deskpass`,
`recordermac`,`recorderport`,`recorderuserid`,`recorderpass`,`callforhelp`) 
 values(cname, tbuild, tfloor, tseat, ccip, cam1ip, cam2ip, deskip, recip, cmac, cport, cid, cpass, cam1mac, 
cam1port, cam1id, cam1pass, cam2mac, cam2port, cam2id, cam2pass, deskmac, deskport, deskid, deskpass, recmac, recport, recid, recpass,
callhelp);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_SaveOrganisationDeptData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_SaveOrganisationDeptData`( deptname varchar(100), buscode varchar(45), 
highoff varchar(45), que int , typeaccess varchar(10),notes varchar(200))
BEGIN
if exists(select departmentcode from departmentdetail where departmentname = deptname COLLATE utf8mb4_unicode_ci)
then
select departmentcode into @num from departmentdetail where departmentname = deptname COLLATE utf8mb4_unicode_ci;
else
select max(serialNo) into @num from departmentdetail;
if(@num is null)
then
set @num = 1;
else set @num = @num+1;
insert into departmentdetail (departmentname, departmentcode) values (deptname , @num);
end if;
end if;

select departmentcode into @dcode from departmentdetail where departmentname =deptname COLLATE utf8mb4_unicode_ci;
insert into organisationdetails (deptcode, businessCtrlCode, HigherOffice, QueueNumber,Public, Notes) values ( @dcode, buscode, highoff, que, typeaccess, notes);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_SaveStudentData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_SaveStudentData`(id varchar(30), tname varchar(100), gend varchar(10), age int, fac varchar(45), ph varchar(20),
idcrd varchar(30), onecrd varchar(30))
BEGIN
if not exists( select studentname from studentdata where studentid = id COLLATE utf8mb4_unicode_ci )
then
insert into studentdata values (id, tname, gend, age, fac, ph, idcrd, onecrd);

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_SaveTeacherData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_SaveTeacherData`(id varchar(30), tname varchar(100), gend varchar(10), age int, fac varchar(45), ph varchar(20),
idcrd varchar(30), onecrd varchar(30))
BEGIN
if not exists( select teachername from teacherdata where teacherid = id COLLATE utf8mb4_unicode_ci )
then
insert into teacherdata values (id, tname, gend, age, fac, ph, idcrd, onecrd);

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_SaveUserData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_SaveUserData`(id varchar(20), uname varchar(50), ptype varchar(45), 
deptname varchar(45), stats varchar(45), phone varchar(15), note varchar(200), pass varchar(20))
BEGIN
if not exists(select loginId from userdetails where LoginId = id  COLLATE utf8mb4_unicode_ci)
then
if exists(select departmentcode from departmentdetail where departmentname = deptname COLLATE utf8mb4_unicode_ci)
then
select departmentcode into @num from departmentdetail where departmentname = deptname COLLATE utf8mb4_unicode_ci;
else
select max(serialNo) into @num from departmentdetail;
if(@num is null)
then
set @num = 1;
else set @num = @num+1;
insert into departmentdetail (departmentname, departmentcode) values (deptname , @num);
end if;
end if;

select departmentcode into @dcode from departmentdetail where departmentname =deptname COLLATE utf8mb4_unicode_ci;
Insert into userdetails (`LoginID`,`UserName`,`PersonType`,
`DeptCode`,`PersonnelStatus`,`telephone`,`Notes`,`Password`)
values (id, uname, ptype, @dcode, stats, phone, note , pass);
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateClassData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateClassData`(clsid int,cname varchar(45), tbuild varchar(45), tfloor varchar(20), tseat int , ccip varchar(20), cam1ip varchar(20),
 cam2ip varchar(20), deskip varchar(20), recip varchar(20), cmac varchar(20), cport int, cid varchar(20), cpass varchar(20), 
 cam1mac varchar(20), cam1port int, cam1id varchar(20), cam1pass varchar(20) ,cam2mac varchar(20), cam2port int, cam2id varchar(20),
 cam2pass varchar(20), deskmac varchar(20), deskport int, deskid varchar(20), deskpass varchar(20), recmac varchar(20), recport int,
  recid varchar(20), recpass varchar(20), callhelp varchar(20))
BEGIN
UPDATE `organisationdatabase`.`classdetails`
SET
`ClassName` = cname,
`teachingBuilding` = tbuild,
`floor` = tfloor,
`Seats` = tseat,
`CCEquipIP` = ccip,
`camipS` = cam1ip,
`camipN` = cam2ip,
`desktopip` = deskip,
`recordingEquip` = recip,
`ccmac` = cmac,
`ccport` = cport,
`ccuserid` = cid,
`ccpass` = cpass,
`camSmac` = cam1mac,
`camSport` = cam1port,
`camSuserid` = cam1id,
`camSpass` = cam1pass,
`camNmac` = cam2mac,
`camNport` = cam2port,
`camNuserid` = cam2id,
`camNpass` = cam2pass,
`deskmac` = deskmac,
`deskport` = deskport,
`deskuserid` = deskid,
`deskpass` = deskpass,
`recordermac` = recmac,
`recorderport` = recport,
`recorderuserid` = recid,
`recorderpass` = recpass,
`callforhelp` = callhelp
WHERE `classID` = clsid;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UPdateOrganisationDeptData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UPdateOrganisationDeptData`( deptname varchar(100), buscode varchar(45), 
highoff varchar(45), que int , typeaccess varchar(10),note varchar(200), sn int)
BEGIN
if exists(select departmentcode from departmentdetail where departmentname = deptname COLLATE utf8mb4_unicode_ci)
then
select departmentcode into @num from departmentdetail where departmentname = deptname COLLATE utf8mb4_unicode_ci;
else
select max(serialNo) into @num from departmentdetail;
if(@num is null)
then
set @num = 1;
else set @num = @num+1;
insert into departmentdetail (departmentname, departmentcode) values (deptname , @num);
end if;
end if;

select departmentcode into @dcode from departmentdetail where departmentname =deptname COLLATE utf8mb4_unicode_ci;
update organisationdetails set deptcode = @dcode , businessCtrlcode = buscode , HigherOffice = highoff , queueNumber = que, Public = typeaccess , Notes = note
 where SerialNo = sn;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateStudentData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateStudentData`(id varchar(30), tname varchar(100), gend varchar(10), ag int, fac varchar(45), ph varchar(20),
idcrd varchar(30), onecrd varchar(30))
BEGIN
if exists(select * from studentdata where studentid =id  COLLATE utf8mb4_unicode_ci )
then
update studentdata set studentname = tname , gender =gend, age=ag , deptcode = fac,
phone =ph , idcard = idcrd , onecard = onecrd where studentid = id  COLLATE utf8mb4_unicode_ci ;

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateTeacherData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateTeacherData`(id varchar(30), tname varchar(100), gend varchar(10), ag int, fac varchar(45), ph varchar(20),
idcrd varchar(30), onecrd varchar(30) )
BEGIN
if exists(select * from teacherdata where teacherid = id  COLLATE utf8mb4_unicode_ci )
then
update teacherdata set teachername = tname , gender =gend, age=ag , faculty = fac,
phone =ph , idcard = idcrd , onecard = onecrd where teacherid = id  COLLATE utf8mb4_unicode_ci ;

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateUserData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateUserData`(id varchar(20), uname varchar(50), ptype varchar(45), 
deptname varchar(45),  phone varchar(15), note varchar(200), pass varchar(20))
BEGIN
if exists(select departmentcode from departmentdetail where departmentname = deptname COLLATE utf8mb4_unicode_ci)
then
select departmentcode into @num from departmentdetail where departmentname = deptname COLLATE utf8mb4_unicode_ci;
else
select max(serialNo) into @num from departmentdetail;
if(@num is null)
then
set @num = 1;
else set @num = @num+1;
insert into departmentdetail (departmentname, departmentcode) values (deptname , @num);
end if;
end if;
select departmentcode into @dcode from departmentdetail where departmentname =deptname COLLATE utf8mb4_unicode_ci;
UPDATE `organisationdatabase`.`userdetails`
SET
`UserName` = uname,
`PersonType` = ptype,
`DeptCode` = @dcode,
`telephone` = phone,
`Notes` = note,
`Password` = pass
WHERE loginId = id COLLATE utf8mb4_unicode_ci;
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

-- Dump completed on 2020-04-13 16:37:42

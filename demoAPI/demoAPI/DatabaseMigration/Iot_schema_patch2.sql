-- MySQL dump 10.13  Distrib 8.0.25, for Linux (x86_64)
--
-- Host: 127.0.0.1    Database: Iot_Schema
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `device_has_phone`
--

DROP TABLE IF EXISTS `device_has_phone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `device_has_phone` (
                                    `id` int NOT NULL AUTO_INCREMENT,
                                    `device_id` int NOT NULL,
                                    `phone_id` varchar(11) NOT NULL,
                                    PRIMARY KEY (`id`),
                                    KEY `device_has_phone_phones_phone_value_fk` (`phone_id`),
                                    KEY `device_has_phone_devices_id_fk` (`device_id`),
                                    CONSTRAINT `device_has_phone_devices_id_fk` FOREIGN KEY (`device_id`) REFERENCES `devices` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device_has_phone`
--

LOCK TABLES `device_has_phone` WRITE;
/*!40000 ALTER TABLE `device_has_phone` DISABLE KEYS */;
INSERT INTO `device_has_phone` VALUES (2,4,'3'),(3,5,'4'),(10,8,'1'),(11,12,'2');
/*!40000 ALTER TABLE `device_has_phone` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devices`
--

DROP TABLE IF EXISTS `devices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `devices` (
                           `id` int NOT NULL AUTO_INCREMENT,
                           `name` varchar(255) DEFAULT NULL,
                           `updated_at` datetime DEFAULT CURRENT_TIMESTAMP,
                           `max_temperature` float NOT NULL DEFAULT '45',
                           `is_off` tinyint(1) DEFAULT '0',
                           `is_alert` tinyint(1) DEFAULT '0',
                           `is_sendWater` tinyint(1) DEFAULT '0',
                           `station_id` int NOT NULL,
                           PRIMARY KEY (`id`),
                           UNIQUE KEY `devices_name_uindex` (`name`),
                           KEY `devices_stations_id_fk` (`station_id`),
                           CONSTRAINT `devices_stations_id_fk` FOREIGN KEY (`station_id`) REFERENCES `stations` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devices`
--

LOCK TABLES `devices` WRITE;
/*!40000 ALTER TABLE `devices` DISABLE KEYS */;
INSERT INTO `devices` VALUES (4,'Greenlam','2021-01-06 21:59:39',43.29,0,0,1,3),(5,'Zaam-Dox','2020-09-15 18:44:19',59.45,0,1,0,1),(8,'Veribet','2021-02-24 23:27:22',42.57,0,1,0,2),(12,'asdas','2021-05-09 22:35:50',55,0,0,0,4);
/*!40000 ALTER TABLE `devices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phones`
--

DROP TABLE IF EXISTS `phones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phones` (
                          `phone_value` varchar(11) NOT NULL,
                          `whole_name` varchar(100) NOT NULL,
                          `id` int NOT NULL AUTO_INCREMENT,
                          PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phones`
--

LOCK TABLES `phones` WRITE;
/*!40000 ALTER TABLE `phones` DISABLE KEYS */;
INSERT INTO `phones` VALUES ('01234323312','Sỹ1',1),('01664972204','Sỹ2',3),('01672321633','Sỹ3',4),('0389444315','Sỹ4',5);
/*!40000 ALTER TABLE `phones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `records`
--

DROP TABLE IF EXISTS `records`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `records` (
                           `id` int NOT NULL AUTO_INCREMENT,
                           `temperature` float NOT NULL,
                           `humidity` float NOT NULL,
                           `device_id` int NOT NULL,
                           `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
                           PRIMARY KEY (`id`),
                           KEY `records_devices_id_fk` (`device_id`),
                           CONSTRAINT `records_devices_id_fk` FOREIGN KEY (`device_id`) REFERENCES `devices` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `records`
--

LOCK TABLES `records` WRITE;
/*!40000 ALTER TABLE `records` DISABLE KEYS */;
INSERT INTO `records` VALUES (1,18,8,4,'2021-03-15 18:59:03'),(6,98,37,5,'2020-09-09 10:59:10'),(8,52,94,8,'2020-09-15 21:10:13'),(10,67,5,8,'2021-01-07 15:38:22'),(15,41,38,8,'2021-01-15 01:43:23'),(18,11,67,4,'2020-07-05 16:36:48'),(22,71,97,5,'2020-12-26 04:54:12'),(25,79,81,4,'2020-03-24 22:40:48'),(29,13,54,4,'2020-12-05 23:32:48'),(35,19,33,5,'2021-03-29 21:14:14'),(36,63,5,8,'2021-03-19 04:07:24'),(40,65,57,5,'2021-03-19 05:31:31'),(42,20,92,5,'2020-09-20 08:48:45'),(43,21,89,4,'2020-11-11 02:19:46'),(45,63,95,4,'2020-03-13 10:18:06'),(47,81,45,5,'2021-03-27 08:26:16'),(55,53,65,5,'2020-04-26 03:24:18'),(60,17,25,4,'2021-04-10 18:27:47'),(61,100,83,5,'2020-03-17 02:07:54'),(62,61,48,5,'2020-07-21 04:20:43'),(73,63,42,4,'2020-10-10 12:10:11'),(76,92,45,5,'2020-05-14 16:38:14'),(83,23,72,8,'2020-12-22 20:30:09'),(84,80,42,8,'2020-05-19 08:02:38'),(87,86,52,4,'2020-04-20 17:48:32'),(91,34,94,4,'2020-09-15 21:43:26'),(95,89,99,5,'2020-08-12 21:21:43'),(98,52,21,5,'2020-03-11 10:00:31'),(99,27,71,5,'2021-03-12 00:49:01');
/*!40000 ALTER TABLE `records` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stations`
--

DROP TABLE IF EXISTS `stations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stations` (
                            `id` int NOT NULL AUTO_INCREMENT,
                            `location_name` varchar(255) NOT NULL,
                            `updated_at` datetime DEFAULT CURRENT_TIMESTAMP,
                            PRIMARY KEY (`id`),
                            UNIQUE KEY `Location_location_name_uindex` (`location_name`),
                            UNIQUE KEY `Location_id_uindex` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stations`
--

LOCK TABLES `stations` WRITE;
/*!40000 ALTER TABLE `stations` DISABLE KEYS */;
INSERT INTO `stations` VALUES (1,'asd','2019-10-03 02:13:19'),(2,'4859 Schmedeman Point','2020-07-15 20:17:23'),(3,'44 Monterey Circle','2020-04-07 11:51:02'),(4,'34 Nelson Hill','2020-08-25 13:03:46');
/*!40000 ALTER TABLE `stations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
                         `id` int NOT NULL AUTO_INCREMENT,
                         `username` varchar(255) NOT NULL,
                         `password` varchar(255) NOT NULL,
                         PRIMARY KEY (`id`),
                         UNIQUE KEY `users_username_uindex` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'user01','user01'),(2,'user02','user02');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-10 15:10:02

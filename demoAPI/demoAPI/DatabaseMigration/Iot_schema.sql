-- MySQL dump 10.13  Distrib 8.0.24, for Linux (x86_64)
--
-- Host: 127.0.0.1    Database: Iot_Schema
-- ------------------------------------------------------
-- Server version	8.0.24

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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device_has_phone`
--

LOCK TABLES `device_has_phone` WRITE;
/*!40000 ALTER TABLE `device_has_phone` DISABLE KEYS */;
INSERT INTO `device_has_phone` (`id`, `device_id`, `phone_id`) VALUES (1,3,'1'),(2,4,'3'),(3,5,'4');
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
INSERT INTO `devices` (`id`, `name`, `updated_at`, `max_temperature`, `is_off`, `is_alert`, `is_sendWater`, `station_id`) VALUES (3,'Editted','2021-05-09 22:45:13',70,1,1,1,6),(4,'Greenlam','2021-01-06 21:59:39',43.29,0,0,1,3),(5,'Zaam-Dox','2020-09-15 18:44:19',59.45,0,1,0,4),(6,'Y-Solowarm','2020-08-05 21:16:47',34.46,1,1,0,5),(7,'Tin','2020-10-23 01:30:57',46.42,0,1,0,6),(8,'Veribet','2021-02-24 23:27:22',42.57,0,1,0,4),(9,'Keylex','2021-01-14 00:29:41',39.12,1,1,1,5),(10,'Fix San','2020-07-01 21:06:30',38.28,0,1,0,5),(11,'test device1','2021-04-18 15:43:19',50,0,0,0,5),(12,'asdas','2021-05-09 22:35:50',55,0,0,0,4);
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
  `whole_name` varbinary(100) NOT NULL,
  `id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phones`
--

LOCK TABLES `phones` WRITE;
/*!40000 ALTER TABLE `phones` DISABLE KEYS */;
INSERT INTO `phones` (`phone_value`, `whole_name`, `id`) VALUES ('01234323312',_binary 'Sỹ1',1),('01664972204',_binary 'Sỹ2',3),('01672321633',_binary 'Sỹ3',4),('0389444315',_binary 'Sỹ4',5);
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
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `records`
--

LOCK TABLES `records` WRITE;
/*!40000 ALTER TABLE `records` DISABLE KEYS */;
INSERT INTO `records` (`id`, `temperature`, `humidity`, `device_id`, `created_at`) VALUES (1,18,8,4,'2021-03-15 18:59:03'),(2,45,24,10,'2021-01-01 23:54:55'),(4,67,89,10,'2020-11-16 03:01:48'),(5,67,11,3,'2020-04-25 20:58:05'),(6,98,37,5,'2020-09-09 10:59:10'),(7,23,33,3,'2020-03-14 07:25:26'),(8,52,94,8,'2020-09-15 21:10:13'),(10,67,5,8,'2021-01-07 15:38:22'),(12,15,47,7,'2020-07-15 22:33:18'),(13,3,71,6,'2020-07-09 16:31:56'),(14,97,16,6,'2020-08-28 17:11:15'),(15,41,38,8,'2021-01-15 01:43:23'),(16,50,46,7,'2021-01-17 20:34:09'),(18,11,67,4,'2020-07-05 16:36:48'),(19,50,24,7,'2020-06-24 11:27:25'),(21,86,10,3,'2021-03-17 22:50:31'),(22,71,97,5,'2020-12-26 04:54:12'),(23,88,71,10,'2021-01-08 12:48:47'),(24,10,49,3,'2021-02-10 10:16:54'),(25,79,81,4,'2020-03-24 22:40:48'),(26,19,22,6,'2020-11-17 08:08:02'),(27,36,34,3,'2020-12-09 03:02:06'),(28,57,63,9,'2020-11-13 19:18:56'),(29,13,54,4,'2020-12-05 23:32:48'),(30,69,100,9,'2020-05-01 20:13:14'),(31,74,92,6,'2020-12-30 16:12:51'),(32,1,14,9,'2021-03-24 18:36:36'),(33,18,25,7,'2020-05-12 10:38:18'),(34,78,4,10,'2021-02-13 11:13:44'),(35,19,33,5,'2021-03-29 21:14:14'),(36,63,5,8,'2021-03-19 04:07:24'),(37,65,5,3,'2021-01-16 07:11:23'),(39,80,15,7,'2020-09-30 08:13:43'),(40,65,57,5,'2021-03-19 05:31:31'),(42,20,92,5,'2020-09-20 08:48:45'),(43,21,89,4,'2020-11-11 02:19:46'),(44,97,94,7,'2021-02-11 12:56:55'),(45,63,95,4,'2020-03-13 10:18:06'),(46,97,100,7,'2020-07-27 12:35:25'),(47,81,45,5,'2021-03-27 08:26:16'),(48,42,10,10,'2021-04-11 07:40:04'),(49,33,50,10,'2021-02-21 14:07:48'),(52,69,45,10,'2020-07-30 10:49:25'),(53,3,82,9,'2020-12-29 22:06:42'),(55,53,65,5,'2020-04-26 03:24:18'),(57,67,55,7,'2021-03-28 04:38:33'),(58,15,93,10,'2020-05-09 23:44:48'),(59,38,75,10,'2020-09-26 01:45:12'),(60,17,25,4,'2021-04-10 18:27:47'),(61,100,83,5,'2020-03-17 02:07:54'),(62,61,48,5,'2020-07-21 04:20:43'),(63,7,83,6,'2020-12-18 20:51:13'),(65,9,91,10,'2021-03-17 22:20:33'),(66,73,85,6,'2020-04-10 19:27:31'),(67,49,48,3,'2020-03-22 14:45:35'),(68,20,18,6,'2021-04-13 14:29:05'),(69,10,62,9,'2020-06-17 19:06:04'),(72,26,61,10,'2020-05-19 21:58:22'),(73,63,42,4,'2020-10-10 12:10:11'),(74,43,81,6,'2020-11-08 01:11:20'),(75,56,35,7,'2020-05-18 23:51:08'),(76,92,45,5,'2020-05-14 16:38:14'),(77,51,20,6,'2020-08-18 14:18:01'),(79,96,62,3,'2020-11-07 17:18:33'),(81,94,70,10,'2020-11-01 10:00:24'),(82,17,93,3,'2020-11-28 03:13:03'),(83,23,72,8,'2020-12-22 20:30:09'),(84,80,42,8,'2020-05-19 08:02:38'),(85,80,33,6,'2020-04-05 12:05:31'),(86,96,31,7,'2020-06-10 22:44:51'),(87,86,52,4,'2020-04-20 17:48:32'),(89,26,7,3,'2020-04-28 09:06:53'),(91,34,94,4,'2020-09-15 21:43:26'),(93,62,3,7,'2020-11-09 13:45:48'),(94,26,68,3,'2020-11-19 00:37:45'),(95,89,99,5,'2020-08-12 21:21:43'),(96,63,38,10,'2020-12-06 23:41:17'),(97,72,79,6,'2021-01-02 23:47:06'),(98,52,21,5,'2020-03-11 10:00:31'),(99,27,71,5,'2021-03-12 00:49:01'),(101,34.12,56.34,3,'2021-05-09 17:50:16');
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
INSERT INTO `stations` (`id`, `location_name`, `updated_at`) VALUES (1,'asd','2019-10-03 02:13:19'),(2,'4859 Schmedeman Point','2020-07-15 20:17:23'),(3,'44 Monterey Circle','2020-04-07 11:51:02'),(4,'34 Nelson Hill','2020-08-25 13:03:46'),(5,'4 Mandrake Center','2019-12-18 09:33:00'),(6,'1 Rowland Parkway','2020-10-04 21:52:23'),(7,'271 Mosinee Circle','2020-04-22 13:00:58'),(8,'6849 Di Loreto Place','2020-12-02 04:15:02'),(9,'439 Cascade Alley','2020-01-25 14:28:46'),(10,'3571 Sycamore Avenue','2019-10-08 09:52:38'),(11,'228 Corscot Road','2019-12-28 10:39:44'),(12,'9 Gina Drive','2019-12-04 11:25:22'),(13,'8 Scoville Lane','2020-06-13 19:57:07'),(14,'842 Melby Street','2019-12-27 22:09:00'),(15,'77 Nova Park','2020-01-26 07:09:01'),(16,'07 Brentwood Court','2021-03-15 00:30:40'),(17,'20403 Ramsey Court','2020-11-12 06:00:04'),(18,'72430 Talisman Parkway','2021-02-24 15:14:53'),(19,'14 Pankratz Lane','2019-11-05 00:25:23'),(20,'25290 Superior Terrace','2020-11-08 12:21:16'),(33,'srting 23123','2021-04-17 00:00:00'),(35,'string lhjlhj','2021-04-17 13:05:13'),(36,'dai hoc back khoa','2021-04-17 13:06:41'),(37,'dai hoc xay dung','2021-04-17 13:07:08'),(38,'dh hn','2021-04-17 13:09:53'),(39,'nhà sỹ','2021-05-09 22:13:00');
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
INSERT INTO `users` (`id`, `username`, `password`) VALUES (1,'user01','user01'),(2,'user02','user02');
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

-- Dump completed on 2021-05-09 22:54:50

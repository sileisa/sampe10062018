-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: sampe
-- ------------------------------------------------------
-- Server version	5.7.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `atividadeos`
--

DROP TABLE IF EXISTS `atividadeos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `atividadeos` (
  `AtividadeOSId` int(11) NOT NULL AUTO_INCREMENT,
  `NomeAtvOs` longtext,
  PRIMARY KEY (`AtividadeOSId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atividadeos`
--

LOCK TABLES `atividadeos` WRITE;
/*!40000 ALTER TABLE `atividadeos` DISABLE KEYS */;
INSERT INTO `atividadeos` VALUES (1,'Limpeza das aletas do condensador com ar comprimido a baixa pressão'),(2,'Verificação da temperatura da água de condensação'),(3,'Verificação de vazamento no selo mecânico a bomba'),(4,'Verificação de ruidos anormais na bomba'),(5,'Verificação de vibração excessiva no ventilador'),(6,'Verificação do visor de líquido'),(7,'Verificação do reservatório e da água de processo'),(8,'Atividade 8'),(9,'Atividade 9'),(10,'Atividade 10'),(11,'Atividade 11'),(12,'Limpeza das aletas do condensador com ar comprimido a baixa pressão dsf ds fds dsdfd ');
/*!40000 ALTER TABLE `atividadeos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-07  8:39:00

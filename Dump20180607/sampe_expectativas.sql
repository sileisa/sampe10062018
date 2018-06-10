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
-- Table structure for table `expectativas`
--

DROP TABLE IF EXISTS `expectativas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `expectativas` (
  `ExpectativaId` int(11) NOT NULL AUTO_INCREMENT,
  `Produto` longtext,
  `CavidadeMolde` int(11) NOT NULL,
  `PesoPecaAproximado` double NOT NULL,
  `PesoPecaCompleta` double NOT NULL,
  `Ciclo` float NOT NULL,
  `ProducaoEsperada` int(11) NOT NULL,
  `ProdInicio` longtext,
  `ProdFim` longtext,
  PRIMARY KEY (`ExpectativaId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expectativas`
--

LOCK TABLES `expectativas` WRITE;
/*!40000 ALTER TABLE `expectativas` DISABLE KEYS */;
INSERT INTO `expectativas` VALUES (1,'Anel de Vedação',12,200,2000,13,15000,'12','18'),(2,'Capa Colonial',12,233,1241,15,2000,'11','17'),(3,'Capa Minionda',12,246,3643,12,500,'12','18'),(4,'Capa Trapezoidal',32,322,3345,33,1500,'12','18'),(5,'Chapéu',14,145,6433,23,1294,'12','18');
/*!40000 ALTER TABLE `expectativas` ENABLE KEYS */;
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

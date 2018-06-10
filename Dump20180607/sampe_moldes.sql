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
-- Table structure for table `moldes`
--

DROP TABLE IF EXISTS `moldes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `moldes` (
  `MoldeId` int(11) NOT NULL AUTO_INCREMENT,
  `NomeMolde` longtext NOT NULL,
  `Cavidade` int(11) DEFAULT NULL,
  `FormularioTrocaMolde_FormularioTrocaMoldeId` int(11) DEFAULT NULL,
  PRIMARY KEY (`MoldeId`),
  KEY `IX_FormularioTrocaMolde_FormularioTrocaMoldeId` (`FormularioTrocaMolde_FormularioTrocaMoldeId`) USING HASH,
  CONSTRAINT `FK_789f8060213f4690b26d10d300e62dd6` FOREIGN KEY (`FormularioTrocaMolde_FormularioTrocaMoldeId`) REFERENCES `formulariotrocamoldes` (`FormularioTrocaMoldeId`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moldes`
--

LOCK TABLES `moldes` WRITE;
/*!40000 ALTER TABLE `moldes` DISABLE KEYS */;
INSERT INTO `moldes` VALUES (1,'Anel',20,NULL),(2,'Chapéu',20,NULL),(3,'Colonial',10,NULL),(4,'Colonial',32,NULL),(5,'Copo Long Drink',2,NULL),(6,'Front',2,NULL),(7,'Minionda',16,NULL),(8,'Rear',2,NULL),(9,'Trapezoidal',16,NULL);
/*!40000 ALTER TABLE `moldes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-07  8:38:59

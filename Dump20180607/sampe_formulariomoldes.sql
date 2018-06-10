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
-- Table structure for table `formulariomoldes`
--

DROP TABLE IF EXISTS `formulariomoldes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formulariomoldes` (
  `FormularioMoldeId` int(11) NOT NULL AUTO_INCREMENT,
  `FormularioTrocaMoldeId` int(11) NOT NULL,
  `MoldeId` int(11) NOT NULL,
  PRIMARY KEY (`FormularioMoldeId`),
  KEY `IX_FormularioTrocaMoldeId` (`FormularioTrocaMoldeId`) USING HASH,
  KEY `IX_MoldeId` (`MoldeId`) USING HASH,
  CONSTRAINT `FK_2e6f69a93bac44d28fc64075bd36c477` FOREIGN KEY (`FormularioTrocaMoldeId`) REFERENCES `formulariotrocamoldes` (`FormularioTrocaMoldeId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_FormularioMoldes_Moldes_MoldeId` FOREIGN KEY (`MoldeId`) REFERENCES `moldes` (`MoldeId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formulariomoldes`
--

LOCK TABLES `formulariomoldes` WRITE;
/*!40000 ALTER TABLE `formulariomoldes` DISABLE KEYS */;
/*!40000 ALTER TABLE `formulariomoldes` ENABLE KEYS */;
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

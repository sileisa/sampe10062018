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
-- Table structure for table `formulariotrocamoldeatividadetms`
--

DROP TABLE IF EXISTS `formulariotrocamoldeatividadetms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formulariotrocamoldeatividadetms` (
  `FormularioTrocaMolde_FormularioTrocaMoldeId` int(11) NOT NULL,
  `AtividadeTM_AtividadeTMId` int(11) NOT NULL,
  PRIMARY KEY (`FormularioTrocaMolde_FormularioTrocaMoldeId`,`AtividadeTM_AtividadeTMId`),
  KEY `IX_FormularioTrocaMolde_FormularioTrocaMoldeId` (`FormularioTrocaMolde_FormularioTrocaMoldeId`) USING HASH,
  KEY `IX_AtividadeTM_AtividadeTMId` (`AtividadeTM_AtividadeTMId`) USING HASH,
  CONSTRAINT `FK_54d45bb7a08c415ab69341c1e4719036` FOREIGN KEY (`AtividadeTM_AtividadeTMId`) REFERENCES `atividadetms` (`AtividadeTMId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_df495d10de08494b9fe94ad6937cf1b9` FOREIGN KEY (`FormularioTrocaMolde_FormularioTrocaMoldeId`) REFERENCES `formulariotrocamoldes` (`FormularioTrocaMoldeId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formulariotrocamoldeatividadetms`
--

LOCK TABLES `formulariotrocamoldeatividadetms` WRITE;
/*!40000 ALTER TABLE `formulariotrocamoldeatividadetms` DISABLE KEYS */;
/*!40000 ALTER TABLE `formulariotrocamoldeatividadetms` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-07  8:38:56

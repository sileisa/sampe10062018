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
-- Table structure for table `kitpecas`
--

DROP TABLE IF EXISTS `kitpecas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kitpecas` (
  `KitPecaId` int(11) NOT NULL AUTO_INCREMENT,
  `CodigoIdentificador` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
  `CodigoIdentificadorKit` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`KitPecaId`),
  KEY `IX_CodigoIdentificador` (`CodigoIdentificador`) USING HASH,
  KEY `IX_CodigoIdentificadorKit` (`CodigoIdentificadorKit`) USING HASH,
  CONSTRAINT `FK_KitPecas_OrdemProducaoKits_CodigoIdentificadorKit` FOREIGN KEY (`CodigoIdentificadorKit`) REFERENCES `ordemproducaokits` (`CodigoIdentificadorKit`),
  CONSTRAINT `FK_KitPecas_OrdemProducaoPecas_CodigoIdentificador` FOREIGN KEY (`CodigoIdentificador`) REFERENCES `ordemproducaopecas` (`CodigoIdentificador`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kitpecas`
--

LOCK TABLES `kitpecas` WRITE;
/*!40000 ALTER TABLE `kitpecas` DISABLE KEYS */;
INSERT INTO `kitpecas` VALUES (4,'I2F3','M2F1'),(5,'I2F4','M2F1'),(6,'I2F1','M2F1');
/*!40000 ALTER TABLE `kitpecas` ENABLE KEYS */;
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

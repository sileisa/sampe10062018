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
-- Table structure for table `atividadetms`
--

DROP TABLE IF EXISTS `atividadetms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `atividadetms` (
  `AtividadeTMId` int(11) NOT NULL AUTO_INCREMENT,
  `NomeAtvTm` longtext,
  PRIMARY KEY (`AtividadeTMId`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atividadetms`
--

LOCK TABLES `atividadetms` WRITE;
/*!40000 ALTER TABLE `atividadetms` DISABLE KEYS */;
INSERT INTO `atividadetms` VALUES (1,'Colocar lubrificante de proteção nas partes (Macho/Fêmea)'),(2,'Utilizar trava de união do molde'),(3,'Desconectar as mangueiras de água'),(4,'Desconectar as mangueiras de ar'),(5,'Colocar olhal de levante de molde'),(6,'Tirar presilha do pino extrator'),(7,'Retirar garras da cavidade macho e fêmea'),(9,'Guardar o molde no local reservado'),(10,'Retirar olhal de levante do molde'),(11,'Colocar o olhal de levante no molde'),(13,'Verificar colocação do anel de centragem do molde'),(14,'Colocação das garras do molde na placa fixa'),(15,'Colocação do pino extrator'),(16,'Regular o pino extrator'),(17,'Colocar a prisilha do pino extrator'),(18,'Colocação das garras do molde na placa móvel'),(19,'Verificar acoplamento do pino extrator'),(20,'Verificar conexão de água'),(21,'Verificar existência da trava de união do molde (Macho/Fêmea)'),(22,'Verificar instalações dos bico de ar'),(23,'Testar sistema de água'),(24,'Testar sistema de ar'),(25,'Testar fechamento do molde');
/*!40000 ALTER TABLE `atividadetms` ENABLE KEYS */;
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

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
-- Table structure for table `paradas`
--

DROP TABLE IF EXISTS `paradas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `paradas` (
  `ParadaId` int(11) NOT NULL AUTO_INCREMENT,
  `HoraParada` longtext,
  `HoraRetorno` longtext,
  `Motivo` longtext,
  `Observacoes` longtext,
  `OrdemProducaoPecaId` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
  `OrdemProducaoPeca_CodigoIdentificador` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`ParadaId`),
  KEY `IX_OrdemProducaoPecaId` (`OrdemProducaoPecaId`) USING HASH,
  KEY `IX_OrdemProducaoPeca_CodigoIdentificador` (`OrdemProducaoPeca_CodigoIdentificador`) USING HASH,
  CONSTRAINT `FK_Paradas_OrdemProducaoPecas_OrdemProducaoPecaId` FOREIGN KEY (`OrdemProducaoPecaId`) REFERENCES `ordemproducaopecas` (`CodigoIdentificador`),
  CONSTRAINT `FK_c6a1215916ed4de48c67bbada44667df` FOREIGN KEY (`OrdemProducaoPeca_CodigoIdentificador`) REFERENCES `ordemproducaopecas` (`CodigoIdentificador`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paradas`
--

LOCK TABLES `paradas` WRITE;
/*!40000 ALTER TABLE `paradas` DISABLE KEYS */;
INSERT INTO `paradas` VALUES (7,'05:06','05:06','','4565','I2F1','I2F1');
/*!40000 ALTER TABLE `paradas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-07  8:38:58

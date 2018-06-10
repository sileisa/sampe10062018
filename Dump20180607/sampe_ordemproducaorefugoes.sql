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
-- Table structure for table `ordemproducaorefugoes`
--

DROP TABLE IF EXISTS `ordemproducaorefugoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ordemproducaorefugoes` (
  `OrdemProducaoRefugoId` int(11) NOT NULL AUTO_INCREMENT,
  `Produto` longtext,
  `Data` datetime NOT NULL,
  `UsuarioId` int(11) NOT NULL,
  `ProdIncio` longtext,
  `ProdFim` longtext,
  `Obs` longtext,
  `EspecificacaoRefugo_EspecificacaoRefugoId` int(11) DEFAULT NULL,
  `ParadaRefugo_ParadaRefugoId` int(11) DEFAULT NULL,
  `Status` tinyint(1) NOT NULL,
  PRIMARY KEY (`OrdemProducaoRefugoId`),
  KEY `IX_UsuarioId` (`UsuarioId`) USING HASH,
  KEY `IX_EspecificacaoRefugo_EspecificacaoRefugoId` (`EspecificacaoRefugo_EspecificacaoRefugoId`) USING HASH,
  KEY `IX_ParadaRefugo_ParadaRefugoId` (`ParadaRefugo_ParadaRefugoId`) USING HASH,
  CONSTRAINT `FK_03df769c7ff348709a3f407c9ecf5ee9` FOREIGN KEY (`ParadaRefugo_ParadaRefugoId`) REFERENCES `paradarefugoes` (`ParadaRefugoId`),
  CONSTRAINT `FK_114c5085c11848e6a48d7082debafb68` FOREIGN KEY (`EspecificacaoRefugo_EspecificacaoRefugoId`) REFERENCES `especificacaorefugoes` (`EspecificacaoRefugoId`),
  CONSTRAINT `FK_OrdemProducaoRefugoes_Usuarios_UsuarioId` FOREIGN KEY (`UsuarioId`) REFERENCES `usuarios` (`UsuarioId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordemproducaorefugoes`
--

LOCK TABLES `ordemproducaorefugoes` WRITE;
/*!40000 ALTER TABLE `ordemproducaorefugoes` DISABLE KEYS */;
/*!40000 ALTER TABLE `ordemproducaorefugoes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-07  8:38:57

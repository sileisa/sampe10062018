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
-- Table structure for table `formularioordemservicoatividadeos`
--

DROP TABLE IF EXISTS `formularioordemservicoatividadeos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formularioordemservicoatividadeos` (
  `FormularioOrdemServico_FormularioOrdemServicoId` int(11) NOT NULL,
  `AtividadeOS_AtividadeOSId` int(11) NOT NULL,
  PRIMARY KEY (`FormularioOrdemServico_FormularioOrdemServicoId`,`AtividadeOS_AtividadeOSId`),
  KEY `IX_FormularioOrdemServico_FormularioOrdemServicoId` (`FormularioOrdemServico_FormularioOrdemServicoId`) USING HASH,
  KEY `IX_AtividadeOS_AtividadeOSId` (`AtividadeOS_AtividadeOSId`) USING HASH,
  CONSTRAINT `FK_542188d91a6842b68fb657f5ec7b570c` FOREIGN KEY (`FormularioOrdemServico_FormularioOrdemServicoId`) REFERENCES `formularioordemservicoes` (`FormularioOrdemServicoId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_affda6a773b549d496ee40b376cfa478` FOREIGN KEY (`AtividadeOS_AtividadeOSId`) REFERENCES `atividadeos` (`AtividadeOSId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formularioordemservicoatividadeos`
--

LOCK TABLES `formularioordemservicoatividadeos` WRITE;
/*!40000 ALTER TABLE `formularioordemservicoatividadeos` DISABLE KEYS */;
/*!40000 ALTER TABLE `formularioordemservicoatividadeos` ENABLE KEYS */;
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

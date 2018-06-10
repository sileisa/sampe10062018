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
-- Table structure for table `ordemproducaokits`
--

DROP TABLE IF EXISTS `ordemproducaokits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ordemproducaokits` (
  `CodigoIdentificadorKit` varchar(128) CHARACTER SET utf8 NOT NULL,
  `Data` datetime NOT NULL,
  `ProdIncio` longtext,
  `ProdFim` longtext,
  `TotalProduzido` int(11) NOT NULL,
  `NivelamentoBalanca` tinyint(1) NOT NULL,
  `Obs` longtext,
  `OPnoMes` int(11) NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `Operdor` int(11) NOT NULL,
  `Especificacao_EspecificacaoId` int(11) DEFAULT NULL,
  `OrdemProducaoPeca_CodigoIdentificador` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
  `ParadaKit_ParadaId` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodigoIdentificadorKit`),
  KEY `IX_Operdor` (`Operdor`) USING HASH,
  KEY `IX_Especificacao_EspecificacaoId` (`Especificacao_EspecificacaoId`) USING HASH,
  KEY `IX_OrdemProducaoPeca_CodigoIdentificador` (`OrdemProducaoPeca_CodigoIdentificador`) USING HASH,
  KEY `IX_ParadaKit_ParadaId` (`ParadaKit_ParadaId`) USING HASH,
  CONSTRAINT `FK_67bee63344a34708ad0c7303d737d136` FOREIGN KEY (`OrdemProducaoPeca_CodigoIdentificador`) REFERENCES `ordemproducaopecas` (`CodigoIdentificador`),
  CONSTRAINT `FK_86651ec5d46642a1869738467ba22f0c` FOREIGN KEY (`Especificacao_EspecificacaoId`) REFERENCES `especificacaos` (`EspecificacaoId`),
  CONSTRAINT `FK_OrdemProducaoKits_ParadaKits_ParadaKit_ParadaId` FOREIGN KEY (`ParadaKit_ParadaId`) REFERENCES `paradakits` (`ParadaId`),
  CONSTRAINT `FK_OrdemProducaoKits_Usuarios_Operdor` FOREIGN KEY (`Operdor`) REFERENCES `usuarios` (`UsuarioId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordemproducaokits`
--

LOCK TABLES `ordemproducaokits` WRITE;
/*!40000 ALTER TABLE `ordemproducaokits` DISABLE KEYS */;
INSERT INTO `ordemproducaokits` VALUES ('M2F1','2018-06-07 00:00:00','13:12','03:04',344,1,'qwerew wqr qwerew weqrrr wqqrqrq',1,0,2,NULL,NULL,NULL);
/*!40000 ALTER TABLE `ordemproducaokits` ENABLE KEYS */;
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

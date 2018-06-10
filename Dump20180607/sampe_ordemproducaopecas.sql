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
-- Table structure for table `ordemproducaopecas`
--

DROP TABLE IF EXISTS `ordemproducaopecas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ordemproducaopecas` (
  `CodigoIdentificador` varchar(128) CHARACTER SET utf8 NOT NULL,
  `ExpectativaId` int(11) NOT NULL,
  `OPnoMes` int(11) NOT NULL,
  `Data` datetime NOT NULL,
  `MateriaPrima` longtext NOT NULL,
  `MPLote` longtext,
  `MPConsumo` double NOT NULL,
  `ProdIncio` longtext,
  `ProdFim` longtext,
  `Produto` longtext,
  `ProdutoCor` longtext,
  `MasterLote` longtext,
  `Fornecedor` longtext,
  `TempAgua` double NOT NULL,
  `NivelOleo` double NOT NULL,
  `Galho` double NOT NULL,
  `OffSpec` double NOT NULL,
  `RefugoKg` double NOT NULL,
  `UnidadesProduzidas` int(11) NOT NULL,
  `ContadorInicial` double NOT NULL,
  `ContadorFinal` double NOT NULL,
  `ControleDeQualidade_ControleDeQualidadeId` int(11) DEFAULT NULL,
  `Parada_ParadaId` int(11) DEFAULT NULL,
  `OrdemProducaoKit_CodigoIdentificadorKit` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
  `MaquinaId` int(11) NOT NULL,
  `Status` tinyint(1) NOT NULL,
  PRIMARY KEY (`CodigoIdentificador`),
  KEY `IX_ExpectativaId` (`ExpectativaId`) USING HASH,
  KEY `IX_ControleDeQualidade_ControleDeQualidadeId` (`ControleDeQualidade_ControleDeQualidadeId`) USING HASH,
  KEY `IX_Parada_ParadaId` (`Parada_ParadaId`) USING HASH,
  KEY `IX_OrdemProducaoKit_CodigoIdentificadorKit` (`OrdemProducaoKit_CodigoIdentificadorKit`) USING HASH,
  KEY `IX_MaquinaId` (`MaquinaId`) USING HASH,
  CONSTRAINT `FK_OrdemProducaoPecas_Expectativas_ExpectativaId` FOREIGN KEY (`ExpectativaId`) REFERENCES `expectativas` (`ExpectativaId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_OrdemProducaoPecas_Maquinas_MaquinaId` FOREIGN KEY (`MaquinaId`) REFERENCES `maquinas` (`MaquinaId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_OrdemProducaoPecas_Paradas_Parada_ParadaId` FOREIGN KEY (`Parada_ParadaId`) REFERENCES `paradas` (`ParadaId`),
  CONSTRAINT `FK_e1597fbfa21341ebbe3f3e1cfe0092d5` FOREIGN KEY (`OrdemProducaoKit_CodigoIdentificadorKit`) REFERENCES `ordemproducaokits` (`CodigoIdentificadorKit`),
  CONSTRAINT `FK_f56f856dbdae4531bd336bb13609fcc5` FOREIGN KEY (`ControleDeQualidade_ControleDeQualidadeId`) REFERENCES `controledequalidades` (`ControleDeQualidadeId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordemproducaopecas`
--

LOCK TABLES `ordemproducaopecas` WRITE;
/*!40000 ALTER TABLE `ordemproducaopecas` DISABLE KEYS */;
INSERT INTO `ordemproducaopecas` VALUES ('I2F1',1,1,'2018-06-07 00:00:00','Virgem','64',56,'13:04','04:05','Anel de Vedação','Ceramica','56','56',56,56,56,65,56,54,56,65,NULL,NULL,NULL,2,0),('I2F2',1,2,'2018-06-07 00:00:00','Refugo','Refugo',1243,'12:03','03:03','Anel de Vedação','Marfim','','',143,2142,2431,431,242,234,44,231,NULL,NULL,NULL,3,0),('I2F3',2,3,'2018-06-07 00:00:00','Refugo','Refugo',45,'03:04','04:53','Capa Colonial','Ceramica','','',233,34,34,54,45,435,45,435,NULL,NULL,NULL,3,0),('I2F4',5,4,'2018-06-07 00:00:00','Refugo','Refugo',564,'23:05','23:05','Chapéu','Marfim','','',243,64,56,56,56,4352,56,56,NULL,NULL,NULL,2,0);
/*!40000 ALTER TABLE `ordemproducaopecas` ENABLE KEYS */;
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

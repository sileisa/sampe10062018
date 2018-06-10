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
-- Table structure for table `controledequalidades`
--

DROP TABLE IF EXISTS `controledequalidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `controledequalidades` (
  `ControleDeQualidadeId` int(11) NOT NULL AUTO_INCREMENT,
  `Ciclo` float NOT NULL,
  `Hora` longtext,
  `PesoDaPeca` float NOT NULL,
  `Peso` tinyint(1) NOT NULL,
  `Cor` tinyint(1) NOT NULL,
  `Dimensao` tinyint(1) NOT NULL,
  `Assinatura` int(11) NOT NULL,
  `Liberado` tinyint(1) NOT NULL,
  `OrdemProducaoPecaId` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
  `OrdemProducaoPeca_CodigoIdentificador` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`ControleDeQualidadeId`),
  KEY `IX_Assinatura` (`Assinatura`) USING HASH,
  KEY `IX_OrdemProducaoPecaId` (`OrdemProducaoPecaId`) USING HASH,
  KEY `IX_OrdemProducaoPeca_CodigoIdentificador` (`OrdemProducaoPeca_CodigoIdentificador`) USING HASH,
  CONSTRAINT `FK_0d5df30c555944faaa36d5bec382459a` FOREIGN KEY (`OrdemProducaoPeca_CodigoIdentificador`) REFERENCES `ordemproducaopecas` (`CodigoIdentificador`),
  CONSTRAINT `FK_6b5465465ddd411193b8888bb1f2d25a` FOREIGN KEY (`OrdemProducaoPecaId`) REFERENCES `ordemproducaopecas` (`CodigoIdentificador`),
  CONSTRAINT `FK_ControleDeQualidades_Usuarios_Assinatura` FOREIGN KEY (`Assinatura`) REFERENCES `usuarios` (`UsuarioId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `controledequalidades`
--

LOCK TABLES `controledequalidades` WRITE;
/*!40000 ALTER TABLE `controledequalidades` DISABLE KEYS */;
INSERT INTO `controledequalidades` VALUES (13,341,'7:00 - 8:00',1324,1,1,1,2,0,'I2F1','I2F1'),(14,1234,'8:00 - 9:00',2134,1,1,1,2,0,'I2F1','I2F1'),(15,1341,'7:00 - 8:00',4321,1,0,0,2,0,'I2F2','I2F2'),(16,431,'8:00 - 9:00',412,0,1,1,2,0,'I2F2','I2F2'),(17,234,'7:00 - 8:00',234,1,1,1,2,0,'I2F3','I2F3'),(18,4,'8:00 - 9:00',43,0,1,0,2,0,'I2F3','I2F3'),(19,3425,'7:00 - 8:00',2345,1,0,0,2,0,'I2F4','I2F4'),(20,34,'8:00 - 9:00',432,0,0,1,2,0,'I2F4','I2F4');
/*!40000 ALTER TABLE `controledequalidades` ENABLE KEYS */;
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

-- MySQL dump 10.13  Distrib 5.5.62, for Win64 (AMD64)
--
-- Host: localhost    Database: MyLibrary
-- ------------------------------------------------------
-- Server version	5.5.5-10.3.34-MariaDB-0ubuntu0.20.04.1

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
-- Table structure for table `Livres`
--

DROP TABLE IF EXISTS `Livres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Livres` (
  `idLivre` int(11) NOT NULL AUTO_INCREMENT,
  `titre` varchar(100) NOT NULL,
  `auteur` varchar(255) NOT NULL,
  `nomImage` varchar(255) NOT NULL,
  `idUtilisateur` int(11) NOT NULL,
  PRIMARY KEY (`idLivre`),
  KEY `Livres_FK` (`idUtilisateur`),
  CONSTRAINT `Livres_FK` FOREIGN KEY (`idUtilisateur`) REFERENCES `Utilisateurs` (`idUtilisateur`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Livres`
--

LOCK TABLES `Livres` WRITE;
/*!40000 ALTER TABLE `Livres` DISABLE KEYS */;
/*!40000 ALTER TABLE `Livres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `References`
--

DROP TABLE IF EXISTS `References`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `References` (
  `idReference` int(11) NOT NULL AUTO_INCREMENT,
  `nomReference` varchar(100) DEFAULT NULL,
  `nomImage` varchar(255) DEFAULT NULL,
  `auteur` varchar(100) DEFAULT NULL,
  `idType` int(11) NOT NULL,
  `livreReference` int(11) DEFAULT NULL,
  `idLivre` int(11) DEFAULT NULL,
  `descriptionLieu` mediumtext DEFAULT NULL,
  PRIMARY KEY (`idReference`),
  KEY `References_FK` (`idType`),
  KEY `References_FK_2` (`livreReference`),
  KEY `References_FK_3` (`idLivre`),
  CONSTRAINT `References_FK` FOREIGN KEY (`idType`) REFERENCES `Types` (`idType`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `References_FK_2` FOREIGN KEY (`livreReference`) REFERENCES `Livres` (`idLivre`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `References_FK_3` FOREIGN KEY (`idLivre`) REFERENCES `Livres` (`idLivre`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=98 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `References`
--

LOCK TABLES `References` WRITE;
/*!40000 ALTER TABLE `References` DISABLE KEYS */;
/*!40000 ALTER TABLE `References` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Types`
--

DROP TABLE IF EXISTS `Types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Types` (
  `idType` int(11) NOT NULL AUTO_INCREMENT,
  `nomType` varchar(100) NOT NULL,
  PRIMARY KEY (`idType`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Types`
--

LOCK TABLES `Types` WRITE;
/*!40000 ALTER TABLE `Types` DISABLE KEYS */;
INSERT INTO `Types` VALUES (1,'livre'),(2,'musique'),(3,'lieu');
/*!40000 ALTER TABLE `Types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Utilisateurs`
--

DROP TABLE IF EXISTS `Utilisateurs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Utilisateurs` (
  `idUtilisateur` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `connecte` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`idUtilisateur`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Utilisateurs`
--

LOCK TABLES `Utilisateurs` WRITE;
/*!40000 ALTER TABLE `Utilisateurs` DISABLE KEYS */;
INSERT INTO `Utilisateurs` VALUES (1,'karel.svbd@eduge.ch','f6889fc97e14b42dec11a8c183ea791c5465b658',0),(2,'amir.yns@eduge.ch','9189e50bd7408fbf02cf59bd58a4776351bdbb72',0);
/*!40000 ALTER TABLE `Utilisateurs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'MyLibrary'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-18 15:02:37

-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: upn.shadir.com    Database: dbtpv
-- ------------------------------------------------------
-- Server version	8.0.32-0ubuntu0.22.04.2

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cajas`
--

DROP TABLE IF EXISTS `cajas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cajas` (
  `ID_Caja` int NOT NULL AUTO_INCREMENT,
  `ID_Sucursal` int DEFAULT NULL,
  `NombreCaja` varchar(45) DEFAULT NULL,
  `NombreSucursal` varchar(45) DEFAULT NULL,
  `ImpresoraTickets` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID_Caja`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cajas`
--

LOCK TABLES `cajas` WRITE;
/*!40000 ALTER TABLE `cajas` DISABLE KEYS */;
/*!40000 ALTER TABLE `cajas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `colonias`
--

DROP TABLE IF EXISTS `colonias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `colonias` (
  `ID_Colonia` int NOT NULL AUTO_INCREMENT,
  `NombreColonia` varchar(45) DEFAULT NULL,
  `zona` int DEFAULT '0',
  `cp` int DEFAULT NULL,
  PRIMARY KEY (`ID_Colonia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `colonias`
--

LOCK TABLES `colonias` WRITE;
/*!40000 ALTER TABLE `colonias` DISABLE KEYS */;
/*!40000 ALTER TABLE `colonias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cortes`
--

DROP TABLE IF EXISTS `cortes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cortes` (
  `ID_Corte` int NOT NULL AUTO_INCREMENT,
  `Fecha_Apertura` datetime DEFAULT CURRENT_TIMESTAMP,
  `Fecha_Cierre` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Fondo` decimal(10,2) NOT NULL,
  `Ingreso_Capturado` decimal(10,2) DEFAULT NULL,
  `Ingreso_Real` decimal(10,2) DEFAULT NULL,
  `Usuario` varchar(45) DEFAULT NULL,
  `Status` varchar(1) DEFAULT NULL,
  `totalAbonos` decimal(10,2) DEFAULT NULL,
  `cantAbonos` int DEFAULT NULL,
  PRIMARY KEY (`ID_Corte`)
) ENGINE=InnoDB AUTO_INCREMENT=350 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cortes`
--

LOCK TABLES `cortes` WRITE;
/*!40000 ALTER TABLE `cortes` DISABLE KEYS */;
/*!40000 ALTER TABLE `cortes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departamentos`
--

DROP TABLE IF EXISTS `departamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departamentos` (
  `ID_Departamento` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID_Departamento`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departamentos`
--

LOCK TABLES `departamentos` WRITE;
/*!40000 ALTER TABLE `departamentos` DISABLE KEYS */;
/*!40000 ALTER TABLE `departamentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `impresoras`
--

DROP TABLE IF EXISTS `impresoras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `impresoras` (
  `idimpresoras` int NOT NULL,
  `ImpresoraTickets` varchar(45) DEFAULT NULL,
  `Impresora` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idimpresoras`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `impresoras`
--

LOCK TABLES `impresoras` WRITE;
/*!40000 ALTER TABLE `impresoras` DISABLE KEYS */;
/*!40000 ALTER TABLE `impresoras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `ID_Producto` varchar(45) NOT NULL,
  `Descripcion` varchar(46) DEFAULT NULL,
  `PrecioContado` decimal(10,2) DEFAULT NULL,
  `Existencias` int DEFAULT NULL,
  `Departamento` varchar(40) DEFAULT NULL,
  `ExistenciaMinima` int DEFAULT NULL,
  `ExistenciaMaxima` int DEFAULT NULL,
  `Impuesto` decimal(10,2) DEFAULT NULL,
  `Descuento` decimal(10,2) DEFAULT '0.00',
  `idDepartamento` int DEFAULT NULL,
  PRIMARY KEY (`ID_Producto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `ID_Rol` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID_Rol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sucursales`
--

DROP TABLE IF EXISTS `sucursales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sucursales` (
  `ID_Sucursal` int NOT NULL AUTO_INCREMENT,
  `NombreComercial` varchar(45) DEFAULT NULL,
  `NombrePropietario` varchar(45) DEFAULT NULL,
  `Telefono` varchar(20) DEFAULT NULL,
  `RFC` varchar(20) DEFAULT NULL,
  `Leyenda` varchar(45) DEFAULT NULL,
  `Correo` varchar(25) DEFAULT NULL,
  `Curp` varchar(25) DEFAULT NULL,
  `DireccionSucursal` varchar(120) DEFAULT NULL,
  `Imagen` longblob,
  PRIMARY KEY (`ID_Sucursal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sucursales`
--

LOCK TABLES `sucursales` WRITE;
/*!40000 ALTER TABLE `sucursales` DISABLE KEYS */;
/*!40000 ALTER TABLE `sucursales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tasas`
--

DROP TABLE IF EXISTS `tasas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tasas` (
  `ID_Tasa` int NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(45) DEFAULT NULL,
  `Valor` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`ID_Tasa`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tasas`
--

LOCK TABLES `tasas` WRITE;
/*!40000 ALTER TABLE `tasas` DISABLE KEYS */;
/*!40000 ALTER TABLE `tasas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tickets`
--

DROP TABLE IF EXISTS `tickets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tickets` (
  `ID_Ticket` int NOT NULL AUTO_INCREMENT,
  `Corte` int DEFAULT NULL,
  `Fecha` varchar(45) DEFAULT NULL,
  `Hora` varchar(45) DEFAULT NULL,
  `Descuento` decimal(10,2) DEFAULT NULL,
  `IVA` decimal(10,2) DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL,
  `PagoMXN` decimal(10,2) DEFAULT NULL,
  `PagoUSD` decimal(10,2) DEFAULT NULL,
  `SuCambio` decimal(10,2) DEFAULT NULL,
  `TipoCambio` decimal(10,2) DEFAULT NULL,
  `ID_Usuario` int DEFAULT NULL,
  `Estado` int DEFAULT '0',
  `Comentarios` varchar(145) DEFAULT 'sc',
  PRIMARY KEY (`ID_Ticket`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tickets`
--

LOCK TABLES `tickets` WRITE;
/*!40000 ALTER TABLE `tickets` DISABLE KEYS */;
/*!40000 ALTER TABLE `tickets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipodecambio`
--

DROP TABLE IF EXISTS `tipodecambio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipodecambio` (
  `idTipoDeCambio` int NOT NULL AUTO_INCREMENT,
  `tipoDeCambio` decimal(10,2) DEFAULT NULL,
  `fecha` varchar(10) DEFAULT NULL,
  `registro` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idTipoDeCambio`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipodecambio`
--

LOCK TABLES `tipodecambio` WRITE;
/*!40000 ALTER TABLE `tipodecambio` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipodecambio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `idusuario` int NOT NULL AUTO_INCREMENT,
  `usuario` varchar(45) DEFAULT NULL,
  `clave` varchar(45) DEFAULT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `NombreCompleto` varchar(45) DEFAULT NULL,
  `apellido` varchar(45) DEFAULT NULL,
  `idrol` varchar(45) DEFAULT NULL,
  `Contrasena` varchar(45) DEFAULT NULL,
  `Contrasena2` varchar(45) DEFAULT NULL,
  `CURP` varchar(45) DEFAULT NULL,
  `RFC` varchar(45) DEFAULT NULL,
  `Tel` varchar(45) DEFAULT NULL,
  `Correo` varchar(45) DEFAULT NULL,
  `Direccion` varchar(45) DEFAULT NULL,
  `ID_Sucursal` varchar(45) DEFAULT '1',
  `Sesion` int DEFAULT '0',
  PRIMARY KEY (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'admin','admin','admin','admin',NULL,'admin','admin','admin','1','1','1','1','1','1',0);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS `ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ventas` (
  `ID_Venta` int NOT NULL AUTO_INCREMENT,
  `ID_Ticket` int DEFAULT NULL,
  `ID_Producto` varchar(45) DEFAULT NULL,
  `Descripcion` varchar(45) DEFAULT NULL,
  `Precio` double DEFAULT NULL,
  `Cantidad` int DEFAULT NULL,
  `SubTotalIVA` double DEFAULT NULL,
  `SubTotalDescuento` double DEFAULT NULL,
  `SubTotal` double DEFAULT NULL,
  `ID_Usuario` int DEFAULT NULL,
  `Estado` int DEFAULT '0',
  `Comentarios` varchar(145) DEFAULT 'sc',
  PRIMARY KEY (`ID_Venta`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES `ventas` WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-05 15:32:55

-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.39 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para proyectoagua
CREATE DATABASE IF NOT EXISTS `proyectoagua` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `proyectoagua`;

-- Volcando estructura para tabla proyectoagua.consumos
CREATE TABLE IF NOT EXISTS `consumos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `consumo` varchar(255) NOT NULL,
  `id_derechoAgua` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_derechoAgua` (`id_derechoAgua`),
  CONSTRAINT `consumos_ibfk_1` FOREIGN KEY (`id_derechoAgua`) REFERENCES `derecho_aguas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyectoagua.consumos: ~0 rows (aproximadamente)

-- Volcando estructura para tabla proyectoagua.derecho_aguas
CREATE TABLE IF NOT EXISTS `derecho_aguas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) NOT NULL,
  `pasaje` varchar(255) NOT NULL,
  `casa` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyectoagua.derecho_aguas: ~0 rows (aproximadamente)

-- Volcando estructura para tabla proyectoagua.empleados
CREATE TABLE IF NOT EXISTS `empleados` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) NOT NULL,
  `direccion` varchar(255) NOT NULL,
  `entrada` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyectoagua.empleados: ~0 rows (aproximadamente)

-- Volcando estructura para tabla proyectoagua.mechas
CREATE TABLE IF NOT EXISTS `mechas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cantidadMecha` varchar(255) NOT NULL,
  `id_derechoAgua` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_derechoAgua` (`id_derechoAgua`),
  CONSTRAINT `mechas_ibfk_1` FOREIGN KEY (`id_derechoAgua`) REFERENCES `derecho_aguas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyectoagua.mechas: ~0 rows (aproximadamente)

-- Volcando estructura para tabla proyectoagua.moras
CREATE TABLE IF NOT EXISTS `moras` (
  `id` int NOT NULL AUTO_INCREMENT,
  `mora` varchar(255) NOT NULL,
  `id_derechoAgua` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_derechoAgua` (`id_derechoAgua`),
  CONSTRAINT `moras_ibfk_1` FOREIGN KEY (`id_derechoAgua`) REFERENCES `derecho_aguas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyectoagua.moras: ~0 rows (aproximadamente)

-- Volcando estructura para tabla proyectoagua.registro_aguas
CREATE TABLE IF NOT EXISTS `registro_aguas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `pago` varchar(255) NOT NULL,
  `fecha_pago` datetime DEFAULT NULL,
  `Id_DerechoAgua` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Id_DerechoAgua` (`Id_DerechoAgua`),
  CONSTRAINT `registro_aguas_ibfk_1` FOREIGN KEY (`Id_DerechoAgua`) REFERENCES `derecho_aguas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyectoagua.registro_aguas: ~0 rows (aproximadamente)

-- Volcando estructura para tabla proyectoagua.roles
CREATE TABLE IF NOT EXISTS `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyectoagua.roles: ~0 rows (aproximadamente)

-- Volcando estructura para tabla proyectoagua.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) NOT NULL,
  `apellido` varchar(255) NOT NULL,
  `usuario` varchar(255) NOT NULL,
  `pass` varchar(255) NOT NULL,
  `id_rol` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_rol` (`id_rol`),
  CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyectoagua.usuarios: ~0 rows (aproximadamente)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

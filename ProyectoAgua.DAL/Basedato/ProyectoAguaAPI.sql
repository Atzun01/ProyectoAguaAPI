create database ProyectoAgua_API
use ProyectoAgua_API

CREATE TABLE derechoagua (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(20) NOT NULL,
    pasaje VARCHAR(50) NOT NULL,
    casa VARCHAR(100) NOT NULL
);

CREATE TABLE consumo (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idderechoagua INT NOT NULL,
    mora VARCHAR(32),
    FOREIGN KEY (idderechoagua) REFERENCES derechoagua(id)
);

CREATE TABLE empleado (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(20) NOT NULL,
    direccion VARCHAR(50) NOT NULL,
    entrada VARCHAR(100) NOT NULL
);

CREATE TABLE mecha (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idderechoagua INT NOT NULL,
    cantidadmecha INT NOT NULL,
    FOREIGN KEY (idderechoagua) REFERENCES derechoagua(id)
);

CREATE TABLE mora (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idderechoagua INT NOT NULL,
    cantidadmora INT NOT NULL,
    FOREIGN KEY (idderechoagua) REFERENCES derechoagua(id)
);

CREATE TABLE registroagua (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idderechoagua INT NOT NULL,
    pago INT NOT NULL,
    fechapago DATE NOT NULL,
    FOREIGN KEY (idderechoagua) REFERENCES derechoagua(id)
);

CREATE TABLE rol (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(20) NOT NULL
);

CREATE TABLE usuario (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idrol INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    login VARCHAR(100) NOT NULL,
    password VARCHAR(32) NOT NULL,
    estatus TINYINT NOT NULL,
    fecharegistro DATE NOT NULL,
    FOREIGN KEY (idrol) REFERENCES rol(id)
);



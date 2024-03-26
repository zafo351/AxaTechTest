
-- Script de creación de base de datos
CREATE DATABASE WPFDatabase
USE WPFDatabase;

-- Database Script
CREATE TABLE Areas (
  IdArea INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  AreaName VARCHAR(50) NOT NULL,
  AreaDescription VARCHAR(200)
);


CREATE TABLE Users (
  IdUser INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  EmailAddress VARCHAR(100) NOT NULL,
  Phone INT NOT NULL,
  IdArea INT FOREIGN KEY REFERENCES Areas (IdArea)
); 

-- Inser data test
INSERT INTO Areas (AreaName, AreaDescription)
VALUES
  ('VENTAS', 'Gestiona las ventas de la empresa.'),
  ('MERCADEO', 'Desarrolla estrategias de marketing para la empresa.'),
  ('RRHH', 'Gestiona el personal de la empresa.'),
  ('CONTABILIDAD', 'Gestiona las finanzas de la empresa.'),
  ('IT', 'Desarrolla y mantiene la infraestructura tecnológica de la empresa.');


INSERT INTO Users (FirstName, LastName, EmailAddress, Phone)
VALUES
('Ana', 'Gómez', 'ana.gomez@ejemplo.com', 123456789),
('Juan', 'Pérez', 'juan.perez@ejemplo.com', 987654321),
('María', 'Martínez', 'maria.martinez@ejemplo.com', 112233445),
('Pedro', 'Fernández', 'pedro.fernandez@ejemplo.com', 678901234),
('Laura', 'Jiménez', 'laura.jimenez@ejemplo.com', 543210987);


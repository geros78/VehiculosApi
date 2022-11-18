CREATE DATABASE Vehiculos

USE Vehiculos

CREATE TABLE Matriculas (
Id INT IDENTITY(1,1),
Numero VARCHAR(20) PRIMARY KEY NOT NULL,
FechaExpedicion DATE NOT NULL,
ValidaHasta DATE NOT NULL,
Activo BIT
)

IF OBJECT_ID('Sanciones') is not null
DROP TABLE Sanciones

CREATE TABLE Conductores (
Id INT IDENTITY(1,1),
Identificacion VARCHAR(15) PRIMARY KEY NOT NULL,
Nombre VARCHAR(20) NOT NULL,
Apellido VARCHAR(20) NOT NULL,
Direccion VARCHAR(30),
Telefono VARCHAR(15),
Email VARCHAR(30),
FechaNacimiento DATE,
Activo BIT,
NumeroMatricula VARCHAR(20) 
FOREIGN KEY REFERENCES Matriculas(Numero)
ON UPDATE CASCADE
)

CREATE TABLE Sanciones (
Id INT IDENTITY(1,1) PRIMARY KEY,
FechaActual DATE DEFAULT GETDATE(),
Sancion VARCHAR(100),
Observacion VARCHAR(MAX) NULL,
Valor DECIMAL(10,2),
ConductorId VARCHAR(15) 
FOREIGN KEY REFERENCES Conductores(Identificacion)
ON UPDATE CASCADE
)

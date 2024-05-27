--USAR BASE DE DATOS CREADA
GO
USE Coink

----------------------------------------------------
--CREACIÓN DE TABLA PERSONA/USUARIO EN BASE DE DATOS
----------------------------------------------------

--Asegurar de que no exista la Tabla, luego crear la tabla.
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'EntidadPersonas')
CREATE TABLE EntidadPersonas (
    Identificador INT PRIMARY KEY IDENTITY(1,1),
    Nombres VARCHAR(50),
    Telefono VARCHAR(50),
    Direccion VARCHAR(50),
    Pais VARCHAR(50),
    Departamento VARCHAR(50),
	Municipio VARCHAR(50)
);

----------------------------------------------------
--CREACIÓN DE TABLAS PARÁMETRICAS PARA 
--"PAIS", "DEPARTAMENTO", "MUNICIPIO"
----------------------------------------------------
GO

--TABLA PAIS
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PaisUsuario')
CREATE TABLE PaisUsuario (
	Identificador INT PRIMARY KEY IDENTITY(1,1),
	Pais VARCHAR(50),
    Id_Usuario VARCHAR(50)
);

--TABLA DEPARTAMENTO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'DepartamentoUsuario')
CREATE TABLE DepartamentoUsuario (
    Identificador INT PRIMARY KEY IDENTITY(1,1),
    Departamento VARCHAR(50),
	Id_Usuario VARCHAR(50)
);

--TABLA MUNICIPIO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'MunicipioUsuario')
CREATE TABLE MunicipioUsuario (
    Identificador INT PRIMARY KEY IDENTITY(1,1),
    Municipio VARCHAR(50),
	Id_Usuario VARCHAR(50)
);
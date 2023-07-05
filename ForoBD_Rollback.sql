-- Creación de la base de datos
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'ForoBD_Rollback')
  DROP DATABASE ForoBD_Rollback;

CREATE DATABASE ForoBD_Rollback;
GO

USE ForoBD_Rollback;
GO

-- Crear tabla empleado
IF OBJECT_ID('empleado', 'U') IS NOT NULL
  DROP TABLE empleado;
CREATE TABLE empleado (
    empleado_id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50),
    direccion VARCHAR(100),
    telefono VARCHAR(50),
    salario FLOAT,
    estado BIT
);

-- Crear tabla proveedor
IF OBJECT_ID('cliente', 'U') IS NOT NULL
  DROP TABLE cliente;
CREATE TABLE cliente (
    cliente_id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50),
	apellido VARCHAR(50),
    direccion VARCHAR(150),
    telefono VARCHAR(50),
    fechaNacimiento DATE,
    estado BIT
);

-- Crear tabla pedido
IF OBJECT_ID('pedido', 'U') IS NOT NULL
  DROP TABLE pedido;
CREATE TABLE pedido (
    pedido_id INT IDENTITY(1,1) PRIMARY KEY,
    fechaPedido DATE,
	cliente_id INT,
    empleado_id INT,
    estado BIT,
	FOREIGN KEY (cliente_id) REFERENCES cliente(cliente_id),
    FOREIGN KEY (empleado_id) REFERENCES empleado(empleado_id)
);


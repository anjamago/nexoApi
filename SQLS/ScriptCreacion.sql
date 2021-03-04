

/**

* Author: Andy Martinez
*/


CREATE DATABASE APINEXOS;
GO

USE APINEXOS;
GO

CREATE TABLE AUTORES(
	ID INT IDENTITY(1,1) NOT NULL,
	NOMBRE_COMPLETO VARCHAR(255),
	FECHA_NACIMIENTO DATETIME,
	CIUDAD VARCHAR(255),
	CORREO VARCHAR(255),

	CONSTRAINT PK_AUTORES PRIMARY KEY(
		ID ASC
	),
	CONSTRAINT UQ_AUTORES UNIQUE(
		 CORREO
	),
	
);
GO

CREATE TABLE EDITORIALES(
	ID INT IDENTITY(1,1) NOT NULL,
	NOMBRE VARCHAR(255),
	DIRECION_CORRESPONDENCIA VARCHAR(255),
	TELEFONO VARCHAR(20),
	CORREO VARCHAR(255),
	LIBROS_REGISTRADO BIGINT,

	CONSTRAINT PK_EDITORIALES PRIMARY KEY(
		ID ASC
	),

	CONSTRAINT UQ_EDITORIAL UNIQUE(
		NOMBRE, CORREO
	),
	
);
GO


CREATE TABLE LIBROS(
	ID INT IDENTITY(1,1) NOT NULL,
	TITULO VARCHAR(255),
	ANNO INT,
	GENERON VARCHAR(255),
	NUMERO_PAGINA INT,
	ID_EDITORIAL INT,
	ID_AUTOR INT,

	CONSTRAINT PK_LIBROS PRIMARY KEY(
		ID ASC
	),
	CONSTRAINT FK_EDITORIAL FOREIGN KEY (ID_EDITORIAL)
		REFERENCES EDITORIALES(ID),
	
	CONSTRAINT FK_AUTOR FOREIGN KEY (ID_AUTOR)
		REFERENCES AUTORES(ID)

);
GO





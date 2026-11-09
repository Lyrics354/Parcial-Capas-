-- Estructura de las tablas que usa la aplicación.

CREATE DATABASE IF NOT EXISTS productosdb;
USE productosdb;

CREATE TABLE IF NOT EXISTS usuarios (
    id INT NOT NULL AUTO_INCREMENT,
    dsId VARCHAR(50) NOT NULL,
    dsUsuario VARCHAR(50) NOT NULL,
    dsPassword VARBINARY(64) NOT NULL,
    dsEstado CHAR(1) NOT NULL DEFAULT '1',
    dsUsuarioCreacion VARCHAR(50) NOT NULL,
    dtFechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    dsUsuarioModificacion VARCHAR(50) NOT NULL DEFAULT 'Sistema',
    dtFechaModificacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    UNIQUE KEY dsUsuario (dsUsuario)
);

CREATE TABLE IF NOT EXISTS productos (
    id INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    cantidad INT NOT NULL,
    imagen LONGBLOB,
    FechaC DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FechaM DATETIME DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (id)
);

-- Usuario de ejemplo: cambia la contraseña antes de ejecutarlo.
INSERT INTO usuarios (dsId, dsUsuario, dsPassword, dsUsuarioCreacion)
VALUES ('1', 'admin', UNHEX(SHA2('CAMBIAR_CLAVE', 512)), 'Sistema');

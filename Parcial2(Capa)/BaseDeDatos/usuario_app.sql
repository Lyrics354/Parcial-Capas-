-- Usuario de la aplicación con los privilegios mínimos.
-- Solo puede leer las columnas que el programa necesita.

CREATE USER 'app_tienda'@'localhost' IDENTIFIED BY 'CAMBIAR_CLAVE';

GRANT SELECT (id, dsUsuario, dsPassword, dsEstado)
    ON productosdb.usuarios TO 'app_tienda'@'localhost';

GRANT SELECT (id, nombre, precio, cantidad, imagen)
    ON productosdb.productos TO 'app_tienda'@'localhost';

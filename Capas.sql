use productosdb;
SELECT dsUsuario, dsEstado FROM productosdb.usuarios;
UPDATE productosdb.usuarios
SET dsPassword = UNHEX(SHA2('TU_CONTRASEÑA', 512))
WHERE dsUsuario = 'admin';
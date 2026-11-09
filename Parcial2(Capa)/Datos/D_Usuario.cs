using Entidades;
using MySql.Data.MySqlClient;

namespace Datos
{
    /// <summary>
    /// Consulta los usuarios en la base de datos.
    /// </summary>
    public class D_Usuario : D_Conexion
    {
        /// <summary>
        /// Busca un usuario activo por su nombre.
        /// </summary>
        /// <param name="strUsuario">Nombre de usuario.</param>
        /// <returns>El usuario con su hash en hexadecimal, o null si no existe.</returns>
        public static E_Usuario ObtenerPorNombre(string strUsuario)
        {
            const string consulta =
                "SELECT id, dsUsuario, HEX(dsPassword) AS dsPassword " +
                "FROM usuarios " +
                "WHERE dsUsuario = @dsUsuario AND dsEstado = '1' " +
                "LIMIT 1";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@dsUsuario", strUsuario);
                conexion.Open();

                using (MySqlDataReader fReader = cmd.ExecuteReader())
                {
                    if (!fReader.Read())
                    {
                        return null;
                    }

                    return new E_Usuario
                    {
                        id = fReader.GetInt32("id"),
                        dsUsuario = fReader.GetString("dsUsuario"),
                        dsPassword = fReader.GetString("dsPassword")
                    };
                }
            }
        }
    }
}

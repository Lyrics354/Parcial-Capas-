using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    /// <summary>
    /// Consulta los productos en la base de datos.
    /// </summary>
    public class D_Producto : D_Conexion
    {
        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>Tabla con el id, nombre, precio, cantidad e imagen.</returns>
        public static DataTable Listar()
        {
            string consulta = "SELECT ID, Nombre, Precio, Cantidad, Imagen FROM productos";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            using (MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }
    }
}

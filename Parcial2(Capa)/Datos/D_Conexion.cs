using System.Configuration;

namespace Datos
{
    /// <summary>
    /// Clase base de la capa de datos. Lee la cadena de conexión desde la
    /// configuración de la aplicación para no guardar credenciales en el código.
    /// </summary>
    public class D_Conexion
    {
        /// <summary>
        /// Cadena de conexión del usuario app_tienda, que solo tiene permisos de lectura.
        /// </summary>
        protected static string cadenaConexion =>
            ConfigurationManager.ConnectionStrings["TiendaDb"].ConnectionString;
    }
}

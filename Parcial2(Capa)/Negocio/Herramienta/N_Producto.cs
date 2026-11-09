using System.Data;
using Datos;

namespace Negocio
{
    /// <summary>
    /// Contiene las operaciones de negocio de los productos.
    /// </summary>
    public class N_Producto
    {
        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>Tabla con los productos registrados.</returns>
        public static DataTable Listar()
        {
            return D_Producto.Listar();
        }
    }
}

using System.Data;

namespace Presentacion.Vistas
{
    /// <summary>
    /// Contrato de la pantalla principal. El presentador solo conoce esta
    /// interfaz, no el formulario.
    /// </summary>
    public interface IPrincipalVista
    {
        /// <summary>Hora actual que se muestra en pantalla.</summary>
        string Hora { set; }

        /// <summary>Fecha actual que se muestra en pantalla.</summary>
        string Fecha { set; }

        /// <summary>Texto con el usuario que inició sesión.</summary>
        string UsuarioActual { set; }

        /// <summary>Productos que se muestran en la tabla.</summary>
        DataTable Productos { set; }

        /// <summary>Reduce el menú izquierdo para mostrar solo los íconos.</summary>
        void ContraerMenu();

        /// <summary>Muestra el menú izquierdo completo.</summary>
        void ExpandirMenu();

        /// <summary>Muestra un mensaje de error.</summary>
        void MostrarError(string mensaje);

        /// <summary>Muestra un mensaje informativo.</summary>
        void MostrarInformacion(string mensaje);
    }
}

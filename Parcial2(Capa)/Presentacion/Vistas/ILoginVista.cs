using Entidades;

namespace Presentacion.Vistas
{
    /// <summary>
    /// Contrato de la pantalla de inicio de sesión. El presentador solo conoce
    /// esta interfaz, no el formulario.
    /// </summary>
    public interface ILoginVista
    {
        /// <summary>Nombre de usuario escrito en pantalla.</summary>
        string Usuario { get; }

        /// <summary>Contraseña escrita en pantalla.</summary>
        string Password { get; }

        /// <summary>Muestra un aviso, por ejemplo cuando faltan datos.</summary>
        void MostrarAdvertencia(string mensaje);

        /// <summary>Muestra un mensaje de error.</summary>
        void MostrarError(string mensaje);

        /// <summary>Muestra un mensaje informativo.</summary>
        void MostrarInformacion(string mensaje);

        /// <summary>Limpia la contraseña y devuelve el foco a ese campo.</summary>
        void LimpiarPassword();

        /// <summary>Abre la pantalla principal con el usuario que inició sesión.</summary>
        void AbrirPrincipal(E_Usuario usuario);
    }
}

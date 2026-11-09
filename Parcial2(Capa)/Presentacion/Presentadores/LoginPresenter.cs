using System;
using Entidades;
using Negocio;
using Presentacion.Vistas;

namespace Presentacion.Presentadores
{
    /// <summary>
    /// Coordina el inicio de sesión entre la vista y la capa de negocio.
    /// </summary>
    public class LoginPresenter
    {
        private readonly ILoginVista vista;
        private readonly N_Usuario negocio;

        /// <summary>
        /// Crea el presentador con su vista y su servicio de negocio.
        /// </summary>
        public LoginPresenter(ILoginVista vista, N_Usuario negocio)
        {
            this.vista = vista;
            this.negocio = negocio;
        }

        /// <summary>
        /// Valida los datos escritos e intenta iniciar sesión.
        /// </summary>
        public void IniciarSesion()
        {
            if (string.IsNullOrWhiteSpace(vista.Usuario) || string.IsNullOrEmpty(vista.Password))
            {
                vista.MostrarAdvertencia("Ingrese usuario y contraseña.");
                return;
            }

            try
            {
                E_Usuario usuario = negocio.Login(vista.Usuario, vista.Password);

                if (usuario == null)
                {
                    vista.MostrarError("Usuario o contraseña incorrectos.");
                    vista.LimpiarPassword();
                    return;
                }

                vista.MostrarInformacion("¡Bienvenido, " + usuario.dsUsuario + "!");
                vista.AbrirPrincipal(usuario);
            }
            catch (Exception ex)
            {
                vista.MostrarError("No se pudo conectar a la base de datos:\n" + ex.Message);
            }
        }
    }
}

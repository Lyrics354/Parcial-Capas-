using Datos;
using Entidades;
using Negocio.Interfaces;

namespace Negocio
{
    /// <summary>
    /// Contiene las reglas de negocio de los usuarios.
    /// </summary>
    public class N_Usuario
    {
        private readonly IVerificarHashService verificador;

        /// <summary>
        /// Recibe el contrato con el que se comprobarán las contraseñas.
        /// </summary>
        public N_Usuario(IVerificarHashService verificador)
        {
            this.verificador = verificador;
        }

        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        /// <param name="strUsuario">Nombre de usuario.</param>
        /// <param name="strPassword">Contraseña en texto plano.</param>
        /// <returns>El usuario si las credenciales son correctas; si no, null.</returns>
        public E_Usuario Login(string strUsuario, string strPassword)
        {
            E_Usuario usuario = D_Usuario.ObtenerPorNombre(strUsuario);

            if (usuario == null || !verificador.Verificar(strPassword, usuario.dsPassword))
            {
                return null;
            }

            usuario.dsPassword = null; // El hash no debe llegar a la interfaz
            return usuario;
        }
    }
}

using System;
using System.Globalization;
using Entidades;
using Negocio;
using Presentacion.Vistas;

namespace Presentacion.Presentadores
{
    /// <summary>
    /// Coordina los datos y el menú de la pantalla principal.
    /// </summary>
    public class PrincipalPresenter
    {
        private readonly IPrincipalVista vista;
        private readonly E_Usuario usuario;
        private bool menuContraido;

        /// <summary>
        /// Crea el presentador con su vista y el usuario que inició sesión.
        /// </summary>
        public PrincipalPresenter(IPrincipalVista vista, E_Usuario usuario)
        {
            this.vista = vista;
            this.usuario = usuario;
        }

        /// <summary>
        /// Carga el usuario, la hora y los productos al abrir la pantalla.
        /// </summary>
        public void Cargar()
        {
            vista.UsuarioActual = "Usuario: " + usuario.dsUsuario;
            ActualizarHora();
            CargarProductos();
        }

        /// <summary>
        /// Actualiza la hora y la fecha en pantalla.
        /// </summary>
        public void ActualizarHora()
        {
            DateTime ahora = DateTime.Now;
            vista.Hora = ahora.ToString("HH:mm:ss");
            vista.Fecha = ahora.ToString("dddd, d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
        }

        /// <summary>
        /// Contrae o expande el menú izquierdo.
        /// </summary>
        public void AlternarMenu()
        {
            menuContraido = !menuContraido;

            if (menuContraido)
            {
                vista.ContraerMenu();
            }
            else
            {
                vista.ExpandirMenu();
            }
        }

        /// <summary>
        /// Responde a la selección de una opción del menú.
        /// </summary>
        /// <param name="modulo">Nombre de la opción elegida.</param>
        public void SeleccionarModulo(string modulo)
        {
            if (modulo == "Productos")
            {
                CargarProductos();
                return;
            }

            vista.MostrarInformacion("El módulo " + modulo + " todavía no está disponible.");
        }

        private void CargarProductos()
        {
            try
            {
                vista.Productos = N_Producto.Listar();
            }
            catch (Exception ex)
            {
                vista.MostrarError("No se pudieron cargar los productos:\n" + ex.Message);
            }
        }
    }
}

using System;
using System.Windows.Forms;
using Entidades;
using Negocio;
using Presentacion.Presentadores;
using Presentacion.Vistas;

namespace Presentacion
{
    /// <summary>
    /// Vista de inicio de sesión. Solo muestra datos y delega la lógica en
    /// <see cref="LoginPresenter"/>.
    /// </summary>
    public partial class frmLogin : Form, ILoginVista
    {
        private readonly LoginPresenter presenter;

        /// <summary>
        /// Inicializa el formulario y su presentador.
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            presenter = new LoginPresenter(this, new N_Usuario(new HashService()));
        }

        /// <inheritdoc />
        public string Usuario => txtUsuario.Text.Trim();

        /// <inheritdoc />
        public string Password => txtPassword.Text;

        /// <inheritdoc />
        public void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Datos incompletos",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <inheritdoc />
        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <inheritdoc />
        public void MostrarInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Inicio de sesión",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <inheritdoc />
        public void LimpiarPassword()
        {
            txtPassword.Clear();
            txtPassword.Focus();
        }

        /// <inheritdoc />
        public void AbrirPrincipal(E_Usuario usuario)
        {
            Hide();
            frmUsuarios principal = new frmUsuarios(usuario);
            // Al cerrar la pantalla principal termina la aplicación
            principal.FormClosed += (s, args) => Close();
            principal.Show();
        }

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            presenter.IniciarSesion();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

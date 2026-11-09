using System;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Presentacion.Presentadores;
using Presentacion.Vistas;

namespace Presentacion
{
    /// <summary>
    /// Vista principal: menú izquierdo, reloj, usuario actual y productos.
    /// Delega la lógica en <see cref="PrincipalPresenter"/>.
    /// </summary>
    public partial class frmUsuarios : Form, IPrincipalVista
    {
        private const int MargenIconos = 4;

        private readonly PrincipalPresenter presenter;
        private int anchoMenuExpandido;
        private int anchoMenuContraido;
        private int separacionBotonMenu;

        /// <summary>
        /// Inicializa la pantalla para el usuario que inició sesión.
        /// </summary>
        /// <param name="usuario">Usuario autenticado.</param>
        public frmUsuarios(E_Usuario usuario)
        {
            InitializeComponent();
            presenter = new PrincipalPresenter(this, usuario);
        }

        /// <inheritdoc />
        public string Hora
        {
            set { lblHora.Text = value; }
        }

        /// <inheritdoc />
        public string Fecha
        {
            set { lblFecha.Text = value; }
        }

        /// <inheritdoc />
        public string UsuarioActual
        {
            set { lblUsuarioActual.Text = value; }
        }

        /// <inheritdoc />
        public DataTable Productos
        {
            set { dataGridView1.DataSource = value; }
        }

        /// <inheritdoc />
        public void ContraerMenu()
        {
            CambiarAnchoMenu(anchoMenuContraido);
        }

        /// <inheritdoc />
        public void ExpandirMenu()
        {
            CambiarAnchoMenu(anchoMenuExpandido);
        }

        /// <inheritdoc />
        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <inheritdoc />
        public void MostrarInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CambiarAnchoMenu(int ancho)
        {
            MenuVertical.Width = ancho;
            btnslide.Left = ancho + separacionBotonMenu;
        }

        // Se mide en ejecución porque Windows escala los controles
        private void MedirMenu()
        {
            anchoMenuExpandido = MenuVertical.Width;
            anchoMenuContraido = pictureBox2.Right + MargenIconos;
            separacionBotonMenu = btnslide.Left - anchoMenuExpandido;
        }

        private void ConfigurarTabla()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            MedirMenu();
            ConfigurarTabla();
            presenter.Cargar();
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            presenter.ActualizarHora();
        }

        private void btnslide_Click(object sender, EventArgs e)
        {
            presenter.AlternarMenu();
        }

        // Compartido por los botones del menú y del sumario
        private void Menu_Click(object sender, EventArgs e)
        {
            presenter.SeleccionarModulo(((Button)sender).Text);
        }
    }
}

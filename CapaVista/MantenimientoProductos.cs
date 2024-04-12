using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class MantenimientoProductos : Form
    {
        ProductoLOG _productoLOG;

        public MantenimientoProductos()
        {
            InitializeComponent();

            _productoLOG = new ProductoLOG();

            dgvProductos.DataSource = _productoLOG.ObtenerProductos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            RegistroProducto objRegistroProducto = new RegistroProducto();
            objRegistroProducto.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

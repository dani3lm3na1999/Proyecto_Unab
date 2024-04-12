using CapaEntidades;
using CapaLogica;
using System;
using System.CodeDom;
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
    public partial class RegistroProducto : Form
    {
        ProductoLOG _productoLOG;

        public RegistroProducto()
        {
            InitializeComponent();

            productoBindingSource.MoveLast();
            productoBindingSource.AddNew();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarProducto();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarProducto()
        {
            try
            {
                _productoLOG = new ProductoLOG();

                //throw new Exception();
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Se requiere el nombre del producto", "Tienda | Registro Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    txtNombre.BackColor = Color.LightYellow;
                    return;
                }

                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    MessageBox.Show("Se requiere la descripción del producto", "Tienda | Registro Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtPrecioUnitario.Text) || Convert.ToDecimal(txtPrecioUnitario.Text) == 0)
                {
                    MessageBox.Show("Se requiere el precio del producto", "Tienda | Registro Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtExistencias.Text) || Convert.ToDecimal(txtExistencias.Text) == 0)
                {
                    MessageBox.Show("Se requiere agregar existencias del producto", "Tienda | Registro Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!chkEstado.Checked)
                {
                    var dialogo = MessageBox.Show("¿Esta seguro que desea guardar el producto inactivo","Tienda | Registro Productos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogo != DialogResult.Yes)
                    {
                        MessageBox.Show("Seleccione el cuadro Estado como activo", "Tienda | Registro Productos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                productoBindingSource.EndEdit();

                Producto producto;
                producto = (Producto)productoBindingSource.Current;

                int resultado = _productoLOG.GuardarProducto(producto);

                if (resultado > 0)
                {
                    MessageBox.Show("Producto agregado con exito", "Tienda | Registro Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se logro guardar el usuario", "Tienda | Registro Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un Error","Tienda | Registro Productos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

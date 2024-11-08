using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_Ej1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidad.Clear();
            txtCodigo.Clear();
            txtDescuento.Clear();
            txtIVA.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtSubtotal.Clear();
            txtTotal.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false; 
            checkBox4.Checked = false;
            checkBox5.Checked = false;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Interfaz hecho por Farid Eduardo Zúñiga Rico // 7-11-24");
            MessageBox.Show("Saliendo..."); 
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos leidos correctamente");
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!int.TryParse(txtPrecio.Text, out int precioUnitario) || precioUnitario <= 0)
            {
                MessageBox.Show("El precio debe ser un número positivo.");
                txtPrecio.Focus();
                return;
            }
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.");
                txtCantidad.Focus();
                return;
            }
            int checkedCount = 0;
            double descuentoSeleccionado = 0;
            //Validación de elección de checklist
            if (checkBox1.Checked)
            {
                checkedCount++;
                descuentoSeleccionado = 0.00;
            }
            if (checkBox2.Checked)
            {
                checkedCount++;
                descuentoSeleccionado = 0.01;
            }
            if (checkBox3.Checked)
            {
                checkedCount++;
                descuentoSeleccionado = 0.5;
            }
            if (checkBox4.Checked)
            {
                checkedCount++;
                descuentoSeleccionado = 0.10;
            }
            if (checkBox5.Checked)
            {
                checkedCount++;
                descuentoSeleccionado = 0.15;
            }

            if (checkedCount == 0)
            {
                MessageBox.Show("Debe seleccionar un porcentaje de descuento.");
                return;
            }
            else if (checkedCount > 1)
            {
                MessageBox.Show("Solo debe seleccionar un porcentaje de descuento.");
                return;
            }

            // Cálculos
            double subtotal = precioUnitario * cantidad;
            double descuento = subtotal * descuentoSeleccionado;
            double iva = subtotal * 0.15;
            double total = subtotal - descuento + iva;

            // Mostrar resultados
            txtSubtotal.Text = subtotal.ToString();
            txtDescuento.Text = descuento.ToString();
            txtIVA.Text = iva.ToString();
            txtTotal.Text = total.ToString();



        }
    }
}

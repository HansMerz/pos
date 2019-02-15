using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class ActualiProd : Form
    {
        Producto producto = new Producto();
   
        public ActualiProd(Int64 numref, String nombre, String marca, Int64 precio, String desc, String catego, int iva)
        {
            InitializeComponent();
            producto.numref = numref;
            producto.nombre = nombre;
            producto.marca = marca;
            producto.precio = precio;
            producto.descripcion = desc;
            producto.categoria = catego;
            producto.iva = iva;
           
            txtMarca.Text = producto.marca;
            txtNombre.Text = producto.nombre;
            numPrecio.Value = producto.precio;
            txtDesc.Text = producto.descripcion;
            cboIva.Text = producto.iva.ToString();

            cboCategoria.Text = producto.loadCategoryComboBox(cboCategoria);

            cboCategoria.Text = producto.categoria.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                producto.nombre = txtNombre.Text;
                producto.marca = txtMarca.Text;
                producto.descripcion = txtDesc.Text;
                producto.idcategoria = producto.getIdFromCategoryName(cboCategoria);
                producto.precio = Convert.ToInt64(numPrecio.Value);
                producto.iva = int.Parse(cboIva.SelectedItem.ToString());

                producto.ActualizarProducto();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al realizar el proceso","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}

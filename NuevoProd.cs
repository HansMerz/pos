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
    public partial class NuevoProd : Form
    {
        Producto producto = new Producto();

        public NuevoProd()
        {
            InitializeComponent();
            cboCategoria.Text = producto.loadCategoryComboBox(cboCategoria);
        }
        
        private void btnReg_Click(object sender, EventArgs e)
        {
            try{

                producto.numref = Convert.ToInt64(numRef.Value);
                producto.nombre = txtNombre.Text;
                producto.marca = txtMarca.Text;
                producto.idcategoria = int.Parse(cboCategoria.SelectedValue.ToString());
                producto.descripcion = txtDesc.Text;
                producto.estado = 1;
                producto.precio = Int64.Parse(txtPrecioUnitario.Value.ToString());
                producto.iva = Convert.ToInt32(cboIva.SelectedItem.ToString());


                String success = "";
                success += ValidarVacio(producto.nombre, "Nombre");
                success += ValidarVacio(producto.marca, "Marca");


                if (success.Length <= 0)
                {
                    producto.InsertarProducto();
                    producto.id = producto.getId();
                    producto.InsertarenStock();
                    Close();
                }
                else
                {
                    MessageBox.Show("Revise que los siguientes campos no estén vacíos:" + success, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception)
            {
                MessageBox.Show("Revise que los datos hayan sido ingresado correctamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public String ValidarVacio(String texto, String alias)
        {
            if(texto.Length <= 0)
            {
                return "\n"+alias;
            }
            return "";
        }
    }
}

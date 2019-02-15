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
    public partial class Inventario : Form
    {
        Producto producto = new Producto();
        Menu m;

        public Inventario(Menu m)
        {
            this.m = m;
            InitializeComponent();
            producto.loadTable(gridRegPro);
            editButton(btnDelete, Color.Gray, false);
            editButton(btnUpdate, Color.Gray, false);
            editButton(btnGestion, Color.Gray, false);
        }

        public void editButton(Button b, Color c, bool enabled)
        {
            b.Enabled = enabled;
            b.BackColor = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new NuevoProd().ShowDialog();
            producto.loadTable(gridRegPro);
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new ActualiProd(producto.numref, producto.nombre, producto.marca, producto.precio, producto.descripcion, producto.categoria, producto.iva).ShowDialog();
            producto.loadTable(gridRegPro);
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            producto.EliminarProducto(producto.numref);
            producto.loadTable(gridRegPro);
        }

        private void gridRegPro_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
                if (e.RowIndex >= 0)
                {

                    producto.numref = Convert.ToInt64(gridRegPro[0, e.RowIndex].Value.ToString());
                    producto.nombre = gridRegPro[1, e.RowIndex].Value.ToString();
                    producto.marca = gridRegPro[2, e.RowIndex].Value.ToString();
                    producto.precio = Convert.ToInt64(gridRegPro[3, e.RowIndex].Value);
                    //producto.iva = int.Parse(gridRegPro[4, e.RowIndex].Value.ToString());
                    producto.descripcion = gridRegPro[4, e.RowIndex].Value.ToString();
                    producto.categoria = gridRegPro[5, e.RowIndex].Value.ToString();

                    producto.id = producto.ExtraerIdDeItem(producto.numref);

                    editButton(btnDelete, Color.Red, true);
                    editButton(btnUpdate, Color.Green, true);
                    editButton(btnGestion, Color.Orange, true);

                }
                else
                {
                    editButton(btnDelete, Color.Gray, false);
                    editButton(btnUpdate, Color.Gray, false);
                    editButton(btnGestion, Color.Gray, false);
                }
                                    
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hide();
            new Stock(producto.id, producto.nombre, producto.numref, m).ShowDialog();
            Show();
        }
    }
}

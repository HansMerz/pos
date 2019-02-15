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
    public partial class Sucursal : Form
    {
        public String id = "";
        public String id2 = "";
        public Sucursal()
        {
            InitializeComponent();
            button1.Hide();
            button2.Show();
            cargarTabla();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id2 = dataGridView1[0, e.RowIndex].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Ingresar los campos vacíos", "Rellenar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String nombre = textBox1.Text;
                String direccion = textBox2.Text;
                try
                {
                    String sql = String.Format("INSERT INTO sucursal VALUES(null, '{0}', '{1}', 1)", nombre, direccion);
                    Conexion.SQL(sql);
                    MessageBox.Show("Sucursal ingresada");
                    cargarTabla();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }                
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String nombre = dataGridView1[1, e.RowIndex].Value.ToString();
            String direc = dataGridView1[2, e.RowIndex].Value.ToString();
            id = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox1.Text = nombre;
            textBox2.Text = direc;
            button1.Show();
            button2.Hide();
            id2 = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                String sql = String.Format("UPDATE sucursal SET Nombre = '{0}', Direccion = '{1}' " +
                    "WHERE idSucursal = '{2}'", textBox1.Text, textBox2.Text, id);
                Conexion.SQL(sql);
                MessageBox.Show("Sucursal actualizada");
                cargarTabla();
                button2.Show();
                button1.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }
        public void cargarTabla()
        {
            try
            {
                DataTable table = Conexion.Data("SELECT idSucursal Codigo, Nombre, Direccion FROM sucursal WHERE Estado = 1");
                dataGridView1.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            id = "";
            id2 = "";
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Hide();
            button2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (id2 != "")
                {
                    String sql = String.Format("UPDATE sucursal SET Estado = 0 WHERE idSucursal = '{0}'", id2);
                    Conexion.SQL(sql);
                    MessageBox.Show("Sucursal eliminada");
                    cargarTabla();
                    id2 = "";
                }
                else
                {
                    MessageBox.Show("Escoge un registro de la tabla para eliminar ");
                }
                
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}

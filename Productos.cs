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
    public partial class Productos : Form
    {
        int precio = 0;
        int cantidad = 0;
        String codeTabla = "";
        decimal operacion = 0;
        Vender fs;
        
        public Productos(Vender fs)
        {
            InitializeComponent();
            cargarTabla("");
            this.fs = fs;
            button1.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            String code = txtCode.Text;
            if (code == "")
            {
                MessageBox.Show("Por favor digita el número de referencia", "Digitar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cargarDatos();
                ope();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if(int.Parse(numCant.Text) > int.Parse(txtExi.Text))
            {
                MessageBox.Show("La cantidad no puede ser mayor a la existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtTot.Text == "")
            {
                MessageBox.Show("Por favor escoge un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String code = txtCode.Text;
                String defi = "";
                if (code == "")
                {
                    defi = codeTabla;
                }
                else
                {
                    defi = code;
                }                                                             
                fs.manejaDatos(operacion, numCant.Value, defi);
                Close();
            }

        }
        public void cargarTabla(String value)
        {
            String sql = "SELECT i.NumRef NumRef, i.Nombre Nombre, i.Marca Marca FROM " +
                "item i INNER JOIN stock s ON i.idItem = s.Item_id WHERE s.Concepto = 'Entrada' AND i.Estado = 1 " +
                "AND CONCAT(NumRef, ' ', Nombre, ' ', Marca) LIKE '%"+value+"%' " +
                "GROUP BY i.idItem";
            DataTable table = Conexion.Data(sql);
            dataGridView1.DataSource = table;
        }
      
        public void cargarDatos()
        {
            String code = txtCode.Text;
            String defi = "";
            if (code == "")
            {
                defi = codeTabla;
            }
            else
            {
                defi = code;
            }
            String sql = String.Format("SELECT i.Nombre, i.Marca, i.Descripcion, i.Precio " +
                          "FROM item i " +
                          "INNER JOIN stock s " +
                          "ON i.idItem = s.Item_id " +
                          "WHERE s.Concepto = 'Entrada' AND i.NumRef = '{0}' " +
                          "AND s.Estado = 1 AND i.Estado = 1", defi);
                DataRow info = Conexion.Data(sql).Rows[0];                
                txtPro.Text = info["Nombre"].ToString();
                txtMar.Text = info["Marca"].ToString();
                txtDes.Text = info["Descripcion"].ToString();
                String sql2 = String.Format("CALL Stock('{0}')", defi);
                DataRow row = Conexion.Data(sql2).Rows[0];
                precio = int.Parse(info["Precio"].ToString()); 
                cantidad = int.Parse(row["CantidadStock"].ToString());
                txtExi.Text = cantidad.ToString();
                txtPre.Text = precio.ToString();                        
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ope();   
        }
        public void ope()
        {
            operacion = precio * numCant.Value;            
            txtTot.Text = operacion.ToString();
        }

        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {
            cargarTabla(txtBusc.Text);
        }

        private void txtBusc_Click(object sender, EventArgs e)
        {
            txtBusc.Text = "";
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
            codeTabla = dataGridView1[0, e.RowIndex].Value.ToString();
            cargarDatos();
            ope();
        }
    }
}

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
    public partial class Devoluciones : Form
    {
        int cantidad = 0;
        Vender v;
        String numRef = "";
        public Devoluciones(Vender v)
        {
            InitializeComponent();
            editButton(button2, Color.Gray, false);
            this.v = v;            
        }        
        private void button1_Click(object sender, EventArgs e)
        {            
            cargarTabla(numericUpDown1.Value.ToString());
        }
        public void cargarTabla(String value)
        {
            String sql = "SELECT i.NumRef NumRef, i.Nombre Nombre, i.Marca Marca, d.Cantidad, f.Fechayhora FechaCompra, CURRENT_TIMESTAMP FechaActual FROM item i "+
                            " INNER JOIN detalle d "+
                            "ON i.idItem = d.Item_id "+
                            "INNER JOIN factura f "+
                            "ON d.Factura_id = f.idFactura "+
                            "WHERE d.Factura_id = "+value+" AND d.Estado = 1";
            DataTable table = Conexion.Data(sql);
            dataGridView1.DataSource = table;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = dataGridView1[1, e.RowIndex].Value.ToString();            
            cantidad = int.Parse(dataGridView1[3, e.RowIndex].Value.ToString());
            numRef = dataGridView1[0, e.RowIndex].Value.ToString();
            editButton(button2, Color.Indigo, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql = String.Format("SELECT DATEDIFF(CURRENT_TIMESTAMP, Fechayhora) Operacion FROM factura WHERE idFactura = '{0}'", numericUpDown1.Value);
            DataRow row = Conexion.Data(sql).Rows[0];
            if (int.Parse(row["Operacion"].ToString()) > 30)
            {
                MessageBox.Show("Lo sentimos, el transcurso de la factura ha superado los 30 días.", "Expiró",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DetalleCRUD d = new DetalleCRUD();             
                try
                {
                    String sqli = String.Format("SELECT idItem FROM item WHERE NumRef = '{0}'", numRef);
                    DataRow r = Conexion.Data(sqli).Rows[0];
                    d.ActualizarDetalle(r["idItem"].ToString(), numericUpDown1.Value.ToString());                    
                    String sql2 = String.Format("INSERT INTO stock VALUES(null, 'Entrada', '{0}', CURRENT_TIMESTAMP, '{1}','{2}','{3}',1)", cantidad, textBox1.Text, v.m.sucursalid, r["idItem"].ToString());
                    Conexion.SQL(sql2);
                    MessageBox.Show("Producto devuelto correctamente");
                    cargarTabla(numericUpDown1.Value.ToString());
                    label5.Text = "";
                    textBox1.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                    throw;
                }
            }
        }
        public void editButton(Button b, Color c, bool estado)
        {
            b.Enabled = estado;
            b.BackColor = c;
        }
    }
}

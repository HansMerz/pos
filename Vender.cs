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
    public partial class Vender : Form
    {
        int id = 0;
        DataTable tab = new DataTable();
        DataRow row;        
        DetalleCRUD d;
        public Menu m;
        public Vender(Menu m)
        {
            InitializeComponent();
            editButton(btnEli, Color.Gray, false);
            tab.Columns.Add("NumRef");
            tab.Columns.Add("Nombre");
            tab.Columns.Add("Marca");
            tab.Columns.Add("Precio_Unitario");
            tab.Columns.Add("Cantidad");
            tab.Columns.Add("IVA");
            tab.Columns.Add("Total");            
            d = new DetalleCRUD();
            this.m = m;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Productos(this).ShowDialog();
        }
        public void manejaDatos(decimal op, decimal cant, String co)
        {
            if (op == 0 || cant == 0 || co == "")
            {
                label2.Show();
            }
            else
            {
                label2.Hide();
                String sql = String.Format("SELECT i.NumRef, i.Nombre, i.Marca, i.Precio, i.IVA FROM item i " +
                    "INNER JOIN stock s ON i.idItem = s.Item_id WHERE i.NumRef = '{0}' " +
                    "AND i.Estado = 1 AND s.Estado = 1", co);
                DataRow info = Conexion.Data(sql).Rows[0];
                row = tab.NewRow();
                row["NumRef"] = info["NumRef"]; 
                row["Nombre"] = info["Nombre"];
                row["Precio_Unitario"] = info["Precio"];
                row["Marca"] = info["Marca"];
                row["Cantidad"] = cant;
                row["IVA"] = info["IVA"];
                
                if (int.Parse(info["IVA"].ToString()) == 0)
                {
                    row["Total"] = op;
                }
                else
                {
                    row["Total"] = ((int)op / int.Parse(info["IVA"].ToString()) + op);
                }                
                tab.Rows.Add(row);
                dataGridView1.DataSource = tab;
                sumetodo();
            }
        }
        public void sumetodo()
        {
            int cont = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                cont += int.Parse(r.Cells[6].Value.ToString());
            }
            label3.Text = cont.ToString();
            if (tab.Rows.Count == 0)
            {
                label2.Show();
            }                     
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tab.Rows.Count == 0)
            {
                MessageBox.Show("Por favor agrega productos para facturar", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {                
                String sql = String.Format("INSERT INTO factura VALUES(null, CURRENT_TIMESTAMP, '{0}', 1)", m.id);
                Conexion.SQL(sql);
                foreach(DataGridViewRow r in dataGridView1.Rows)
                {                    
                    String sql2 = String.Format("SELECT idItem FROM item WHERE NumRef = '{0}'", r.Cells[0].Value.ToString());
                    DataRow ro = Conexion.Data(sql2).Rows[0];
                    agregarDatos(ro["idItem"].ToString(), r.Cells[4].Value.ToString(),r.Cells[6].Value.ToString());
                    d.InsertarDetalle();
                }
                tab.Rows.Clear();
                sumetodo();
                new Facturar().ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tab.Rows.RemoveAt(id);
            MessageBox.Show("Item eliminado");
            sumetodo();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = e.RowIndex;
            editButton(btnEli, Color.Red, true);
        }
        public void agregarDatos(String r, String cant, String pre)
        {
            String sql = "SELECT MAX(idFactura) Max FROM factura";
            DataRow ro = Conexion.Data(sql).Rows[0];
            d.factura_id = ro["Max"].ToString();
            d.item_id = r;
            d.cantidad = cant;
            d.precio_total = pre;
        }
        public void editButton(Button b, Color c, bool estado)
        {
            b.Enabled = estado;
            b.BackColor = c;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new Devoluciones(this).ShowDialog();
        }
    }
}

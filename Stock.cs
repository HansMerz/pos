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
    public partial class Stock : Form
    {
        StockClass stock = new StockClass();
        Menu m;

        public Stock(Int64 itemid, String name, Int64 numeref, Menu m)
        {
            this.m = m;
            InitializeComponent();
            stock.idItem = itemid;
            stock.nombreItem = name;
            stock.numrefItem = numeref;
            stock.idSucursal = Int64.Parse(m.sucursalid);
            lblProducto.Text = stock.nombreItem;
            stock.loadTable(tbStock);
            lblCantidad.Text = stock.loadCountProduct();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboMovimiento.Text == "" || numCant.Value == 0)
            {
                MessageBox.Show("Elija el movimiento o La cantidad no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                stock.transaccion = cboMovimiento.Text;
                stock.cantidad = Int64.Parse(numCant.Value.ToString());
                stock.descripcion = txtDesc.Text;

                stock.InsertarStock();
                stock.loadTable(tbStock);
                lblCantidad.Text = stock.loadCountProduct();
            }
        }
        
    }
}

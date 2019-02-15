using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    class StockClass
    {
        public Int64 idItem { get; set; }
        public Int64 numrefItem { get; set; }
        public String nombreItem { get; set; }
        public String transaccion { get; set; }
        public Int64 cantidad { get; set; }
        public String descripcion { get; set; }
        public Int64 idSucursal { get; set; }

        public String loadCountProduct()
        {
            DataRow dt = Conexion.Data("CALL Stock('" + numrefItem + "')").Rows[0]; 
            String cantidad = dt["CantidadStock"].ToString();
            return cantidad;
        }
        public void InsertarStock()
        {
            String sql = String.Format("INSERT INTO stock VALUES(NULL, '{0}',{1}, CURRENT_TIMESTAMP, '{2}', {4}, {3}, 1)", transaccion, cantidad, descripcion, idItem, idSucursal);
            Conexion.SQL(sql);
            MessageBox.Show("Registro insertado","",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void loadTable(DataGridView tabla)
        {
            DataTable result = Conexion.Data("SELECT Concepto, Cantidad, fechayHora as Fecha_y_Hora, descripcion as Descripcion FROM stock as sto INNER JOIN sucursal as suc ON sto.Sucursal_id = suc.idSucursal WHERE sto.Item_id ="+idItem+" and suc.idSucursal ="+idSucursal+"");
            tabla.DataSource = result;
            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                tabla.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}

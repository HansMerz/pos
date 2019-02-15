using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{    
    class DetalleCRUD
    {
        public String factura_id { get; set; }
        public String item_id { get; set; }
        public String cantidad { get; set; }
        public String precio_total { get; set; }
        public String estado { get; set; }

        public void InsertarDetalle()
        {
            try
            {
                String sql = String.Format("INSERT INTO detalle VALUES(null, '{0}', '{1}', '{2}', '{3}', 1)", factura_id, item_id,
                    cantidad, precio_total);
                Conexion.SQL(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }            
        }
        public DataTable BuscarDetalle(String sql)
        {
            return Conexion.Data(sql);
        }
        public void ActualizarDetalle(String it, String fac)
        {
            try
            {
                String sql = String.Format("UPDATE detalle SET Estado = 0 WHERE Item_id = '{0}' AND Factura_id = '{1}'",it, fac );
                Conexion.SQL(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }
    }
}

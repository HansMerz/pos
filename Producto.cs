using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    class Producto
    {
        public Int64 id { get; set; }
        public Int64 numref { get; set; }
        public String nombre { get; set; }
        public String marca { get; set; }
        public String descripcion { get; set; }
        public int iva { get; set; }
        public Int64 precio { get; set; }
        public String categoria { get; set; }
        public int estado { get; set; }
        public int idcategoria { get; set; }
      

        public void InsertarProducto()
        {
            String sql = String.Format("INSERT INTO item VALUES (Null, '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                numref, nombre, marca, descripcion, iva, precio, idcategoria, estado);
            Conexion.SQL(sql);
        }
        public void InsertarenStock()
        {
            String sql = String.Format("INSERT INTO stock VALUES(Null, '{0}',{1}, CURRENT_TIMESTAMP, 'Primera entrada del producto al inventario', 2, {2},1)",
                "Entrada", 0, id);
            Conexion.SQL(sql);
        }
        public void ActualizarProducto()
        {
            String sql = String.Format("UPDATE item SET Nombre='{0}', Marca='{1}', Precio={2}, Descripcion='{3}', Categoria_id={4}, IVA={5} WHERE NumRef={6}",nombre, marca, precio, descripcion, idcategoria, iva, numref);
            Conexion.SQL(sql);
            MessageBox.Show("Registro Actualizado","",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
        public void EliminarProducto(Int64 numref)
        {
            DialogResult res = MessageBox.Show("¿Desea eliminar el registro permanentemente?", "",MessageBoxButtons.YesNo,MessageBoxIcon.Question);


            if (res == DialogResult.Yes)
            {
                String sql = "UPDATE item SET Estado=0 WHERE NumRef=" + numref + "";
                Conexion.SQL(sql);
                MessageBox.Show("El registro fue eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else{}
            
        }
        public Int64 ExtraerIdDeItem(Int64 numref)
        {
            DataTable dato = Conexion.Data("SELECT idItem FROM item WHERE NumRef=" + numref + "");
            Int64 iditem = Convert.ToInt64(dato.Rows[0]["idItem"].ToString());
            return iditem;
        }
        public String loadCategoryComboBox(ComboBox combobox)
        {
            String r;
            DataTable dt = Conexion.Data("SELECT idCategoria, nombre FROM categoria");
            combobox.DisplayMember = "nombre";
            combobox.ValueMember = "idCategoria";
            combobox.DataSource = dt;
            r = dt.Rows[0]["nombre"].ToString();
            return r;
        }
        public int getIdFromCategoryName(ComboBox combobox)
        {
            String sql = String.Format("SELECT idCategoria as id FROM categoria WHERE nombre = '{0}'", combobox.Text);
            DataRow dato = Conexion.Data(sql).Rows[0];

            int id = Convert.ToInt32(dato["id"].ToString());
            return id;
        }
        public void loadTable(DataGridView tabla)
        {
            DataTable result = Conexion.Data("SELECT * FROM DATOS");
            tabla.DataSource = result;
            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                tabla.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public Int64 getId()
        {
            DataTable res = Conexion.Data("SELECT idItem FROM item WHERE NumRef=" + numref + "");
            Int64 id = Int64.Parse(res.Rows[0]["idItem"].ToString());
            return id;
        }
    }
}

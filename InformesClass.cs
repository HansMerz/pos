using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    class InformesClass
    {
        public String tipo { get; set; }
        public String periodo { get; set; }
        public String meses { get; set; }
        public String year { get; set; }
        public String sql { get; set; }

        public void CargarTablaVentas(DataGridView dataGridView, int primerMes, int ultimoMes)
        {
            this.sql = String.Format("SELECT * FROM informeventas WHERE Fechayhora between '" + year + "-"+primerMes+"-00 00:00:00' AND '" + year + "-"+ultimoMes+"-30 11:59:59';");
            DataTable dt = Conexion.Data(this.sql);

            dataGridView.DataSource = dt;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void CargarTablaIVA(DataGridView dataGridView, int primerMes, int ultimoMes)
        {
            this.sql = String.Format("SELECT * FROM iva WHERE Fechayhora BETWEEN '" + year + "-" + primerMes + "-00 00:00:00' AND '" + year + "-" + ultimoMes + "-29 11:59:59'");
            DataTable dt = Conexion.Data(this.sql);
            dataGridView.DataSource = dt;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void CargarTablaVentasVendedor(DataGridView dataGridView, int primerMes, int ultimoMes)
        {
            this.sql = String.Format("select * from informeventasvendedor where Fechayhora between '" + year + "-" + primerMes + "-00 00:00:00' AND '" + year + "-" + ultimoMes + "-29 11:59:59';");
            DataTable dt = Conexion.Data(this.sql);
            dataGridView.DataSource = dt;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void CargarTablaVentasSede(DataGridView dataGridView, int primerMes, int ultimoMes)
        {
            this.sql = String.Format("SELECT * FROM informeventassede  where Fechayhora between '" + year + "-" + primerMes + "-00 00:00:00' AND '" + year + "-" + ultimoMes + "-31 23:59:59' and idSucursal=2");
            DataTable dt = Conexion.Data(this.sql);
            dataGridView.DataSource = dt;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        public String llenarComboBoxYear(ComboBox combobox)
        {
            DataTable dt = Conexion.Data("SELECT DISTINCT YEAR(fechayhora) as year FROM factura");
            combobox.DisplayMember = "year";
            combobox.DataSource = dt;

            String year = combobox.SelectedValue.ToString();
            return year;
        }
    }
}

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
    public partial class InformeVentasVendedor : Form
    {
        public InformeVentasVendedor(String sql)
        {
            InitializeComponent();
            ReporteVentasVendedor1.SetDataSource(Conexion.Data(sql));
        }
    }
}

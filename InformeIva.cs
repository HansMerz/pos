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
    public partial class InformeIva : Form
    {
        public InformeIva(String sql)
        {
            InitializeComponent();
            ReporteIva1.SetDataSource(Conexion.Data(sql));
        }
    }
}

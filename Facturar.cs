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
    public partial class Facturar : Form
    {
        public Facturar()
        {
            InitializeComponent();
            Reporte1.SetDataSource(Conexion.Data("SELECT * FROM facturaimpresa WHERE idFactura = (SELECT MAX(idFactura) FROM factura)"));
        }
    }
}

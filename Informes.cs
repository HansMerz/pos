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
    public partial class Informes : Form
    {
        InformesClass informe = new InformesClass();

        public Informes()
        {
            InitializeComponent();
            cboMesesRep.Enabled = false;
            cboPeriodoRep.Enabled = false;
            cboYear.Enabled = false;
            
        }

        private String llenarMeses()
        {
            if (cboPeriodoRep.SelectedItem.ToString().Equals("Bimestral"))
            {
                cboMesesRep.Items.Clear();
                cboMesesRep.Text = "Enero-Febrero";

                cboMesesRep.Items.Add("Enero-Febrero");
                cboMesesRep.Items.Add("Marzo-Abril");
                cboMesesRep.Items.Add("Mayo-Junio");
                cboMesesRep.Items.Add("Julio-Agosto");
                cboMesesRep.Items.Add("Septiembre-Octubre");
                cboMesesRep.Items.Add("Noviembre-Diciembre");
            }
            else if (cboPeriodoRep.SelectedItem.ToString().Equals("Trimestral"))
            {
                cboMesesRep.Items.Clear();
                cboMesesRep.Text = "Ene-Feb-Mar";
                cboMesesRep.Items.Add("Ene-Feb-Mar");
                cboMesesRep.Items.Add("Abr-May-Jun");
                cboMesesRep.Items.Add("Jul-Ago-Sep");
                cboMesesRep.Items.Add("Oct-Nov-Dic");
            }
            else if (cboPeriodoRep.SelectedItem.ToString().Equals("Semestral"))
            {
                cboMesesRep.Items.Clear();
                cboMesesRep.Text = "Enero-Junio";
                cboMesesRep.Items.Add("Enero-Junio");
                cboMesesRep.Items.Add("Julio-Diciembre");
            }
            else if (cboPeriodoRep.SelectedItem.ToString().Equals("Anual"))
            {
                cboMesesRep.Items.Clear();
                cboMesesRep.Text = "Enero-Diciembre";
                cboMesesRep.Items.Add("Enero-Diciembre");
            }
            return cboMesesRep.Text;
        }
        private String llenarPeriodos()
        {
            if (cboTipoRep.SelectedItem.ToString().Equals("Informe de Ventas") || cboTipoRep.SelectedItem.ToString().Equals("Informe de Ventas por Vendedor") || cboTipoRep.SelectedItem.ToString().Equals("Informe de Ventas por Sede"))
            {
                cboPeriodoRep.Items.Clear();
                cboPeriodoRep.Text = "Bimestral";
                cboPeriodoRep.Items.Add("Bimestral");
                cboPeriodoRep.Items.Add("Trimestral");
                cboPeriodoRep.Items.Add("Semestral");
                cboPeriodoRep.Items.Add("Anual");

                if (cboTipoRep.SelectedItem.ToString().Equals("Informe de Ventas"))
                {
                    button1.Visible = true;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                }
                if (cboTipoRep.SelectedItem.ToString().Equals("Informe de Ventas por Vendedor"))
                {
                    button1.Visible = false;
                    button3.Visible = false;
                    button4.Visible = true;
                    button5.Visible = false;
                }
                if (cboTipoRep.SelectedItem.ToString().Equals("Informe de Ventas por Sede"))
                {
                    button1.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = true;
                }
            }
            else if (cboTipoRep.SelectedItem.ToString().Equals("Informe de IVA Semestral"))
            {
                cboPeriodoRep.Items.Clear();
                cboMesesRep.Items.Clear();

                cboPeriodoRep.Text = "Semestral";
                cboPeriodoRep.Items.Add("Semestral");

                cboMesesRep.Text = "Enero-Junio";
                cboMesesRep.Items.Add("Enero-Junio");
                cboMesesRep.Items.Add("Julio-Diciembre");

                button1.Visible = false;
                button3.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
            }
            return cboPeriodoRep.Text;
        }

        private void cboPeriodoRep_SelectedValueChanged(object sender, EventArgs e)
        {
            cboMesesRep.Enabled = true;
            llenarMeses();
            cboMesesRep.SelectedIndex = 0;
            cboMesesRep.Text = cboMesesRep.SelectedItem.ToString();
        }
        private void InformeVentas(String periodo, String meses, int primerMes, int ultimoMes)
        {
            if (informe.tipo.Equals("Informe de Ventas") && informe.periodo.Equals(periodo) && informe.meses.Equals(meses))
            {
                informe.CargarTablaVentas(tbInforme, primerMes, ultimoMes);
            }
        }
        private void InformeIva(String meses, int primerMes, int ultimoMes)
        {
            if (informe.tipo.Equals("Informe de IVA Semestral") && informe.periodo.Equals("Semestral") && informe.meses.Equals(meses))
            {
                informe.CargarTablaIVA(tbInforme, primerMes, ultimoMes);
            }
        }
        private void InformeVentasVendedor(String periodo, String meses, int primerMes, int ultimoMes)
        {
            if (informe.tipo.Equals("Informe de Ventas por Vendedor") && informe.periodo.Equals(periodo) && informe.meses.Equals(meses))
            {
                informe.CargarTablaVentasVendedor(tbInforme, primerMes, ultimoMes);
            }
        }
        private void InformeVentasSede(String periodo, String meses, int primerMes, int ultimoMes)
        {
            if (informe.tipo.Equals("Informe de Ventas por Sede") && informe.periodo.Equals(periodo) && informe.meses.Equals(meses))
            {
                informe.CargarTablaVentasSede(tbInforme, primerMes, ultimoMes);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            informe.tipo = cboTipoRep.Text;
            informe.periodo = cboPeriodoRep.Text;
            informe.meses = cboMesesRep.Text;
            informe.year = cboYear.Text;
              // ----------------------------------------------------AREA DE BIMESTRALES -------------------------------------------------
               InformeVentas("Bimestral","Enero-Febrero",01,02);
               InformeVentas("Bimestral", "Marzo-Abril", 03, 04);
               InformeVentas("Bimestral", "Mayo-Junio", 05, 06);
               InformeVentas("Bimestral", "Julio-Agosto", 07, 08);
               InformeVentas("Bimestral", "Septiembre-Octubre", 09, 10);
               InformeVentas("Bimestral", "Noviembre-Diciembre", 11, 12);
               // ----------------------------------------------------AREA DE TRIMESTRALES -------------------------------------------------
               InformeVentas("Trimestral", "Ene-Feb-Mar", 01, 03);
               InformeVentas("Trimestral", "Abr-May-Jun", 04, 06);
               InformeVentas("Trimestral", "Jul-Ago-Sep", 07, 09);
               InformeVentas("Trimestral", "Oct-Nov-Dic", 10, 12);
               // ----------------------------------------------------AREA DE SEMESTRALES -------------------------------------------------
               InformeVentas("Semestral", "Enero-Junio", 01, 06);
               InformeVentas("Semestral", "Julio-Diciembre", 07, 12);
               // ----------------------------------------------------AREA DE ANUALES -----------------------------------------------------
               InformeVentas("Anual", "Enero-Diciembre", 01, 12);

               //---------------------------------------------------------------------------------------------------------------------------------------


               InformeIva("Enero-Junio",01,06);
               InformeIva("Julio-Diciembre", 07, 12);

               //---------------------------------------------------------------------------------------------------------------------------

               // ----------------------------------------------------AREA DE BIMESTRALES -------------------------------------------------
               InformeVentasVendedor("Bimestral", "Enero-Febrero", 01, 02);
               InformeVentasVendedor("Bimestral", "Marzo-Abril", 03, 04);
               InformeVentasVendedor("Bimestral", "Mayo-Junio", 05, 06);
               InformeVentasVendedor("Bimestral", "Julio-Agosto", 07, 08);
               InformeVentasVendedor("Bimestral", "Septiembre-Octubre", 09, 10);
               InformeVentasVendedor("Bimestral", "Noviembre-Diciembre", 11, 12);
               // ----------------------------------------------------AREA DE TRIMESTRALES -------------------------------------------------
               InformeVentasVendedor("Trimestral", "Ene-Feb-Mar", 01, 03);
               InformeVentasVendedor("Trimestral", "Abr-May-Jun", 04, 06);
               InformeVentasVendedor("Trimestral", "Jul-Ago-Sep", 07, 09);
               InformeVentasVendedor("Trimestral", "Oct-Nov-Dic", 10, 12);
               // ----------------------------------------------------AREA DE SEMESTRALES -------------------------------------------------
               InformeVentasVendedor("Semestral", "Enero-Junio", 01, 06);
               InformeVentasVendedor("Semestral", "Julio-Diciembre", 07, 12);
               // ----------------------------------------------------AREA DE ANUALES -----------------------------------------------------
               InformeVentasVendedor("Anual", "Enero-Diciembre", 01, 12);

               //---------------------------------------------------------------------------------------------------------------------------

               // ----------------------------------------------------AREA DE BIMESTRALES -------------------------------------------------
               InformeVentasSede("Bimestral", "Enero-Febrero", 01, 02);
               InformeVentasSede("Bimestral", "Marzo-Abril", 03, 04);
               InformeVentasSede("Bimestral", "Mayo-Junio", 05, 06);
               InformeVentasSede("Bimestral", "Julio-Agosto", 07, 08);
               InformeVentasSede("Bimestral", "Septiembre-Octubre", 09, 10);
               InformeVentasSede("Bimestral", "Noviembre-Diciembre", 11, 12);
               // ---------------------------------------------------AREA DE TRIMESTRALES -------------------------------------------------
               InformeVentasSede("Trimestral", "Ene-Feb-Mar", 01, 03);
               InformeVentasSede("Trimestral", "Abr-May-Jun", 04, 06);
               InformeVentasSede("Trimestral", "Jul-Ago-Sep", 07, 09);
               InformeVentasSede("Trimestral", "Oct-Nov-Dic", 10, 12);
               // ------------------------------------------------AREA DE SEMESTRALES -------------------------------------------------
               InformeVentasSede("Semestral", "Enero-Junio", 01, 06);
               InformeVentasSede("Semestral", "Julio-Diciembre", 07, 12);
               // --------------------------------------------------AREA DE ANUALES -----------------------------------------------------
               InformeVentasSede("Anual", "Enero-Diciembre", 01, 12); 
        }

        private void cboTipoRep_SelectedValueChanged(object sender, EventArgs e)
        {
            cboPeriodoRep.Enabled = true;
            llenarPeriodos();
            cboPeriodoRep.SelectedIndex= 0 ;
            cboPeriodoRep.Text = cboPeriodoRep.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new InformeVentas(informe.sql).ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new InformeIva(informe.sql).ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new InformeVentasVendedor(informe.sql).ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new InformeVentasSede(informe.sql).ShowDialog();
        }

        private void cboMesesRep_SelectedValueChanged(object sender, EventArgs e)
        {
            cboYear.Enabled = true;
            cboYear.Text = informe.llenarComboBoxYear(cboYear);
        }
    }
        
    
}

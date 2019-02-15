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
    public partial class RegistrarUsuario : Form
    {
        String id1 = "";
        String id2 = "";
        Persona p;
        String genero = "";
        public RegistrarUsuario()
        {
            InitializeComponent();
            cargarTabla();
            btnReg.Show();
            btnAct.Hide();
            cargarCombo();
            p = new Persona();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "" || txtApe.Text == "" || txtDoc.Text == "" || txtCor.Text == "" ||
                numTel.Text == "" || txtCon1.Text == "")
            {
                MessageBox.Show("Llenar todos los campos vacíos", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {                                    
                    if (rbFem.Checked)
                    {
                        genero = "F";
                    }
                    else
                    {
                        genero = "M";
                    }

                AgarraDatos();
                p.InsertarPersona();
                cargarTabla();                
            }
        }
        public void AgarraDatos()
        {
            p.docPersona = txtDoc.Text;
            p.nombres = txtNom.Text;
            p.apellidos = txtApe.Text;
            p.genero = genero;
            p.correo = txtCor.Text;
            p.telefono = numTel.Text;
            p.password = txtCon1.Text;
            p.sucursal_id = comboSucur.SelectedValue.ToString();
            p.rol_id = comboRol.SelectedValue.ToString();
        }
        public void cargarTabla()
        {
            try
            {
                String sql = "SELECT docPersona Documento, Nombres, Apellidos, r.Nombre FROM persona p " +
                    "INNER JOIN rol r ON p.Rol_id = idRol WHERE p.Estado = 1";
                DataTable table = Conexion.Data(sql);
                dataGridView1.DataSource = table;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String documento = dataGridView1[0, e.RowIndex].Value.ToString();
                String sql = String.Format("SELECT p.*, s.Nombre, r.Nombre Rol FROM persona p INNER JOIN sucursal s "+
                    "ON p.Sucursal_id = s.idSucursal "+
                    "INNER JOIN rol r "+
                    "ON p.Rol_id = r.idRol "+
                    "WHERE p.docPersona = '{0}'", documento);
                DataRow info = p.ConsultarPersona(sql).Rows[0];
                txtNom.Text = info["Nombres"].ToString();
                txtApe.Text = info["Apellidos"].ToString();
                txtDoc.Text = info["docPersona"].ToString();
                txtCor.Text = info["Correo"].ToString();
                numTel.Text = info["Telefono"].ToString();
                txtCon1.Text = info["password"].ToString();
                comboRol.Text = info["Rol"].ToString();
                comboSucur.Text = info["Nombre"].ToString();
                id1 = info["docPersona"].ToString();
                id2 = "";
                if (info["Genero"].ToString() == "M")
                {
                    rbMas.Checked = true;
                }
                else
                {
                    rbFem.Checked = true;
                }
                btnAct.Show();
                btnReg.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            id2 = "";
            id1 = "";
            txtNom.Text = "";
            txtApe.Text = "";
            txtDoc.Text = "";
            txtCor.Text = "";
            numTel.Text = "";
            txtCon1.Text = "";
            rbFem.Checked = false;
            rbMas.Checked = false;
            btnReg.Show();
            btnAct.Hide();
        }
        public void cargarCombo()
        {
            comboSucur.DataSource = Conexion.Data("SELECT * FROM sucursal WHERE Estado = 1");
            comboSucur.DisplayMember = "Nombre";
            comboSucur.ValueMember = "idSucursal";
            comboRol.DataSource = Conexion.Data("SELECT * FROM rol WHERE Estado = 1");
            comboRol.DisplayMember = "Nombre";
            comboRol.ValueMember = "idRol";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            try
            {
                String genero = "";
                if (rbFem.Checked)
                {
                    genero = "F";
                }
                else
                {
                    genero = "M";
                }
                AgarraDatos();
                p.ActualizarPersona(id1);
                cargarTabla();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id2 = dataGridView1[0, e.RowIndex].Value.ToString();
            id1 = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (id2 != "")
                {
                    p.EliminarPersona(id2, 0);
                    cargarTabla();
                    id2 = "";
                }
                else
                {
                    MessageBox.Show("Escoge un registro de la tabla para eliminar ");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }
    }    
}


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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            String user = txtUser.Text;
            String pass = txtPass.Text;
            if (user.Length > 0 && pass.Length > 0)
            {
                String sql = String.Format("SELECT p.*, idRol FROM persona p " +
                    "INNER JOIN rol r " +
                    "ON p.Rol_id = r.idRol WHERE docPersona = '{0}' AND password = '{1}'", user, pass);
                DataTable tab = Conexion.Data(sql);
                if (tab.Rows.Count > 0)
                {
                    Hide();
                    Menu m = new Menu();
                    m.Privilegios(tab.Rows[0]);
                    m.ShowDialog();
                    Show();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingresa el Usuario o contraseña", "Verifica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}

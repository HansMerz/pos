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
    public partial class Menu : Form
    {
        public String usuario;
        public String id;
        public String nombre_apellido;
        public String sucursalid;  
        
        public Menu()
        {
            InitializeComponent();           
            timer1.Enabled = true;            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Vender(this).Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new Informes().Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new RegistrarUsuario().Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new Sucursal().Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Inventario(this).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Login log = new Login();
            log.txtUser.Text = "";
            log.txtPass.Text = "";
        }
        public void Privilegios(DataRow user)
        {
            usuario = user["docPersona"].ToString();
            id = user["idPersona"].ToString();            
            nombre_apellido = user["Nombres"].ToString() + " " + user["Apellidos"].ToString();
            sucursalid = user["Sucursal_id"].ToString();
            label9.Text = nombre_apellido;
            Int64 cargo = Int64.Parse(user["idRol"].ToString());
            if (cargo == 2)
            {
                pictureBox4.Hide();
                pictureBox3.Hide();
                pictureBox6.Hide();
                pictureBox2.Hide();
                lblInv.Hide();
                lblSuc.Hide();
                lblTra.Hide();
                lblIng.Hide();
                lblInf.Hide();
            }
            else if (cargo == 3)
            {
                pictureBox1.Hide();
                pictureBox3.Hide();
                pictureBox6.Hide();
                pictureBox2.Hide();
                lblVen.Hide();
                lblIng.Hide();
                lblSuc.Hide();
                lblTra.Hide();
                lblInf.Hide();
            }
            else if (cargo == 4)
            {
                pictureBox1.Hide();
                pictureBox6.Hide();
                pictureBox4.Hide();                
                lblVen.Hide();                
                lblSuc.Hide();
                lblInv.Hide();
            }
        }

        private void lblInf_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    class Persona
    {
        public String docPersona { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public String genero { get; set; }
        public String correo { get; set; }
        public String telefono { get; set; }
        public String password { get; set; }
        public String sucursal_id { get; set; }
        public String estado { get; set; }
        public String rol_id { get; set; }

        public void InsertarPersona()
        {
            try
            {
                String sql = String.Format("INSERT INTO persona VALUES(null, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', " +
                        "'{6}', '{7}', 1, '{8}')", docPersona, nombres, apellidos, genero, correo, telefono, password, sucursal_id, rol_id);
                Conexion.SQL(sql);
                MessageBox.Show("Trabajador registrado");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }            

        }
        public void ActualizarPersona(String doc)
        {
            try
            {
                String sql = String.Format("UPDATE persona SET docPersona =  '{0}', Nombres = '{1}', " +
                    "Apellidos = '{2}', Genero = '{3}', Correo = '{4}', Telefono = '{5}', " +
                    "password = '{6}', Sucursal_id = '{7}', Rol_id = '{8}' WHERE docPersona = '{9}'", docPersona, nombres, apellidos, genero, correo, 
                    telefono, password, sucursal_id, rol_id, doc);
                Conexion.SQL(sql);
                MessageBox.Show("Trabajador actualizado");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }
        public void EliminarPersona(String id2, int est)
        {
            try
            {
                String sql = String.Format("UPDATE persona SET Estado = '{0}' WHERE docPersona = '{1}'", est, id2);
                Conexion.SQL(sql);
                MessageBox.Show("Trabajador eliminado");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }            
        }
        public DataTable ConsultarPersona(String sql)
        {
            return Conexion.Data(sql);
        }
    }
}

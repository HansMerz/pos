using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public static class Conexion
    {
        static MySqlConnection Conectar()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            MySqlConnection connect;
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "dbPuntoVenta";

            connect = new MySqlConnection(builder.ToString());
            connect.Open();
            return connect;
        }
        public static int SQL(String sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Conectar());
            return command.ExecuteNonQuery();
        }
        public static DataTable Data(String sql)
        {
            MySqlDataAdapter oAdap = new MySqlDataAdapter(sql, Conectar());
            DataTable result = new DataTable();
            oAdap.Fill(result);
            return result;
        }
    }
}

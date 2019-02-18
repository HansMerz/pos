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
            builder.Server = "lhcp2038.webapps.net";
            builder.UserID = "sq3703yh_root";
            builder.Password = "R00t@2019";
            builder.Database = "sq3703yh_dbpuntoventa";

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

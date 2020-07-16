using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DAL
{
    public class Conexao
    {
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(connectionString);

        #region Conectar e Desconectar com DB
        public static void Conectar()
        {
            //var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void Desconectar()
        {
            //var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;

            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        #endregion
    }
}

using BibliotecaJogos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DAL
{
    public class GeneroDao
    {
        public List<Genero> ObterTodosOsGeneros()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM generos order by descricao";

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                var generos = new List<Genero>();

                while (reader.Read())
                {
                    var genero = new Genero();

                    genero.Id = Convert.ToInt32(reader["Id"]);
                    genero.Descricao = reader["Descricao"].ToString();
                    

                    generos.Add(genero);
                }
                return generos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}

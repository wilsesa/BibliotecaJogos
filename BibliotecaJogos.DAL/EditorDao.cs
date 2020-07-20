using BibliotecaJogos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DAL
{
    public class EditorDao
    {
        public List<Editor> ObterTodosOsEditores()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM editores order by nome";

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                var editores = new List<Editor>();

                while (reader.Read())
                {
                    var editor = new Editor();

                    editor.Id = Convert.ToInt32(reader["Id"]);
                    editor.Nome = reader["Nome"].ToString();


                    editores.Add(editor);
                }
                return editores;
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

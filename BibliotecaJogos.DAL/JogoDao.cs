using BibliotecaJogos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DAL
{
    public class JogoDao
    {
        public List<Jogo> ObterTodosOsJogos()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM jogos";

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                var jogos = new List<Jogo>();

                while (reader.Read())
                {
                    var jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["Id"]);
                    jogo.Imagem = reader["Imagem"].ToString();
                    jogo.DataCompra = reader["data_compra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["data_compra"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = reader["valor_pago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valor_pago"]);

                    jogos.Add(jogo);
                }
                return jogos;
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

        public Jogo ObterJogoPeloId(int id)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM jogos WHERE id = @id";

                command.Parameters.AddWithValue("@id", id);

                Conexao.Conectar();

                var reader = command.ExecuteReader();   

                Jogo jogo = null;

                while (reader.Read())
                {
                    jogo = new Jogo();

                    jogo.Id         = Convert.ToInt32(reader["id"]);
                    jogo.Imagem     = reader["imagem"].ToString();
                    jogo.DataCompra = reader["data_compra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["data_compra"]);
                    jogo.Titulo     = reader["titulo"].ToString();
                    jogo.ValorPago  = reader["valor_pago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valor_pago"]);
                    
                    jogo.IdEditor   = Convert.ToInt32(reader["id_editor"]);
                    jogo.IdGenero   = Convert.ToInt32(reader["id_genero"]);

                }
                return jogo;
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

        public int InserirJogo(Jogo jogo)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"INSERT INTO[dbo].[jogos]
                           ([titulo]
                           ,[valor_pago]
                           ,[data_compra]
                           ,[id_editor]
                           ,[id_genero]
                           ,[imagem])
                     VALUES
                           (@TITULO
                           ,@VALOR_PAGO
                           ,@DATA_COMPRA
                           ,@ID_EDITOR
                           ,@ID_GENERO
                           ,@IMAGEM)";

                command.Parameters.AddWithValue("@TITULO", jogo.Titulo);
                command.Parameters.AddWithValue("@VALOR_PAGO", jogo.ValorPago);
                command.Parameters.AddWithValue("@DATA_COMPRA", jogo.DataCompra);
                command.Parameters.AddWithValue("@ID_EDITOR", jogo.IdEditor);
                command.Parameters.AddWithValue("@ID_GENERO", jogo.IdGenero);
                command.Parameters.AddWithValue("@IMAGEM", jogo.Imagem);

                Conexao.Conectar();

                return command.ExecuteNonQuery();
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

        public int AlterarJogo(Jogo jogo)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"UPDATE[dbo].[jogos]
                                            SET[titulo]         = @TITULO
                                              ,[valor_pago]     = @VALOR_PAGO
                                              ,[data_compra]    = @DATA_COMPRA
                                              ,[id_editor]      = @ID_EDITOR
                                              ,[id_genero]      = @ID_GENERO
                                              
                                          WHERE Id              = @ID";

                  command.Parameters.AddWithValue("@TITULO", jogo.Titulo);
                command.Parameters.AddWithValue("@VALOR_PAGO", jogo.ValorPago);
                command.Parameters.AddWithValue("@DATA_COMPRA", jogo.DataCompra);
                command.Parameters.AddWithValue("@ID_EDITOR", jogo.IdEditor);
                command.Parameters.AddWithValue("@ID_GENERO", jogo.IdGenero);
                //command.Parameters.AddWithValue("@IMAGEM", jogo.Imagem);
                command.Parameters.AddWithValue("@ID", jogo.Id);

                Conexao.Conectar();

                return command.ExecuteNonQuery();
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

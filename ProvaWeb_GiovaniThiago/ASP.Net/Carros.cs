using Npgsql;
using System;
using System.Web.UI.WebControls;

namespace ProvaWeb_GiovaniThiago.ASP.Net
{
    public class Carros
    {
        public int IdCarro { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string KM { get; set; }
        public string Preco { get; set; }
        public string Cor { get; set; }

        public void Inserir(string stringConexao, Label labelRetorno)
        {
            try
            {
                NpgsqlConnection conBanco;
                NpgsqlCommand cmdSql;
                string strComando;

                conBanco = new NpgsqlConnection(stringConexao);

                strComando = "INSERT INTO \"Carros\"(\"Ano\", \"KM\", \"Modelo\", \"Marca\", \"Cor\", \"Preco\")" +
                             "VALUES(@ano, @km, @modelo, @marca, @cor, @preco)";

                cmdSql = new NpgsqlCommand(strComando, conBanco);

                NpgsqlParameter parametro = new NpgsqlParameter();
                //parametro.ParameterName = "@id";
                //parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                //parametro.Value = IdCarro;
                //cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@ano";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                parametro.Value = Ano;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@km";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Value = KM;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@modelo";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Size = 20;
                parametro.Value = Modelo;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@marca";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Size = 20;
                parametro.Value = Marca;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@cor";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Size = 20;
                parametro.Value = Cor;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@preco";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Value = Preco;
                cmdSql.Parameters.Add(parametro);

                conBanco.Open();

                cmdSql.ExecuteNonQuery();

                conBanco.Close();

                labelRetorno.ForeColor = System.Drawing.Color.Green;
                labelRetorno.Text = "Cadastrado com sucesso!";
            }
            catch (NpgsqlException ex)
            {
                labelRetorno.ForeColor = System.Drawing.Color.Red;
                labelRetorno.Text = ex.Message;
            }
            catch (Exception ex)
            {
                labelRetorno.ForeColor = System.Drawing.Color.Red;
                labelRetorno.Text = ex.Message;
            } 
        }

        public void Atualizar(string stringConexao, Label labelRetorno)
        {
            try
            {
                NpgsqlConnection conBanco;
                NpgsqlCommand cmdSql;
                string strComando;

                conBanco = new NpgsqlConnection(stringConexao);

                strComando = "UPDATE \"Carros\"" +
                             " SET \"Ano\" = @ano, \"KM\" = @km, \"Modelo\" = @modelo, \"Marca\" = @marca, \"Cor\" = @cor, \"Preco\" = @preco" +
                             " WHERE \"IdCarro\" = @id";

                cmdSql = new NpgsqlCommand(strComando, conBanco);

                NpgsqlParameter parametro = new NpgsqlParameter();
                parametro.ParameterName = "@id";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                parametro.Value = IdCarro;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@ano";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                parametro.Value = Ano;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@km";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Value = KM;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@modelo";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Size = 20;
                parametro.Value = Modelo;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@marca";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Size = 20;
                parametro.Value = Marca;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@cor";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Size = 20;
                parametro.Value = Cor;
                cmdSql.Parameters.Add(parametro);

                parametro = new NpgsqlParameter();
                parametro.ParameterName = "@preco";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                parametro.Value = Preco;
                cmdSql.Parameters.Add(parametro);

                conBanco.Open();

                cmdSql.ExecuteNonQuery();

                conBanco.Close();

                labelRetorno.ForeColor = System.Drawing.Color.Green;
                labelRetorno.Text = "Carro ID " + IdCarro + " atualizado com sucesso!";
            }
            catch (NpgsqlException ex)
            {
                labelRetorno.ForeColor = System.Drawing.Color.Red;
                labelRetorno.Text = ex.Message;
            }
            catch (Exception ex)
            {
                labelRetorno.ForeColor = System.Drawing.Color.Red;
                labelRetorno.Text = ex.Message;
            }
        }

        public void Excluir(string stringConexao, Label labelRetorno)
        {
            try
            {
                NpgsqlConnection conBanco;
                NpgsqlCommand cmdSql;
                string strComando;

                conBanco = new NpgsqlConnection(stringConexao);

                strComando = "DELETE FROM \"Carros\"" +
                             " WHERE \"IdCarro\" = @id";

                cmdSql = new NpgsqlCommand(strComando, conBanco);

                NpgsqlParameter parametro = new NpgsqlParameter();
                parametro.ParameterName = "@id";
                parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                parametro.Value = IdCarro;
                cmdSql.Parameters.Add(parametro);

                conBanco.Open();

                cmdSql.ExecuteNonQuery();

                conBanco.Close();

                labelRetorno.ForeColor = System.Drawing.Color.Green;
                labelRetorno.Text = "Carro ID " + IdCarro + " excluído com sucesso!";
            }
            catch (NpgsqlException ex)
            {
                labelRetorno.ForeColor = System.Drawing.Color.Red;
                labelRetorno.Text = ex.Message;
            }
            catch (Exception ex)
            {
                labelRetorno.ForeColor = System.Drawing.Color.Red;
                labelRetorno.Text = ex.Message;
            }
        }
    }
}
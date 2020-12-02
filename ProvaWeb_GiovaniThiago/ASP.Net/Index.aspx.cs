using Npgsql;
using ProvaWeb_GiovaniThiago.ASP.Net;
using System;
using System.Data;

namespace ProvaWeb_GiovaniThiago.NewFolder1
{
    public partial class Index : System.Web.UI.Page
    {
        public string connectionString = "server=localhost;Port=5432;user id=postgres;password=modsix6;database=provaWeb";
        protected void Page_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Carros novoCarro = new Carros();
                
                if (string.IsNullOrEmpty(txtMarca.Text) || string.IsNullOrEmpty(txtModelo.Text) ||
                    string.IsNullOrEmpty(txtAno.Text) || string.IsNullOrEmpty(txtKM.Text) ||
                    string.IsNullOrEmpty(txtPreco.Text))
                {
                    throw new Exception("Para cadastrar, com exceção do ID, todos os campos são obrigatórios!");
                }
                
                string km = Convert.ToDouble(txtKM.Text).ToString("C").Replace(",", ".").Replace("R$", "");
                //novoCarro.IdCarro = 2;
                novoCarro.Ano = Convert.ToInt32(txtAno.Text);
                novoCarro.KM = km.Remove(km.Length - 3, 3).PadLeft(20, ' ');
                novoCarro.Marca = txtMarca.Text;
                novoCarro.Modelo = txtModelo.Text;
                novoCarro.Preco = Convert.ToDouble(txtPreco.Text).ToString("C").PadLeft(20, ' ');
                novoCarro.Cor = txtCor.Text.ToString();

                novoCarro.Inserir(connectionString, lblRetorno);

                Buscar();
                Limpar();
            }
            catch(Exception ex)
            {
                lblRetorno.ForeColor = System.Drawing.Color.Red;
                lblRetorno.Text = ex.Message;
            }
        }        

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Carros novoCarro = new Carros();

                if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtMarca.Text) || string.IsNullOrEmpty(txtModelo.Text) ||
                    string.IsNullOrEmpty(txtAno.Text) || string.IsNullOrEmpty(txtKM.Text) ||
                    string.IsNullOrEmpty(txtPreco.Text))
                {
                    throw new Exception("Para atualizar, informe todos os campos, inclusive o ID!");
                }

                string km = Convert.ToDouble(txtKM.Text).ToString("C").Replace(",", ".").Replace("R$", "");
                novoCarro.IdCarro = Convert.ToInt32(txtId.Text);
                novoCarro.Ano = Convert.ToInt32(txtAno.Text);
                novoCarro.KM = km.Remove(km.Length - 3, 3).PadLeft(20, ' ');
                novoCarro.Marca = txtMarca.Text;
                novoCarro.Modelo = txtModelo.Text;
                novoCarro.Preco = Convert.ToDouble(txtPreco.Text).ToString("C").PadLeft(20, ' ');
                novoCarro.Cor = txtCor.Text.ToString();

                novoCarro.Atualizar(connectionString, lblRetorno);

                Buscar();
                Limpar();
            }
            catch (Exception ex)
            {
                lblRetorno.ForeColor = System.Drawing.Color.Red;
                lblRetorno.Text = ex.Message;
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Carros novoCarro = new Carros();

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    throw new Exception("Para excluir, informe o ID!");
                }
                novoCarro.IdCarro = Convert.ToInt32(txtId.Text);

                novoCarro.Excluir(connectionString, lblRetorno);

                Buscar();
                Limpar();
            }
            catch (Exception ex)
            {
                lblRetorno.ForeColor = System.Drawing.Color.Red;
                lblRetorno.Text = ex.Message;
            }
        }

        public void Buscar()
        {
            try
            {
                NpgsqlConnection conBanco = new NpgsqlConnection(connectionString);

                conBanco.Open();

                string strComando;

                strComando = "SELECT \"IdCarro\", \"Marca\", \"Modelo\", \"Ano\", \"KM\", \"Preco\", \"Cor\" FROM \"Carros\" ORDER BY \"IdCarro\"";

                NpgsqlDataAdapter daBusca = new NpgsqlDataAdapter(strComando, conBanco);

                DataSet ds = new DataSet();

                daBusca.Fill(ds, "Carros");

                dtCarros.DataSource = ds.Tables["Carros"].DefaultView;

                dtCarros.DataBind();

                conBanco.Close();
            }
            catch (NpgsqlException ex)
            {
                lblRetorno.ForeColor = System.Drawing.Color.Red;
                lblRetorno.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblRetorno.ForeColor = System.Drawing.Color.Red;
                lblRetorno.Text = ex.Message;
            }
        }

        public void Limpar()
        {
            txtId.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtAno.Text = "";
            txtPreco.Text = "";
            txtKM.Text = "";
            txtCor.Text = "";
        }
    }
} 
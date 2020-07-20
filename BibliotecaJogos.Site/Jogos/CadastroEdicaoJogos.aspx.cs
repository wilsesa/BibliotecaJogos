using BibliotecaJogos.BLL;
using BibliotecaJogos.BLL.Autenticacao;
using BibliotecaJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Jogos
{
    public partial class CadastroEdicaoJogos : System.Web.UI.Page
    {
        private GeneroBo _generoBo;
        private EditorBo _editorBo;
        private JogosBo _jogosBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarEditoresNaCombo();
                CarregarGenerosNaCombo();
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            _jogosBo = new JogosBo();

            var jogo = new Jogo();
            
            jogo.Titulo = txtTitulo.Text;
            jogo.ValorPago = string.IsNullOrWhiteSpace(txtValorPago.Text) ? (double?) null : Convert.ToDouble(txtValorPago.Text);
            jogo.DataCompra = string.IsNullOrWhiteSpace(txtDataCompra.Text) ? (DateTime?)null : Convert.ToDateTime(txtDataCompra.Text);
            //jogo.Imagem = DateTime.Now.ToString("yyyyMMddhhmmss") + FileUploadImage.FileName;

            try
            {
                jogo.Imagem = GravarImagemNoDisco();
            }
            catch
            {
                lblMensagem.Text = "Ocurreu um erro ao salvar a imagem";
            }

            jogo.IdEditor = Convert.ToInt32(DdlEditor.SelectedValue);
            jogo.IdGenero = Convert.ToInt32(DdlGenero.SelectedValue);

            try
            {
                _jogosBo.InserirNovoJogo(jogo);
                lblMensagem.Text = "Green";
                lblMensagem.Text = "Jogo Cadastrado com sucesso!!!";
                btnGravar.Enabled = false;
            }
            catch 
            {
                lblMensagem.Text = "Ocurreu um erro ao gravar o jogo";
            }
            
        }

        private string GravarImagemNoDisco()
        {
            if (FileUploadImage.HasFile)
            {
                try
                {
                    var caminho = $"{AppDomain.CurrentDomain.BaseDirectory}Content\\ImagensJogos\\";
                    var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}_{FileUploadImage.FileName}";
                    FileUploadImage.SaveAs($"{caminho}{fileName}");

                    return fileName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        } 
            
        private void CarregarEditoresNaCombo()
        {
            _editorBo = new EditorBo();
            var editores = _editorBo.ObterTodosOsEditores();

            DdlEditor.DataSource = editores;
            DdlEditor.DataBind();
        }

        private void CarregarGenerosNaCombo()
        {
            _generoBo = new GeneroBo();
            var generos = _generoBo.ObterTodosOsGeneros();

            DdlGenero.DataSource = generos;
            DdlGenero.DataBind();
        }
    }
}
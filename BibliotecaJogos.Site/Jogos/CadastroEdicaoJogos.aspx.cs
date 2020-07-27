using BibliotecaJogos.BLL;
using BibliotecaJogos.Entities;
using System;
using System.Linq;
using System.Web.UI;

namespace BibliotecaJogos.Site.Jogos
{
    public partial class PreencherModelo : System.Web.UI.Page
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

                if (EstaEmModoEdicao())
                {
                    CarregarDadosParaEdicao();
                }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            _jogosBo = new JogosBo();

            //var jogo = new Jogo();

            var jogo = ObterModeloPrenchido();


            //jogo.Titulo = txtTitulo.Text;
            //jogo.ValorPago = string.IsNullOrWhiteSpace(txtValorPago.Text) ? (double?) null : Convert.ToDouble(txtValorPago.Text);
            //jogo.DataCompra = string.IsNullOrWhiteSpace(txtDataCompra.Text) ? (DateTime?)null : Convert.ToDateTime(txtDataCompra.Text);
            //jogo.Imagem = DateTime.Now.ToString("yyyyMMddhhmmss") + FileUploadImage.FileName;

            try
            {
                jogo.Imagem = GravarImagemNoDisco();
            }
            catch
            {
                lblMensagem.Text = "Ocurreu um erro ao salvar a imagem";
            }

            //jogo.IdEditor = Convert.ToInt32(DdlEditor.SelectedValue);
            //jogo.IdGenero = Convert.ToInt32(DdlGenero.SelectedValue);

            try
            {
                var mensagemDeSucesso = "";

                if (EstaEmModoEdicao())
                {
                    jogo.Id = ObterIdDoJogo();

                    _jogosBo.AlterarJogo(jogo);
                    mensagemDeSucesso = "Jogo alterado com sucesso...";
                }
                else
                {
                    _jogosBo.InserirNovoJogo(jogo);
                    mensagemDeSucesso = "Jogo cadastrado com sucesso...";
                }

                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = mensagemDeSucesso;

                btnGravar.Enabled = false;
            }
            catch (Exception)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Ocurreu um erro ao gravar o jogo";
            }
        }

        private Jogo ObterModeloPrenchido()
        {
            var jogo = new Jogo();

            jogo.Titulo = txtTitulo.Text;
            jogo.ValorPago = string.IsNullOrWhiteSpace(txtValorPago.Text) ? (double?)null : Convert.ToDouble(txtValorPago.Text);
            jogo.DataCompra = string.IsNullOrWhiteSpace(txtDataCompra.Text) ? (DateTime?)null : Convert.ToDateTime(txtDataCompra.Text);
            jogo.IdEditor = Convert.ToInt32(DdlEditor.SelectedValue);
            jogo.IdGenero = Convert.ToInt32(DdlGenero.SelectedValue);


            return jogo;

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

        private void CarregarDadosParaEdicao()
        {
            _jogosBo = new JogosBo();

            var id = ObterIdDoJogo();

            var jogo = _jogosBo.ObterJogoPeloId(id);

            txtTitulo.Text = jogo.Titulo;
            txtValorPago.Text = jogo.ValorPago.ToString();
            txtDataCompra.Text = jogo.DataCompra.HasValue ? jogo.DataCompra.Value.ToString("yyyy-MM-dd") : string.Empty;
            DdlEditor.SelectedValue = jogo.IdEditor.ToString();
            DdlGenero.SelectedValue = jogo.IdGenero.ToString();
        }

        public int ObterIdDoJogo()
        {
            var id = 0;
            var idQueryString = Request.QueryString["id"];
            if (int.TryParse(idQueryString, out id))
            {
                if (id <= 0)
                {
                    throw new Exception("Id inválido");
                }
                return id;
            }
            else
            {
                throw new Exception("Id inválido");
            }
        }
        public bool EstaEmModoEdicao()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }
    }
}
using BibliotecaJogos.BLL.Autenticacao;
using BibliotecaJogos.BLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Autenticacao
{
    public partial class Login : System.Web.UI.Page
    {
        private LoginBo _loginBo;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            _loginBo = new LoginBo();

            var nomeUsuario = txtUsuario.Text;
            var senha = txtSenha.Text;

            try
            {
                var usuario = _loginBo.ObterUsuarioParaLogar(nomeUsuario, senha);
                FormsAuthentication.RedirectFromLoginPage(nomeUsuario, false);
                Session["Perfil"] = usuario.Perfil;
            }
            catch (UsuarioNaoCadastradoException)
            {
                lblStatus.Text = "Usuario não identificado!!!";
            }
            catch (Exception)
            {
                lblStatus.Text = "Ocurreu um erro inesperado, favor consultar o administrador do sistema";
            }

             
        }
    }
}
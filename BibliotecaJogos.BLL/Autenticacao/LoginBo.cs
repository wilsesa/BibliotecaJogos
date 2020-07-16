﻿using BibliotecaJogos.BLL.Exceptions;
using BibliotecaJogos.DAL;
using BibliotecaJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.BLL.Autenticacao
{
    public class LoginBo
    {
        private UsuarioDao _usuarioDao;
        public Usuario ObterUsuarioParaLogar(string nomeUsuario, string senha)
        {
            _usuarioDao = new UsuarioDao();
           var usuario =  _usuarioDao.ObterUsuarioPeloUsuarioESenha(nomeUsuario, senha);
            
            if(usuario == null)
            {
                throw new UsuarioNaoCadastradoException();
            }
            else
            {
                return usuario;
            }
        }
    }
}

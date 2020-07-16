﻿using BibliotecaJogos.DAL;
using BibliotecaJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.BLL.Autenticacao
{
    public class JogosBo
    {
        private JogoDao _jogoDao;

        public List<Jogo> ObterTodosOsJogos()
        {
            _jogoDao = new JogoDao();   

            return _jogoDao.ObterTodosOsJogos();
        } 
    }
}

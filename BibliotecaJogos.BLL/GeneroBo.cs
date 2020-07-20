using BibliotecaJogos.DAL;
using BibliotecaJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.BLL
{
    public class GeneroBo
    {
        private GeneroDao _generoDao;

        public List<Genero> ObterTodosOsGeneros()
        {
            _generoDao = new GeneroDao();

            return _generoDao.ObterTodosOsGeneros();
        }
    }
}
